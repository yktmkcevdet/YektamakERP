using ApiService.Interfaces;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Windows.Forms;
using Utilities.Interfaces;
using YektamakDesktop.Common;
using YektamakDesktop.CustomControls;

namespace YektamakDesktop.Formlar.Genel
{
    public partial class ExcelGrupParametreForm : Form
    {
        private readonly IStokService _stokService;
        private readonly ICache _cache;
        public ExcelGrupParametreForm(IStokService stokService, ICache cache)
        {
            _stokService = stokService;
            _cache = cache;
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            int sizeX = universalGrid1.Size.Width;
            int sizeY = universalGrid1.Size.Height;
            int locationY = universalGrid1.Location.Y;
            int locationX = universalGrid1.Location.X;
            Controls.Remove(universalGrid1);
            universalGrid1 = DIContainer.GetService<UniversalGrid>();
            universalGrid1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            universalGrid1.Location = new System.Drawing.Point(locationX, locationY);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new System.Drawing.Size(sizeX, sizeY);
            Controls.Add(universalGrid1);
            universalGrid1.SetData(new List<ExcelGrupParametre>(), this.Name);
            universalGrid1.MouseDown1 += UniversalGrid1_MouseDown1;

            fcbMalzemeStandart.SetDataSource(_cache.malzemeStandarts);
            fcbStokTip.SetDataSource(_cache.stokTips);
            fcbStokGrup.SetDataSource(_cache.stokGrups);
            fcbMalzemeGrup.SetDataSource(_cache.malzemeGrups);
            fcbMalzemeAltGrup.SetDataSource(_cache.malzemeAltGrups);
            fcbMalzemeAltGrup2.SetDataSource(_cache.malzemeAltGrup2List);
            fcbKarsilastirmaOperator.SetDataSource(Enum.GetValues(typeof(KarsilastirmaOperatoru)).Cast<KarsilastirmaOperatoru>()
                .ToList());
            Binding();
        }
        private void UniversalGrid1_MouseDown1(object sender, MouseEventArgs e)
        {
            excelGrupParametre = (ExcelGrupParametre)universalGrid1.Grid.CurrentRow.DataBoundItem;
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(universalGrid1, e.Location);
            }
        }
        private void Binding()
        {
            BindHelper.BindData(fcbMalzemeStandart, excelGrupParametre, nameof(excelGrupParametre.malzemeStandartId));
            BindHelper.BindData(fcbStokTip, excelGrupParametre, nameof(excelGrupParametre.stokTipId));
            BindHelper.BindData(fcbStokGrup, excelGrupParametre, nameof(excelGrupParametre.stokGrupId));
            BindHelper.BindData(fcbMalzemeGrup, excelGrupParametre, nameof(excelGrupParametre.malzemeGrupId));
            BindHelper.BindData(fcbMalzemeAltGrup, excelGrupParametre, nameof(excelGrupParametre.malzemeAltGrupId));
            BindHelper.BindData(fcbMalzemeAltGrup2, excelGrupParametre, nameof(excelGrupParametre.malzemeAltGrup2Id));
            BindHelper.BindData(ctbAnahtarKelime, excelGrupParametre, nameof(excelGrupParametre.karsilastirmaKelimesi));
            BindHelper.BindData(ctbExcelSutunAd, excelGrupParametre, nameof(excelGrupParametre.sutunAdi));
            BindHelper.BindDataEnum(fcbKarsilastirmaOperator, excelGrupParametre, nameof(excelGrupParametre.karsilastirmaOperatoru));
            BindHelper.BindData(ctbId, excelGrupParametre, nameof(excelGrupParametre.Id));
            BindHelper.BindData(chkTalasli, excelGrupParametre, nameof(excelGrupParametre.isTalasli));
            BindHelper.BindData(chkBukum, excelGrupParametre, nameof(excelGrupParametre.isBukum));
        }

        private ExcelGrupParametre _excelGrupParametre;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ExcelGrupParametre excelGrupParametre
        {
            get { if (_excelGrupParametre == null) { _excelGrupParametre = new(); } return _excelGrupParametre; }
            set { _excelGrupParametre = value; Binding(); }
        }
        private void ExcelGrupParametre_Load(object sender, EventArgs e)
        {
            string jsonResult = _stokService.GetExcelGrupParametre(new ExcelGrupParametre());
            List<ExcelGrupParametre> grupParametreList = JsonConvert.DeserializeObject<List<ExcelGrupParametre>>(jsonResult);
            universalGrid1.SetData(grupParametreList, this.Name);
        }

