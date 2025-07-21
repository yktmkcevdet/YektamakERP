using ApiService.Interfaces;
using FontAwesome.Sharp;
using Models;
using Models.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Utilities.Interfaces;

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
            ctbId.DataBindings.Clear();
            clbFormAd.DataBindings.Clear();
            clbIcon.DataBindings.Clear();
            ctbDtoName.DataBindings.Clear();
            ctbMenuAd.DataBindings.Clear();
            ctbId.DataBindings.Add("TextCustom", menu, $"{nameof(menu.Id)}", true, DataSourceUpdateMode.OnPropertyChanged);
            clbFormAd.DataBindings.Add("selectedDataRowValue", menu, $"{nameof(menu.formAd)}", true, DataSourceUpdateMode.OnPropertyChanged);
            clbIcon.DataBindings.Add("selectedDataRowId", menu, $"{nameof(menu.icon)}", true, DataSourceUpdateMode.OnPropertyChanged);
            ctbDtoName.DataBindings.Add("TextCustom", menu, $"{nameof(menu.model)}", true, DataSourceUpdateMode.OnPropertyChanged);
            ctbMenuAd.DataBindings.Add("TextCustom", menu, $"{nameof(menu.ad)}", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private Menu _menu;
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
            int id = 0;
            foreach (Type type in assembly.GetTypes())
            {
                if (type.IsSubclassOf(typeof(Form))) // Form sınıfından miras alan türleri kontrol et
                {
                    clbFormAd.AddDataRow(id, type.Name);
                    id++;
                }
            }
            foreach (var icon in Enum.GetValues(typeof(IconChar)))
            {
                clbIcon.AddDataRow((int)icon, icon.ToString());
            }
        }
        private void customComboListBoxIcon_SelectedIndexChanged(object sender, EventArgs e)
        {
            roundedIconButton1.IconChar = (IconChar)Enum.Parse(typeof(IconChar), clbIcon.selectedDataRowValue, true);
        }

        private async void rButtonKaydet_Click(object sender, EventArgs e)
        {
            string jsonResult = await _kullaniciYetkiService.SaveMenu(menu);
            Result result = _jsonConverter.DeserializeToModelList<Result>(jsonResult).FirstOrDefault(); ;
            if (result?.result != null)
            {
                menu = _jsonConverter.DeserializeToModelList<Menu>(result.result).FirstOrDefault();
                _cache.menuList.Add(menu);
                MessageBox.Show("Kayıt Başarılı");
            }
            else
            {
                MessageBox.Show(result.result);
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
