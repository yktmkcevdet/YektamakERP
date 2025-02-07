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

namespace YektamakDesktop.Formlar.Proje
{
    public partial class ExceldenVeriAlmaFormu : Form, IForm
    {
        private string[] files;
        public ExceldenVeriAlmaFormu(ICache cache)
        {
            InitializeComponent();
            ButtonImageLoad();
            Models.Proje proje = new();
            proje.personel = cache.kullanici.personel;
            string jsonString = WebMethods.GetProjeKodByUserId(proje);
            
            IJsonConvertHelper jsonConverter = new JsonConvertHelper();
            DataSet dataSet = jsonConverter.JsonStringToDataSet(jsonString);
            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                Models.Proje proje1;
                proje1 = Common.ConvertHelper.DataRowToModel<Models.Proje>(dataRow);
                customComboListProjeKodu.AddDataRow(proje1.Id, proje1.kod);
            }
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
                    _exceldenVeriAlmaFormu = new ExceldenVeriAlmaFormu(new Cache(new JsonConvertHelper(), new DataTableConverter()));
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
            string filePath = customTextBoxDosyaYolu.TextCustom;
            if(filePath == "")
            {
                MessageBox.Show("Dosya seçilmelidir.");
                return;
            }
            if (customComboListProjeKodu.selectedDataRowId == -1)
            {
                MessageBox.Show("Proje kodu seçilmelidir.");
                return;
            }
            Models.Proje proje = new Models.Proje();
            proje.Id = customComboListProjeKodu.selectedDataRowId;
            totalCount.Text = "Dosyalar Siliniyor";
            string resultMessage = await WebMethods.DeleteProjeDosya(proje);
            totalCount.Text = "Dosyalar Silindi";
            using (var file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                long maxFileSize = 10 * 1024 * 1024;
                using var memoryStream = new MemoryStream();
                file.CopyTo(memoryStream);
                memoryStream.Position = 0; // Stream başına dönün
                IWorkbook workbook;
                //MalzemeGrup listesi oluştur
                List<MalzemeGrup> malzemeGrupList = new List<MalzemeGrup>();
                
                IJsonConvertHelper jsonConverter = new JsonConvertHelper();
                DataTable dataTable = jsonConverter.JsonStringToDataSet(WebMethods.GetMalzemeGrup(new MalzemeGrup())).Tables[0];
                foreach(DataRow row in dataTable.Rows)
                {
                    malzemeGrupList.Add(Common.ConvertHelper.DataRowToModel<MalzemeGrup>(row));
                }
                // Dosya uzantısına göre doğru sınıfı kullanın
                if (file.Name.EndsWith(".xls"))
                {
                    workbook = new HSSFWorkbook(memoryStream); // .xls formatı için
                }
                else if (file.Name.EndsWith(".xlsx"))
                {
                    workbook = new XSSFWorkbook(memoryStream); // .xlsx formatı için
                }
                else
                {
                    MessageBox.Show("Desteklenmeyen dosya formatı. Lütfen bir Excel dosyası yükleyiniz.");
                    return;
                }
                var sheet = workbook.GetSheetAt(0); // İlk sayfa
                totalCount.Text=sheet.LastRowNum.ToString();
                for (int row = 1; row <= sheet.LastRowNum; row++)
                {
                    var rowData = sheet.GetRow(row);
                    StokKart stokKart = new StokKart();
                    string sutun9 = rowData.GetCell(9)?.ToString() ?? "";
                    string sutun2 = rowData.GetCell(2)?.ToString() ?? "";
                    MalzemeGrup malzemeGrup = malzemeGrupList.Find(x => x.ad == sutun9 || x.ad == sutun2);
                    if (malzemeGrup == null)
                    {
                        malzemeGrup = malzemeGrupList.Find(x => x.ad == "-");
                    }
                    stokKart.parcaGrup.Id = malzemeGrup.parcaGrupId;
                    stokKart.malzemeGrup.Id = malzemeGrup.Id;
                    stokKart.proje.Id = customComboListProjeKodu.selectedDataRowId;
                    stokKart.kod = rowData.GetCell(1)?.ToString() ?? "";
                    stokKart.ad = rowData.GetCell(2)?.ToString() ?? "";
                    stokKart.parcaAdi = rowData.GetCell(2)?.ToString() ?? "";
                    stokKart.miktar = Convert.ToInt32(rowData.GetCell(3)?.ToString() ?? "");
                    stokKart.adet = Int32.TryParse(rowData.GetCell(4).ToString() ?? "0",out int adet)?adet:0;
                    stokKart.fark = Convert.ToInt32(rowData.GetCell(5)?.ToString() ?? "");
                    stokKart.boyut = rowData.GetCell(6)?.ToString() ?? "";
                    stokKart.uzunluk = Double.TryParse(rowData.GetCell(7)?.ToString() ?? "0", out Double uzunluk) ? uzunluk : 0;
                    stokKart.malzeme = rowData.GetCell(8)?.ToString() ?? "";
                    stokKart.aciklama = rowData.GetCell(9)?.ToString() ?? "";
                    stokKart.agirlik = Double.TryParse(rowData.GetCell(10)?.ToString() ?? "",out Double agirlik)?agirlik:0;
                    stokKart.olcuBirim.Id = 1;
                    stokKart.isFromExcel = true;
                    stokKart.parcaAltGrup.Id = 1;
                    stokKart.stokTip.Id = 1;
                    stokKart.profilTipId = 1;
                    if(stokKart.malzemeGrup.Id == 0)
                    {
                        MalzemeGrubu.malzemeGrubu.ShowDialog();
                    }
                    string pdfFileName = stokKart.pdfFileName();
                    var pdfFile = files.FirstOrDefault(file => file.Contains(pdfFileName, StringComparison.OrdinalIgnoreCase));
                    byte[] pdfContent = pdfFile==null?null:ReadPdfAsBinary(pdfFile);
                    stokKart.pdf= pdfContent;
                    string dxfFileName = stokKart.dxfFileName();
                    var dxfFile = files.FirstOrDefault(file => file.Contains(dxfFileName, StringComparison.OrdinalIgnoreCase));
                    byte[] dxfContent = dxfFile == null ? null : ReadPdfAsBinary(dxfFile);
                    stokKart.dxf = dxfContent;
                    string stepFileName = stokKart.stepFileName();
                    var stepFile = files.FirstOrDefault(file => file.Contains(stepFileName, StringComparison.OrdinalIgnoreCase));
                    byte[] stepContent = stepFile == null ? null : ReadPdfAsBinary(stepFile);
                    stokKart.step = stepContent;
                    resultMessage = await WebMethods.SaveStokKart(stokKart);
                    transferredCount.Text=row.ToString();
                }
                MessageBox.Show("Veri alma işlemi tamamlandı");
            }
        }
        private byte[] ReadPdfAsBinary(string pdfPath)
        {
            return File.ReadAllBytes(pdfPath); // PDF'yi binary olarak oku
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
            using (MemoryStream ms = new MemoryStream(buttonImageExcel.btnImage))
            {
                Image image = Image.FromStream(ms);
                dosyaSec.Image = image;
            }
        }

        private void dosyaSec_MouseLeave(object sender, EventArgs e)
        {
            dosyaSec.Image = Properties.Resources.fromExcelButton2;
        }
        private void ButtonImageLoad()
        {
            buttonImageExcel.btnName = "btnExcelDosyaSec";
            buttonImageExcel = GlobalData.GetModelFromDatabase(WebMethods.GetButtonImage, buttonImageExcel);
            buttonImageClose.btnName = "btnClose";
            buttonImageClose = GlobalData.GetModelFromDatabase(WebMethods.GetButtonImage, buttonImageClose);
            buttonImageLoad.btnName = "btnDosyaAktar";
            buttonImageLoad = GlobalData.GetModelFromDatabase(WebMethods.GetButtonImage, buttonImageLoad);
        }
    }
}
