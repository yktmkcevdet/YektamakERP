using ApiService.Interfaces;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Utilities.Interfaces;
using YektamakDesktop.Common;

namespace YektamakDesktop.Formlar.Genel
{
    public partial class MailAyarlarim : Form
    {
        private readonly ICache _cache;
        private readonly IKullaniciYetkiService _kullaniciYetkiService;
        private readonly IPasswordService _passwordService;
        public MailAyarlarim(ICache cache, IKullaniciYetkiService kullaniciYetkiService, IPasswordService passwordService)
        {
            _cache = cache;
            _kullaniciYetkiService = kullaniciYetkiService;
            _passwordService = passwordService;
            InitializeComponent();
            Initialize();
        }
        private MailAdres _mail;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MailAdres mailAdres
        {
            get { if (_mail == null) { _mail = new(); } if (!string.IsNullOrEmpty(_mail.sifre)) { _mail.sifre = _passwordService.HashPassword(_mail.sifre).CombinedHash; } return _mail; }
            set { _mail = value; Binding(); }
        }
        private void Initialize()
        {
            Binding();
        }
        private void Binding()
        {
            BindHelper.BindData(ctbMailId, mailAdres, nameof(mailAdres.Id));
            BindHelper.BindData(ctbSmtpServer, mailAdres, nameof(mailAdres.smtpServer));
            BindHelper.BindData(ctbPort, mailAdres, nameof(mailAdres.port));
            BindHelper.BindData(ctbKullaniciAdi, mailAdres, nameof(mailAdres.adres));
            BindHelper.BindData(ctbSifre, mailAdres, nameof(mailAdres.sifre));
            BindHelper.BindData(chkSSL, mailAdres, nameof(mailAdres.SSL));
        }

        private async void customButtonSave1_SaveButtonClick(object sender, EventArgs e)
        {
            if (CheckFields())
            {
                string jsonResult = await _kullaniciYetkiService.SaveMailAdres(mailAdres);
                mailAdres = JsonConvert.DeserializeObject<List<MailAdres>>(jsonResult)[0];
                (await _cache.mailAdresList).Clear();
            }
        }
        private bool CheckFields()
        {
            bool result = true;
            result = GlobalData.CheckField("*", ctbKullaniciAdi) && result;
            result = GlobalData.CheckField("*", ctbSifre) && result;
            result = GlobalData.CheckField("*", ctbSmtpServer) && result;
            result = GlobalData.CheckField("*", ctbPort) && result;
            return result;
        }

        private void MailAyarlarim_Load(object sender, EventArgs e)
        {
            mailAdres = _cache.kullanici.mailAdres; 
        }
    }
}
