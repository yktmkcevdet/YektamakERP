using YektamakDesktop.CustomControls;
using YektamakDesktop.Formlar.Ortak;
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

namespace YektamakDesktop.Formlar.Satinalma
{
    public partial class SatinalmaTalepGridForm : Form, IForm
    {
        private static SatinalmaTalepGridForm _satinalmaTalepGridForm;
        public static SatinalmaTalepGridForm satinalmaTalepGridForm
        {
            get
            {
                if (_satinalmaTalepGridForm == null)
                {
                    _satinalmaTalepGridForm = new SatinalmaTalepGridForm();
                    GlobalData.Yetki(ref _satinalmaTalepGridForm);
                }
                return _satinalmaTalepGridForm;
            }
            set
            {
                _satinalmaTalepGridForm = value;
            }
        }
        public List<Control> _controlsToDisable;
        public List<Control> controlsToDisable
        {
            get
            {
                if (_controlsToDisable == null) _controlsToDisable = new();
                return _controlsToDisable;
            }
            set
            {
                _controlsToDisable = value;
            }
        }
        public bool activeForm { get; set; }
        public SatinalmaTalepGridForm()
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
        private async void buttonTumKayitlariGetir_Click(object sender, EventArgs e)
        {
            IJsonConvertHelper jsonConverter = new JsonConvertHelper();
            DataSet dataSet = jsonConverter.JsonStringToDataSet(await WebMethods.GetSatinalmaTalep(new SatinalmaTalepBaslik()));
            //GlobalData.FillDataGrid(dataSet.Tables[0],dataGridView1,new SatinalmaTalepBaslik());
        }
        private async void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == dataGridView1.Rows[e.RowIndex].Cells["Guncelle"].ColumnIndex || e.ColumnIndex == dataGridView1.Rows[e.RowIndex].Cells["Sil"].ColumnIndex)
            {
                SatinalmaTalepBaslik satinalmaTalepBaslik = new();
                satinalmaTalepBaslik.Id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["satinalmaTalepBaslikId"].Value);
                satinalmaTalepBaslik.talepTarihi = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells["talepTarihi"].Value);
                satinalmaTalepBaslik.proje.Id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["projeKodId"].Value);
                satinalmaTalepBaslik.talepTip.talepTipId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["TalepTipId"].Value);
                if (e.ColumnIndex == dataGridView1.Rows[e.RowIndex].Cells["Guncelle"].ColumnIndex)
                {
                    SatinalmaTalepFormu satinalmaTalepFormu = SatinalmaTalepFormu.satinalmaTalepFormu;
                    satinalmaTalepFormu.UpdateMode(satinalmaTalepBaslik);
                    satinalmaTalepFormu.Show();
                }
                else if (e.ColumnIndex == dataGridView1.Rows[e.RowIndex].Cells["Sil"].ColumnIndex)
                {
                    DialogResult dialogResult = MessageBox.Show(String.Format("{0} nolu satınalma talebini silmek istediğinizden emin misiniz?", satinalmaTalepBaslik.Id), "Kayıt silinsin mi?", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        await WebMethods.DeleteSatinalmaTalep(satinalmaTalepBaslik);
                        dataGridView1.Rows.RemoveAt(e.RowIndex);
                    }
                }
            }
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            CloseForm();
        }
        private void CloseForm()
        {
            GlobalData.RemoveLastForm();
            satinalmaTalepGridForm = null;
            this.Close();
        }
        private void rButtonCikis_Click(object sender, EventArgs e)
        {
            CloseForm();
        }
        private void buttonSatinalmaTalepEkle_Click(object sender, EventArgs e)
        {
            SatinalmaTalepFormu satinalmaTalepFormu = SatinalmaTalepFormu.satinalmaTalepFormu;
            satinalmaTalepFormu.Show();

        }

        private void SatinalmaTalepGridForm_Load(object sender, EventArgs e)
        {
            GlobalData.PlaceFilterFields(dataGridView1,panelFilter);
        }
        

        private void dataGridView1_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            GlobalData.ResizeFilterFields(dataGridView1,panelFilter);
        }
    }

}
