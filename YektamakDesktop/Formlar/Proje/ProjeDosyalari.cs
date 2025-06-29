using ApiService.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities.Interfaces;
using YektamakDesktop.Common;
using YektamakDesktop.Formlar.Ortak;
using YektamakDesktop.Formlar.Satinalma;
using YektamakDesktop.Formlar.Stok;

namespace YektamakDesktop.Formlar.Proje
{
    public partial class ProjeDosyalari : Form, IForm, IGridForm<StokKart>
    {
        private static ICache _cache;
        private static IJsonConverter _jsonConvertHelper;
        private static IDataTableMapper _dataTableHelper;
        private static IStokService _stokService;
        private static ProjeDosyalari _projeDosyalari;
        public static ProjeDosyalari projeDosyalari
        {
            get
            {
                if (_projeDosyalari == null)
                {
                    _projeDosyalari = new ProjeDosyalari();
                    GlobalData.Yetki(ref _projeDosyalari);
                }
                return _projeDosyalari;
            }
        }

        private DataTable _dataTable;
        public async Task<DataTable> GetDataTableAsync()
        {
            if (_dataTable == null)
            {
                _dataTable = new DataTable();
                _dataTable.RowDeleted += dataTableRowChanged;
                _dataTable.RowChanged += dataTableRowChanged;
            }

            if (_dataTable.Rows.Count == 0)
            {
                _dataTable = await GlobalData.FillDataTableAsync(_stokService.GetStokKart, stokKartFilter);
            }

            return _dataTable;
        }
        private StokKart _stokKartFilter;
        private StokKart stokKartFilter
        {
            get
            {
                if (_stokKartFilter == null)
                {
                    _stokKartFilter = new StokKart();
                }
                if (_stokKartFilter.proje.Id == 0)
                {
                    _stokKartFilter.proje.Id = -1;
                }
                return _stokKartFilter;
            }
            set { _stokKartFilter = value; }
        }
        public List<Control> _controlsToDisable;
        public List<Control> controlsToDisable { get => _controlsToDisable; set => _controlsToDisable = value; }
        public bool _activeForm;
        public bool activeForm
        {
            get { return _activeForm; }
            set
            {
                if (value == true)
                {
                    //dataTable = GlobalData.FillDataTableAsync(_stokService.GetStokKart, stokKartFilter).Result;
                    //if (dataTable.Rows.Count > 0) DataRefresh();
                }
                _activeForm = value;
            }
        }
        private ProjeDosyalari()
        {
            InitializeComponent();
            controlsToDisable = new List<Control> { panelFilter, panelHeader };
            ComboBoxListFill.GetLookupKod(_cache.projes.Where(x => x.personel.Id == _cache.kullanici.personel.Id).ToList(), ref projeKodu);
            ComboBoxListFill.GetLookupAd(_cache.stokGrups, ref cbxStokGrup);
            ComboBoxListFill.GetLookupAd(_cache.malzemeGrups, ref cbxMalzemeGrup);
            ComboBoxListFill.GetLookupAd(_cache.malzemeAltGrups, ref cbxMalzemeAltGrup);
            ComboBoxListFill.GetLookupAd(_cache.malzemeAltGrup2List, ref cbxMalzemeAltGrup2);
        }
        public ProjeDosyalari(ICache cache, IJsonConverter jsonConvertHelper, IDataTableMapper dataTableHelper, IStokService stokService)
        {
            _cache = cache;
            _jsonConvertHelper = jsonConvertHelper;
            _dataTableHelper = dataTableHelper;
            _stokService = stokService;
        }
        #region mouseDrag
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
        #endregion mouseDrag
        public async void AddNewRow(StokKart stokKart)
        {
            await GetDataTableAsync();
            List<StokKart> stokKarts = new List<StokKart> { stokKart };
            _dataTable=ConvertHelper.ToDataTable(stokKarts);
        }

        public void buttomMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        public void buttonClose_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        public void buttonEkle_Click(object sender, EventArgs e)
        {
            StokKartKayitFormu stokKartTanimlamaFormu = StokKartKayitFormu.stokKartKayitFormu;
            if (stokKartTanimlamaFormu != null)
            {
                stokKartTanimlamaFormu.Show();
            }
        }

