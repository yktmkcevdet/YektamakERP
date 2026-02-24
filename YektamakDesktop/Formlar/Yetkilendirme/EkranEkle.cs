using ApiService.Interfaces;
using FontAwesome.Sharp;
using Models;
using Models.Models;
using Models.Models.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Utilities.Interfaces;
using YektamakDesktop.Common;
using System.ComponentModel;

namespace YektamakDesktop.Formlar.Yetkilendirme
{
    public partial class EkranEkle : Form
    {
        private readonly IKullaniciYetkiService _kullaniciYetkiService;
        private readonly IJsonConverter _jsonConverter;
        private readonly ICache _cache;    
        public EkranEkle(IKullaniciYetkiService kullaniciYetkiService, IJsonConverter jsonConverter, ICache cache)
        {
            _kullaniciYetkiService = kullaniciYetkiService;
            _jsonConverter = jsonConverter;
            _cache = cache;
            InitializeComponent();
            CustomComboLists_Load();
            Binding();
        }

        private void Binding()
        {
            BindHelper.BindData(ctbId, menu, nameof(menu.Id));
            BindHelper.BindData(clbFormAd, menu, nameof(menu.formAd));
            BindHelper.BindData(clbIcon, menu, nameof(menu.icon));
            BindHelper.BindData(ctbDtoName, menu, nameof(menu.model));
            BindHelper.BindData(ctbMenuAd, menu, nameof(menu.ad));
        }

        private Menu _menu;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Menu menu
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
                Binding();
            }
        }
        private void CustomComboLists_Load()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            List<FontAwesomeIcon> icons = Enum.GetValues(typeof(IconChar))
                .Cast<IconChar>()
                .Select(icon => new FontAwesomeIcon { Id = (int)icon, ad = icon.ToString() })
                .ToList();
            clbFormAd.SetDataSource(assembly.GetTypes().Where(t=> t.IsSubclassOf(typeof(Form))).Select(t=> new MenuForm{ Id=t.GUID,ad=t.Name}).ToList());
            clbIcon.SetDataSource(icons);
        }
        private void customComboListBoxIcon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(((FontAwesomeIcon)clbIcon.SelectedItem)?.ad))roundedIconButton1.IconChar = (IconChar)Enum.Parse(typeof(IconChar), ((FontAwesomeIcon)clbIcon.SelectedItem).ad, true);
        }

        private async void rButtonKaydet_Click(object sender, EventArgs e)
        {
            string jsonResult = await _kullaniciYetkiService.SaveMenu(menu);
            if(String.IsNullOrEmpty(jsonResult) || jsonResult.Contains("error", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show(jsonResult);
            }
            else
            {
                menu = JsonConvert.DeserializeObject<List<Menu>>(jsonResult).FirstOrDefault();
                _cache.menuList.Add(menu);
                MessageBox.Show("Kayıt Başarılı");
            }
        }
        public void UpdateMode(Menu menuUpdate)
        {
            menu = menuUpdate;
        }

        private void rButtonKaydet_Load(object sender, EventArgs e)
        {

        }
    }
}
