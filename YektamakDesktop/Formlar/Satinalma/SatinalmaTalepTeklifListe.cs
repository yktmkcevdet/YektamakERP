using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YektamakDesktop.Abstracts;
using Models;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using FastReport.Data;
using YektamakDesktop.CustomControls;
using Outlook = Microsoft.Office.Interop.Outlook;
using ApiService;
using Utilities.Implementations;
using Utilities.Interfaces;

namespace YektamakDesktop.Formlar.Satinalma
{
    public partial class SatinalmaTalepTeklifListe : Form,IForm
    {
        private WebMethods _webMethods;
        private DataSet _dataSetSatinalmaTalepler;
        private DataSet dataSetSatinalmaTalepler { get { if (_dataSetSatinalmaTalepler == null) _dataSetSatinalmaTalepler = new();return _dataSetSatinalmaTalepler; } set { _dataSetSatinalmaTalepler = value; } }
        public static SatinalmaTalepTeklifListe _satinalmaTalepTeklifListe;
        public static SatinalmaTalepTeklifListe satinalmaTalepTeklifListe
        {
            get
            {
                if (_satinalmaTalepTeklifListe == null)
                {
                    _satinalmaTalepTeklifListe = new();
                    GlobalData.Yetki(ref _satinalmaTalepTeklifListe);
                }
                return _satinalmaTalepTeklifListe;
            }
            set
            {
                _satinalmaTalepTeklifListe = value;
            }
        }
        public List<Control> controlsToDisable { get; set; }
        public bool activeForm { get; set; }
        public SatinalmaTalepTeklifListe()
        {
            InitializeComponent();
        }

        public SatinalmaTalepTeklifListe(WebMethods webMethods)
        {
            _webMethods = webMethods;
        }

        #region MouseDrag
        bool mouseDown;
        private Point offset;
        private void panelHeader_MouseDown(object sender, MouseEventArgs e)
        {
            offset.X = e.X;
            offset.Y = e.Y;
            mouseDown = true;
        }

