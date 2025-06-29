using YektamakDesktop.Formlar.Stok;
using Models;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using ApiService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Utilities.Interfaces;
using Utilities.Implementations;
using YektamakDesktop.Common;
using ApiService.Interfaces;
using Models.Models;
using System.Threading.Tasks;
using Org.BouncyCastle.Asn1.X509;

namespace YektamakDesktop.Formlar.Proje
{
    public partial class ExceldenVeriAlmaFormu : Form, IForm
    {
        private string[] files;
        private static ICache _cache;
        private static IProjeService _projeService;
        private static IStokService _stokService;
        private static IDataTableMapper _dataTableMapper;
        public ExceldenVeriAlmaFormu(ICache cache,IProjeService projeService,IStokService stokService, IDataTableMapper dataTableMapper)
        {
            _cache = cache;
            _projeService = projeService;
            _stokService = stokService;
            _dataTableMapper = dataTableMapper;
        }
        public ExceldenVeriAlmaFormu()
        {
            InitializeComponent();
            ButtonImageLoad();
            ComboBoxListFill.GetLookupKod(_cache.projes, ref customComboListProjeKodu);
        }
        #region declarations
        private ButtonImage buttonImageExcel = new ButtonImage();
        private ButtonImage buttonImageClose = new ButtonImage();
        private ButtonImage buttonImageLoad = new ButtonImage();
        private static ExceldenVeriAlmaFormu _exceldenVeriAlmaFormu;
        public static ExceldenVeriAlmaFormu exceldenVeriAlmaFormu
        {
            get
            {
                if (_exceldenVeriAlmaFormu == null)
                {
                    _exceldenVeriAlmaFormu = new ExceldenVeriAlmaFormu();
                    GlobalData.Yetki(ref _exceldenVeriAlmaFormu);
                }
                return _exceldenVeriAlmaFormu;
            }

        }
        private List<Control> _controlsToDisable;
        public List<Control> controlsToDisable { get => _controlsToDisable; set => _controlsToDisable = value; }
        private bool _activeForm;

        public bool activeForm { get => _activeForm; set => _activeForm = value; }

        #endregion declarations
        
        private void verileriAktar_MouseHover(object sender, EventArgs e)
        {
            verileriAktar.Image = Properties.Resources.aktar;
            verileriAktar.Cursor = Cursors.Hand;
        }

        private async void verileriAktar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validasyonları ayrı metoda çıkar
                if (!ValidateInputs())
                    return;

                await ProcessExcelFileAsync();
                MessageBox.Show("Veri alma işlemi başarıyla tamamlandı", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Log the exception
                // _logger.LogError(ex, "Excel veri aktarımında hata");
            }
        }

        private bool ValidateInputs()
        {
            bool isValid = true;
            // Tüm validasyonları çalıştır - short-circuit kullanma
            isValid = Validation.CheckField("Dosya seçilmelidir.", this, customTextBoxDosyaYolu) && isValid;
            isValid = Validation.CheckField("Proje kodu seçilmelidir.", this, customComboListProjeKodu) && isValid;

            return isValid;
        }

        private async Task ProcessExcelFileAsync()
        {
            string filePath = customTextBoxDosyaYolu.TextCustom;

            // Progress reporting için UI thread'de güncelleme
            UpdateProgressText("İşlem başlatılıyor...");

            // Proje nesnesini oluştur
            var proje = new Models.Proje { Id = customComboListProjeKodu.selectedDataRowId };

            // Eski dosyaları sil
            UpdateProgressText("Eski dosyalar siliniyor...");
            await _projeService.DeleteProjeDosya(proje);
            UpdateProgressText("Eski dosyalar silindi");


            // Excel dosyasını işle
            using var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            using var workbook = CreateWorkbook(fileStream, filePath);

            var sheet = workbook.GetSheetAt(0);
            int totalRows = sheet.LastRowNum;
            UpdateProgressText($"Toplam {totalRows} satır bulundu");

            // Batch processing için liste
            var stokKartList = new List<StokKart>();
            const int batchSize = 169; // Her seferinde * kayıt işle
            DateTime startTime = DateTime.Now;
            for (int rowIndex = 1; rowIndex <= totalRows; rowIndex++)
            {
                var rowData = sheet.GetRow(rowIndex);
                if (rowData == null) continue;

                var stokKart = CreateStokKartFromRow(rowData);
                await AttachFilesToStokKart(stokKart);

                stokKartList.Add(stokKart);

                // Batch size'a ulaştığında veya son satırda kaydet
                if (stokKartList.Count >= batchSize || rowIndex == totalRows)
                {
                    await SaveStokKartBatch(stokKartList);
                    UpdateProgressText($"{totalRows}");
                    UpdateTransferCount(rowIndex);

                    stokKartList.Clear();

                    // UI'nin yanıt verebilmesi için kısa bir bekleme
                    Application.DoEvents();
                }
            }
            DateTime endTime = DateTime.Now;
            TimeSpan duration = endTime - startTime;
            UpdateProgressText($"İşlem tamamlandı. Toplam süre: {duration.TotalSeconds} saniye");
        }


