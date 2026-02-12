using ApiService.Interfaces;
using Models;
using Newtonsoft.Json;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities.Interfaces;
using YektamakDesktop.Common;
using YektamakDesktop.Formlar.Projemodul;

namespace YektamakDesktop.Formlar.ProjeModul
{
    public partial class ExceldenVeriAlmaFormu : Form
    {
        private string[] files;
        private readonly ICache _cache;
        private readonly IProjeService _projeService;
        private readonly IStokService _stokService;
        private readonly IJsonConverter _jsonConverter;
        private readonly IFileHelper _fileHelper;
        private readonly IFileService _fileService;

        public ExceldenVeriAlmaFormu(ICache cache,IProjeService projeService,IStokService stokService, IJsonConverter jsonConverter, IFileHelper fileHelper, IFileService fileService)
        {
            _fileService = fileService;
            _fileHelper = fileHelper;
            _cache = cache;
            _projeService = projeService;
            _stokService = stokService;
            _jsonConverter = jsonConverter;
            InitializeComponent();
            clbProjeKodu.SetDataSource(_cache.projeList.Where(x => x.sorumluList.Where(s => s.personel.Id == _cache.kullanici.personel.Id).Count() > 0).ToList());
        }
        private List<ProjeStokKart> _projeStokKarts;
        private List<ProjeStokKart> projeStokKarts
        {
            get { if (_projeStokKarts == null) { _projeStokKarts = new(); } return _projeStokKarts; }
            set { _projeStokKarts = value; }
        }
        private void dosyaSec_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\";
                openFileDialog.Filter = "Excel Dosyaları (*.xls;*.xlsx)|*.xls;*.xlsx";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Seçilen dosya yolunu TextBox'a yükle
                    ctbDosyaYolu.isPlaceHolder = false;
                    ctbDosyaYolu.TextCustom = openFileDialog.FileName;
                    string filePath = Path.GetDirectoryName(openFileDialog.FileName);
                    files = Directory.GetFiles(filePath, "*.*", SearchOption.AllDirectories);
                }
            }
        }
        private bool ValidateInputs()
        {
            bool isValid = true;
            isValid = CheckFieldHelper.CheckField("Dosya seçilmelidir.",  ctbDosyaYolu) && isValid;
            isValid = CheckFieldHelper.CheckField("Proje kodu seçilmelidir.", clbProjeKodu) && isValid;
            return isValid;
        }
        public class MyCustomEventArgs : EventArgs
        {
            public int? Veri { get; set; }
        }
        public event EventHandler<MyCustomEventArgs> FormClosedWithData;
        private async void verileriAktar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInputs()) return;
                await ProcessExcelFileAsync();
                MessageBox.Show("Veri alma işlemi başarıyla tamamlandı", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var resultData = new MyCustomEventArgs { Veri = int.Parse(clbProjeKodu.SelectedValue.ToString()) };

                // Form kapanmadan önce eventi tetikle
                FormClosedWithData?.Invoke(this, resultData);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        string logDosyasi;
        string klasor;
        List<ProjeStokKart> kayitliStokKods = new List<ProjeStokKart>();
        int secim;
        Dictionary<string, ProjeStokKart> satirList = new Dictionary<string, ProjeStokKart>();
        private async Task ProcessExcelFileAsync()
        {
            this.Enabled = false;
            try
            {
                string filePath = ctbDosyaYolu.TextCustom;
                UpdateProgressText("İşlem başlatılıyor...");
                var proje = new Proje { Id = int.Parse(clbProjeKodu.SelectedValue.ToString()) };
                if (chkProjeDosyaSil.Checked == true)
                {
                    UpdateProgressText("Eski dosyalar siliniyor...");
                    string jsonResult = await _projeService.DeleteProjeDosya(proje);
                    if (jsonResult.Contains("error", StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show(jsonResult);
                        return;
                    }
                    UpdateProgressText($"{jsonResult} adet stok kartı silindi");
                }
                using var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                using var workbook = CreateWorkbook(fileStream, filePath);
                var sheet = workbook.GetSheetAt(0);
                int totalRows = sheet.LastRowNum;

                //UpdateProgressText($"Toplam {totalRows} satır bulundu");

                // Batch processing için liste
                var stokKartList = new List<StokKart>();
                const int batchSize = 1; // Her seferinde * kayıt işle
                DateTime startTime = DateTime.Now;
                logDosyasi = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonTemplates), @"\Logs\app.log");
                klasor = Path.GetDirectoryName(logDosyasi);
                if (!Directory.Exists(klasor))
                    Directory.CreateDirectory(klasor);
                File.WriteAllText(logDosyasi, "Eklenemeyen satırlar");
                for (int rowIndex = 0; rowIndex <= totalRows; rowIndex++)
                {
                    var rowData = sheet.GetRow(rowIndex);
                    string no = GetCellValueAsString(rowData, 0);
                    if (no.Contains("no", StringComparison.OrdinalIgnoreCase)) continue; // Başlık satırını atla
                    var projeStokKart = CreateStokKartFromRow(rowData);
                    var key= $"{projeStokKart.stokKart.kod}{projeStokKart.stokKart.boyut}{projeStokKart.stokKart.malzeme}{projeStokKart.stokKart.aciklama}";
                    if (satirList.ContainsKey(key))
                    {
                        satirList[key].miktar += projeStokKart.miktar;
                    }
                    else
                    {
                        satirList.Add(key, projeStokKart);
                    }
                }
                UpdateProgressText($"Excel dosyasında toplam {totalRows} satır bulundu {satirList.Count} olarak tekilleştirildi");


                kayitliStokKods = await _projeService.GetProjeStokKart(new ProjeStokKart { proje = new Proje { Id = int.Parse(clbProjeKodu.SelectedValue.ToString()) } });
                int existsCount = 0;
                foreach (var satir in satirList)
                {
                    if (kayitliStokKods.Any(x => x.stokKart.kod == satir.Key))
                    {
                        existsCount++;
                    }
                }

                int i = 0;
                foreach (var satir in satirList)
                {
                    if (existsCount > 0)
                    {
                        var form = FormFactory.CreateForm<ExceldenVeriAlmaCakisanKodlar>();
                        form.SetData(kayitliStokKods);
                        form.SecimYapildi += (s, e) => {
                            secim = e;
                        };
                        form.ShowDialog();
                    }
                    var projeStokKart = (ProjeStokKart)satir.Value;
                    await AttachFilesToStokKart(projeStokKart);

                    projeStokKarts.Add(projeStokKart);
                    if (projeStokKarts.Count >= batchSize)
                    {

                        await SaveStokKartBatch();
                        i++;
                        UpdateTransferCount(i);

                        projeStokKarts.Clear();

                        // UI'nin yanıt verebilmesi için kısa bir bekleme
                        Application.DoEvents();
                    }
                }
                DateTime endTime = DateTime.Now;
                TimeSpan duration = endTime - startTime;
                UpdateProgressText($"İşlem tamamlandı. Toplam süre: {duration.TotalSeconds} saniye");
                Process.Start(new ProcessStartInfo
                {
                    FileName = logDosyasi,
                    UseShellExecute = true // Varsayılan uygulama ile açar
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Enabled = true;
                return;
            }
            
            this.Enabled = true;
        }
        private IWorkbook CreateWorkbook(FileStream fileStream, string filePath)
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
        private ProjeStokKart CreateStokKartFromRow(IRow rowData)
        {
            var excelData = ExtractExcelData(rowData);
            SetGrupIds(excelData);
            
            return new ProjeStokKart
            {
                proje = { Id = int.Parse(clbProjeKodu.SelectedValue.ToString()) },
                adet = excelData.adet,
                miktar = excelData.miktar,
                no = excelData.no.Replace(",",".").Replace(".\r\n",".").Replace("\r\n.","."),
                hamVeri = JsonConvert.SerializeObject(excelData),
                stokKart ={
                    stokTip = _cache.stokTips.FirstOrDefault(s=>s.Id==excelData.stokTip),
                    stokGrup = _cache.stokGrups.FirstOrDefault(s=>s.Id== excelData.stokGrup),
                    malzemeGrup = _cache.malzemeGrups.FirstOrDefault(m=>m.Id== excelData.malzemeGrup),
                    malzemeAltGrup = _cache.malzemeAltGrups.FirstOrDefault(m=>m.Id== excelData.malzemeAltGrup),
                    malzemeAltGrup2 = _cache.malzemeAltGrup2List.FirstOrDefault(m=>m.Id== excelData.malzemeAltGrup2),
                    malzemeStandart = _cache.malzemeStandarts.FirstOrDefault(m=>m.Id== excelData.malzemeStandart),
                    isTalasli = excelData.isTalasli,
                    isBukum = excelData.isBukum,
                    kod = excelData.kod,
                    parcaKod = excelData.kod,
                    ad = excelData.parcaAdi,
                    parcaAdi = excelData.parcaAdi,
                    fark = excelData.fark,
                    boyut = excelData.Boyut().boyutText,
                    uzunluk = (excelData.uzunluk==0) ? excelData.Boyut().uzunluk:excelData.uzunluk,
                    malzeme = excelData.malzeme,
                    aciklama = excelData.aciklama,
                    agirlik = excelData.agirlik,
                    olcuBirim = { Id = 1 },
                    isFromExcel = true,
                }
            };
        }
        private void SetGrupIds(ExcelFormat excelData)
        {
            List<ExcelGrupParametre> grupParametreList = _cache.excelGrupParametreList;

            foreach (var param in grupParametreList)
            {
                if (string.IsNullOrWhiteSpace(param.kosulMetni))
                    continue;

                try
                {
                    var matches = new List<ExcelFormat> { excelData }
                        .AsQueryable()
                        .Where(param.kosulMetni) // <-- string ifadeyi çalıştırır
                        .ToList();

                    if (matches.Any())
                    {
                        excelData.stokTip = excelData.stokTip == null ? param.stokTipId : excelData.stokTip;
                        excelData.stokGrup = excelData.stokGrup==null? param.stokGrupId : excelData.stokGrup;
                        excelData.malzemeGrup = excelData.malzemeGrup==null? param.malzemeGrupId : excelData.malzemeGrup;
                        excelData.malzemeAltGrup = excelData.malzemeAltGrup==null? param.malzemeAltGrupId : excelData.malzemeAltGrup;
                        excelData.malzemeAltGrup2 = excelData.malzemeAltGrup2==null? param.malzemeAltGrup2Id : excelData.malzemeAltGrup2;
                        excelData.malzemeStandart = excelData.malzemeStandart==null? param.malzemeStandartId : excelData.malzemeStandart;
                        excelData.isTalasli = excelData.isTalasli==null ? param.isTalasli: excelData.isTalasli;
                        excelData.isBukum = excelData.isBukum == null ? param.isBukum : excelData.isBukum;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Koşul çalıştırılırken hata: {ex.Message}");
                }
            }
        }

        private ExcelFormat ExtractExcelData(IRow rowData)
        {
            return new ExcelFormat
            {
                no = GetCellValueAsString(rowData, 0),
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
        private string GetCellValueAsString(IRow row, int columnIndex)
        {
            return row.GetCell(columnIndex)?
                       .ToString()?
                       .Replace("\r", "")
                       .Replace("\n", "")
                       .Trim()
                   ?? string.Empty;
        }
        private int GetCellValueAsInt(IRow row, int columnIndex)
        {
            var cellValue = GetCellValueAsString(row, columnIndex);
            return int.TryParse(cellValue, out int result) ? result : 0;
        }
        private double GetCellValueAsDouble(IRow row, int columnIndex)
        {
            var cellValue = GetCellValueAsString(row, columnIndex);
            return double.TryParse(cellValue, out double result) ? result : 0.0;
        }
        private async Task AttachFilesToStokKart(ProjeStokKart projeStokKart)
        {
            
            // PDF dosyası ekle
            var pdfDosya = await CreateStokKartDosya(projeStokKart.pdfFileName(), 1);
            if (pdfDosya != null)
                projeStokKart.stokKart.dosyaList.Add(pdfDosya);

            // DXF dosyası ekle
            var dxfDosya = await CreateStokKartDosya(projeStokKart.dxfFileName(), 2);
            string jsonResult = _stokService.GetMalzemeStandart(projeStokKart.stokKart.malzemeStandart);
            MalzemeStandart malzemeStandart = _jsonConverter.DeserializeObject<List<MalzemeStandart>>(jsonResult).Where(m=>m.Id==projeStokKart.stokKart.malzemeStandart.Id).FirstOrDefault();
            if (dxfDosya != null)
            {
                dxfDosya.dosyaAd = $"{projeStokKart.stokKart.kod}_{malzemeStandart?.ad}_{projeStokKart.dxfAddition()}mm_{projeStokKart.miktar}adet";
                projeStokKart.stokKart.dosyaList.Add(dxfDosya);
            }

            // STEP dosyası ekle
            var stepDosya = await CreateStokKartDosya(projeStokKart.stepFileName(), 3);
            if (stepDosya != null)
                projeStokKart.stokKart.dosyaList.Add(stepDosya);
            var drwDosya = await CreateStokKartDosya(projeStokKart.drwFileName(), 4);
            if (drwDosya != null)
                projeStokKart.stokKart.dosyaList.Add(drwDosya);
            var prtDosya = await CreateStokKartDosya(projeStokKart.prtFileName(), 5);
            if (prtDosya != null)
                projeStokKart.stokKart.dosyaList.Add(prtDosya);
            var asmDosya = await CreateStokKartDosya(projeStokKart.asmFileName(), 6);
            if (asmDosya != null)
                projeStokKart.stokKart.dosyaList.Add(asmDosya);
        }
        private async Task<StokKartDosya> CreateStokKartDosya(string fileName, int dosyaTipId)
        {
            if(fileName == null) return null;
            var file = files.FirstOrDefault(f => Regex.IsMatch(f, fileName, RegexOptions.IgnoreCase));
            if (file == null) return null;
            var content = await _fileHelper.ReadFileAsBinaryAsync(file);
            if (content == null) return null;
            var filePath = Path.Combine(Guid.NewGuid() + Path.GetExtension(file));
            _fileService.SaveFile(content,filePath);
            return new StokKartDosya
            {
                dosyaUzanti = Path.GetExtension(file).TrimStart('.'),
                dosyaAd = Path.GetFileNameWithoutExtension(file),
                dosyaTip = { Id = dosyaTipId },
                dosyaFullPath = filePath
            };
        }
        private async Task SaveStokKartBatch()
        {
            
            foreach (var projeStokKart in projeStokKarts)
            {
                var existingStokKart = kayitliStokKods.FirstOrDefault(s => s.stokKart.kod == projeStokKart.stokKart.kod);
                if (!string.IsNullOrEmpty(existingStokKart?.stokKart.kod))
                {
                    if (secim == 1)
                    {
                        continue;
                    }
                    else if (secim == 2)
                    {
                        if (JsonConvert.SerializeObject(projeStokKart.stokKart) != JsonConvert.SerializeObject(existingStokKart.stokKart))
                        {
                            // Form açılacak ve kullanıcıya gösterilecek
                            var form = FormFactory.CreateForm<ExcelVeriAlmaCakisanOnayFormu>(); 
                            form.UpdateMode(projeStokKart, existingStokKart);
                            form.ShowDialog();
                        }
                    }
                    else if (secim == 3)
                    {
                        _projeService.DeleteProjeStokKart(projeStokKart);
                    }
                }
                string jsonResult = await _projeService.SaveProjeStokKart(projeStokKart);
                if (jsonResult.Contains("error",StringComparison.OrdinalIgnoreCase))
                {
                    using (var sw = new StreamWriter(logDosyasi, append: true))
                    {
                        sw.WriteLine($"{Environment.NewLine}{projeStokKart.stokKart.kod} - {projeStokKart.stokKart.ad} {Environment.NewLine} {jsonResult}");
                    }
                }
                else
                {
                    if (String.IsNullOrEmpty(jsonResult) || jsonResult.Contains("error", StringComparison.OrdinalIgnoreCase))
                    {
                        using (var sw = new StreamWriter(logDosyasi, append: true))
                        {
                            sw.WriteLine($"{Environment.NewLine}{projeStokKart.stokKart.kod} - {projeStokKart.stokKart.ad}");
                        }
                    }
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
        
    }
}
