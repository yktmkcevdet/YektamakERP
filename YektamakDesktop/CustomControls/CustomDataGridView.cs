using Models;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using YektamakDesktop.Common;

namespace YektamakDesktop.CustomControls
{
    public partial class CustomDataGridView<T> : UserControl where T : class,IEntity, new()
    {
        public CustomDataGridView()
        {
            InitializeComponent();
        }
        private static List<T> _entities;
        public static List<T> entities
        {
            get
            {
                if (_entities == null)
                {
                    _entities = new List<T>();
                }
                return _entities;
            }
            set
            {
                _entities = value;
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
                    _dataTable = ConvertHelper.ToDataTable(entities);
                }
                return _dataTable;
            }
            set
            {
                _dataTable = value;
                DataRefresh();
            }
        }
        private T _filter;
        private T filter
        {
            get
            {
                if (_filter == null)
                {
                    _filter = new T();
                }
                return _filter;
            }
            set { _filter = value; }
        }
        public void dataTableRowChanged(object sender, DataRowChangeEventArgs e)
        {
            DataRefresh();
        }
        private void DataRefresh()
        {
            GlobalData.FillDataGrid(dataTable, dataGridView1, filter);
            //lblKayitSayisi.Text = $"Toplam Kayıt Sayısı: {dataGridView1.RowCount}";
        }
    }
}
