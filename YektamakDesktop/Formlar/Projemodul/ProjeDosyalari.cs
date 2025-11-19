using ApiService.Interfaces;
using Models;
using Models.DTO;
using Models.Models.Stok;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities.Interfaces;
using YektamakDesktop.Common;
using YektamakDesktop.CustomControls;
using YektamakDesktop.Formlar.Ortak;
using YektamakDesktop.Formlar.Satinalma;
using YektamakDesktop.Formlar.Stok;

namespace YektamakDesktop.Formlar.ProjeModul
{
    public partial class ProjeDosyalari : Form
    {
        private readonly ICache _cache;
        private readonly IJsonConverter _jsonConverter;
        private readonly IProjeService _projeService;
        private readonly IStokService _stokService;
        private readonly IFileHelper _fileHelper;
        private readonly IFileService _fileService;
        public ProjeDosyalari(ICache cache, IJsonConverter jsonConvertHelper, IProjeService projeService, IStokService stokService, IFileHelper fileHelper, IFileService fileService)
        {
            _fileHelper = fileHelper;
            _cache = cache;
            _jsonConverter = jsonConvertHelper;
            _projeService = projeService;
            _stokService = stokService;
            _fileService = fileService;
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
            universalGrid1.Location = new Point(locationX, locationY);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new Size(sizeX, sizeY);
            universalGrid1.TabIndex = 13;
            Controls.Add(universalGrid1);
            universalGrid1.MouseDown1 += universalGrid1_MouseClick;
            fcbStokTip.SetDataSource(_cache.stokTips);
            Load += async (s, e) => await form_Load(s, e);
            fcbProjeKod.SelectedIndexChanged += async(s,e)=>await fcbProjeKod_SelectedIndexChanged(s,e);
            clbStokGrup.SelectedIndexChanged += async (s, e) => await parcaGrubu_SelectedIndexChanged(s, e);
            clbMalzemeGrup.SelectedIndexChanged += async (s, e) => await parcaAltGrubu_SelectedIndexChanged(s, e);
            ctbParcaKod.KeyDown += async (s, e) => await parcaAdi_KeyDown(s, e);
            ctbParcaAd.KeyDown += async (s, e) => await parcaAdi_KeyDown(s, e);
            chkSatinalma.CheckedChanged += async (s, e) => await chkPdf_CheckStateChanged(s, e);
            chkPdf.CheckStateChanged += async (s, e) => await chkPdf_CheckStateChanged(s, e);
            chkDxf.CheckStateChanged += async (s, e) => await chkDxf_CheckedChanged(s, e);
            chkStep.CheckStateChanged += async (s, e) => await chkStep_CheckedChanged(s, e);
            chkSatinalma.CheckStateChanged += async (s, e) => await chkSatinalma_CheckedChanged(s, e);
            clbMalzemeAltGrup.SelectedIndexChanged += async (s, e) => await cbxMalzemeAltGrup_SelectedIndexChanged(s, e);
            clbMalzemeAltGrup2.SelectedIndexChanged += async (s, e) => await cbxMalzemeAltGrup2_SelectedIndexChanged(s, e);
            FormClosing += async (s, e) => await ProjeDosyalari_FormClosing(s, e);
            seçilenKayıtlarıSilToolStripMenuItem.Click += async (s, e) => await seçilenKayıtlarıSilToolStripMenuItem_Click(s, e);
            universalGrid1.Grid.CellMouseEnter += Grid_CellMouseEnter;
            universalGrid1.Grid.CellMouseLeave += Grid_CellMouseLeave;

        }
        private PdfGoruntuleme _pdfPopup;
        private PdfGoruntuleme pdfPopup
        {
            get { if (_pdfPopup == null || _pdfPopup.IsDisposed) { _pdfPopup = FormFactory.CreateForm<PdfGoruntuleme>(); } return _pdfPopup; }
            set { _pdfPopup = value; }
        }
        
        private void Grid_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            pdfPopup?.Close();
        }

        private async void Grid_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string columnName = universalGrid1.Grid.Columns[e.ColumnIndex].Name;

