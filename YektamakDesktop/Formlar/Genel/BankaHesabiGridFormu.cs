using Models;
using ApiService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using YektamakDesktop.Common;

namespace YektamakDesktop.Formlar.Genel
{
    public partial class BankaHesabiGridFormu : Form, IForm
    {
        private static BankaHesabiGridFormu _bankaHesabiGridFormu;
        public static BankaHesabiGridFormu bankaHesabiGridFormu
        {
            get
            {
                if (_bankaHesabiGridFormu == null)
                {
                    _bankaHesabiGridFormu = new BankaHesabiGridFormu();
                    GlobalData.Yetki(ref _bankaHesabiGridFormu);
                }
                return _bankaHesabiGridFormu;
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
                    _dataTable = GlobalData.FillDataTable(WebMethods.GetFilteredBankaHesabi, bankaHesabiFilter);
                    _dataTable.RowDeleted += dataTableRowChanged;
                    _dataTable.RowChanged += dataTableRowChanged;
                }
                return _dataTable;
            }
            set { _dataTable = value; }
        }
        private List<Control> _controlsToDisable;
        public List<Control> controlsToDisable { get => _controlsToDisable; set => _controlsToDisable = value; }
        private bool _activeForm;
        public bool activeForm { get => _activeForm; set => _activeForm = value; }

        /// <summary>
        /// dataSet her zaman grid'le aynı sıralamaya sahip olacak
        /// </summary>
        private DataSet dataSet;

        //Firma güncelleme formundan personelgrid'e gelindiyse bu veriler kullanılacak
        public int firmaId;
        public string firmaUnvan;

