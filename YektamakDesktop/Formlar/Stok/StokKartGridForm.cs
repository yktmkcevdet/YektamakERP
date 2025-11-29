using ApiService.Interfaces;
using Models;
using Models.DTO;
using Models.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities.Interfaces;
using YektamakDesktop.Common;
using YektamakDesktop.CustomControls;
using YektamakDesktop.Formlar.Genel;

namespace YektamakDesktop.Formlar.Stok
{
    public partial class StokKartGridForm : Form
    {
        private readonly IStokService _stokService;
        private readonly ICache _cache;
        private readonly IJsonConverter _jsonConverter;
        private readonly IProjeService _projeService;
        public StokKartGridForm(ICache cache, IJsonConverter jsonConvertHelper, IStokService stokService, IProjeService projeService)
        {
            _stokService = stokService;
            _cache = cache;
            _jsonConverter = jsonConvertHelper;
            _projeService = projeService;
            InitializeComponent();
            InitializeGridForm();
        }
        private void InitializeGridForm()
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
            universalGrid1.TabIndex = 13;
            Controls.Add(universalGrid1);
            universalGrid1.MouseDown1 += universalGrid1_MouseDown1;
            fcbProjeKodu.SetDataSource(_cache.projeList.Select(p => new { p.Id, p.kod}).Distinct().ToList());
            fcbStokGrup.SetDataSource(_cache.stokGrups);
            fcbMalzemeGrup.SetDataSource(_cache.malzemeGrups);
            fcbMalzemeAltGrup.SetDataSource(_cache.malzemeAltGrups);
            fcbMalzemeAltGrup2.SetDataSource(_cache.malzemeAltGrup2List);
            fcbStokTip.SetDataSource(_cache.stokTips);
            Binding();
            Load += async (s, e) => await StokKartGridForm_Load(s, e);
            fcbProjeKodu.SelectedIndexChanged += async (s, e) => await projeKodu_SelectedIndexChanged(s, e);
            stokKartınıSilToolStripMenuItem.Click += async (s, e) => await stokKartınıSilToolStripMenuItem_Click(s,e);

            ctbParcaAdi.TextChanged += ctbParcaAdi_TextChanged;
        }

        private void ctbParcaAdi_TextChanged(object s, EventArgs e)
        {
            if (ctbParcaAdi.TextCustom.Length > 2)
            {
                stokKartFilter.stokKart.ad = ctbParcaAdi.TextCustom;
                //stokKartFilter.stokKart.parcaAdi = ctbParcaAdi.TextCustom;
                //stokKartFilter.stokKart.boyut = ctbParcaAdi.TextCustom;
            }
            else
            {
                stokKartFilter.stokKart.ad = null;
                //stokKartFilter.stokKart.parcaAdi = String.Empty;
                //stokKartFilter.stokKart.boyut = String.Empty;
            }
            GridYenile();
        }

        private List<ProjeStokKartDTO> _stokKartDTOs;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<ProjeStokKartDTO> stokKartDTOs
        {
            get
            {
                if (_stokKartDTOs == null)
                {
                    _stokKartDTOs = new List<ProjeStokKartDTO>();
                }
                return _stokKartDTOs;
            }
            set
            {
                _stokKartDTOs = value;
            }
        }

        private List<ProjeStokKart> _stokKarts;
        private List<ProjeStokKart> stokKarts
        {
            get
            {
                if (_stokKarts == null)
                {
                    _stokKarts = new List<ProjeStokKart>();
                }
                return _stokKarts;
            }
            set
            {
                _stokKarts = value;
            }
        }

        private ProjeStokKart _stokKartFilter;
        private ProjeStokKart stokKartFilter
        {
            get
            {
                if (_stokKartFilter == null)
                {
                    _stokKartFilter = new ProjeStokKart();
                }
                return _stokKartFilter;
            }
            set { _stokKartFilter = value; }
        }