        public void buttonFiltre_Click(object sender, EventArgs e)
        {
            stokKartFilter.proje.Id = projeKodu.selectedDataRowId;
            DataRefresh();
        }

        public void buttonTumKayitlariGetir_Click(object sender, EventArgs e)
        {
            DataRefresh();
        }

        public void CloseForm()
        {
            GlobalData.CloseForm(ref _projeDosyalari);
        }

        public async void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            GlobalData.DataGridViewCellClick<CariKart>(ref _dataTable, dataGridViewStokKart, e);
            bool isClick = e.ColumnIndex == dataGridViewStokKart.Columns["pdf"].Index || e.ColumnIndex == dataGridViewStokKart.Columns["dxf"].Index || e.ColumnIndex == dataGridViewStokKart.Columns["step"].Index;
            bool isPdf = e.ColumnIndex == dataGridViewStokKart.Columns["pdf"].Index;
            bool isDxf = e.ColumnIndex == dataGridViewStokKart.Columns["dxf"].Index;
            bool isStep = e.ColumnIndex == dataGridViewStokKart.Columns["step"].Index;
            if (isClick)
            {
                StokKart stokKart = new StokKart();
                stokKart.Id = Convert.ToInt32(dataGridViewStokKart.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                string serializeString = await _stokService.GetStokKartPdf(stokKart);

                DataSet dataSet = _jsonConvertHelper.DeserializeToDataSet(serializeString);
                if (dataSet != null)
                {
                    foreach (DataRow dataRow in dataSet.Tables[0].Rows)
                    {
                        stokKart = _dataTableHelper.MapToEntity<StokKart>(dataRow);
                    }
                }
                if (isPdf)
                {
                    if (stokKart.isPdf == true)
                    {
                        string tempFilePath = Path.Combine(Path.GetTempPath(), stokKart.pdfFileName());
                        // Byte[]'i geçici bir dosyaya yaz
                        File.WriteAllBytes(tempFilePath, stokKart.pdf);
                        // WebBrowser kontrolünde göster


                        //Windows Formda Göster
                        PdfGoruntuleme pdfGoruntuleme = PdfGoruntuleme.pdfGoruntuleme;
                        pdfGoruntuleme.pdfFilePath = tempFilePath;
                        pdfGoruntuleme.ShowDialog();

                        //Varsayılan Uygulama ile Aç
                        //Process.Start(new ProcessStartInfo
                        //{
                        //    FileName = tempFilePath,
                        //    UseShellExecute = true
                        //});
                    }
                    else if (stokKart.isPdf == false)
                    {
                        MessageBox.Show("PDF dosyası bulunamadı.");
                    }
                }
                if (isDxf)
                {
                    if (stokKart.isDxf == true)
                    {
                        string tempFilePath = Path.Combine(Path.GetTempPath(), stokKart.dxfFileName());
                        // Byte[]'i geçici bir dosyaya yaz

                        File.WriteAllBytes(tempFilePath, stokKart.dxf);
                        // WebBrowser kontrolünde göster
                        //DxfViewer dxfViewer = new DxfViewer();
                        //dxfViewer.fileName = tempFilePath;
                        //dxfViewer.Show();
                        Process.Start(new ProcessStartInfo
                        {
                            FileName = tempFilePath,
                            UseShellExecute = true
                        });
                    }
                    else if (stokKart.isDxf == false)
                    {
                        MessageBox.Show("DXF dosyası bulunamadı.");
                    }
                }
                if (isStep)
                {
                    if (stokKart.isStep == true)
                    {
                        string tempFilePath = Path.Combine(Path.GetTempPath(), stokKart.stepFileName());
                        // Byte[]'i geçici bir dosyaya yaz
                        File.WriteAllBytes(tempFilePath, stokKart.step);
                        // WebBrowser kontrolünde göster
                        Process.Start(new ProcessStartInfo
                        {
                            FileName = tempFilePath,
                            UseShellExecute = true
                        });
                    }
                    else if (stokKart.isStep == false)
                    {
                        MessageBox.Show("STEP dosyası bulunamadı.");
                    }
                }

            }

        }

        public void dataGridView_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            GlobalData.ResizeFilterFields(dataGridViewStokKart, panelFilter);
        }
        int oldScrollOffset = 0;
        public void dataGridView_Scroll(object sender, ScrollEventArgs e)
        {
            GlobalData.AdjustControlsOnScroll(dataGridViewStokKart, panelFilter, e, ref oldScrollOffset);
        }

