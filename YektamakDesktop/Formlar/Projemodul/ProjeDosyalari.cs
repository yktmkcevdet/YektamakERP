using ApiService.Interfaces;
using Models;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities.Implementations;
using Utilities.Interfaces;
using YektamakDesktop.Common;
using YektamakDesktop.CustomControls;
using YektamakDesktop.Formlar.Ortak;
using YektamakDesktop.Formlar.Stok;

namespace YektamakDesktop.Formlar.ProjeModul
{
    public partial class ProjeDosyalari : Form
    {
        private readonly ICache _cache;
        private readonly IProjeService _projeService;
        private readonly IFileService _fileService;
        private readonly IConvertHelper _convertHelper;
        private readonly ISatinalmaTalepHelper _satinalmaTalepHelper;
        public ProjeDosyalari(ICache cache, IProjeService projeService, IFileService fileService, IConvertHelper convertHelper, ISatinalmaTalepHelper satinalmaTalepHelper)
        {
            _cache = cache;
            _projeService = projeService;
            _fileService = fileService;
            _convertHelper = convertHelper;
            _satinalmaTalepHelper = satinalmaTalepHelper;
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
            fcbProjeKod.SelectedIndexChanged += async (s, e) => await fcbProjeKod_SelectedIndexChanged(s, e);
            fcbStokGrup.SelectedIndexChanged += async (s, e) => await fcbStokGrup_SelectedIndexChanged(s, e);
            fcbMalzemeGrup.SelectedIndexChanged += async (s, e) => await fcbMalzemeGrup_SelectedIndexChanged(s, e);
            fcbMalzemeAltGrup.SelectedIndexChanged += async (s, e) => await fcbMalzemeAltGrup_SelectedIndexChanged(s, e);
            fcbMalzemeAltGrup2.SelectedIndexChanged += async (s, e) => await fcbMalzemeAltGrup2_SelectedIndexChanged(s, e);
            ctbParcaKod.KeyDown += async (s, e) => await parcaAdi_KeyDown(s, e);
            ctbParcaAd.KeyDown += async (s, e) => await parcaAdi_KeyDown(s, e);
            chkSatinalma.CheckedChanged += async (s, e) => await chkPdf_CheckStateChanged(s, e);
            chkPdf.CheckStateChanged += async (s, e) => await chkPdf_CheckStateChanged(s, e);
            chkDxf.CheckStateChanged += async (s, e) => await chkDxf_CheckedChanged(s, e);
            chkStep.CheckStateChanged += async (s, e) => await chkStep_CheckedChanged(s, e);
            chkSatinalma.CheckStateChanged += async (s, e) => await chkSatinalma_CheckedChanged(s, e);
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
                if (columnName == "Stok Kart Kod")
                {
                    pdfPopup?.Close();
                    var projeStokKartDTO = (ProjeStokKartDTO)universalGrid1.Grid.Rows[e.RowIndex].DataBoundItem;
                    var projeStokKart = _convertHelper.ToEntity<ProjeStokKart>(projeStokKartDTO);
                    if (projeStokKart.stokKart.dosyaList.Any(d => d.dosyaTip.Id == 1))
                    {
                        string filePath = projeStokKart.stokKart.dosyaList.Where(d => d.dosyaTip.Id == 1).FirstOrDefault()?.dosyaFullPath;
                        var pdfBytes = await _fileService.GetFile(filePath);
                        pdfPopup.GetInstance(pdfBytes);
                        pdfPopup.FormBorderStyle = FormBorderStyle.None;
                        pdfPopup.StartPosition = FormStartPosition.Manual;
                        pdfPopup.Size = new Size(400, 300);

                        Point mousePos = Cursor.Position;
                        pdfPopup.Location = new Point(mousePos.X + 20, mousePos.Y + 20);
                        pdfPopup.Show();
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
            fcbProjeKod.SetDataSource(_cache.projeList.Where(x => x.sorumluList.Where(s => s.personel.Id == _cache.kullanici.personel.Id).Count() > 0).ToList());
            fcbStokGrup.SetDataSource(_cache.stokGrups);
            await Binding();
        }

        private async Task Binding()
        {
            BindHelper.BindData(fcbProjeKod, projeStokKartFilter.proje, nameof(projeStokKartFilter.proje.Id));
            BindHelper.BindData(fcbStokTip, projeStokKartFilter.stokKart.stokTip, nameof(projeStokKartFilter.stokKart.stokTip.Id));
            BindHelper.BindData(fcbMalzemeGrup, projeStokKartFilter.stokKart.malzemeGrup, nameof(projeStokKartFilter.stokKart.malzemeGrup.Id));
            BindHelper.BindData(fcbStokGrup, projeStokKartFilter.stokKart.stokGrup, nameof(projeStokKartFilter.stokKart.stokGrup.Id));
            BindHelper.BindData(fcbMalzemeAltGrup, projeStokKartFilter.stokKart.malzemeAltGrup, nameof(projeStokKartFilter.stokKart.malzemeAltGrup.Id));
            BindHelper.BindData(chkPdf, projeStokKartFilter.stokKart, nameof(projeStokKartFilter.stokKart.isPdf));
            BindHelper.BindData(chkDxf, projeStokKartFilter.stokKart, nameof(projeStokKartFilter.stokKart.isDxf));
            BindHelper.BindData(chkStep, projeStokKartFilter.stokKart, nameof(projeStokKartFilter.stokKart.isStep));
            BindHelper.BindData(chkSatinalma, projeStokKartFilter.stokKart, nameof(projeStokKartFilter.stokKart.isSatinalma));
            BindHelper.BindData(ctbParcaKod, projeStokKartFilter.stokKart, nameof(projeStokKartFilter.stokKart.kod));
            BindHelper.BindData(ctbParcaAd, projeStokKartFilter.stokKart, nameof(projeStokKartFilter.stokKart.ad));
            await universalGrid1.SetData(projeStokKartDTOs, this.Name, true);
        }

        private async Task GridDoldur()
        {
            if (projeStokKartFilter.proje.Id == null || projeStokKartFilter.proje.Id == -1) return;
            this.Enabled = false;

            List<ProjeStokKart> projeStokKarts = await _projeService.GetProjeStokKart(projeStokKartFilter);
            projeStokKartDTOs = projeStokKarts.CastToDTO<ProjeStokKartDTO>(_convertHelper).ToList();
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
                ProjeStokKartDTO projeStokKartDTO = _convertHelper.ToDTO<ProjeStokKartDTO>(projeStokKartFilter);
                await universalGrid1.Filtrele(projeStokKartDTO);
                this.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Enabled = true;
            }
        }
        private async Task fcbStokGrup_SelectedIndexChanged(object sender, EventArgs e)
        {
            await GridYenile();
            fcbMalzemeGrup.SetDataSource(_cache.malzemeGrups.Where(mg => mg.stokGrup.Id == Convert.ToInt32(fcbStokGrup.SelectedValue.ToString())).ToList());
        }
        private async Task fcbMalzemeGrup_SelectedIndexChanged(object sender, EventArgs e)
        {
            await GridYenile();
            fcbMalzemeAltGrup.SetDataSource(_cache.malzemeAltGrups.Where(mag => mag.malzemeGrup.Id == Convert.ToInt32(fcbMalzemeGrup.SelectedValue.ToString())).ToList());
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
            var talepList = universalGrid1.GetCheckedRows<ProjeStokKartDTO>();
            Proje proje = new Proje { Id = int.TryParse(fcbProjeKod.SelectedValue.ToString(), out int projeId) ? projeId : null };
            MalzemeGrup malzemeGrup = new MalzemeGrup { Id = int.TryParse(fcbMalzemeGrup.SelectedValue.ToString(), out int malzemeGrupId) ? malzemeGrupId : null };
            if (result) _satinalmaTalepHelper.CreateSatinalmaTalep(talepList,proje,malzemeGrup);
        }
        private void stokKartınıGörüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var projeStokKartDTO = (ProjeStokKartDTO)universalGrid1.Grid.CurrentRow.DataBoundItem;
            ProjeStokKart projeStokKart = _convertHelper.ToEntity<ProjeStokKart>(projeStokKartDTO);
            StokKartKayitFormu stokKartKayitFormu = FormFactory.CreateForm<StokKartKayitFormu>();
            stokKartKayitFormu.AfterSave += StokKartKayitFormu_AfterSave;
            stokKartKayitFormu.UpdateMode(projeStokKart);
            stokKartKayitFormu.ShowDialog();
        }

