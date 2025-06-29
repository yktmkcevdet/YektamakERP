using ApiService.Interfaces;
using Models.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Utilities.Interfaces;

namespace YektamakDesktop.Formlar.Genel
{
    public partial class ExcelTanimlamaFormu : Form, IForm
    {
        private static IAnaVeriService _anaVeriService;
        private static IJsonConverter _jsonConverter;
        public ExcelTanimlamaFormu(IAnaVeriService anaVeriService,IJsonConverter jsonConverter)
        {
            _anaVeriService = anaVeriService;
            _jsonConverter = jsonConverter;
        }
        private ExcelTanimlamaFormu()
        {
            InitializeComponent();
            controlsToDisable = new List<Control>();
        }
        private static ExcelTanimlamaFormu _excelTanimlamaFormu;
        public static ExcelTanimlamaFormu excelTanimlamaFormu
        {
            get
            {
                if (_excelTanimlamaFormu == null || _excelTanimlamaFormu.IsDisposed)
                {
                    _excelTanimlamaFormu = new ExcelTanimlamaFormu();
                    GlobalData.Yetki(ref _excelTanimlamaFormu);
                }
                return _excelTanimlamaFormu;
            }
        }

        public List<Control> controlsToDisable { get; set; }
        public bool activeForm { get; set; }

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
                Result result = _jsonConverter.DeserializeToModelList<Result>(jsonResult)[0];
                MessageBox.Show(result.result);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