        public BankaHesabiGridFormu()
        {
            InitializeComponent();
            controlsToDisable = new List<Control>
            {
                buttonBankaHesabiEkle,
                dataGridViewBankaHesabi,
                rButtonCikis
            };
        }
        #region mouseDrag
        private void rButtonCikis_Click(object sender, EventArgs e)
        {
            GlobalData.RemoveLastForm();
            this.Close();
            _bankaHesabiGridFormu = null;
        }
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
        public async void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            dataGridViewBankaHesabi.Rows[e.RowIndex].Selected = true;
            if (e.ColumnIndex == dataGridViewBankaHesabi.Rows[e.RowIndex].Cells["Guncelle"].ColumnIndex || e.ColumnIndex == dataGridViewBankaHesabi.Rows[e.RowIndex].Cells["Sil"].ColumnIndex)
            {
                if (dataGridViewBankaHesabi.Rows[e.RowIndex].Cells[0].Value == null)
                    return;

                if (e.ColumnIndex == dataGridViewBankaHesabi.Rows[e.RowIndex].Cells["Guncelle"].ColumnIndex)//Update
                {
                    UpdateBankaHesabi(SelectedData(e.RowIndex));
                }
                else if (e.ColumnIndex == dataGridViewBankaHesabi.Rows[e.RowIndex].Cells["Sil"].ColumnIndex)//Delete
                {
                    await DeleteBankaHesabi(SelectedData(e.RowIndex));
                }
            }
        }
        /// <summary>
        /// Verilen SatisFatura nesnesinin güncelleme işlemi için formu açar.
        /// </summary>
        /// <param name="firma"></param>
        public void UpdateBankaHesabi(BankaHesabi bankaHesabi)
        {
            BankaHesabiKayitFormu bankaHesabiKayitFormu = BankaHesabiKayitFormu.bankaHesabiKayitFormu;
            if (bankaHesabiKayitFormu != null)
            {
                bankaHesabiKayitFormu.Show();
                bankaHesabiKayitFormu.UpdateMode(bankaHesabi);
            }
        }
        /// <summary>
        /// Kullanıcıya silme işlemi için onay sorusu gösterir ve işlemi gerçekleştirir.
        /// Grid'de seçili olan kaydı Grid'den ve veritabanından siler.
        /// </summary>
        /// </summary>
        /// <param name="satisProje"></param>
        private async Task DeleteBankaHesabi(BankaHesabi bankaHesabi)
        {
            DialogResult dialogResult = MessageBox.Show(string.Format($"{bankaHesabi.hesapAdi} hesabını silmek istediğinizden emin misiniz" ), "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Enabled = false;
                string result = await WebMethods.DeleteBankaHesabi(bankaHesabi);
                if (result.Contains("error", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show(result);
                }
                else
                {
                    MessageBox.Show("Silme İşlemi Başarılı");
                    int i = GlobalData.IndexOfDataSet(dataTable, bankaHesabi.hesapId);
                    dataTable.Rows[i].Delete();

                }
                this.Enabled = true;
            }
        }
        private BankaHesabi SelectedData(int rowIndex)
        {
            if (dataTable == null || rowIndex < 0) return null;
            if (rowIndex >= dataTable.Rows.Count) return null;
            BankaHesabi bankaHesabi = new BankaHesabi();
            int satialmaFaturaId = int.Parse(dataGridViewBankaHesabi.Rows[rowIndex].Cells[0].Value.ToString());
            bankaHesabi.hesapId = satialmaFaturaId;
            int i = GlobalData.IndexOfDataSet(dataTable, satialmaFaturaId);
            bankaHesabi = ConvertHelper.DataRowToModel<BankaHesabi>(dataTable.Rows[i]);
            return bankaHesabi;
        }
        private void dataTableRowChanged(object sender, DataRowChangeEventArgs e)
        {
            GlobalData.FillDataGrid(dataTable, dataGridViewBankaHesabi, bankaHesabiFilter);
        }

        /// <summary>
        /// Grid'i firma hesaplarının detaylı bilgileri ile doldurur
        /// </summary>
        /// <param name="firmaId"></param>
        public void FirmaMode(int firmaId)
        {
            BankaHesabi bankaHesabi = new();
            bankaHesabi.firma.id = firmaId;
            this.firmaId = firmaId;
        }
        /// <summary>
        /// Grid'i firma hesaplarının detaylı bilgileri ile doldurur
        /// </summary>
        /// <param name="firma"></param>
        public void FirmaMode(Firma firma)
        {
            FirmaMode(firma.id);
        }

        private void buttonBankaHesabiEkle_Click(object sender, EventArgs e)
        {
            BankaHesabiKayitFormu bankaHesabiKayitFormu = BankaHesabiKayitFormu.bankaHesabiKayitFormu;
            Firma firma = new();
            firma.id = firmaId;
            firma.unvan = firmaUnvan;
            bankaHesabiKayitFormu.Show();
            bankaHesabiKayitFormu.SaveMode(firma);
        }   

        private void CloseForm()
        {
            GlobalData.CloseForm(ref _bankaHesabiGridFormu);
        }

        private void BankaHesabiGridFormu_Load(object sender, EventArgs e)
        {
            GlobalData.PlaceFilterFields(dataGridViewBankaHesabi, panelFilter);
        }

        private void buttomMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void dataGridViewBankaHesabi_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            GlobalData.ResizeFilterFields(dataGridViewBankaHesabi, panelFilter);
        }


        private void buttonTumKayitlariGetir_Click(object sender, EventArgs e)
        {
            GlobalData.FillDataGrid(dataTable, dataGridViewBankaHesabi, bankaHesabiFilter);
        }
        private BankaHesabi bankaHesabiFilter
        {
            get
            {
                return GlobalData.GridFilter<BankaHesabi>(panelFilter);
            }
        }
        /// <summary>
        /// Datatable nesnesine kayıt formundan gelen kaydı ekler
        /// </summary>
        /// <param name="satisFatura"></param>
        private void AddNewRow(BankaHesabi bankaHesabi)
        {
            dataTable.Rows.Add(
                bankaHesabi.hesapId,
                bankaHesabi.hesapAdi,
                bankaHesabi.IBAN,
                bankaHesabi.dovizCinsi.id,
                bankaHesabi.dovizCinsi.sembol,
                bankaHesabi.firma.id,
                bankaHesabi.firma.unvan,
                bankaHesabi.banka.id,
                bankaHesabi.banka.unvan);
        }
        public void UpdateRow(BankaHesabi bankaHesabi)
        {
            int i = GlobalData.IndexOfDataSet(dataTable, bankaHesabi.hesapId);
            if (i == -1)
            {
                AddNewRow(bankaHesabi);
            }
            else
            {
                GlobalData.UpdateDataRow(dataTable, bankaHesabi, i);
            }
        }
    }
}