        public void dataTableRowChanged(object sender, DataRowChangeEventArgs e)
        {
            DataRefresh();
        }

        public void form_Load(object sender, EventArgs e)
        {
            //GlobalData.PlaceFilterFields(dataGridViewStokKart, panelFilter);


        }

        public void UpdateRow(StokKart stokKart)
        {
            int i = GlobalData.IndexOfDataSet(_dataTable, stokKart.Id ?? 0);
            if (i == -1)
            {
                AddNewRow(stokKart);
            }
            else
            {
                GlobalData.UpdateDataRow(ref _dataTable, stokKart, i);
            }
        }

        private async void projeKod_SelectedIndexChanged(object sender, EventArgs e)
        {
            _dataTable = null;
            stokKartFilter.proje.Id = projeKodu.selectedDataRowId;
            _dataTable = await GetDataTableAsync();
            DataRefresh();
        }

        private void parcaGrubu_SelectedIndexChanged(object sender, EventArgs e)
        {
            stokKartFilter.stokGrup.Id = cbxStokGrup.selectedDataRowId;
            ComboBoxListFill.GetLookupAd(_cache.malzemeGrups.Where(c => c.stokGrup.Id == cbxStokGrup.selectedDataRowId).ToList(), ref cbxMalzemeGrup);
            ComboBoxListFill.GetLookupAd(_cache.malzemeAltGrups.Where(c => c.malzemeGrup.stokGrup.Id == cbxStokGrup.selectedDataRowId).ToList(), ref cbxMalzemeAltGrup);
            ComboBoxListFill.GetLookupAd(_cache.malzemeAltGrup2List.Where(c => c.malzemeAltGrup.malzemeGrup.stokGrup.Id == cbxStokGrup.selectedDataRowId).ToList(), ref cbxMalzemeAltGrup2);
            DataRefresh();
        }

        private void parcaAltGrubu_SelectedIndexChanged(object sender, EventArgs e)
        {
            stokKartFilter.malzemeGrup.Id = cbxMalzemeGrup.selectedDataRowId;
            ComboBoxListFill.GetLookupAd(_cache.malzemeAltGrups.Where(c => c.malzemeGrup.Id == cbxMalzemeGrup.selectedDataRowId).ToList(), ref cbxMalzemeAltGrup);
            ComboBoxListFill.GetLookupAd(_cache.malzemeAltGrup2List.Where(c => c.malzemeAltGrup.malzemeGrup.Id == cbxMalzemeGrup.selectedDataRowId).ToList(), ref cbxMalzemeAltGrup2);
            DataRefresh();
        }

