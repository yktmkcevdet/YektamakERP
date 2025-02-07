using YektamakDesktop.Formlar.Genel;
using Models;
using ApiService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YektamakDesktop.Common;

namespace YektamakDesktop.Formlar.Satinalma
{
    public partial class SatinalmaTalepleri : Form, IForm, IGridForm<SatinalmaTalepDetay>
    {
        public SatinalmaTalepleri()
        {
            InitializeComponent();
            dataGridView.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridView.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView.DefaultCellStyle.BackColor = Color.White;
            GlobalData.FillDataGrid(dataTable, dataGridView, satinalmaTalepDetayFilter);
            //for (int i = 0; i < GlobalData.firmaUnvanList.Count; i++)
            //{
            //    customComboListBoxFirma.AddDataRow(GlobalData.firmaUnvanList[i].id, GlobalData.firmaUnvanList[i].unvan);
            //}
        }
        private static SatinalmaTalepleri _satinalmaTalepleri;
        public static SatinalmaTalepleri satinalmaTalepleri
        {
            get
            {
                if (_satinalmaTalepleri == null)
                {
                    _satinalmaTalepleri = new SatinalmaTalepleri();
                    GlobalData.Yetki(ref _satinalmaTalepleri);
                }
                return _satinalmaTalepleri;
            }
        }
        private List<Control> _controlsToDisable;
        public List<Control> controlsToDisable { get => _controlsToDisable; set => _controlsToDisable = value; }
        private bool _activeForm;
        public bool activeForm { get => _activeForm; set => _activeForm = value; }
        private SatinalmaTalepDetay satinalmaTalepDetayFilter
        {
            get
            {
                return GlobalData.GridFilter<SatinalmaTalepDetay>(panelFilter);
            }
        }
        private DataTable _dataTable;
        public DataTable dataTable
        {
            get
            {
                if (_dataTable == null)
                {
                    _dataTable = new DataTable();
                    _dataTable = GlobalData.FillDataTable(WebMethods.GetFilteredSatinalmaTalepDetay, satinalmaTalepDetayFilter);
                    _dataTable.RowDeleted += dataTableRowChanged;
                    _dataTable.RowChanged += dataTableRowChanged;
                }
                return _dataTable;
            }
            set { _dataTable = value; }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            GlobalData.CloseForm(ref _satinalmaTalepleri);
        }

        public void UpdateRow(SatinalmaTalepDetay model)
        {
            throw new NotImplementedException();
        }

        public void AddNewRow(SatinalmaTalepDetay model)
        {
            throw new NotImplementedException();
        }

        public void form_Load(object sender, EventArgs e)
        {
            GlobalData.PlaceFilterFields(dataGridView, panelFilter);
        }

        public void dataTableRowChanged(object sender, DataRowChangeEventArgs e)
        {

        }

        public void buttonEkle_Click(object sender, EventArgs e)
        {

        }

        public void CloseForm()
        {

        }

        public void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            GlobalData.DataGridViewCellClick<SatinalmaTalepDetay>(ref _dataTable, dataGridView, e);
        }

        public void buttonTumKayitlariGetir_Click(object sender, EventArgs e)
        {

        }

        public void buttonFiltre_Click(object sender, EventArgs e)
        {
            GlobalData.FillDataGrid(dataTable, dataGridView, satinalmaTalepDetayFilter);
        }

        public void dataGridView_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {

        }

        public void buttonClose_Click(object sender, EventArgs e)
        {

        }

        public void buttomMinimize_Click(object sender, EventArgs e)
        {

        }

        public void dataGridView_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void roundedIconButton1_Click(object sender, EventArgs e)
        {
            List<SatinalmaTalepDetay> satinalmaTalepDetayList = new List<SatinalmaTalepDetay>();
            foreach (DataGridViewRow selectedRow in dataGridView.Rows)
            {
                string sec = selectedRow.Cells["sec"].Value.ToString();
                if (Convert.ToBoolean(selectedRow.Cells["sec"].Value))
                {
                    Int64 satinalmaTalepDetayId = Convert.ToInt64(selectedRow.Cells["id"].Value);
                    var dataRow = dataTable.AsEnumerable().First(row => row.Field<Int64>("id") == satinalmaTalepDetayId);
                    SatinalmaTalepDetay satinalmaTalepDetay = ConvertHelper.DataRowToModel<SatinalmaTalepDetay>(dataRow);
                    satinalmaTalepDetayList.Add(satinalmaTalepDetay);
                }
            }
            WebMethods.SaveSatinalmaTeklifTalep(satinalmaTalepDetayList);
        }
    }   
}
