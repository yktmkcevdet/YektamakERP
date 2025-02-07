using YektamakDesktop.Formlar.Satinalma;
using YektamakDesktop.Formlar.Satinalma.DataControl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using DataTable = System.Data.DataTable;
using Excel = Microsoft.Office.Interop.Excel;
using Point = System.Drawing.Point;
using static YektamakDesktop.GlobalData;
namespace YektamakDesktop.Formlar.Ortak
{
    public partial class ExceldenVeriAlmaFormu : Form, IForm
    {
        public ExceldenVeriAlmaFormu()
        {
            InitializeComponent();
        }
        private static ExceldenVeriAlmaFormu _exceldenVeriAlmaFormu;
        public static ExceldenVeriAlmaFormu exceldenVeriAlmaFormu 
        {
            get 
            {
                if (_exceldenVeriAlmaFormu == null)
                {
                    _exceldenVeriAlmaFormu = new ExceldenVeriAlmaFormu();
                    GlobalData.Yetki(ref _exceldenVeriAlmaFormu);
                }
                return _exceldenVeriAlmaFormu;  
            } 
            set 
            { 
                _exceldenVeriAlmaFormu = value;
            } 
        }
        private List<Control> _controlsToDisable;
        public List<Control> controlsToDisable { get { if (_controlsToDisable == null) { _controlsToDisable = new List<Control>(); } return _controlsToDisable; } set { _controlsToDisable = value; } }
        public bool activeForm { get; set; }

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

        private void buttonClose_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void CloseForm()
        {
            
            this.Close();
            GlobalData.RemoveLastForm();
            _exceldenVeriAlmaFormu = null;
        }
    }
}
