using YektamakDesktop.Formlar.Stok;
using Models;
using ApiService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using YektamakDesktop.Formlar.Ortak;
using YektamakDesktop.Common;
using Utilities.Interfaces;
using Utilities.Implementations;

namespace YektamakDesktop.Formlar.Proje
{
    public partial class ProjeDosyalari : Form, IForm, IGridForm<StokKart>
    {
        private static ICache _cache;
        private static ProjeDosyalari _projeDosyalari;
        public static ProjeDosyalari projeDosyalari
        {
            get
            {
                if (_projeDosyalari == null)
                {
                    _projeDosyalari = new ProjeDosyalari(_cache);
                    GlobalData.Yetki(ref _projeDosyalari);
                }
                return _projeDosyalari;
            }
        }
        
        private DataTable _dataTable;
        private DataTable dataTable
        {
            get
            {
                if (_dataTable == null)
                {
                    _dataTable = new DataTable();
                    _dataTable.RowDeleted += dataTableRowChanged;
                    _dataTable.RowChanged += dataTableRowChanged;
                }
                if (_dataTable.Rows.Count == 0)
                {
                    _dataTable = GlobalData.FillDataTable(WebMethods.GetStokKart, stokKartFilter);
                }
                return _dataTable;
            }
            set { _dataTable = value; }
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
        public bool activeForm { get => _activeForm; set => _activeForm = value; }

        public ProjeDosyalari(ICache cache)
        {
            InitializeComponent();
            _cache = cache;
            controlsToDisable = new List<Control> { panelFilter, panelHeader };
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


        public void AddNewRow(StokKart stokKart)
        {
            dataTable.Rows.Add(
                stokKart.Id,
                stokKart.kod,
                stokKart.ad,
                stokKart.boyut,
                stokKart.proje,
                stokKart.uzunluk,
                stokKart.aciklama,
                stokKart.agirlik,
                stokKart.miktar,
                stokKart.parcaAltGrup,
                stokKart.parcaGrup,
                stokKart.isPdf,
                stokKart.isDxf,
                stokKart.isStep
                );
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
            /*CariKartKayitFormu cariKartKayitFormu = CariKartKayitFormu.cariKartKayitFormu;
            if (cariKartKayitFormu != null)
            {
                cariKartKayitFormu.Show();
                cariKartKayitFormu.SaveMode();
            }*/
        }

        public void buttonFiltre_Click(object sender, EventArgs e)
        {
            stokKartFilter.proje.Id = projeKod.selectedDataRowId;
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

        public void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
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
                string serializeString = WebMethods.GetStokKartPdf(stokKart);
                
                IJsonConvertHelper jsonConverter = new JsonConvertHelper();
                DataSet dataSet = jsonConverter.JsonStringToDataSet(serializeString);
                if (dataSet != null)
                {
                    foreach (DataRow dataRow in dataSet.Tables[0].Rows)
                    {
                        stokKart = Common.ConvertHelper.DataRowToModel<StokKart>(dataRow);
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
                        PdfGoruntuleme pdfGoruntuleme = PdfGoruntuleme.pdfGoruntuleme;
                        pdfGoruntuleme.pdfFilePath = tempFilePath;
                        pdfGoruntuleme.ShowDialog();
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
            ComboBoxListFill.GetLookupKod(_cache.proje.Where(x => x.personel.Id == _cache.kullanici.personel.Id).ToList(), ref projeKod);
            ComboBoxListFill.GetLookupAd(_cache.parcaGrups, ref parcaGrubu);
            ComboBoxListFill.GetLookupAd(_cache.malzemeGrup, ref parcaAltGrubu);
            
        }

        public void UpdateRow(StokKart stokKart)
        {
            int i = GlobalData.IndexOfDataSet(dataTable, stokKart.Id);
            if (i == -1)
            {
                AddNewRow(stokKart);
            }
            else
            {
                GlobalData.UpdateDataRow(dataTable, stokKart, i);
            }
        }

        private void projeKod_SelectedIndexChanged(object sender, EventArgs e)
        {
            stokKartFilter.proje.Id = projeKod.selectedDataRowId;
            _dataTable = new DataTable();
            DataRefresh();
        }

        private void parcaGrubu_SelectedIndexChanged(object sender, EventArgs e)
        {
            stokKartFilter.parcaGrup.Id = parcaGrubu.selectedDataRowId;
            DataRefresh();
        }

        private void parcaAltGrubu_SelectedIndexChanged(object sender, EventArgs e)
        {
            stokKartFilter.parcaAltGrup.Id = parcaAltGrubu.selectedDataRowId;
            DataRefresh();
        }

        private void parcaAdi_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Enter tuşuna basıldı mı kontrolü
            {
                stokKartFilter.ad = textBoxParcaAdi.TextCustom;
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
                stokKartFilter.isPdf = false;
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
            SatinalmaTalebiOlustur(sender, e);
        }
        private void DataRefresh()
        {
            GlobalData.FillDataGrid(dataTable, dataGridViewStokKart, stokKartFilter);
            lblKayitSayisi.Text = $"Toplam Kayıt Sayısı: {dataGridViewStokKart.RowCount}";
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
            dataTable.Rows[dataGridViewStokKart.CurrentRow.Index]["sec"] = dataGridViewStokKart.CurrentRow.Cells["sec"].Value;
        }

        private void selectAll_CheckStateChanged(object sender, EventArgs e)
        {
            dataTable.Rows.Cast<DataRow>().ToList().ForEach(row => row["sec"] = selectAll.CheckState == CheckState.Checked);
            dataGridViewStokKart.Rows.Cast<DataGridViewRow>().ToList().ForEach(row => row.Cells["sec"].Value = selectAll.CheckState == CheckState.Checked);
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
                if (dataGridViewStokKart.Rows[e.RowIndex].Cells["isPdf"].Value.ToString() == "true")
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
                if (dataGridViewStokKart.Rows[e.RowIndex].Cells["isDxf"].Value.ToString() == "true")
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
                string pdfFilePath = dataGridViewStokKart.Rows[e.RowIndex].Cells["isPdf"].Value?.ToString(); // PDF dosyası var mı yok mu hücresine erişim
                pdfFilePath = pdfFilePath == "true" ? "true" : pdfFilePath == "false" ? "false" : null; // 1 ve 0 değerlerini true ve false'a çevir
                bool? pdfExists = bool.TryParse(pdfFilePath, out bool val) ? val : null;// Dosyanın mevcut olup olmadığını kontrol et

                e.Value = pdfExists == true ? Properties.Resources.pdf : pdfExists == false ? Properties.Resources.pdf_passive : null;
            }
            if (dataGridViewStokKart.Columns["dxf"].Index == e.ColumnIndex && dataGridViewStokKart.Columns["dxf"] is DataGridViewImageColumn)
            {
                string dxffFilePath = dataGridViewStokKart.Rows[e.RowIndex].Cells["isDxf"].Value?.ToString(); // DXF dosyası var mı yok mu hücresine erişim
                dxffFilePath = dxffFilePath == "true" ? "true" : dxffFilePath == "false" ? "false" : null; // 1 ve 0 değerlerini true ve false'a çevir
                bool? dxfExists = bool.TryParse(dxffFilePath, out bool val) ? val : null;// Dosyanın mevcut olup olmadığını kontrol et
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

        private void SatinalmaTalebiOlustur(object sender, EventArgs e)
        {
            SatinalmaTalepOlusturma.stokKarts = Common.ConvertHelper.ToList<StokKart>(dataTable.AsEnumerable().Where(row => row.Field<string>("sec") == "True").ToList());
            if(SatinalmaTalepOlusturma.stokKarts.Count == 0)
            {
                MessageBox.Show("Satınalma talebi oluşturulacak satırlar seçilmelidir.");
                return;
            }
            SatinalmaTalepOlusturma satinalmaTalepOlusturma = SatinalmaTalepOlusturma.satinalmaTalepOlusturma;
            if(satinalmaTalepOlusturma != null)
            {
                satinalmaTalepOlusturma.Show();
            }
        }

        private void dataGridViewStokKart_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
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

        private void stokKartınıGörüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StokKart stokKart =new StokKart();
            stokKart =Common.ConvertHelper.DataRowToModel<StokKart>(dataTable.Rows[dataGridViewStokKart.SelectedRows[0].Index]);
            StokKartTanimlamaFormu stokKartTanimlamaFormu= StokKartTanimlamaFormu.stokKartTanimlamaFormu(stokKart);
            if(stokKartTanimlamaFormu != null)
            {
                stokKartTanimlamaFormu.Show();
            }
        }
    }
}