        private static IWorkbook CreateWorkbook(FileStream fileStream, string filePath)
        {
            using var memoryStream = new MemoryStream();
            fileStream.CopyTo(memoryStream);
            memoryStream.Position = 0;

            return Path.GetExtension(filePath).ToLowerInvariant() switch
            {
                ".xls" => new HSSFWorkbook(memoryStream),
                ".xlsx" => new XSSFWorkbook(memoryStream),
                _ => throw new NotSupportedException("Desteklenmeyen dosya formatı. Lütfen bir Excel dosyası (.xls veya .xlsx) yükleyiniz.")
            };
        }

        private StokKart CreateStokKartFromRow(IRow rowData)
        {
            var excelData = ExtractExcelData(rowData);

            return new StokKart
            {
                stokGrup = { Id = ExcelMalzemeGrup.stokGrup(excelData.aciklama, excelData.boyut, excelData.malzeme) },
                malzemeGrup = { Id = ExcelMalzemeGrup.malzemeGrup(excelData.aciklama, excelData.boyut, excelData.malzeme) },
                malzemeAltGrup = { Id = ExcelMalzemeGrup.malzemeAltGrup(excelData.aciklama, excelData.boyut, excelData.malzeme) },
                malzemeAltGrup2 = { Id = ExcelMalzemeGrup.malzemeAltGrup2(excelData.aciklama, excelData.boyut, excelData.malzeme) },
                proje = { Id = customComboListProjeKodu.selectedDataRowId },
                kod = excelData.kod,
                parcaKod = excelData.kod,
                ad = excelData.parcaAdi,
                parcaAdi = excelData.parcaAdi,
                miktar = excelData.miktar,
                adet = excelData.adet,
                fark = excelData.fark,
                boyut = ExcelMalzemeGrup.Boyut(excelData.boyut).boyutText,
                uzunluk = (excelData.uzunluk==0) ? ExcelMalzemeGrup.Boyut(excelData.boyut).uzunluk:excelData.uzunluk,
                malzeme = excelData.malzeme,
                aciklama = excelData.aciklama,
                agirlik = excelData.agirlik,
                olcuBirim = { Id = 1 },
                stokTip = { Id=1},
                isFromExcel = true,
                stokKartDosya = new List<StokKartDosya>()
            };
        }

        private static ExcelParcaListesi ExtractExcelData(IRow rowData)
        {
            return new ExcelParcaListesi
            {
                no = GetCellValueAsInt(rowData, 0),
                kod = GetCellValueAsString(rowData, 1),
                parcaAdi = GetCellValueAsString(rowData, 2),
                miktar = GetCellValueAsInt(rowData, 3),
                adet = GetCellValueAsInt(rowData, 4),
                fark = GetCellValueAsInt(rowData, 5),
                boyut = GetCellValueAsString(rowData, 6),
                uzunluk = GetCellValueAsDouble(rowData, 7),
                malzeme = GetCellValueAsString(rowData, 8),
                aciklama = GetCellValueAsString(rowData, 9),
                agirlik = GetCellValueAsDouble(rowData, 10)
            };
        }

        private static string GetCellValueAsString(IRow row, int columnIndex)
        {
            return row.GetCell(columnIndex)?.ToString()?.Trim() ?? string.Empty;
        }

        private static int GetCellValueAsInt(IRow row, int columnIndex)
        {
            var cellValue = GetCellValueAsString(row, columnIndex);
            return int.TryParse(cellValue, out int result) ? result : 0;
        }

        private static double GetCellValueAsDouble(IRow row, int columnIndex)
        {
            var cellValue = GetCellValueAsString(row, columnIndex);
            return double.TryParse(cellValue, out double result) ? result : 0.0;
        }

        private async Task AttachFilesToStokKart(StokKart stokKart)
        {
            // PDF dosyası ekle
            var pdfDosya = await CreateStokKartDosya(stokKart.pdfFileName(), 1);
            if (pdfDosya != null)
                stokKart.stokKartDosya.Add(pdfDosya);

            // DXF dosyası ekle
            var dxfDosya = await CreateStokKartDosya(stokKart.dxfFileName(), 2);
            if (dxfDosya != null)
                stokKart.stokKartDosya.Add(dxfDosya);

            // STEP dosyası ekle
            var stepDosya = await CreateStokKartDosya(stokKart.stepFileName(), 3);
            if (stepDosya != null)
                stokKart.stokKartDosya.Add(stepDosya);
        }

