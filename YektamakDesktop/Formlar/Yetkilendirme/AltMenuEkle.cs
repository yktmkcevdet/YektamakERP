using YektamakDesktop.Formlar.Ortak;
using Models;

using Newtonsoft.Json;
using ApiService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YektamakDesktop.Formlar.Yetkilendirme
{
    public partial class AltMenuEkle : Form, IForm
    {
        private static AltMenuEkle _altMenuekle;
        public static AltMenuEkle altMenuekle
        {
            get
            {
                if (_altMenuekle == null)
                {
                    _altMenuekle = new AltMenuEkle();
                    GlobalData.Yetki(ref _altMenuekle);
                }
                return _altMenuekle;
            }
        }
        private List<Control> _controlsToDisable;
        public List<Control> controlsToDisable { get => _controlsToDisable; set => _controlsToDisable = value; }
        private bool _activeForm;
        public bool activeForm { get => _activeForm; set => _activeForm = value; }
        public AltMenuEkle()
        {
            InitializeComponent();
            controlsToDisable = new List<Control>() { };
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

        private void CloseForm()
        {
            this.Close();
            _altMenuekle = null;
            GlobalData.RemoveLastForm();
        }
        private bool CheckFields()
        {
            bool result = true;
            GlobalData.ClearWarningLabels(this);
            result = GlobalData.CheckField("* Menü adı girilmelidir", altMenuekle, customTextBoxMenuAdi) ? result : false;
            result = GlobalData.CheckField("* Ana menü seçimi yapılmalıdır.", altMenuekle, comboListBoxAnaMenu) ? result : false;
            result = GlobalData.CheckField("* Form seçimi yapılmalıdır.", altMenuekle, comboListBoxForm) ? result : false;
            return result;
        }

        private void rButtonKapat_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private async void rButtonKaydet_Click(object sender, EventArgs e)
        {   
            if (!CheckFields()) return;
            Ekran ekran = new Ekran();
            ekran.menu.Id = comboListBoxAnaMenu.selectedDataRowId;
            ekran.altMenuId = comboListBoxForm.selectedDataRowId;
            ekran.ekranAdi = customTextBoxMenuAdi.TextCustom;
            ekran.formAdi = comboListBoxForm.selectedDataRowValue;
            string httpResult = await WebMethods.SaveEkran(ekran);

            if (!httpResult.Contains("error"))
            {
                MessageBox.Show("Kayıt başarılı");
                CloseForm();
            }
            else
            {
                MessageBox.Show(httpResult);
            }
        }
        public void SaveMode(Menu menu)
        {
            //foreach (Menu anaMenu in GlobalData.menuList)
            //{
            //    comboListBoxAnaMenu.AddDataRow(int.Parse(anaMenu.Id.ToString()), anaMenu.ad.ToString());
            //    comboListBoxForm.AddDataRow(int.Parse(anaMenu.Id.ToString()), anaMenu.ad.ToString());
            //}
            
            comboListBoxAnaMenu.SelectDataRowId(menu.Id);
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void buttomMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState=FormWindowState.Minimized;
        }
    }
}