                // Sadece istediğin sütun için popup aç
                if (columnName == "Stok Kart Kod")
                {
                    pdfPopup?.Close();
                    var projeStokKartDTO = (ProjeStokKartDTO)universalGrid1.Grid.Rows[e.RowIndex].DataBoundItem;
                    var projeStokKart = ConvertHelper.ToEntity<ProjeStokKart>(projeStokKartDTO);
                    //string jsonResult = _stokService.GetStokKartPdf(projeStokKart.stokKart);
                    //var stokKartPdf = JsonConvert.DeserializeObject<List<StokKart>>(jsonResult)[0];
                    if (projeStokKart.stokKart.dosyaList.Any(d => d.dosyaTip.Id == 1))
                    {
                        //string pdfBytes = Convert.ToBase64String(stokKartPdf.dosyaList.Where(d => d.dosyaTip.Id == 1).FirstOrDefault()?.dosya);
                        string filePath = projeStokKart.stokKart.dosyaList.Where(d => d.dosyaTip.Id == 1).FirstOrDefault()?.dosyaFullPath;
                        var pdfBytes = await _fileService.GetFile(filePath);
                        pdfPopup.GetInstance(pdfBytes);
                        pdfPopup.FormBorderStyle = FormBorderStyle.None;
                        pdfPopup.StartPosition = FormStartPosition.Manual;
                        pdfPopup.Size = new Size(400, 300);

                        Point mousePos = Cursor.Position;
                        pdfPopup.Location = new Point(mousePos.X + 20, mousePos.Y + 20);
                        pdfPopup.Show();
                        //pdfPopup = _pdfPopup;
                    }
                }
            }
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
            fcbProjeKod.SetDataSource(_cache.projes.Where(x => x.personel.Id == _cache.kullanici.personel.Id).ToList());
            clbStokGrup.SetDataSource(_cache.stokGrups);
            await Binding();
        }

        private async Task Binding()
        {
            BindHelper.BindData(fcbProjeKod, projeStokKartFilter.proje, nameof(projeStokKartFilter.proje.Id));
            BindHelper.BindData(fcbStokTip, projeStokKartFilter.stokKart.stokTip, nameof(projeStokKartFilter.stokKart.stokTip.Id));
            BindHelper.BindData(clbMalzemeGrup, projeStokKartFilter.stokKart.malzemeGrup, nameof(projeStokKartFilter.stokKart.malzemeGrup.Id));
            BindHelper.BindData(clbStokGrup, projeStokKartFilter.stokKart.stokGrup, nameof(projeStokKartFilter.stokKart.stokGrup.Id));
            BindHelper.BindData(clbMalzemeAltGrup, projeStokKartFilter.stokKart.malzemeAltGrup, nameof(projeStokKartFilter.stokKart.malzemeAltGrup.Id));
            BindHelper.BindData(chkPdf, projeStokKartFilter.stokKart, nameof(projeStokKartFilter.stokKart.isPdf));
            BindHelper.BindData(chkDxf, projeStokKartFilter.stokKart, nameof(projeStokKartFilter.stokKart.isDxf));
            BindHelper.BindData(chkStep, projeStokKartFilter.stokKart, nameof(projeStokKartFilter.stokKart.isStep));
            BindHelper.BindData(chkSatinalma, projeStokKartFilter.stokKart, nameof(projeStokKartFilter.stokKart.isSatinalma));
            BindHelper.BindData(ctbParcaKod, projeStokKartFilter.stokKart, nameof(projeStokKartFilter.stokKart.kod));
            BindHelper.BindData(ctbParcaAd, projeStokKartFilter.stokKart, nameof(projeStokKartFilter.stokKart.ad));
            await universalGrid1.SetData(projeStokKartDTOs, this.Name,true);
        }

        private async Task GridDoldur()
        {
            if (projeStokKartFilter.proje.Id == null || projeStokKartFilter.proje.Id == -1) return;
            this.Enabled = false;
            
            List<ProjeStokKart> projeStokKarts = await _projeService.GetProjeStokKart(projeStokKartFilter);
            projeStokKartDTOs = projeStokKarts.CastToDTO<ProjeStokKartDTO>().ToList();
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
        private async Task parcaAdi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                chkPdf.Focus();
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
        private async void CreateSatinalmaTalep(object sender, EventArgs e)
        {
            var talepList = universalGrid1.GetCheckedRows<ProjeStokKartDTO>(); 
            if (ValidateForm(talepList))
            {
                List<SatinalmaTalepDetay> satinalmaTalepDetayList = new List<SatinalmaTalepDetay>();
                foreach (var item in talepList)
                {
                    //item.Id = null; //projestokKartId satinalmaTalepDetayId olarak aktarılmaması için null yapılıyor
                    SatinalmaTalepDetay satinalmaTalepdetay = new SatinalmaTalepDetay { proje = { Id = int.TryParse(fcbProjeKod.SelectedValue.ToString(), out int proje) ? proje : null } };
                    SatinalmaTalepSatirDetayDTO satinalmaTalepSatirDetay = new SatinalmaTalepSatirDetayDTO();
                    // Eğer stok kartının hammaddeId'si varsa, ve lazer grubuna ait parça değilse satınalma talep detay listesine hammadde olarak ekle
                    if (item.stokKarthammaddeId != null && item.stokKartmalzemeGrupId != 28)
                    {
                        //Hammadde ise ve listeye daha önce eklenmiş mi kontrol et, eklenmişse miktarını güncelle
                        if (satinalmaTalepDetayList.Any(x => x.projeStokKart.stokKart.Id == item.stokKarthammaddeId))
                        {
                            satinalmaTalepdetay = satinalmaTalepDetayList.FirstOrDefault(x => x.projeStokKart.stokKart.Id == item.stokKarthammaddeId);
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
                                new SatinalmaTalepSatirDetay { projeStokKart = ConvertHelper.ToEntity<ProjeStokKart>(item) });
                        }
                        // Eğer hammadde olarak eklenmemişse, yeni bir hammadde olarak ekle
                        else
                        {
                            if (satinalmaTalepdetay.projeStokKart.stokKart.hammadde.olcuBirim.Id == 2)
                            {
                                satinalmaTalepdetay.miktar = item.miktar * item.stokKartagirlik;
                            }
                            else
                            {
                                satinalmaTalepdetay.miktar = item.miktar;
                            }
                            satinalmaTalepdetay.projeStokKart = new ProjeStokKart
                            {
                                stokKart = new StokKart { Id = item.stokKarthammaddeId }
                            };
                            satinalmaTalepdetay.agirlik = item.miktar * item.stokKartagirlik;
                            satinalmaTalepdetay.satinalmaTalepSatirDetays.Add(new SatinalmaTalepSatirDetay { projeStokKart = ConvertHelper.ToEntity<ProjeStokKart>(item) });
                            satinalmaTalepdetay.projeStokKart = (await _projeService.GetProjeStokKart(new ProjeStokKart
                                                                        {
                                                                            //proje = { Id = Convert.ToInt32(fcbProjeKod.SelectedValue) },
                                                                            stokKart = new StokKart { Id = item.stokKarthammaddeId }
                                                                        })).FirstOrDefault();
                            satinalmaTalepDetayList.Add(satinalmaTalepdetay);
                        }
                    }
                    // Eğer stok kartının hammaddeId'si yoksa, satınalma talep detay listesine normal stok kartı olarak ekle
                    else
                    {
                        satinalmaTalepdetay = new SatinalmaTalepDetay { projeStokKart =  ConvertHelper.ToEntity<ProjeStokKart>(item) } ;
                        satinalmaTalepdetay.miktar = item.miktar;
                        satinalmaTalepdetay.onaylananMiktar = item.miktar;
                        satinalmaTalepdetay.agirlik = item.miktar * item.stokKartagirlik;
                        satinalmaTalepDetayList.Add(satinalmaTalepdetay);
                    }
                }
                if(clbMalzemeGrup.SelectedValue.ToString() == "29")
                {
                    var profilGroups = talepList.GroupBy(t => new { t.stokKarthammaddeId }).Select(group => group.First()).ToList();
                    foreach(var profilGroup in profilGroups)
                    {
                        var profilList = talepList.Where(t => t.stokKarthammaddeId == profilGroup.stokKarthammaddeId).ToList();
                        var sonuc = OptimizedCutting(profilList,Convert.ToDouble(profilGroup.stokKarthammaddeuzunluk),2);
                        satinalmaTalepDetayList.Where(s=> s.projeStokKart.stokKart.Id == profilGroup.stokKarthammaddeId).FirstOrDefault().miktar = sonuc.Bins.Count;
                        foreach(var b in sonuc.Bins)
                        {
                            var fire = profilGroup.stokKarthammaddeuzunluk - b.Sum(x=>x.projeStokKart.stokKart.uzunluk);
                        }
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
            stokKartKayitFormu.AfterSave += StokKartKayitFormu_AfterSave;
            stokKartKayitFormu.UpdateMode(projeStokKart);
            stokKartKayitFormu.ShowDialog();
        }

        private void StokKartKayitFormu_AfterSave(object sender, object e)
        {
            var index = universalGrid1.Grid.CurrentRow.Index;
            var liste = (BindingList<ProjeStokKartDTO>)universalGrid1.Grid.DataSource;
            if (liste[index] == null)
            {
                liste.Add(ConvertHelper.ToDTO<ProjeStokKartDTO>((ProjeStokKart)e));
            }
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
            exceldenVeriAlmaFormu.FormClosedWithData += (s, args) =>
            {
                fcbProjeKod.SelectedValue = null;
                fcbProjeKod.SelectedValue = args.Veri;
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

        private async Task fcbProjeKod_SelectedIndexChanged(object sender, EventArgs e)
        {
           await GridDoldur();
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
                        string jsonResult = await _projeService.DeleteProjeStokKart(ConvertHelper.ToEntity<ProjeStokKart>(item));
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

        private async void fcbStokTip_SelectedIndexChanged(object sender, EventArgs e)
        {
            await GridYenile();
        }

        public CuttingOptimizationResult OptimizedCutting(
            List<ProjeStokKartDTO> items,
            double stockLength,
            int kerf,
            double usableWasteMinLength = 0) // Minimum kullanılabilir fire uzunluğu
        {
            // 1) Tüm parçaları adetlerine göre aç
            var allPieces = new List<SatinalmaTalepDetay>();
            foreach (var item in items)
            {
                for (int i = 0; i < item.miktar; i++)
                {
                    allPieces.Add(new SatinalmaTalepDetay { miktar=item.miktar,projeStokKart =  ConvertHelper.ToEntity<ProjeStokKart>(item) });
                }
            }

            // 2) Parçaları boydan küçüğe sırala
            var sorted = allPieces.OrderByDescending(x => x.projeStokKart.stokKart.uzunluk).ToList();

            // Bin sınıfı - her stoğun durumunu takip eder
            var bins = new List<BinInfo>();

            // 3) Best Fit Decreasing ile yerleştirme
            foreach (var piece in sorted)
            {
                BinInfo bestBin = null;
                double bestRemainingSpace = double.MaxValue;

                // Mevcut stoklarda en uygun yeri bul
                foreach (var bin in bins)
                {
                    double requiredSpace = piece.projeStokKart.stokKart.uzunluk.Value + (bin.Pieces.Count > 0 ? kerf : 0);
                    double remainingSpace = bin.RemainingSpace - requiredSpace;

                    // Parça sığıyor mu?
                    if (remainingSpace >= 0)
                    {
                        // En az fire bırakacak stoğu seç
                        if (remainingSpace < bestRemainingSpace)
                        {
                            bestRemainingSpace = remainingSpace;
                            bestBin = bin;
                        }
                    }
                }

                // Uygun stok bulunduysa yerleştir
                if (bestBin != null)
                {
                    bestBin.AddPiece(piece, kerf);
                }
                else
                {
                    // Yeni stok aç
                    var newBin = new BinInfo(stockLength);
                    newBin.AddPiece(piece, kerf);
                    bins.Add(newBin);
                }
            }

            // 4) İkinci geçiş: Küçük parçaları fire alanlarına yerleştirmeye çalış
            if (usableWasteMinLength > 0)
            {
                OptimizeWithWasteReuse(bins, sorted, kerf, usableWasteMinLength);
            }

            // 5) Sonuçları hesapla
            var result = new CuttingOptimizationResult
            {
                Bins = bins.Select(b => b.Pieces).ToList(),
                TotalStocksUsed = bins.Count,
                TotalWaste = bins.Sum(b => b.RemainingSpace),
                UsableWaste = bins.Count(b => b.RemainingSpace >= usableWasteMinLength) * usableWasteMinLength,
                WastePercentage = (bins.Sum(b => b.RemainingSpace) / (bins.Count * stockLength)) * 100
            };

            return result;
        }
        // İkinci geçiş optimizasyonu: Fire alanlarını kullan
        private void OptimizeWithWasteReuse(
            List<BinInfo> bins,
            List<SatinalmaTalepDetay> allPieces,
            int kerf,
            double usableWasteMinLength)
        {
            // Fire alanlarını büyükten küçüğe sırala
            var binsWithUsableWaste = bins
                .Where(b => b.RemainingSpace >= usableWasteMinLength)
                .OrderByDescending(b => b.RemainingSpace)
                .ToList();

            // Kullanılmayan küçük parçaları bul
            var unusedSmallPieces = allPieces
                .Where(p => p.projeStokKart.stokKart.uzunluk <= usableWasteMinLength)
                .OrderByDescending(p => p.projeStokKart.stokKart.uzunluk)
                .ToList();

            foreach (var wasteBin in binsWithUsableWaste)
            {
                foreach (var smallPiece in unusedSmallPieces.ToList())
                {
                    double requiredSpace = smallPiece.projeStokKart.stokKart.uzunluk.Value + kerf;
                    if (wasteBin.RemainingSpace >= requiredSpace)
                    {
                        // Not: Gerçek uygulamada bu parçanın başka bir bin'den çıkarılması gerekebilir
                        // Bu basitleştirilmiş versiyon sadece konsepti gösteriyor
                    }
                }
            }
        }
    }
}