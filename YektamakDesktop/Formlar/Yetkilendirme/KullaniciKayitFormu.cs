using ApiService.Interfaces;
using Models;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Utilities.Implementations;
using Utilities.Interfaces;
using YektamakDesktop.Common;
using ConvertHelper = YektamakDesktop.Common.ConvertHelper;

namespace YektamakDesktop.Formlar.Yetkilendirme
{
    public partial class KullaniciKayitFormu : Form, IForm
    {
        private static IKullaniciYetkiService _kullaniciYetkiService;
        private static IPasswordService _passwordService;
        private static ICache _cache;
        private static IJsonConverter _jsonConverter;
        private static IDataTableMapper _dataTableMapper;
        public KullaniciKayitFormu(IKullaniciYetkiService kullaniciYetkiService, IPasswordService passwordService, ICache cache, IJsonConverter jsonConverter, IDataTableMapper dataTableMapper)
        {
            _kullaniciYetkiService = kullaniciYetkiService;
            _passwordService = passwordService;
            _cache = cache;
            _jsonConverter = jsonConverter;
            _dataTableMapper = dataTableMapper;
        }
        private static KullaniciKayitFormu _kullaniciKayitFormu;
        public static KullaniciKayitFormu kullaniciKayitFormu
        {
            get
            {
                if (_kullaniciKayitFormu == null || _kullaniciKayitFormu.IsDisposed)
                {
                    _kullaniciKayitFormu = new KullaniciKayitFormu();
                    GlobalData.Yetki(ref _kullaniciKayitFormu);
                }
                return _kullaniciKayitFormu;
            }
        }
        private List<Control> _controlsToDisable;
        public List<Control> controlsToDisable { get => _controlsToDisable; set => _controlsToDisable = value; }
        private bool _activeForm;
        public bool activeForm { get => _activeForm; set => _activeForm = value; }
        private int _kullaniciId;
        public KullaniciKayitFormu()
        {
            InitializeComponent();
            ComboBoxListFill.GetLookupAd(_cache.rolList, ref comboListBoxRol);
            ComboBoxListFill.GetLookupAd(_cache.personelList, ref cbxPersonel);
        }
        private void rButtonKullaniciKaydet_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;
            GlobalData.HandleException(async () =>
            {
                string salt = GlobalData.GenerateSalt();
                string password = customTextBoxSifre.TextCustom;
                string kullaniciAdi = textBoxKullaniciAdi.TextCustom;
                string hashedPassword = _passwordService.HashPassword(password).CombinedHash;
                Models.Kullanici kullanici = new Models.Kullanici();
                kullanici.Id = _kullaniciId;
                kullanici.ad = kullaniciAdi;
                kullanici.sifre = hashedPassword;
                kullanici.salt = salt;
                kullanici.personel.Id = cbxPersonel.selectedDataRowId;
                kullanici.rol.Id = comboListBoxRol.selectedDataRowId;
                kullanici.isSifreDegisti = false;
                string httpResult = _kullaniciYetkiService.SaveKullanici(kullanici);
                if (httpResult.Contains("error", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show(httpResult);
                }
                else
                {
                    IMailHandler mailHandler = new MailHandler();
                    mailHandler.SendMail("cevdet.oguz@yektamak.com.tr", "şifre değişti", "");
                    MessageBox.Show("Kayıt başarılı");
                }

            });
        }
        private bool ValidateInputs()
        {
            bool isValid = true;

            // Tüm validasyonları çalıştır, kısa devre yapmadan
            isValid &= GlobalData.CheckField("Bu alan boş olamaz", this, textBoxKullaniciAdi);
            isValid &= GlobalData.CheckField("Bu alan boş olamaz", this, cbxPersonel);
            isValid &= GlobalData.CheckField("Bu alan boş olamaz", this, customTextBoxSifre);
            isValid &= GlobalData.CheckField("Bu alan boş olamaz", this, customTextBoxSifreTekrar);
            isValid &= GlobalData.CheckField("Bu alan boş olamaz", this, comboListBoxRol);
            return isValid;
        }
        private async void buttonFiltre_Click(object sender, EventArgs e)
        {

        }
        private void ClearFields()
        {
            labelUyariKulllaniciAdi.Text = "";
            labelUyariSifre.Text = "";
            labelUyariSifreTekrar.Text = "";
            labelUyariPersonel.Text = "";
            labelUyariRol.Text = "";
            textBoxKullaniciAdi.TextCustom = "";
            customTextBoxSifre.TextCustom = "";
            customTextBoxSifreTekrar.TextCustom = "";
            cbxPersonel.SelectDataRowId(-1);
            comboListBoxRol.SelectDataRowId(-1);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        private async void KullaniciKayitFormu_Load(object sender, EventArgs e)
        {
            var kullaniciList = _cache.kullaniciList;
            DataTable dataTable = ConvertHelper.ToDataTable(kullaniciList);
            var kullaniciKayit = _dataTableMapper.MapToEntityList<Models.DTO.KullaniciDTO>(dataTable);
            universalGrid1.SetData(kullaniciKayit, this.Name);
        }

        private void universalGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var source = universalGrid1.Grid.DataSource;
                if (source is IEnumerable<Models.DTO.KullaniciDTO> list)
                {
                    DataTable dataTable = ConvertHelper.ToDataTable(list);
                    GlobalData.DataGridViewCellClick<Models.DTO.KullaniciDTO>(ref dataTable, universalGrid1.Grid, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        public void UpdateMode(Models.DTO.KullaniciDTO kullanici)
        {
            textBoxKullaniciAdi.TextCustom = kullanici.ad;
            comboListBoxRol.SelectDataRowId(kullanici.rolId ?? -1);
            cbxPersonel.SelectDataRowId(kullanici.personelId ?? -1);
        }

        private void KullaniciKayitFormu_FormClosing(object sender, FormClosingEventArgs e)
        {
            universalGrid1.SaveSettings(this.Name);
        }
    }
}