        private void parcaAdi_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Enter tuşuna basıldı mı kontrolü
            {
                stokKartFilter.parcaKod = textBoxParcaAdi.TextCustom;
                DataRefresh();
            }
        }

        private void chkSatinalma_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSatinalma.Checked)
            {
                stokKartFilter.isSatinalma = false;
            }
            else
            {
                stokKartFilter.isSatinalma = null;
            }
            DataRefresh();
        }

        private void chkPdf_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPdf.Checked)
            {
                stokKartFilter.isPdf =false;
            }
            else
            {
                stokKartFilter.isPdf = null;
            }
            DataRefresh();
        }

        private void chkDxf_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDxf.Checked)
            {
                stokKartFilter.isDxf = false;
            }
            else
            {
                stokKartFilter.isDxf = null;
            }
            DataRefresh();
        }

        private void chkStep_CheckedChanged(object sender, EventArgs e)
        {
            if (chkStep.Checked)
            {
                stokKartFilter.isStep = false;
            }
            else
            {
                stokKartFilter.isStep = null;
            }
            DataRefresh();
        }

        private void roundedButton4_Click(object sender, EventArgs e)
        {
            bool result = true;
            result = GlobalData.CheckField("Stok grubu seçilmelidir", this, cbxStokGrup) && result;
            result = GlobalData.CheckField("Malzeme grubu seçilmelidir", this, cbxMalzemeGrup) && result;
            if (result) CreateSatinalmaTalep(sender, e);
        }
        private void DataRefresh()
        {
            try
            {
                GlobalData.FillDataGrid(_dataTable, dataGridViewStokKart, stokKartFilter);
                _dataTable.Rows.Cast<DataRow>().ToList().ForEach(row => row["sec"] = false);
                selectAll.CheckStateChanged -= selectAll_CheckStateChanged;
                selectAll.Checked = false;
                selectAll.CheckStateChanged += selectAll_CheckStateChanged;
                lblKayitSayisi.Text = $"Görüntülenen Kayıt Sayısı: {dataGridViewStokKart.RowCount}";
                lblToplamKayitSayisi.Text = $"Toplam Kayıt Sayısı: {_dataTable.Rows.Count}";
                lblSecilmisKayitSayisi.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veri tablosu yenilenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void chkSec_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkSec.CheckState == CheckState.Checked)
            {
                chkSec.Text = "Seçilmiş kayıtlar";
                stokKartFilter.sec = true;
            }
            else if (chkSec.CheckState == CheckState.Unchecked)
            {
                chkSec.Text = "Seçilmemiş kayıtlar";
                stokKartFilter.sec = false;
            }
            else
            {
                chkSec.Text = "Tüm kayıtlar";
                stokKartFilter.sec = null;
            }
            DataRefresh();

        }

        private void dataGridViewStokKart_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridViewStokKart.IsCurrentCellDirty)
            {
                dataGridViewStokKart.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
            int i = _dataTable.Rows.IndexOf(_dataTable.Select($"Id={dataGridViewStokKart.CurrentRow.Cells["Id"].Value}").FirstOrDefault());
            _dataTable.Rows[i]["sec"] = dataGridViewStokKart.CurrentRow.Cells["sec"].Value;
            lblSecilmisKayitSayisi.Text = $"Seçilen Kayıt Sayısı: {_dataTable.Select("sec=True").Count()}";
        }

        private void selectAll_CheckStateChanged(object sender, EventArgs e)
        {
            string filter = "";
            if (_dataTable != null)
            {
                GlobalData.RowFilterFromGridFilterFields(stokKartFilter, ref filter);
                filter = filter == "" ? "" : filter.Substring(5);
                _dataTable.Select(filter).Cast<DataRow>().ToList().ForEach(row => row["sec"] = selectAll.CheckState == CheckState.Checked);
                dataGridViewStokKart.Rows.Cast<DataGridViewRow>().ToList().ForEach(row => row.Cells["sec"].Value = selectAll.CheckState == CheckState.Checked);
                lblSecilmisKayitSayisi.Text = $"Seçilen Kayıt Sayısı: {_dataTable.Select("sec=True").Count()}";
            }
        }
        private ToolTip dynamicToolTip = new ToolTip();
        private void dataGridViewStokKart_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            // "pdf" sütunundaki hücrelere özel davranış
            if (e.ColumnIndex == dataGridViewStokKart.Columns["pdf"].Index)
            {
                // Fare el simgesi
                this.Cursor = Cursors.Hand;

                // ToolTip metni ayarla
                if ((bool)dataGridViewStokKart.Rows[e.RowIndex].Cells["isPdf"].Value == true)
                {
                    string toolTipText = dataGridViewStokKart.Rows[e.RowIndex].Cells["kod"].Value?.ToString() + ".pdf";
                    // ToolTip zaten gösteriliyorsa tekrarlamayı önle
                    if (dynamicToolTip.GetToolTip(dataGridViewStokKart) != toolTipText)
                    {
                        dynamicToolTip.SetToolTip(dataGridViewStokKart, toolTipText);
                    }
                }
                else
                {
                    dynamicToolTip.SetToolTip(dataGridViewStokKart, "PDF dosyası yok");
                }
            }
            else if (e.ColumnIndex == dataGridViewStokKart.Columns["dxf"].Index)
            {
                // Fare el simgesi
                this.Cursor = Cursors.Hand;

                // ToolTip metni ayarla
                if ((bool)dataGridViewStokKart.Rows[e.RowIndex].Cells["isDxf"].Value == true)
                {
                    string toolTipText = dataGridViewStokKart.Rows[e.RowIndex].Cells["kod"].Value?.ToString() + ".dxf";
                    // ToolTip zaten gösteriliyorsa tekrarlamayı önle
                    if (dynamicToolTip.GetToolTip(dataGridViewStokKart) != toolTipText)
                    {
                        dynamicToolTip.SetToolTip(dataGridViewStokKart, toolTipText);
                    }
                }
                else
                {
                    dynamicToolTip.SetToolTip(dataGridViewStokKart, "DXF dosyası yok");
                }
            }
            else if (e.ColumnIndex == dataGridViewStokKart.Columns["step"].Index)
            {
                // Fare el simgesi
                this.Cursor = Cursors.Hand;

                // ToolTip metni ayarla
                if (dataGridViewStokKart.Rows[e.RowIndex].Cells["isStep"].Value.ToString() == "true")
                {
                    string toolTipText = dataGridViewStokKart.Rows[e.RowIndex].Cells["kod"].Value?.ToString() + ".step";
                    // ToolTip zaten gösteriliyorsa tekrarlamayı önle
                    if (dynamicToolTip.GetToolTip(dataGridViewStokKart) != toolTipText)
                    {
                        dynamicToolTip.SetToolTip(dataGridViewStokKart, toolTipText);
                    }
                }
                else
                {
                    dynamicToolTip.SetToolTip(dataGridViewStokKart, "STEP dosyası yok");
                }
            }
            else
            {
                // Fare başka sütuna geçtiğinde ToolTip'i temizle ve fare simgesini normal yap
                dynamicToolTip.SetToolTip(dataGridViewStokKart, null);
                this.Cursor = Cursors.Default;
            }
        }

        private void dataGridViewStokKart_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            // Sadece Image sütununda işlem yapmak için
            if (dataGridViewStokKart.Columns["pdf"].Index == e.ColumnIndex && dataGridViewStokKart.Columns["pdf"] is DataGridViewImageColumn)
            {
                // PDF dosyasının var olup olmadığını kontrol et
                bool? pdfFilePath = (bool)dataGridViewStokKart.Rows[e.RowIndex].Cells["isPdf"].Value; // PDF dosyası var mı yok mu hücresine erişim
                pdfFilePath = pdfFilePath == true ? true : false; // 1 ve 0 değerlerini true ve false'a çevir
                bool? pdfExists = pdfFilePath;// Dosyanın mevcut olup olmadığını kontrol et

                e.Value = pdfExists == true ? Properties.Resources.pdf : pdfExists == false ? Properties.Resources.pdf_passive : null;
            }
            if (dataGridViewStokKart.Columns["dxf"].Index == e.ColumnIndex && dataGridViewStokKart.Columns["dxf"] is DataGridViewImageColumn)
            {
                bool? dxffFilePath = (bool)dataGridViewStokKart.Rows[e.RowIndex].Cells["isDxf"].Value; // DXF dosyası var mı yok mu hücresine erişim
                dxffFilePath = dxffFilePath == true ? true : dxffFilePath == false ? false : null; // 1 ve 0 değerlerini true ve false'a çevir
                bool? dxfExists = dxffFilePath;// Dosyanın mevcut olup olmadığını kontrol et
                e.Value = dxfExists == true ? Properties.Resources.dxfImage : dxfExists == false ? Properties.Resources.dxf_passive : null;
            }
            if (dataGridViewStokKart.Columns["step"].Index == e.ColumnIndex && dataGridViewStokKart.Columns["step"] is DataGridViewImageColumn)
            {
                string stepFilePath = dataGridViewStokKart.Rows[e.RowIndex].Cells["isStep"].Value?.ToString(); // STEP dosyası var mı yok mu hücresine erişim
                stepFilePath = stepFilePath == "true" ? "true" : stepFilePath == "false" ? "false" : null; // 1 ve 0 değerlerini true ve false'a çevir
                bool? stepExists = bool.TryParse(stepFilePath, out bool val) ? val : null;// Dosyanın mevcut olup olmadığını kontrol et
                e.Value = stepExists == true ? Properties.Resources.step : stepExists == false ? Properties.Resources.step_passive : null;
            }
        }

        private async void CreateSatinalmaTalep(object sender, EventArgs e)
        {
            DataView dataView= _dataTable.AsDataView();
            dataView.RowFilter = "sec=True"; // Sadece seçili satırları filtrele
            var stokKartList = dataView.ToTable(); // Filtrelenmiş DataTable'ı al
            List<StokKart> stokKarts = _dataTableHelper.MapToEntityList<StokKart>(stokKartList);
            if(!ValidateForm(stokKarts)) return;
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.MarqueeAnimationSpeed = 30;
            progressBar1.Visible = true;
            SatinalmaTalepKayitFormu satinalmaTalepOlusturma = SatinalmaTalepKayitFormu.satinalmaTalepKayitFormu;
            satinalmaTalepOlusturma.UpdateMode(await CreateSatinalmaTalep(stokKarts));
            satinalmaTalepOlusturma.Show();
            progressBar1.Visible = false;
        }
        private bool ValidateForm(List<StokKart> stokKarts)
        {
            // Formdaki gerekli alanların dolu olup olmadığını kontrol et
            if (!stokKarts.Any())
            {
                MessageBox.Show("Satınalma talebi oluşturulacak satırlar seçilmelidir.");
                return false;
            }
            if (stokKarts.Any(x => x.isPdf == false))
            {
                MessageBox.Show("PDF dosyası olmayan kayıtlar seçilemez.");
                return false;
            }
            if (stokKarts.Any(x => x.isDxf == false))
            {
                MessageBox.Show("DXF dosyası olmayan kayıtlar seçilemez.");
                return false;
            }
            if (stokKarts.Any(x => x.isSatinalma == true))
            {
                MessageBox.Show("Satınalma talebi açılmış kayıtlar seçilemez.");
                return false;
            }
            return true;
        }
        private async Task<SatinalmaTalep> CreateSatinalmaTalep(List<StokKart> stokKarts)
        {
            SatinalmaTalep satinalmaTalep = new SatinalmaTalep();
            satinalmaTalep.proje.Id = projeKodu.selectedDataRowId;
            satinalmaTalep.malzemeGrup.Id = cbxMalzemeGrup.selectedDataRowId;
            satinalmaTalep.talepEdenKullanici.Id = _cache.kullanici.Id;
            satinalmaTalep.teslimTarihi = DateTime.Now;
            satinalmaTalep.talepTarihi = DateTime.Now;
            satinalmaTalep.satinalmaTalepDetays = await CreateSatinalmaTalepDetay(stokKarts);
            return satinalmaTalep;
        }
        private async Task<List<SatinalmaTalepDetay>> CreateSatinalmaTalepDetay(List<StokKart> stokKarts)
        {
            List<SatinalmaTalepDetay> satinalmaTalepDetays = new List<SatinalmaTalepDetay>();

            foreach (var stokKart in stokKarts)
            {
                var satinalmaTalepDetay = new SatinalmaTalepDetay();
                var satinalmaTalepSatirDetay = new SatinalmaTalepSatirDetay()
                {
                    stokKart = stokKart,
                    stokKartKod = stokKart.kod,
                    stokKartAd = stokKart.ad,
                    miktar = stokKart.miktar,
                };

                if (stokKart.hammaddeId != null)
                {
                    StokKart hammadde = new StokKart { Id = stokKart.hammaddeId };
                    hammadde = _dataTableHelper.MapToEntity<StokKart>(_jsonConvertHelper.DeserializeToDataSet(await _stokService.GetStokKart(hammadde)).Tables[0].Rows[0]);
                    hammadde.proje.Id = stokKart.proje.Id;
                    hammadde.proje.kod = stokKart.proje.kod;
                    if (stokKart.malzemeGrup.Id == 30) hammadde.uzunluk = stokKart.uzunluk;
                    satinalmaTalepDetay.stokKart = hammadde;
                    satinalmaTalepDetay.miktar = stokKart.miktar;
                    satinalmaTalepDetay.agirlik = (stokKart.miktar.HasValue? stokKart.miktar.Value:0) * (stokKart.agirlik.HasValue ? stokKart.agirlik.Value : 0);
                    satinalmaTalepDetay.satinalmaTalepSatirDetays.Add(satinalmaTalepSatirDetay);
                }
                else
                {
                    satinalmaTalepDetay.stokKart = stokKart;
                }
                
                var mevcut = satinalmaTalepDetays.FirstOrDefault(x => x.stokKart.Id == satinalmaTalepDetay.stokKart.Id && x.stokKart.uzunluk == satinalmaTalepDetay.stokKart.uzunluk);
                if (mevcut != null)
                {
                    mevcut.miktar += stokKart.miktar;
                    mevcut.agirlik += (stokKart.miktar.HasValue ? stokKart.miktar.Value : 0) * (stokKart.agirlik.HasValue ? stokKart.agirlik.Value : 0);
                    mevcut.satinalmaTalepSatirDetays.Add(satinalmaTalepSatirDetay);
                }
                else
                {
                    satinalmaTalepDetays.Add(satinalmaTalepDetay);
                }
            }
            return satinalmaTalepDetays;
        }

        private void dataGridViewStokKart_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) // Sağ tıklama kontrolü
            {
                var hitTestInfo = dataGridViewStokKart.HitTest(e.X, e.Y); // Tıklanan hücreyi belirle

                if (hitTestInfo.RowIndex >= 0) // Eğer geçerli bir satır tıklanmışsa
                {
                    dataGridViewStokKart.ClearSelection(); // Önceki seçimleri temizle
                    dataGridViewStokKart.Rows[hitTestInfo.RowIndex].Selected = true; // Tıklanan satırı seç
                    contextMenuStrip1.Show(dataGridViewStokKart, e.Location); // Sağ tıklama menüsünü göster
                }
            }
        }

        private async void stokKartınıGörüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StokKart stokKart = new StokKart();
            stokKartFilter.Id = Convert.ToInt32(dataGridViewStokKart.Rows[dataGridViewStokKart.SelectedRows[0].Index].Cells["Id"].Value);
            DataRow dataRow = _jsonConvertHelper.DeserializeToDataSet(await _stokService.GetStokKartPdf(stokKartFilter)).Tables[0].Rows[0];
            int dtId = GlobalData.IndexOfDataSet(_dataTable, int.Parse(dataGridViewStokKart.Rows[dataGridViewStokKart.SelectedRows[0].Index].Cells[0].Value.ToString()));
            //_dataTable.Rows[dtId].ItemArray = dataRow.ItemArray;

            //stokKart = _dataTableHelper.MapToEntity<StokKart>(_dataTable.Rows[dtId]);
            stokKart = _dataTableHelper.MapToEntity<StokKart>(dataRow);
            StokKartKayitFormu stokKartTanimlamaFormu = StokKartKayitFormu.stokKartKayitFormu;
            if (stokKartTanimlamaFormu != null)
            {
                stokKartTanimlamaFormu.UpdateMode(stokKart);
                stokKartTanimlamaFormu.Show();
            }
        }

        private void dataGridViewStokKart_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if ((bool)dataGridViewStokKart.Rows[e.RowIndex].Cells["isPdf"].Value == false) dataGridViewStokKart.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Cyan;
                if ((bool)dataGridViewStokKart.Rows[e.RowIndex].Cells["isDxf"].Value == false) dataGridViewStokKart.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Cyan;
                //if ((bool)dataGridViewStokKart.Rows[e.RowIndex].Cells["isStep"].Value == false) dataGridViewStokKart.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Cyan;
                if ((bool)dataGridViewStokKart.Rows[e.RowIndex].Cells["isSatinalma"].Value==true) dataGridViewStokKart.Rows[e.RowIndex].DefaultCellStyle.BackColor =Color.Aqua;
            }
        }

        private void cbxMalzemeAltGrup_SelectedIndexChanged(object sender, EventArgs e)
        {
            stokKartFilter.malzemeAltGrup.Id = cbxMalzemeAltGrup.selectedDataRowId;
            ComboBoxListFill.GetLookupAd(_cache.malzemeAltGrup2List.Where(c => c.malzemeAltGrup.Id == cbxMalzemeAltGrup.selectedDataRowId).ToList(), ref cbxMalzemeAltGrup2);
            DataRefresh();
        }

        private void cbxMalzemeAltGrup2_SelectedIndexChanged(object sender, EventArgs e)
        {
            stokKartFilter.malzemeAltGrup2.Id = cbxMalzemeAltGrup2.selectedDataRowId;
            DataRefresh();
        }

        private void textBoxParcaAdi_TextChanged(object sender, EventArgs e)
        {
            stokKartFilter.parcaAdi = textBoxParcaAdi.TextCustom;
            DataRefresh();
        }

    }
}