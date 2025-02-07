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
using Utilities.Implementations;
using Utilities.Interfaces;

namespace YektamakDesktop.Formlar.Stok
{
    public partial class StokKartGridForm : Form
    {
        private static StokKartGridForm _stokKartGridForm;
        public static StokKartGridForm stokKartGridForm 
        { 
            get 
            {
                if (_stokKartGridForm == null)
                { 
                    _stokKartGridForm = new StokKartGridForm(); 
                    GlobalData.Yetki(ref _stokKartGridForm); 
                } 
                return _stokKartGridForm; 
            } 
            set 
            { 
                _stokKartGridForm = value; 
            } 
        }
        public StokKartGridForm()
        {
            InitializeComponent();
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
        private void buttonTumKayitlariGetir_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string jsonString = WebMethods.GetStokKart(new StokKart());
            IJsonConvertHelper jsonConverter = new JsonConvertHelper();
            DataSet dataSet = jsonConverter.JsonStringToDataSet(jsonString);
            //GlobalData.FillDataGrid(dataSet.Tables[0],dataGridView1, new StokKart());
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            StokKart stokKart = new();
            
            if (e.ColumnIndex == dataGridView1.Rows[e.RowIndex].Cells["Guncelle"].ColumnIndex)
            {
                
            }
            if (e.ColumnIndex == dataGridView1.Rows[e.RowIndex].Cells["Sil"].ColumnIndex)
            {
                
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            CloseForm();
        }
        private void CloseForm()
        {
            GlobalData.RemoveLastForm();
            stokKartGridForm = null;
            this.Close();
        }

        private void teklifOlusturToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1_CellClick(null, null);
        }

        private void rButtonCikis_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void buttonSatisSiparisEkle_Click(object sender, EventArgs e)
        {
            
        }
    }

}
