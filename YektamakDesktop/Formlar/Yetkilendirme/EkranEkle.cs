using Models;

using FontAwesome.Sharp;
using Newtonsoft.Json;
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
using ApiService;

namespace YektamakDesktop.Formlar.Yetkilendirme
{
    public partial class EkranEkle : Form, IForm
    {
        private static Menu _menu;
        public static Menu menu
        {
            get
            {
                if (_menu == null)
                {
                    _menu = new Menu();
                }
                return _menu;
            }
            set
            {
                _menu = value;
            }
        }
        private static EkranEkle _ekranEkle;
        public static EkranEkle ekranEkle
        {
            get
            {
                if (_ekranEkle == null)
                {
                    _ekranEkle = new EkranEkle();
                    GlobalData.Yetki(ref _ekranEkle);
                }
                return _ekranEkle;
            }
        }

        public List<Control> controlsToDisable { get; set; }
        public bool activeForm { get; set; }

        private bool mouseDown;
        private Point offset;
        public EkranEkle()
        {
            InitializeComponent();
            CustomComboLists_Load();
            customComboListBoxFormlar.SelectDataRowValue(menu.formAdi);
            customComboListBoxIcon.SelectDataRowValue(menu.icon);
            customTextBoxMenuAdi.TextCustom = menu.ad;
        }
        #region mouseDrag
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
        private void CustomComboLists_Load()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            int id = 0;
            foreach (Type type in assembly.GetTypes())
            {
                if (type.IsSubclassOf(typeof(Form))) // Form sınıfından miras alan türleri kontrol et
                {
                    customComboListBoxFormlar.AddDataRow(id, type.Name);
                    id++;
                }
            }
            foreach (IconChar icon in Enum.GetValues(typeof(IconChar)))
            {
                customComboListBoxIcon.AddDataRow(id, icon.ToString());
                id++;
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            GlobalData.CloseForm(ref _ekranEkle);
        }

        private async void rButtonKaydet_Click(object sender, EventArgs e)
        {
            menu.ad = customTextBoxMenuAdi.TextCustom;
            menu.formAdi = customComboListBoxFormlar.selectedDataRowValue;
            menu.icon = customComboListBoxIcon.selectedDataRowValue;
            string result = await WebMethods.SaveMenu(menu);
            if (!result.Contains("error", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Kayıt başarılı");
            }
            else
            {
                MessageBox.Show(result);
            }
        }
    }
}
