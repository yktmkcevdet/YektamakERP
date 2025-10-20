using ApiService.Interfaces;
using Models.Configuration;
using Models.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities.Interfaces;
using YektamakDesktop.Common;
using YektamakDesktop.CustomControls;

namespace YektamakDesktop.Formlar.Genel
{
    public partial class DosyalamaParametreleri : Form
    {
        private readonly ICache _cache;
        private readonly IAnaVeriService _anaVeriService;
        public DosyalamaParametreleri(ICache cache, IAnaVeriService anaVeriService)
        {
            _cache = cache;
            _anaVeriService = anaVeriService;
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            Controls.Remove(universalGrid1);
            universalGrid1 = DIContainer.GetService<UniversalGrid>();
            universalGrid1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            universalGrid1.Location = new Point(12, 247);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new Size(819, 385);
            universalGrid1.TabIndex = 1;
            Controls.Add(universalGrid1);
            universalGrid1.SetData(new List<DosyalamaYapisi>(), this.Name);
            universalGrid1.MouseDown1 += UniversalGrid1_MouseDown1;
            fcbStokGrup.SetDataSource(_cache.stokGrups);
            fcbMalzemeGrup.SetDataSource(_cache.malzemeGrups);
            fcbMalzemeAltGrup.SetDataSource(_cache.malzemeAltGrups);
            fcbBoyut.SetDataSource(_cache.boyutList);
            Binding();
        }

        private void UniversalGrid1_MouseDown1(object sender, MouseEventArgs e)
        {
            dosyalamaYapisi = (DosyalamaYapisi)universalGrid1.Grid.CurrentRow.DataBoundItem;
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(universalGrid1, e.Location);
            }
        }

        private DosyalamaYapisi _dosyalamaYapisi;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DosyalamaYapisi dosyalamaYapisi
        {
            get
            {
                if (_dosyalamaYapisi == null)
                    _dosyalamaYapisi = new DosyalamaYapisi();
                return _dosyalamaYapisi;
            }
            set
            {
                _dosyalamaYapisi = value;
                Binding();
            }
        }
        private void Binding()
        {
            BindHelper.BindData(ctbId, dosyalamaYapisi, nameof(dosyalamaYapisi.Id));
            BindHelper.BindData(fcbStokGrup, dosyalamaYapisi, nameof(dosyalamaYapisi.stokGrupId));
            BindHelper.BindData(fcbMalzemeGrup, dosyalamaYapisi, nameof(dosyalamaYapisi.malzemeGrupId));
            BindHelper.BindData(fcbMalzemeAltGrup, dosyalamaYapisi, nameof(dosyalamaYapisi.malzemeAltGrupId));
            BindHelper.BindData(fcbBoyut, dosyalamaYapisi, nameof(dosyalamaYapisi.boyutId));
            BindHelper.BindData(ctbKlasor, dosyalamaYapisi, nameof(dosyalamaYapisi.klasorAd));
            BindHelper.BindData(ctbPath, dosyalamaYapisi, nameof(dosyalamaYapisi.path));
            BindHelper.BindData(chkPdf, dosyalamaYapisi, nameof(dosyalamaYapisi.pdf));
            BindHelper.BindData(chkDxf, dosyalamaYapisi, nameof(dosyalamaYapisi.dxf));
            BindHelper.BindData(chkStep, dosyalamaYapisi, nameof(dosyalamaYapisi.step));
            BindHelper.BindData(chkBukum, dosyalamaYapisi, nameof(dosyalamaYapisi.isBukum));
            BindHelper.BindData(chkTalasli, dosyalamaYapisi, nameof(dosyalamaYapisi.isTalasli));
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _anaVeriService.DeleteDosyalamaYapisi(dosyalamaYapisi);
        }

        private void DosyalamaParametreleri_Load(object sender, EventArgs e)
        {
            string jsonResult = _anaVeriService.GetDosyalamaYapisi(dosyalamaYapisi);
            var dosyalamaYapisiList = JsonConvert.DeserializeObject<List<DosyalamaYapisi>>(jsonResult);
            universalGrid1.SetData(dosyalamaYapisiList, this.Name);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            dosyalamaYapisi = new DosyalamaYapisi();
        }

        private void btnSave_SaveButtonClick(object sender, EventArgs e)
        {
            string jsonResult = _anaVeriService.SaveDosyalamaYapisi(dosyalamaYapisi);
            if (!string.IsNullOrEmpty(jsonResult) && !jsonResult.Contains("error", StringComparison.OrdinalIgnoreCase))
            {
                dosyalamaYapisi = JsonConvert.DeserializeObject<List<DosyalamaYapisi>>(jsonResult).FirstOrDefault();
                universalGrid1.binding.Add(dosyalamaYapisi);
                MessageBox.Show("Kayıt işlemi başarıyla tamamlandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Kayıt işlemi sırasında bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void DosyalamaParametreleri_FormClosing(object sender, FormClosingEventArgs e)
        {
            universalGrid1.SaveSettings();
        }
    }
}