        private void customButtonSave1_SaveButtonClick(object sender, EventArgs e)
        {
            if (!CheckFields()) return;
            if ((KarsilastirmaOperatoru)fcbKarsilastirmaOperator.SelectedItem == KarsilastirmaOperatoru.Count)
            {
                excelGrupParametre.kosulMetni = $"{excelGrupParametre.sutunAdi}.{excelGrupParametre.karsilastirmaOperatoru}" +
                $"(p=>p==\"{excelGrupParametre.karsilastirmaKelimesi}\")=={ctbCount.TextCustom}";
            }
            else
            {
                excelGrupParametre.kosulMetni = $"{excelGrupParametre.sutunAdi}.{excelGrupParametre.karsilastirmaOperatoru}" +
                $"(\"{excelGrupParametre.karsilastirmaKelimesi}\", StringComparison.OrdinalIgnoreCase)";
            }
            string jsonResult = _stokService.SaveExcelGrupParametre(excelGrupParametre);
            if (jsonResult != null && !jsonResult.Contains("error", StringComparison.OrdinalIgnoreCase))
            {
                excelGrupParametre = JsonConvert.DeserializeObject<List<ExcelGrupParametre>>(jsonResult)[0];
            }
            else
            {
                MessageBox.Show(jsonResult, "Hata");
            }
        }
        private bool CheckFields()
        {
            bool result = true;
            result &= CheckFieldHelper.CheckField("*", fcbKarsilastirmaOperator);
            result &= CheckFieldHelper.CheckField("*", ctbAnahtarKelime);
            result &= CheckFieldHelper.CheckField("*", ctbExcelSutunAd);
            return result;
        }

        private void fcbStokGrup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fcbStokGrup.SelectedIndex == -1) return;
            fcbMalzemeGrup.SetDataSource(_cache.malzemeGrups.Where(m => m.stokGrup.Id.ToString() == fcbStokGrup.SelectedValue.ToString()).ToList());
            fcbMalzemeGrup.Enabled = true;
            fcbMalzemeAltGrup.DataSource = null;
            fcbMalzemeAltGrup2.DataSource = null;
        }

        private void fcbMalzemeGrup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fcbMalzemeGrup.SelectedIndex == -1) return;
            fcbMalzemeAltGrup.SetDataSource(_cache.malzemeAltGrups.Where(m => m.malzemeGrup.Id.ToString() == fcbMalzemeGrup.SelectedValue.ToString()).ToList());
            fcbMalzemeAltGrup.Enabled = true;
        }

        private void fcbMalzemeAltGrup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fcbMalzemeAltGrup.SelectedIndex == -1) return;
            fcbMalzemeAltGrup2.SetDataSource(_cache.malzemeAltGrup2List.Where(m => m.malzemeAltGrup.Id.ToString() == fcbMalzemeAltGrup.SelectedValue.ToString()).ToList());
            fcbMalzemeAltGrup2.Enabled = true;
        }

        private void koşuluSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string jsonResult = _stokService.DeleteExcelGrupParametre(excelGrupParametre);

            if (string.IsNullOrEmpty(jsonResult) || jsonResult.Contains("error", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show(jsonResult);
            }
            else
            {
                universalGrid1.binding.Remove(excelGrupParametre);
            }
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            excelGrupParametre = new ExcelGrupParametre();
        }
        public void Filter(ExcelGrupParametre filter)
        {
            universalGrid1.Filtrele(filter);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (fcbKarsilastirmaOperator.SelectedIndex == -1)
            {
                ctbCount.Visible = false;
            }
            else if ((KarsilastirmaOperatoru)fcbKarsilastirmaOperator.SelectedItem == KarsilastirmaOperatoru.Count)
            {
                excelGrupParametre.kosulMetni = $"{excelGrupParametre.sutunAdi}.{excelGrupParametre.karsilastirmaOperatoru}" +
                $"(p=>p==\"{excelGrupParametre.karsilastirmaKelimesi}\")=={ctbCount.TextCustom} && ";
                ctbExcelSutunAd.TextCustom = null;
                fcbKarsilastirmaOperator.SelectedIndex = -1;
                ctbAnahtarKelime.TextCustom = null;
            }
            else
            {
                excelGrupParametre.kosulMetni = $"{excelGrupParametre.sutunAdi}.{excelGrupParametre.karsilastirmaOperatoru}" +
                $"(\"{excelGrupParametre.karsilastirmaKelimesi}\", StringComparison.OrdinalIgnoreCase) && ";
                ctbExcelSutunAd.TextCustom = null;
                fcbKarsilastirmaOperator.SelectedIndex = -1;
                ctbAnahtarKelime.TextCustom = null;
            }
        }

        private void fcbKarsilastirmaOperator_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fcbKarsilastirmaOperator.SelectedIndex == -1)
            {
                ctbCount.Visible = false;
            }
            else if ((KarsilastirmaOperatoru)fcbKarsilastirmaOperator.SelectedItem == KarsilastirmaOperatoru.Count)
            {
                ctbCount.Visible = true;
            }
            else
            {
                ctbCount.Visible = false;
            }
        }
    }
}