        private async Task<StokKartDosya> CreateStokKartDosya(string fileName, int dosyaTipId)
        {
            var file = files.FirstOrDefault(f => f.Contains(fileName, StringComparison.OrdinalIgnoreCase));
            if (file == null) return null;

            var content = await ReadFileAsBinaryAsync(file);
            if (content == null) return null;

            return new StokKartDosya
            {
                dosyaUzanti = Path.GetExtension(fileName).TrimStart('.'),
                dosyaAd = Path.GetFileNameWithoutExtension(fileName),
                dosya = content,
                dosyaTip = { Id = dosyaTipId }
            };
        }

        private async Task<byte[]> ReadFileAsBinaryAsync(string filePath)
        {
            try
            {
                return await File.ReadAllBytesAsync(filePath);
            }
            catch (Exception ex)
            {
                // Log the exception
                // _logger.LogWarning(ex, "Dosya okunamadı: {FilePath}", filePath);
                return null;
            }
        }

        private async Task SaveStokKartBatch(List<StokKart> stokKartList)
        {
            // Tek tek kaydet
            foreach (var stokKart in stokKartList)
            {
                var jsonConverter = new JsonConverter();
                var row = jsonConverter.DeserializeToDataSet(
                    await _stokService.SaveStokKart(stokKart)
                ).Tables[0].Rows[0];
                stokKart.Id=_dataTableMapper.MapToEntity<StokKart>(row).Id;
                if (stokKart.stokTip.Id == 2)
                {
                    var sonuc=await _stokService.SaveStokKartHammadde(stokKart);
                }
            }
        }

        private void UpdateProgressText(string message)
        {
            if (totalCount.InvokeRequired)
            {
                totalCount.Invoke(new Action<string>(UpdateProgressText), message);
            }
            else
            {
                totalCount.Text = message;
            }
        }

        private void UpdateTransferCount(int count)
        {
            if (transferredCount.InvokeRequired)
            {
                transferredCount.Invoke(new Action<int>(UpdateTransferCount), count);
            }
            else
            {
                transferredCount.Text = count.ToString();
            }
        }
        private void verileriAktar_MouseLeave(object sender, EventArgs e)
        {
            verileriAktar.Image = Properties.Resources.aktar2;
        }

        private void kapat_Click(object sender, EventArgs e)
        {
            GlobalData.CloseForm(ref _exceldenVeriAlmaFormu);
        }

        private void kapat_MouseHover(object sender, EventArgs e)
        {
            kapat.Cursor = Cursors.Hand;
            kapat.Image = Properties.Resources.close2;

        }

        private void kapat_MouseLeave(object sender, EventArgs e)
        {
            kapat.Image = Properties.Resources.close;
        }

        private void dosyaSec_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // OpenFileDialog ayarları
                openFileDialog.InitialDirectory = "C:\\";
                openFileDialog.Filter = "Excel Dosyaları (*.xls;*.xlsx)|*.xls;*.xlsx";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Seçilen dosya yolunu TextBox'a yükle
                    customTextBoxDosyaYolu.TextCustom = openFileDialog.FileName;
                    string filePath = Path.GetDirectoryName(openFileDialog.FileName);
                    files = Directory.GetFiles(filePath, "*.*", SearchOption.AllDirectories);
                }
            }
        }

        private void dosyaSec_MouseHover(object sender, EventArgs e)
        {
            dosyaSec.Cursor = Cursors.Hand;
            //using (MemoryStream ms = new MemoryStream(buttonImageExcel.btnImage))
            //{
            //    Image image = Image.FromStream(ms);
            //    dosyaSec.Image = image;
            //}
        }

        private void dosyaSec_MouseLeave(object sender, EventArgs e)
        {
            dosyaSec.Image = Properties.Resources.fromExcelButton2;
        }
        private void ButtonImageLoad()
        {
            //buttonImageExcel.btnName = "btnExcelDosyaSec";
            //buttonImageExcel = GlobalData.GetModelFromDatabase(WebMethods.GetButtonImage, buttonImageExcel);
            //buttonImageClose.btnName = "btnClose";
            //buttonImageClose = GlobalData.GetModelFromDatabase(WebMethods.GetButtonImage, buttonImageClose);
            //buttonImageLoad.btnName = "btnDosyaAktar";
            //buttonImageLoad = GlobalData.GetModelFromDatabase(WebMethods.GetButtonImage, buttonImageLoad);
        }
    }
}
