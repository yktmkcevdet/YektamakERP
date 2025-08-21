using ApiService.Interfaces;
using Models;
using Models.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities.Interfaces;
using YektamakDesktop.Common;
using YektamakDesktop.CustomControls;
using YektamakDesktop.Formlar.Satinalma;
using YektamakDesktop.Formlar.Stok;
using System.ComponentModel;

namespace YektamakDesktop.Formlar.ProjeModul
{
    public partial class ProjeDosyalari : Form
    {
        private readonly ICache _cache;
        private readonly IJsonConverter _jsonConverter;
        private readonly IProjeService _projeService;
        public ProjeDosyalari(ICache cache, IJsonConverter jsonConvertHelper, IProjeService projeService)
        {
            _cache = cache;
            _jsonConverter = jsonConvertHelper;
            _projeService = projeService;
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            Controls.Remove(universalGrid1);
            universalGrid1 = DIContainer.GetService<UniversalGrid>();
            universalGrid1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            universalGrid1.Location = new System.Drawing.Point(8, 270);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new System.Drawing.Size(1273, 474);
            universalGrid1.TabIndex = 124;
            universalGrid1.MouseDown1 += universalGrid1_MouseClick;
            Controls.Add(universalGrid1);

            Load += async (s, e) => await form_Load(s, e);
            clbStokGrup.SelectedIndexChanged += async (s, e) => await parcaGrubu_SelectedIndexChanged(s, e);
            clbMalzemeGrup.SelectedIndexChanged += async (s, e) => await parcaAltGrubu_SelectedIndexChanged(s, e);
            ctbParcaAdi.TextChanged += async (s, e) => await textBoxParcaAdi_TextChanged(s, e);
            ctbParcaAdi.KeyDown += async (s, e) => await parcaAdi_KeyDown(s, e);
            chkSatinalma.CheckedChanged += async (s, e) => await chkPdf_CheckStateChanged(s, e);
            chkPdf.CheckStateChanged += async (s, e) => await chkPdf_CheckStateChanged(s, e);
            chkDxf.CheckStateChanged += async (s, e) => await chkDxf_CheckedChanged(s, e);
            chkStep.CheckStateChanged += async (s, e) => await chkStep_CheckedChanged(s, e);
            chkSatinalma.CheckStateChanged += async (s, e) => await chkSatinalma_CheckedChanged(s, e);
            clbMalzemeAltGrup.SelectedIndexChanged += async (s, e) => await cbxMalzemeAltGrup_SelectedIndexChanged(s, e);
            clbMalzemeAltGrup2.SelectedIndexChanged += async (s, e) => await cbxMalzemeAltGrup2_SelectedIndexChanged(s, e);
            roundedIconButton2.Click += async (s, e) => await roundedIconButton2_Click(s, e);
            FormClosing += async (s, e) => await ProjeDosyalari_FormClosing(s, e);
            seçilenKayıtlarıSilToolStripMenuItem.Click += async (s, e) => await seçilenKayıtlarıSilToolStripMenuItem_Click(s, e);

        }
        private ProjeStokKart _projeStokKartFilter;
        private ProjeStokKart projeStokKartFilter
        {
            get
            {
                if (_projeStokKartFilter == null)
                {
                    _projeStokKartFilter = new ProjeStokKart();
                }
                return _projeStokKartFilter;
            }
            set
            {
                _projeStokKartFilter = value;
            }
        }

        private List<ProjeStokKartDTO> _projeStokKartDTOs;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<ProjeStokKartDTO> projeStokKartDTOs
        {
            get
            {
                if (_projeStokKartDTOs == null)
                {
                    _projeStokKartDTOs = new();
                }
                return _projeStokKartDTOs;
            }
            set
            {
                _projeStokKartDTOs = value;
            }
        }
        public async Task form_Load(object sender, EventArgs e)
        {
            ComboBoxListFill.GetLookupKod(_cache.projes.Where(x => x.personel.Id == _cache.kullanici.personel.Id).ToList(), ref fcbProjeKod);
            //ComboBoxListFill.GetLookupAd(_cache.stokGrups, ref clbStokGrup);
            clbStokGrup.SetDataSource(_cache.stokGrups);
            await Binding();
        }

