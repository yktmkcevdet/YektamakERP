using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Net.Http;
using System.Text.Unicode;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Globalization;
using YektamakDesktop.Formlar.Ortak;
using ApiService;
using YektamakDesktop.Common;

namespace YektamakDesktop.Formlar.Satis
{
    public partial class SatisFaturaGridForm : Form, IForm
    {
        private static SatisFaturaGridForm _satisFaturaGridForm;
        public static SatisFaturaGridForm satisFaturaGridForm
        {
            get
            {
                if (_satisFaturaGridForm == null)
                {
                    _satisFaturaGridForm = new SatisFaturaGridForm();
                    GlobalData.Yetki(ref _satisFaturaGridForm);
                }
                return _satisFaturaGridForm;
            }
        }
        private List<Control> _controlsToDisable;
        public List<Control> controlsToDisable { get => _controlsToDisable; set => _controlsToDisable = value; }
        public static List<SatisFatura> _satisFaturaList;
        public static List<SatisFatura> satisFaturaList { get => _satisFaturaList; set => _satisFaturaList = value; }
        private bool _activeForm;
        public bool activeForm { get => _activeForm; set => _activeForm = value; }
        private DataTable _dataTable;

        private DataTable dataTable
        {
            get
            {
                if (_dataTable == null)
                {
                    _dataTable = new DataTable();
                    _dataTable=GlobalData.FillDataTable(WebMethods.GetFilteredSatisFatura,satisFaturaFilter);
                    _dataTable.RowDeleted += dataTableRowChanged;
                    _dataTable.RowChanged += dataTableRowChanged;
                }
                return _dataTable;
            }
            set { _dataTable = value; }
        }
        ToolTip buttonFiltreToolTip;
        public SatisFaturaGridForm()
        {
            InitializeComponent();
            SetToolTips();
            controlsToDisable = new List<Control>
            {
                buttonFiltre,
                buttonSatisSiparisEkle,
                buttonTumKayitlariGetir,
                dataGridViewSatisFatura,
                rButtonCikis
            };

        }
        /// <summary>
        /// Form kontrollerinin ToolTip ayarlarını yapar
        /// </summary>
        public void SetToolTips()
        {
            buttonFiltreToolTip = new ToolTip();
            buttonFiltreToolTip.ToolTipTitle = "Satış Siparişleri Filtreleme";
            buttonFiltreToolTip.SetToolTip(buttonFiltre, "Sol taraftaki ifadeleri içeren filtrelenmiş sonuçları getirir");
            buttonFiltreToolTip.ToolTipIcon = ToolTipIcon.Info;
            buttonFiltreToolTip.AutoPopDelay = 20000;
        }
        #region MouseDrag
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
        #endregion MouseDrag
        /// <summary>
        /// dataSet'teki verileri Grid'e yükler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void buttonTumKayitlariGetir_Click(object sender, EventArgs e)
        {
            GlobalData.FillDataGrid(dataTable, dataGridViewSatisFatura, satisFaturaFilter);
        }
        /// <summary>
        /// Update ikonuna tıklatılınca satisFatura formunu güncelleme modunda açar.
        /// Delete ikonuna tıklatınca kaydı siler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewSatisFatura_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            dataGridViewSatisFatura.Rows[e.RowIndex].Selected = true;
            if (e.ColumnIndex == dataGridViewSatisFatura.Rows[e.RowIndex].Cells["Guncelle"].ColumnIndex || e.ColumnIndex == dataGridViewSatisFatura.Rows[e.RowIndex].Cells["Sil"].ColumnIndex)
            {
                if (dataGridViewSatisFatura.Rows[e.RowIndex].Cells[0].Value == null)
                    return;

                if (e.ColumnIndex == dataGridViewSatisFatura.Rows[e.RowIndex].Cells["Guncelle"].ColumnIndex)//Update
                {
                    UpdateSatisFatura(SelectedData(e.RowIndex));
                }
                else if (e.ColumnIndex == dataGridViewSatisFatura.Rows[e.RowIndex].Cells["Sil"].ColumnIndex)//Delete
                {
                    DeleteSatisFatura(SelectedData(e.RowIndex));
                }
            }
        }
        /// <summary>
        /// Verilen SatisFatura nesnesinin güncelleme işlemi için formu açar.
        /// </summary>
        /// <param name="firma"></param>
        public void UpdateSatisFatura(SatisFatura satisFatura)
        {
            SatisFaturaKayitFormu satisFaturaKayitFormu = SatisFaturaKayitFormu.satisFaturaKayitFormu;
            if (satisFaturaKayitFormu != null)
            {
                satisFaturaKayitFormu.Show();
                satisFaturaKayitFormu.UpdateMode(satisFatura);
            }
        }
        /// <summary>
        /// Kullanıcıya silme işlemi için onay sorusu gösterir ve işlemi gerçekleştirir.
        /// Grid'de seçili olan kaydı Grid'den ve veritabanından siler.
        /// </summary>
        /// </summary>
        /// <param name="satisProje"></param>
        private async Task DeleteSatisFatura(SatisFatura satisFatura)
        {
            DialogResult dialogResult = MessageBox.Show(string.Format("{0} nolu faturayı silmek istediğinizden emin misiniz", satisFatura.faturaNo), "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                var httpTask = WebMethods.DeleteSatisFatura(satisFatura);
                this.Enabled = false;
                string result = await httpTask;
                if (result.Contains("error",StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show(result);
                }
                else
                {
                    MessageBox.Show("Silme İşlemi Başarılı");
                    int i = GlobalData.IndexOfDataSet(dataTable, satisFatura.satisFaturaId);
                    dataTable.Rows[i].Delete(); 
                   
                }
                this.Enabled = true;
            }
        }
        private SatisFatura SelectedData(int rowIndex)
        {
            if (dataTable == null || rowIndex < 0) return null;
            if (rowIndex >= dataTable.Rows.Count) return null;
            SatisFatura satisFatura = new SatisFatura();
            int satisFaturaId = int.Parse(dataGridViewSatisFatura.Rows[rowIndex].Cells[0].Value.ToString());
            satisFatura.satisFaturaId = satisFaturaId;
            int i = GlobalData.IndexOfDataSet(dataTable, satisFaturaId);
            satisFatura = ConvertHelper.DataRowToModel<SatisFatura>(dataTable.Rows[i]);
            return satisFatura;
        }
        private void buttonFiltre_Click(object sender, EventArgs e)
        {
            GlobalData.FillDataGrid(dataTable, dataGridViewSatisFatura, satisFaturaFilter);
        }
        
        /// <summary>
        /// satisFaturaKayitFormu'bu savemode'da açar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSatisSiparisEkle_Click(object sender, EventArgs e)
        {
            SatisFaturaKayitFormu satisFaturaKayitFormu = SatisFaturaKayitFormu.satisFaturaKayitFormu;
            if(satisFaturaKayitFormu != null)
            {
                satisFaturaKayitFormu.Show();
                satisFaturaKayitFormu.SaveMode();
            }
        }
        /// <summary>
        /// Formu kapatır ve activeformstack listesinden siler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rButtonCikis_Click(object sender, EventArgs e)
        {
            GlobalData.CloseForm(ref _satisFaturaGridForm);
        }

        private void buttomMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            GlobalData.CloseForm(ref _satisFaturaGridForm);
        }
        private SatisFatura satisFaturaFilter
        {
            get
            {
                return GlobalData.GridFilter<SatisFatura>(panelFilter);
            }
        }
        private void dataTableRowChanged(object sender, DataRowChangeEventArgs e)
        {
            GlobalData.FillDataGrid(dataTable, dataGridViewSatisFatura, satisFaturaFilter);
        }
        private void SatisFaturaGridForm_Load(object sender, EventArgs e)
        {
            GlobalData.PlaceFilterFields(dataGridViewSatisFatura, panelFilter);
        }