        private void StokKartKayitFormu_AfterSave(object sender, object e)
        {
            var index = universalGrid1.Grid.CurrentRow.Index;
            var liste = (BindingList<ProjeStokKartDTO>)universalGrid1.binding.DataSource;
            if (liste[index] == null)
            {
                liste.Add(_convertHelper.ToDTO<ProjeStokKartDTO>((ProjeStokKart)e));
            }
        }

        private async Task fcbMalzemeAltGrup_SelectedIndexChanged(object sender, EventArgs e)
        {
            await GridYenile();
            fcbMalzemeAltGrup2.SetDataSource(_cache.malzemeAltGrup2List.Where(mag2 => mag2.malzemeAltGrup.Id == Convert.ToInt32(fcbMalzemeAltGrup.SelectedValue.ToString())).ToList());
        }
        private async Task fcbMalzemeAltGrup2_SelectedIndexChanged(object sender, EventArgs e)
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
            result = CheckFieldHelper.CheckField("", fcbProjeKod) || result;
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
            result = CheckFieldHelper.CheckField("Stok grubu seçilmelidir", fcbStokGrup) && result;
            result = CheckFieldHelper.CheckField("Malzeme grubu seçilmelidir", fcbMalzemeGrup) && result;
            var talepList = universalGrid1.GetCheckedRows<ProjeStokKartDTO>();
            Proje proje = new Proje { Id = int.TryParse(fcbProjeKod.SelectedValue.ToString(), out int projeId) ? projeId : null };
            MalzemeGrup malzemeGrup = new MalzemeGrup { Id = int.TryParse(fcbMalzemeGrup.SelectedValue.ToString(), out int malzemeGrupId) ? malzemeGrupId : null };
            if (result) _satinalmaTalepHelper.CreateSatinalmaTalep(talepList, proje, malzemeGrup);
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
                        string jsonResult = await _projeService.DeleteProjeStokKart(_convertHelper.ToEntity<ProjeStokKart>(item));
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

    }
}