        private async Task Binding()
        {
            BindHelper.BindData(fcbProjeKod, projeStokKartFilter,e=>e.proje);
            BindHelper.BindData(clbMalzemeGrup, projeStokKartFilter.stokKart,e=>e.malzemeGrup);
            BindHelper.BindData(clbStokGrup, projeStokKartFilter.stokKart,e=>e.stokGrup);
            BindHelper.BindData(clbMalzemeAltGrup, projeStokKartFilter.stokKart,e=>e.malzemeAltGrup);
            BindHelper.BindData(chkPdf, projeStokKartFilter.stokKart, nameof(projeStokKartFilter.stokKart.isPdf));
            BindHelper.BindData(chkDxf, projeStokKartFilter.stokKart, nameof(projeStokKartFilter.stokKart.isDxf));
            BindHelper.BindData(chkStep, projeStokKartFilter.stokKart, nameof(projeStokKartFilter.stokKart.isStep));
            BindHelper.BindData(chkSatinalma, projeStokKartFilter.stokKart, nameof(projeStokKartFilter.stokKart.isSatinalma));
            await universalGrid1.SetData(projeStokKartDTOs, this.Name, true);
        }

        private async Task GridDoldur()
        {
            if (projeStokKartFilter.proje.Id == null || projeStokKartFilter.proje.Id==-1) return;
            this.Enabled = false;
            _cache.stokKartList.Clear();
            projeStokKartDTOs.Clear();
            string jsonResult = await _projeService.GetProjeStokKart(projeStokKartFilter);
            if (String.IsNullOrEmpty(jsonResult) || jsonResult.Contains("error", StringComparison.OrdinalIgnoreCase))
            {
                projeStokKartDTOs = null;
            }
            else
            {
                List<ProjeStokKart> projeStokKarts = JsonConvert.DeserializeObject<List<ProjeStokKart>>(jsonResult);
                foreach (var psk in projeStokKarts)
                {
                    _cache.stokKartList.Add(psk.stokKart);
                    projeStokKartDTOs.Add(ConvertHelper.ToDTO<ProjeStokKartDTO>(psk));
                }
            }
            await universalGrid1.SetData(projeStokKartDTOs, this.Name, true);
            this.Enabled = true;
        }
        private async Task GridYenile()
        {
            try
            {
                bool isValid = ValidationFilterFields();

                if (!isValid)
                {
                    return;
                }
                this.Enabled = false;
                ProjeStokKartDTO projeStokKartDTO = ConvertHelper.ToDTO<ProjeStokKartDTO>(projeStokKartFilter);
                await universalGrid1.Filtrele(projeStokKartDTO);
                this.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Enabled = true;
            }
        }
        private void projeKod_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridDoldur();
        }
        private async Task parcaGrubu_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxListFill.GetLookupAd(_cache.malzemeGrups.Where(c => c.stokGrup.Id.ToString() == JsonConvert.SerializeObject(clbStokGrup.SelectedValue)).ToList(), ref clbMalzemeGrup);
            await GridYenile();
        }
        private async Task parcaAltGrubu_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxListFill.GetLookupAd(_cache.malzemeAltGrups.Where(c => c.malzemeGrup.Id.ToString() == JsonConvert.SerializeObject(clbMalzemeGrup.SelectedValue)).ToList(), ref clbMalzemeAltGrup);
            await GridYenile();
        }
        private async Task parcaAdi_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                await GridYenile();
            }
        }
        private async Task chkSatinalma_CheckedChanged(object sender, EventArgs e)
        {
            chkSatinalma.DataBindings["CheckState"].WriteValue();
            await GridYenile();
        }
        private async Task chkPdf_CheckStateChanged(object sender, EventArgs e)
        {
            chkPdf.DataBindings["CheckState"].WriteValue();
            if (chkPdf.CheckState == CheckState.Checked)
            {
                chkPdf.Text = "PDF Dosyası Olanlar";
            }
            else if (chkPdf.CheckState == CheckState.Unchecked)
            {
                chkPdf.Text = "PDF Dosyası Olmayanlar";
            }
            else if (chkPdf.CheckState == CheckState.Indeterminate)
            {
                chkPdf.Text = "PDF";
            }
            await GridYenile();
        }
        private async Task chkStep_CheckedChanged(object sender, EventArgs e)
        {
            chkStep.DataBindings["CheckState"].WriteValue();
            await GridYenile();
        }
        private void roundedButton4_Click(object sender, EventArgs e)
        {
            bool result = true;
            if (result) CreateSatinalmaTalep(sender, e);
        }
        private void CreateSatinalmaTalep(object sender, EventArgs e)
        {
            var talepList = universalGrid1.GetCheckedRows<ProjeStokKartDTO>();
            if (ValidateForm(talepList))
            {
                List<SatinalmaTalepDetay> satinalmaTalepDetayList = new List<SatinalmaTalepDetay>();
                foreach (var item in talepList)
                {
                    item.Id = null; //projestokKartId satinalmaTalepDetayId olarak aktarılmaması için null yapılıyor
                    SatinalmaTalepDetay satinalmaTalepdetay = new SatinalmaTalepDetay { proje = { Id = int.TryParse(fcbProjeKod.SelectedValue.ToString(), out int proje) ? proje : null } };
                    SatinalmaTalepSatirDetayDTO satinalmaTalepSatirDetay = new SatinalmaTalepSatirDetayDTO();
                    // Eğer stok kartının hammaddeId'si varsa, ve lazer grubuna ait parça değilse satınalma talep detay listesine hammadde olarak ekle
                    if (item.stokKarthammaddeId != null && item.stokKartmalzemeGrupId!=28)
                    {
                        //Hammadde ise ve listeye daha önce eklenmiş mi kontrol et, eklenmişse miktarını güncelle
                        if (satinalmaTalepDetayList.Any(x => x.stokKart.Id == item.stokKarthammaddeId))
                        {
                            satinalmaTalepdetay = satinalmaTalepDetayList.FirstOrDefault(x => x.stokKart.Id == item.stokKarthammaddeId);
                            if (item.stokKarthammaddeolcuBirimId == 2)
                            {
                                satinalmaTalepdetay.miktar += item.miktar * item.stokKartagirlik;
                            }
                            else
                            {
                                satinalmaTalepdetay.miktar += item.miktar;
                            }
                            satinalmaTalepdetay.agirlik += item.miktar * item.stokKartagirlik;
                            
                            satinalmaTalepdetay.satinalmaTalepSatirDetays.Add(
                                ConvertHelper.ToEntity<SatinalmaTalepSatirDetay>(item));
                        }
                        // Eğer hammadde olarak eklenmemişse, yeni bir hammadde olarak ekle
                        else
                        {
                            if (satinalmaTalepdetay.stokKart.hammadde.olcuBirim.Id == 2)
                            {
                                satinalmaTalepdetay.miktar = item.miktar * item.stokKartagirlik;
                            }
                            else
                            {
                                satinalmaTalepdetay.miktar = item.miktar;
                            }
                            satinalmaTalepdetay.agirlik = item.miktar * item.stokKartagirlik;
                            satinalmaTalepdetay.satinalmaTalepSatirDetays.Add(ConvertHelper.ToEntity<SatinalmaTalepSatirDetay>(item));
                            satinalmaTalepdetay.stokKart = JsonConvert.DeserializeObject<StokKart>(
                                JsonConvert.SerializeObject(ConvertHelper.ToEntity<ProjeStokKart>(item).stokKart.hammadde));
                            //satinalmaTalepdetay.stokKart.Id = item.stokKarthammaddeId;
                            //satinalmaTalepdetay.stokKart.kod = item.stokKarthammaddekod;
                            //satinalmaTalepdetay.stokKart.ad = item.stokKarthammaddead;
                            satinalmaTalepDetayList.Add(satinalmaTalepdetay);
                        }
                    }
                    // Eğer stok kartının hammaddeId'si yoksa, satınalma talep detay listesine normal stok kartı olarak ekle
                    else
                    {
                        satinalmaTalepdetay = ConvertHelper.ToEntity<SatinalmaTalepDetay>(item);
                        satinalmaTalepdetay.miktar = item.miktar;
                        satinalmaTalepdetay.agirlik = item.miktar * item.stokKartagirlik;
                        satinalmaTalepDetayList.Add(satinalmaTalepdetay);
                    }
                }
                SatinalmaTalep satinalmaTalep = new SatinalmaTalep
                {
                    proje = { Id = int.TryParse(fcbProjeKod.SelectedValue.ToString(), out int projeId) ? projeId : null },
                    //malzemeGrup = new MalzemeGrup { Id = int.TryParse(clbMalzemeGrup.SelectedValue.ToString(), out int malzemegrupId) ? malzemegrupId : null },
                    talepTarihi = DateTime.Today,
                    teslimTarihi = null,
                    aciklama = "Otomatik oluşturulan satınalma talebi",
                    talepEdenKullanici = _cache.kullanici,
                    satinalmaTalepDetays = satinalmaTalepDetayList
                };
                SatinalmaTalepKayitFormu satinalmaTalepKayitFormu = FormFactory.CreateForm<SatinalmaTalepKayitFormu>();
                satinalmaTalepKayitFormu.UpdateMode(satinalmaTalep);
                satinalmaTalepKayitFormu.ShowDialog();
            }
        }
        private bool ValidateForm(List<ProjeStokKartDTO> stokKarts)
        {
            // Formdaki gerekli alanların dolu olup olmadığını kontrol et
            if (!stokKarts.Any())
            {
                MessageBox.Show("Satınalma talebi oluşturulacak satırlar seçilmelidir.");
                return false;
            }
            if (stokKarts.Any(x => x.stokKartisPdf == false))
            {
                MessageBox.Show("PDF dosyası olmayan kayıtlar seçilemez.");
                return false;
            }
            if (stokKarts.Any(x => x.stokKartisDxf == false))
            {
                MessageBox.Show("DXF dosyası olmayan kayıtlar seçilemez.");
                return false;
            }
            if (stokKarts.Any(x => x.stokKartisStep == false))
            {
                DialogResult dialogResult = MessageBox.Show("STEP dosyası olmayan kayıtlar var devam edilsin mi?", "STEP Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.No)
                {
                    return false;
                }
            }
            if (stokKarts.Any(x => x.stokKartisSatinalma == true))
            {
                DialogResult dialogResult = MessageBox.Show("Satınalma talebi açılmış kayıtlar seçildi. Devam etmek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.No)
                {
                    return false;
                }
            }
            return true;
        }
        private void stokKartınıGörüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var projeStokKartDTO = (ProjeStokKartDTO)universalGrid1.Grid.CurrentRow.DataBoundItem;
            ProjeStokKart projeStokKart = ConvertHelper.ToEntity<ProjeStokKart>(projeStokKartDTO);
            StokKartKayitFormu stokKartKayitFormu = FormFactory.CreateForm<StokKartKayitFormu>();
            stokKartKayitFormu.UpdateMode(projeStokKart);
            stokKartKayitFormu.ShowDialog();
        }
        private async Task cbxMalzemeAltGrup_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxListFill.GetLookupAd(_cache.malzemeAltGrup2List.Where(c => c.malzemeAltGrup.Id.ToString() == JsonConvert.SerializeObject(clbMalzemeAltGrup.SelectedValue)).ToList(), ref clbMalzemeAltGrup2);
            await GridYenile();
        }
        private async Task cbxMalzemeAltGrup2_SelectedIndexChanged(object sender, EventArgs e)
        {
            await GridYenile();
        }
        private async Task textBoxParcaAdi_TextChanged(object sender, EventArgs e)
        {
            await GridYenile();
        }
        private void roundedIconButton1_Click(object sender, EventArgs e)
        {
            ExceldenVeriAlmaFormu exceldenVeriAlmaFormu = FormFactory.CreateForm<ExceldenVeriAlmaFormu>();
            exceldenVeriAlmaFormu.FormClosedWithData += async (s, args) =>
            {
                fcbProjeKod.SelectedValue = args.Veri;
                await GridDoldur();
            };
            exceldenVeriAlmaFormu.ShowDialog();
        }


        private async Task ProjeDosyalari_FormClosing(object sender, FormClosingEventArgs e)
        {
            await universalGrid1.SaveSettings();
        }

        private bool ValidationFilterFields()
        {
            bool result = false;
            result = GlobalData.CheckField("", fcbProjeKod) || result;
            return result;
        }

        private async Task chkDxf_CheckedChanged(object sender, EventArgs e)
        {
            chkDxf.DataBindings["CheckState"].WriteValue();
            if (chkDxf.CheckState == CheckState.Checked)
            {
                chkDxf.Text = "DXF Dosyası Olanlar";
            }
            else if (chkDxf.CheckState == CheckState.Unchecked)
            {
                chkDxf.Text = "DXF Dosyası Olmayanlar";
            }
            else if (chkDxf.CheckState == CheckState.Indeterminate)
            {
                chkDxf.Text = "DXF";
            }
            await GridYenile();
        }

        private async Task roundedIconButton2_Click(object sender, EventArgs e)
        {
            if (fcbProjeKod.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen bir proje seçiniz.");
                return;
            }
            else
            {
                await GridDoldur();
            }
        }

        private void fcbProjeKod_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridDoldur();
        }

        private void universalGrid1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(universalGrid1.Grid, e.Location);
            }
        }

        private void seçiliKalemlerİçinSaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool result = true;
            result = GlobalData.CheckField("Stok grubu seçilmelidir", clbStokGrup) && result;
            result = GlobalData.CheckField("Malzeme grubu seçilmelidir", clbMalzemeGrup) && result;
            if (result) CreateSatinalmaTalep(sender, e);
        }
        

        private async Task seçilenKayıtlarıSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show($"Seçilen kayıtlar silinecektir. Onaylıyor musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                List<ProjeStokKartDTO> projeStokKartDTOs = universalGrid1.GetCheckedRows<ProjeStokKartDTO>();
                for (int i = 0; i < projeStokKartDTOs.Count; i++)
                {
                    var item = projeStokKartDTOs[i];
                    if (item.Id != null)
                    {
                        string jsonResult=await _projeService.DeleteProjeStokKart(ConvertHelper.ToEntity<ProjeStokKart>(item));
                        if (String.IsNullOrEmpty(jsonResult) || jsonResult.Contains("error", StringComparison.OrdinalIgnoreCase))
                        {
                            MessageBox.Show($"{item.stokKartkod} silinirken hata oluştu: {jsonResult}");
                            return;
                        }
                        else
                        {
                            universalGrid1.binding.Remove(item);
                        }
                    }
                }
            }
        }
    }
}