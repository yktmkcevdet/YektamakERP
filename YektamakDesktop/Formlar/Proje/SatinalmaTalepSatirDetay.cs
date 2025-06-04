using ApiService.Interfaces;
using Models;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YektamakDesktop.Formlar.Proje
{
    public partial class SatinalmaTalepSatirDetayForm : Form
    {
        private static ISatinalmaService _satinalmaService;
        private static SatinalmaTalepDetay _satinalmaTalepDetay;
        public SatinalmaTalepSatirDetayForm(SatinalmaTalepDetay satinalmaTalepSatirDetay)
        {
            InitializeComponent();
            _satinalmaTalepDetay = satinalmaTalepSatirDetay;
            GetDataTable();
             GlobalData.FillDataGrid(_dataTable, dataGridViewSatinalmaTalepSatirDetay, _satinalmaTalepDetay);
        }
        public SatinalmaTalepSatirDetayForm(ISatinalmaService satinalmaService)
        {
            _satinalmaService = satinalmaService;
        }
        private DataTable _dataTable;
        public DataTable GetDataTable()
        {
            if (_dataTable == null)
            {
                _dataTable = new DataTable();
            }

            if (_dataTable.Rows.Count == 0)
            {
                _dataTable = GlobalData.FillDataTable(_satinalmaService.GetSatinalmaTalepSatirDetay, _satinalmaTalepDetay);
            }

            return _dataTable;
        }

    }
}
