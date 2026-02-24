using ApiService.Interfaces;
using Models;
using System;
using System.IO;
using System.Windows.Forms;
using Utilities.Interfaces;

namespace YektamakDesktop.Formlar.Genel
{
    public partial class ExcelTanimlamaFormu : Form
    {
        private IAnaVeriService _anaVeriService;
        private IJsonConverter _jsonConverter;
        public ExcelTanimlamaFormu(IAnaVeriService anaVeriService,IJsonConverter jsonConverter)
        {
            _anaVeriService = anaVeriService;
            _jsonConverter = jsonConverter;
            InitializeComponent();
        }
        private void btnDosyaSec_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel Files|*.xls;*.xlsx;*.xlsm",
                Title = "Excel Dosyası Seçin"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ctxtFilePath.TextCustom = openFileDialog.FileName;
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] dosyaIcerigi;
                using (var stream = new FileStream(ctxtFilePath.TextCustom, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        stream.CopyTo(memoryStream);
                        dosyaIcerigi = memoryStream.ToArray();
                    }
                }
                ExcelForm excelForm = new ExcelForm
                {
                    formAd = ctxtFormAd.TextCustom,
                    excel = Convert.ToBase64String(dosyaIcerigi),
                };
                string jsonResult=await _anaVeriService.SaveExcelForm(excelForm);
                MessageBox.Show(jsonResult);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
