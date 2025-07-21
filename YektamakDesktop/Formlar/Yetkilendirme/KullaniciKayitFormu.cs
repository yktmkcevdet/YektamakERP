using ApiService.Interfaces;
using Models;
using Models.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Utilities.Implementations;
using Utilities.Interfaces;
using YektamakDesktop.Common;
using ConvertHelper = YektamakDesktop.Common.ConvertHelper;

namespace YektamakDesktop.Formlar.Yetkilendirme
{
    public partial class KullaniciKayitFormu : Form
    {
        private readonly IKullaniciYetkiService _kullaniciYetkiService;
        private readonly IPasswordService _passwordService;
        private readonly ICache _cache;
        private readonly IJsonConverter _jsonConverter;
        private readonly IDataTableMapper _dataTableMapper;
        public KullaniciKayitFormu(IKullaniciYetkiService kullaniciYetkiService, IPasswordService passwordService, ICache cache, IJsonConverter jsonConverter, IDataTableMapper dataTableMapper)
        {
            _kullaniciYetkiService = kullaniciYetkiService;
            _passwordService = passwordService;
            _cache = cache;
            _jsonConverter = jsonConverter;
            _dataTableMapper = dataTableMapper;
            InitializeComponent();
            ComboBoxListFill.GetLookupAd(_cache.rolList, ref clbRol);
            ComboBoxListFill.GetLookupAd(_cache.personelList, ref clbPersonel);
            universalGrid1.kullanici = _cache.kullanici;
            universalGrid1.Grid.CellClick += universalGrid1_CellClick;
        }
        private Kullanici _kullanici;
        public Kullanici kullanici
        {
            get { if (_kullanici == null) { _kullanici = new Kullanici(); } return _kullanici; }
            set
            {
                _kullanici = value;
                _kullaniciId = _kullanici.Id;
                Binding();
            }
        }
        private void Binding()
        {
            ctbKullaniciAd.DataBindings.Clear();
            ctbSifre.DataBindings.Clear();
            ctbSifreTekrar.DataBindings.Clear();
            clbPersonel.DataBindings.Clear();
            clbRol.DataBindings.Clear();
            ctbId.DataBindings.Clear();
            ctbId.DataBindings.Add("TextCustom",kullanici,$"{nameof(kullanici.Id)}",true,DataSourceUpdateMode.OnPropertyChanged);
            ctbKullaniciAd.DataBindings.Add("TextCustom", kullanici, $"{nameof(kullanici.ad)}", true, DataSourceUpdateMode.OnPropertyChanged);
            ctbSifre.DataBindings.Add("TextCustom", kullanici, $"{nameof(kullanici.sifre)}", true, DataSourceUpdateMode.OnPropertyChanged);
            ctbSifreTekrar.DataBindings.Add("TextCustom", kullanici, $"{nameof(kullanici.sifre)}", true, DataSourceUpdateMode.OnPropertyChanged);
            clbPersonel.DataBindings.Add("selectedDataRowId", kullanici.personel, $"{nameof(kullanici.personel.Id)}", true, DataSourceUpdateMode.OnPropertyChanged);
            clbRol.DataBindings.Add("selectedDataRowId", kullanici.rol, $"{nameof(kullanici.rol.Id)}", true, DataSourceUpdateMode.OnPropertyChanged);
        }
        private int? _kullaniciId { get; set; }
        private void rButtonKullaniciKaydet_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;
            try
            {
                string hashedPassword = _passwordService.HashPassword(kullanici.sifre).CombinedHash;
                kullanici.Id = _kullaniciId;
                kullanici.sifre = hashedPassword;
                kullanici.isSifreDegisti = false;
                string jsonResult = _kullaniciYetkiService.SaveKullanici(kullanici);
                Result result = _jsonConverter.DeserializeToModelList<Result>(jsonResult).FirstOrDefault();
                if (result?.result != null)
                {
                    if (result.result.Contains("error", StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show(result.result);
                    }
                    else
                    {
                        kullanici = JsonConvert.DeserializeObject<Kullanici>(result.result);
                        _cache.kullaniciList.Add(kullanici);
                        IMailHandler mailHandler = new MailHandler();
                        mailHandler.SendMail(kullanici.personel.mail, "ERP şifreniz değiştirildi", "");
                        KullaniciKayitFormu_Load(sender, e);
                        MessageBox.Show("Kayıt başarılı");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata oluştu: {ex.Message}");
            }
        }
        private bool ValidateInputs()
        {
            bool isValid = true;

            // Tüm validasyonları çalıştır, kısa devre yapmadan
            isValid &= GlobalData.CheckField("Bu alan boş olamaz", this, ctbKullaniciAd);
            isValid &= GlobalData.CheckField("Bu alan boş olamaz", this, clbPersonel);
            isValid &= GlobalData.CheckField("Bu alan boş olamaz", this, ctbSifre);
            isValid &= GlobalData.CheckField("Bu alan boş olamaz", this, ctbSifreTekrar);
            isValid &= GlobalData.CheckField("Bu alan boş olamaz", this, clbRol);
            return isValid;
        }
        private async void KullaniciKayitFormu_Load(object sender, EventArgs e)
        {
            Binding();
            var kullaniciList = _cache.kullaniciList;
            List<KullaniciDTO> kullaniciKayit = new List<KullaniciDTO>();
            foreach (var kullanici in kullaniciList)
            {
                kullaniciKayit.Add(ConvertHelper.ToDTO<KullaniciDTO>(kullanici));
            }
            await universalGrid1.SetData(kullaniciKayit, this.Name);
        }

        private void universalGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                KullaniciDTO kullaniciDTO = (KullaniciDTO)universalGrid1.Grid.CurrentRow.DataBoundItem;
                kullanici=ConvertHelper.ToEntity<Kullanici>(kullaniciDTO);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void KullaniciKayitFormu_FormClosing(object sender, FormClosingEventArgs e)
        {
            universalGrid1.SaveSettings();
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            kullanici = new Kullanici();
        }
    }
}