        private async Task GridDoldur()
        {
            this.Enabled = false;
            stokKarts.Clear();
            stokKarts = await _projeService.GetProjeStokKart(stokKartFilter); 
            List<ProjeStokKartDTO> pskDTOs = new List<ProjeStokKartDTO>();
            stokKartDTOs = stokKarts.CastToDTO<ProjeStokKartDTO>().ToList();
            await universalGrid1.SetData(stokKartDTOs, this.Name, true);
            this.Enabled = true;
        }
        private void malzemeGrubu_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridYenile();
            ComboBoxListFill.GetLookupAd(_cache.malzemeAltGrups.Where(x => x.malzemeGrup.Id == stokKartFilter.stokKart.malzemeGrup.Id).ToList(), ref fcbMalzemeAltGrup);

        }

        private void GridYenile()
        {
            ProjeStokKartDTO stokKartDTO = ConvertHelper.ToDTO<ProjeStokKartDTO>(stokKartFilter);
            universalGrid1.Filtrele(stokKartDTO);
        }

        public void buttonEkle_Click(object sender, EventArgs e)
        {
            StokKartKayitFormu stokKartKayitFormu = FormFactory.CreateForm<StokKartKayitFormu>();
            stokKartKayitFormu.AfterSave += StokKartKayitFormu_AfterSave;
            if (fcbMalzemeGrup.SelectedIndex != -1) stokKartKayitFormu.projeStokKart.stokKart.malzemeGrup.Id = int.Parse(fcbMalzemeGrup.SelectedValue.ToString());
            if (fcbMalzemeAltGrup.SelectedIndex != -1) stokKartKayitFormu.projeStokKart.stokKart.malzemeAltGrup.Id = int.Parse(fcbMalzemeAltGrup.SelectedValue.ToString());
            if (fcbMalzemeAltGrup2.SelectedIndex != -1) stokKartKayitFormu.projeStokKart.stokKart.malzemeAltGrup2.Id = int.Parse(fcbMalzemeAltGrup2.SelectedValue.ToString());
            if (stokKartKayitFormu != null)
            {
                stokKartKayitFormu.Show();
            }
        }
        private void Binding()
        {
            BindHelper.BindData(fcbProjeKodu, stokKartFilter.proje, nameof(stokKartFilter.proje.Id));
            BindHelper.BindData(fcbStokGrup, stokKartFilter.stokKart.stokGrup, nameof(stokKartFilter.stokKart.stokGrup.Id));
            BindHelper.BindData(fcbMalzemeGrup, stokKartFilter.stokKart.malzemeGrup, nameof(stokKartFilter.stokKart.malzemeGrup.Id));
            BindHelper.BindData(fcbMalzemeAltGrup, stokKartFilter.stokKart.malzemeAltGrup, nameof(stokKartFilter.stokKart.malzemeAltGrup.Id));
            BindHelper.BindData(fcbMalzemeAltGrup2, stokKartFilter.stokKart.malzemeAltGrup2, nameof(stokKartFilter.stokKart.malzemeAltGrup2.Id));
            BindHelper.BindData(fcbStokTip, stokKartFilter.stokKart.stokTip, nameof(stokKartFilter.stokKart.stokTip.Id));
            BindHelper.BindData(ctbParcaAdi, stokKartFilter.stokKart, nameof(stokKartFilter.stokKart.ad));
        }
        private async Task projeKodu_SelectedIndexChanged(object sender, EventArgs e)
        {
            await GridDoldur();
        }

        private void cbxStokGrup_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridYenile();
            ComboBoxListFill.GetLookupAd(_cache.malzemeGrups.Where(x => x.stokGrup.Id == stokKartFilter.stokKart.stokGrup.Id).ToList(), ref fcbMalzemeGrup);
        }

        private void cbxMalzemeAltGrup_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridYenile();
            ComboBoxListFill.GetLookupAd(_cache.malzemeAltGrup2List.Where(x => x.malzemeAltGrup.Id == stokKartFilter.stokKart.malzemeAltGrup.Id).ToList(), ref fcbMalzemeAltGrup2);
        }

        private void cbxMalzemeAltGrup2_DoubleClick(object sender, EventArgs e)
        {
            DIContainer.GetService<AnaVeriTanimlamaFormu<MalzemeAltGrup2>>();
            AnaVeriTanimlamaFormu<MalzemeAltGrup2> anaVeriTanimlamaFormu = FormFactory.CreateForm<AnaVeriTanimlamaFormu<MalzemeAltGrup2>>();
            if (anaVeriTanimlamaFormu != null) anaVeriTanimlamaFormu.Show();
        }

        private void cbxStokTip_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridYenile();
        }

        private void StokKartGridForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            universalGrid1.SaveSettings();
        }

        private async Task StokKartGridForm_Load(object sender, EventArgs e)
        {
            await universalGrid1.SetData(stokKartDTOs, this.Name, true);
        }

        private void stokKartınıGörüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var proejStokKartDTO = (ProjeStokKartDTO)universalGrid1.Grid.CurrentRow.DataBoundItem;
            ProjeStokKart projeStokKart = ConvertHelper.ToEntity<ProjeStokKart>(proejStokKartDTO);
            StokKartKayitFormu stokKartKayitFormu = FormFactory.CreateForm<StokKartKayitFormu>();
            stokKartKayitFormu.AfterSave += StokKartKayitFormu_AfterSave;
            stokKartKayitFormu.UpdateMode(projeStokKart);
            stokKartKayitFormu.Show();
        }

        private void StokKartKayitFormu_AfterSave(object sender, object e)
        {
            var liste = (BindingList<ProjeStokKartDTO>)universalGrid1.binding.DataSource;
            var index = liste.ToList().FindIndex(s => s.Id == ((ProjeStokKart)e).Id);
            if (index == -1)
            {
                liste.Add(ConvertHelper.ToDTO<ProjeStokKartDTO>((ProjeStokKart)e));
            }
            else
            {
                liste[index] = ConvertHelper.ToDTO<ProjeStokKartDTO>((ProjeStokKart)e);
            }
        }

        private void universalGrid1_MouseDown1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(universalGrid1, e.Location);
            }
        }

        private async Task stokKartınıSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show($"Seçilen kayıtlar silinecektir. Onaylıyor musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            string logDosyasi = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonTemplates), @"\Logs\app.log");
            string klasor = Path.GetDirectoryName(logDosyasi);
            if (!Directory.Exists(klasor))
                Directory.CreateDirectory(klasor);
            File.WriteAllText(logDosyasi, "Silinemeyen satırlar");
            if (dialogResult == DialogResult.Yes)
            {
                List<ProjeStokKartDTO> projeStokKartDTOs = universalGrid1.GetCheckedRows<ProjeStokKartDTO>();
                for (int i = 0; i < projeStokKartDTOs.Count; i++)
                {
                    var item = projeStokKartDTOs[i];
                    if (!_cache.projeList.Any(p => p.sorumluList.Where(s=>s.Id == _cache.kullanici.personel.Id).Count()>0 && p.Id == item.projeId))
                    {
                        File.AppendAllText(logDosyasi, $"{item.stokKartkod} koduna ait stok kartını silemezsiniz\r\n");
                    }
                    else
                    {
                        string jsonResult = await _projeService.DeleteProjeStokKart(ConvertHelper.ToEntity<ProjeStokKart>(item));
                        if (String.IsNullOrEmpty(jsonResult) || jsonResult.Contains("error", StringComparison.OrdinalIgnoreCase))
                        {
                            File.AppendAllText(logDosyasi, $"{item.stokKartkod} {jsonResult}\r\n");
                        }
                        else
                        {
                            universalGrid1.binding.Remove(item);
                        }
                    }
                }
                Process.Start(new ProcessStartInfo
                {
                    FileName = logDosyasi,
                    UseShellExecute = true
                });
            }
        }
    }
}