        private void panelHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Point currentScreepPos = PointToScreen(e.Location);
                Location = new Point(currentScreepPos.X - offset.X, currentScreepPos.Y - offset.Y);
            }
        }

        private void panelHeader_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        #endregion MouseDrag
        private void CloseForm()
        {
            this.Close();
            GlobalData.RemoveLastForm();
            _satinalmaTalepTeklifListe = null;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void buttomMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private async void SatinalmaTalepTeklifListe_Load(object sender, EventArgs e)
        {
            IJsonConvertHelper jsonConverter = new JsonConvertHelper();
            string jsonStringProjeKod = WebMethods.GetFilteredSatisProje(new SatisProje());
            DataSet dataSetProjeKod = jsonConverter.JsonStringToDataSet(jsonStringProjeKod);
            foreach (DataRow dataRow in dataSetProjeKod.Tables[0].Rows)
            {
                IDataTableConverter dataTableConverter = new DataTableConverter();
                SatisProje projeKod = dataTableConverter.DataRowToModel<SatisProje>(dataRow);
                comboListProjeKodu.AddDataRow(projeKod.projeKod.Id, projeKod.projeKod.kod);
            }
            string jsonStringTalepTipleri = _webMethods.GetTalepTipleri();
            DataSet dataSetTalepTipleri = jsonConverter.JsonStringToDataSet(jsonStringTalepTipleri);
            foreach (DataRow dataRow in dataSetTalepTipleri.Tables[0].Rows)
            {
                IDataTableConverter dataTableConverter = new DataTableConverter();
                TalepTip talepTip = dataTableConverter.DataRowToModel<TalepTip>(dataRow);
                customCheckedComboBox1.AddDataRow(talepTip.talepTipId, talepTip.kod);
            }
            //foreach(Firma firma in GlobalData.firmaUnvanList)
            //{
            //    comboListBoxFirma.AddDataRow(firma.id, firma.unvan);
            //}
            SatinalmaTalepBaslik satinalmaTalepBaslik = new SatinalmaTalepBaslik();
            satinalmaTalepBaslik.proje.Id = comboListProjeKodu.selectedDataRowId;
            string jsonString = await WebMethods.GetSatinalmaTalep(satinalmaTalepBaslik);
            dataSetSatinalmaTalepler = jsonConverter.JsonStringToDataSet(jsonString);
            //GlobalData.FillDataGrid(dataSetSatinalmaTalepler.Tables[1], dataGridView1, satinalmaTalepBaslik);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            SatinalmaTeklifBaslik satinalmaTeklifBaslik = new SatinalmaTeklifBaslik();
            List<StokKart> binaryDataList = new List<StokKart>();
            foreach (DataGridViewRow dataGridViewRow in dataGridView1.Rows)
            {
                if ((bool)dataGridViewRow.Cells["Secim"].Value == true)
                {
                    if (string.IsNullOrEmpty(dataGridViewRow.Cells["pdf"].Value.ToString()))
                    {
                        MessageBox.Show($"{dataGridViewRow.Cells["StokKartKodu"].Value.ToString()} kodlu parçaya ait pdf dosyası kayıtlı değil. İşlem iptal edildi.");
                    }
                    string jsonString = "\"" + dataGridViewRow.Cells["pdf"].Value.ToString() + "\"";
                    byte[] pdfData = JsonConvert.DeserializeObject<byte[]>(jsonString);
                    StokKart stokKart = new();
                    stokKart.pdf = pdfData;
                    stokKart.kod = dataGridViewRow.Cells["stokKartKodu"].Value.ToString();
                    binaryDataList.Add(stokKart);
                    SatinalmaTeklifDetay satinalmaTeklifDetay = new SatinalmaTeklifDetay();
                    satinalmaTeklifDetay.satinalmaTalepDetayId = Convert.ToInt32(dataGridViewRow.Cells["satinalmaTalepDetayId"].Value.ToString());
                    satinalmaTeklifBaslik.satinalmaTeklifDetayList.Add(satinalmaTeklifDetay);
                }
            }
            string tempFolder = Path.Combine(Path.GetTempPath(), "TempFolder"); // Geçici olarak dosyaların saklanacağı klasör
            Directory.CreateDirectory(tempFolder);

            // Geçici klasöre dosyaları yazma
            for (int i = 0; i < binaryDataList.Count; i++)
            {
                string dosyaYolu = Path.Combine(tempFolder, binaryDataList[i].kod + ".pdf"); // Dosya adını ve yolunu oluştur
                File.WriteAllBytes(dosyaYolu, binaryDataList[i].pdf); // Dosyayı diske yaz
            }
            
            string birlesmisDosyaAdi = "birlesmisDosya.rar"; // Birleştirilmiş dosyanın adı ve RAR uzantısı

            using (FileStream birlesmisDosya = new FileStream(birlesmisDosyaAdi, FileMode.Create))
            {
                using (ZipArchive zipArchive = new ZipArchive(birlesmisDosya, ZipArchiveMode.Create))
                {
                    string[] dosyaYollari = Directory.GetFiles(tempFolder); // Geçici klasördeki dosya yollarını al
                    foreach (string dosyaYolu in dosyaYollari)
                    {
                        string dosyaAdi = Path.GetFileName(dosyaYolu);
                        zipArchive.CreateEntryFromFile(dosyaYolu, dosyaAdi); // Her bir dosyayı arşive ekleyin
                    }   
                }
            }
            // Geçici klasörü temizle
            Directory.Delete(tempFolder, true);
            SendMail(Environment.CurrentDirectory+"\\"+birlesmisDosyaAdi);
            satinalmaTeklifBaslik.teklifTalepTarihi = DateTime.Now;
            satinalmaTeklifBaslik.teklifFirma.id = comboListBoxFirma.selectedDataRowId;
            WebMethods.SaveSatinalmaTeklif(satinalmaTeklifBaslik);
            
        }

        private async void roundedIconButton1_Click(object sender, EventArgs e) 
        {
            dataGridView1.Rows.Clear();

            string talepTipFiltre="(Aciklama=";
            if(customCheckedComboBox1.listBoxDataRows.Where(x => x.isChecked == true).Count() == 0)
            {
                foreach (CheckedListBoxDataRow checkedListBoxDataRow in customCheckedComboBox1.listBoxDataRows)
                {
                    talepTipFiltre = talepTipFiltre + "'" + checkedListBoxDataRow.value + "' or Aciklama=";
                }
            }
            else
            {
                foreach (CheckedListBoxDataRow checkedListBoxDataRow in customCheckedComboBox1.listBoxDataRows.Where(x => x.isChecked == true))
                {
                    talepTipFiltre = talepTipFiltre + "'" + checkedListBoxDataRow.value + "' or Aciklama=";
                }
            }
            
            talepTipFiltre=talepTipFiltre.Substring(0, talepTipFiltre.Length - 13)+")";
            DataTable dataTable = dataSetSatinalmaTalepler.Tables[1].Select($"ProjeKod='{comboListProjeKodu.selectedDataRowValue}' and {talepTipFiltre}").CopyToDataTable();
            GlobalData.FillDataGrid(dataTable, dataGridView1, new SatinalmaTalepBaslik());
        }
        private void SendMail(string ekDosya)
        {
            Outlook.Application outlookApp = new Outlook.Application();

            Outlook.MailItem mailItem = (Outlook.MailItem)outlookApp.CreateItem(Outlook.OlItemType.olMailItem);

            mailItem.To = "alici@example.com";
            mailItem.Subject = "RAR Dosyası Ekli";
            mailItem.Body = "Merhaba, ekte bir RAR dosyası bulunmaktadır.";

            string rarFilePath = ekDosya;
            mailItem.Attachments.Add(rarFilePath);

            mailItem.Display(true);
        }
    }
}
