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
using YektamakDesktop.CustomControls;
using ConvertHelper = YektamakDesktop.Common.ConvertHelper;
using System.ComponentModel;

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
            Initialize();
        }
        private void Initialize()
        {
            Controls.Remove(universalGrid1);
            universalGrid1 = DIContainer.GetService<UniversalGrid>();
            universalGrid1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            universalGrid1.Location = new System.Drawing.Point(0, 319);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new System.Drawing.Size(693, 353);
            universalGrid1.TabIndex = 107;
            universalGrid1.Grid.MouseClick += universalGrid1_CellClick;
            Controls.Add(universalGrid1);
            ComboBoxListFill.GetLookupAd(_cache.rolList, ref clbRol);
            ComboBoxListFill.GetLookupAd(_cache.personelList, ref clbPersonel);
        }

        private void universalGrid1_CellClick(object sender, MouseEventArgs e)
        {
            try
            {
                KullaniciDTO kullaniciDTO = (KullaniciDTO)universalGrid1.Grid.CurrentRow.DataBoundItem;
                kullanici = ConvertHelper.ToEntity<Kullanici>(kullaniciDTO);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private Kullanici _kullanici;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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
            ctbId.DataBindings.Add(nameof(ctbId.TextCustom),kullanici,$"{nameof(kullanici.Id)}",true,DataSourceUpdateMode.OnPropertyChanged);
            ctbKullaniciAd.DataBindings.Add(nameof(ctbKullaniciAd.TextCustom), kullanici, $"{nameof(kullanici.ad)}", true, DataSourceUpdateMode.OnPropertyChanged);
            ctbSifre.DataBindings.Add(nameof(ctbSifre.TextCustom), kullanici, $"{nameof(kullanici.sifre)}", true, DataSourceUpdateMode.OnPropertyChanged);
            ctbSifreTekrar.DataBindings.Add(nameof(ctbSifreTekrar.TextCustom), kullanici, $"{nameof(kullanici.sifre)}", true, DataSourceUpdateMode.OnPropertyChanged);
            clbPersonel.DataBindings.Add(nameof(clbPersonel.SelectedValue), kullanici.personel, $"{nameof(kullanici.personel.Id)}", true, DataSourceUpdateMode.OnPropertyChanged);
            clbRol.DataBindings.Add(nameof(clbRol.SelectedValue), kullanici.rol, $"{nameof(kullanici.rol.Id)}", true, DataSourceUpdateMode.OnPropertyChanged);
        }
        private int? _kullaniciId { get; set; }
        private void rButtonKullaniciKaydet_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;
            try
            {
                string hashedPassword = _passwordService.HashPassword(kullanici.sifre).CombinedHash;
                kullanici.sifre = hashedPassword;
                kullanici.isSifreDegisti = false;
                string jsonResult = _kullaniciYetkiService.SaveKullanici(kullanici);
                if (String.IsNullOrEmpty(jsonResult) || jsonResult.Contains("error", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show(jsonResult);
                        
                    
                }
                else
                {
                    kullanici = JsonConvert.DeserializeObject<List<Kullanici>>(jsonResult).FirstOrDefault();
                    if (!_cache.kullaniciList.Any(x => x.Id == kullanici.Id))
                    {
                        _cache.kullaniciList.Add(kullanici);
                    }
                    IMailHandler mailHandler = new MailHandler();
                    mailHandler.SendMail(kullanici.personel.mail, "ERP şifreniz değiştirildi", "");
                    KullaniciKayitFormu_Load(sender, e);
                    MessageBox.Show("Kayıt başarılı");
                }
                    kullanici.sifre = "";
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
            isValid &= GlobalData.CheckField("Bu alan boş olamaz", ctbKullaniciAd);
            isValid &= GlobalData.CheckField("Bu alan boş olamaz", clbPersonel);
            isValid &= GlobalData.CheckField("Bu alan boş olamaz", ctbSifre);
            isValid &= GlobalData.CheckField("Bu alan boş olamaz", ctbSifreTekrar);
            isValid &= GlobalData.CheckField("Bu alan boş olamaz", clbRol);
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
