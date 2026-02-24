using Models;
using System;
using System.Windows.Forms;
using YektamakDesktop.Common;

namespace YektamakDesktop.Formlar.Stok
{
    public partial class StokKartHamVeri : Form
    {
        public StokKartHamVeri()
        {
            InitializeComponent();
        }
        private ExcelFormat _excelData;
        private ExcelFormat excelData
        {
            get
            {
                return _excelData;
            }
            set
            {
                _excelData = value;
                Binding();
            }
        }
        private void StokKartHamVeri_Load(object sender, EventArgs e)
        {

        }
        public void UpdateMode(ExcelFormat excelFormat)
        {
            excelData = excelFormat;
        }
        private void Binding()
        {
            BindHelper.BindData(ctbNo,excelData,nameof(excelData.no));
            BindHelper.BindData(ctbKod, excelData, nameof(excelData.kod));
            BindHelper.BindData(ctbParcaAdi, excelData, nameof(excelData.parcaAdi));
            BindHelper.BindData(ctbMiktar, excelData, nameof(excelData.miktar));
            BindHelper.BindData(ctbAdet, excelData, nameof(excelData.adet));
            BindHelper.BindData(ctbFark, excelData, nameof(excelData.fark));
            BindHelper.BindData(ctbBoyut, excelData, nameof(excelData.boyut));
            BindHelper.BindData(ctbUzunluk, excelData, nameof(excelData.uzunluk));
            BindHelper.BindData(ctbMalzeme, excelData, nameof(excelData.malzeme));
            BindHelper.BindData(ctbAciklama, excelData, nameof(excelData.aciklama));
            BindHelper.BindData(ctbAgirlik, excelData, nameof(excelData.agirlik));
        }
    }
}
