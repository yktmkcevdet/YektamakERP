using ApiService.Interfaces;
using Models;
using Models.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Utilities.Interfaces;
using YektamakDesktop.Common;

namespace YektamakDesktop.Formlar.Yetkilendirme
{
    public partial class AltMenuEkleForm : Form
    {
        private readonly IKullaniciYetkiService _kullaniciYetkiService;
        private readonly ICache _cache;
        public AltMenuEkleForm(ICache cache, IKullaniciYetkiService kullaniciYetkiService)
        {
            _kullaniciYetkiService = kullaniciYetkiService;
            _cache = cache;
            InitializeComponent();
            ComboBoxListFill.GetLookupAd(_cache.menuList, ref clbAnaMenu);
            ComboBoxListFill.GetLookupAd(_cache.menuList, ref clbForm);
            Binding();
        }

        private void Binding()
        {
            clbAnaMenu.DataBindings.Clear();
            clbForm.DataBindings.Clear();
            clbAnaMenu.DataBindings.Add("SelectedValue", ekran, $"{nameof(ekran.menu)}.{nameof(ekran.menu.Id)}", true, DataSourceUpdateMode.OnPropertyChanged);
            clbForm.DataBindings.Add("SelectedValue", ekran, $"{nameof(ekran.altMenuId)}", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private Ekran _ekran;
        private Ekran ekran
        {
            get {
                if (_ekran == null)
                {
                    _ekran = new();
                }
                return _ekran;
            }
            set
            {
                _ekran = value;
            }
        }
       
        private bool CheckFields()
        {
            bool result = true;
            result = GlobalData.CheckField("* Ana menü seçimi yapılmalıdır.", clbAnaMenu) ? result : false;
            result = GlobalData.CheckField("* Form seçimi yapılmalıdır.", clbForm) ? result : false;
            return result;
        }
        private async void rButtonKaydet_Click(object sender, EventArgs e)
        {
            if (!CheckFields()) return;
            
            string jsonResult = await _kullaniciYetkiService.SaveEkran(ekran);
            MessageBox.Show(jsonResult);
        }
        public void UpdateMode(Menu menu)
        {
            ekran.menu = menu;
        }
    }
}
