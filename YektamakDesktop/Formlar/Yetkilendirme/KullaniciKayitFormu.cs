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
        private async void Initialize()
        {
            int sizeX = universalGrid1.Size.Width;
            int sizeY = universalGrid1.Size.Height;
            int locationY = universalGrid1.Location.Y;
            int locationX = universalGrid1.Location.X;
            Controls.Remove(universalGrid1);
            universalGrid1 = DIContainer.GetService<UniversalGrid>();
            universalGrid1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            universalGrid1.Location = new System.Drawing.Point(locationX, locationY);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new System.Drawing.Size(sizeX, sizeY);
            universalGrid1.TabIndex = 13;
            Controls.Add(universalGrid1);
            universalGrid1.MouseDown1 += universalGrid1_CellClick;
            universalGrid1.SetData(new List<KullaniciDTO>(), this.Name);
            ComboBoxListFill.GetLookupAd(_cache.rolList, ref clbRol);
            ComboBoxListFill.GetLookupAd(_cache.personelList, ref clbPersonel);
            fcbMailAdres.SetDataSource(await _cache.mailAdresList);
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
                Binding();
            }
        }
        private void Binding()
        {
            BindHelper.BindData(ctbId, kullanici, nameof(kullanici.Id));
            BindHelper.BindData(ctbKullaniciAd, kullanici, nameof(kullanici.ad));
            BindHelper.BindData(ctbSifre, kullanici, nameof(kullanici.sifre));
            BindHelper.BindData(clbPersonel, kullanici.personel, nameof(kullanici.personel.Id));
            BindHelper.BindData(clbRol, kullanici.rol, nameof(kullanici.rol.Id));
            BindHelper.BindData(fcbMailAdres, kullanici.mailAdres, nameof(kullanici.mailAdres.Id));
        }
        private void rButtonKullaniciKaydet_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;
            try
            {
                if (!string.IsNullOrEmpty(kullanici.sifre))
                {
                    string hashedPassword = _passwordService.HashPassword(kullanici.sifre).CombinedHash;
                    kullanici.sifre = hashedPassword;
                    kullanici.isSifreDegisti = false;
                }
                
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
                    if (!string.IsNullOrEmpty(kullanici.sifre))
                    {
                        IMailHandler mailHandler = new MailHandler();
                        mailHandler.SendSystemMail(kullanici.personel.mail, "ERP şifreniz değiştirildi", "");
                    }
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
            //isValid &= GlobalData.CheckField("Bu alan boş olamaz", ctbSifre);
            //isValid &= GlobalData.CheckField("Bu alan boş olamaz", ctbSifreTekrar);
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