        private void dataGridViewSatisFatura_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            GlobalData.ResizeFilterFields(dataGridViewSatisFatura, panelFilter);
        }
        /// <summary>
        /// Datatable nesnesine kayıt formundan gelen kaydı ekler
        /// </summary>
        /// <param name="satisFatura"></param>
        private void AddNewRow(SatisFatura satisFatura)
        {
            dataTable.Rows.Add(
                satisFatura.satisFaturaId,
                satisFatura.faturaNo,
                satisFatura.faturaTarihi ,
                satisFatura.satisSiparis.satisProje.projeKod.Id,
                satisFatura.satisSiparis.satisProje.projeKod.kod,
                satisFatura.cariKart.cariKartId,
                satisFatura.cariKart.cariAdi,
                satisFatura.tutar.tutar,
                satisFatura.tutar.dovizCinsi.sembol,
                satisFatura.satisSiparis.satisProje.projeId,
                0, //Faturalandırılmamış tutar alanı dataTable'da 0 olarak tutulacak.
                satisFatura.satisSiparis.Id,
                satisFatura.satisSiparis.satisProje.musteri.Id,
                satisFatura.cariKart.cari.Id);
        }
        public void UpdateRow(SatisFatura satisFatura)
        {
            int i = GlobalData.IndexOfDataSet(dataTable, satisFatura.satisFaturaId);
            if (i == -1)
            {
                AddNewRow(satisFatura);
            }
            else
            {
                GlobalData.UpdateDataRow(dataTable, satisFatura, i);
            }                                         
        }
    }
}