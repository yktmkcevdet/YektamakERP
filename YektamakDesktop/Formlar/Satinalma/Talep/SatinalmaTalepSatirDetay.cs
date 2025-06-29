using Models;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using YektamakDesktop.Common;

namespace YektamakDesktop.Formlar.Proje
{
    public partial class SatinalmaTalepSatirDetayForm : Form, IForm
    {
        public static List<SatinalmaTalepSatirDetay> _satinalmaTalepSatirDetays;
        public SatinalmaTalepSatirDetayForm(List<SatinalmaTalepSatirDetay> satinalmaTalepSatirDetays)
        {
            InitializeComponent();
            _satinalmaTalepSatirDetays = satinalmaTalepSatirDetays;
             GlobalData.FillDataGrid(GetDataTable(), dataGridViewSatinalmaTalepSatirDetay, new SatinalmaTalepSatirDetay());
            controlsToDisable=new List<Control>{this };
        }
        private static SatinalmaTalepSatirDetayForm _satinalmaTalepSatirDetayForm;
        public static SatinalmaTalepSatirDetayForm satinalmaTalepSatirDetayForm
        {
            get
            {
                if (_satinalmaTalepSatirDetayForm == null || _satinalmaTalepSatirDetayForm.IsDisposed)
                {
                    _satinalmaTalepSatirDetayForm = new SatinalmaTalepSatirDetayForm(_satinalmaTalepSatirDetays);
                    GlobalData.Yetki(ref _satinalmaTalepSatirDetayForm);
                }
                return _satinalmaTalepSatirDetayForm;
            }
        }

        public List<Control> controlsToDisable { get; set; }
        public bool activeForm { get; set; }

        private DataTable _dataTable;
        public DataTable GetDataTable()
        {
            if (_dataTable == null)
            {
                _dataTable = new DataTable();
            }

            if (_dataTable.Rows.Count == 0)
            {
                _dataTable = ConvertHelper.ToDataTable(_satinalmaTalepSatirDetays);
            }

            return _dataTable;
        }

    }
}
