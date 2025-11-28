using ApiService.Interfaces;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities.Interfaces;
using YektamakDesktop.Common;

namespace YektamakDesktop.Formlar.Genel
{
    public partial class MailAyarlarim : Form
    {
        private readonly ICache _cache;
        private readonly IKullaniciYetkiService _kullaniciYetkiService;
        public MailAyarlarim(ICache cache, IKullaniciYetkiService kullaniciYetkiService)
        {
            _cache = cache;
            _kullaniciYetkiService = kullaniciYetkiService;
            InitializeComponent();
            Initialize();
        }
        private MailAdres _mailAdres;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MailAdres mailAdres
        {
            get { if (_mailAdres == null) { _mailAdres = new(); } return _mailAdres; }
            set {   _mailAdres = value; }
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

        private async Task MailAyarlarim_Load(object sender, EventArgs e)
        {
            mailAdres = _cache.kullanici.mailAdres; 
            if(mailAdres.Id==null)
            {
                ctbSmtpServer.TextCustom = "smtp-mail.outlook.com";
                ctbPort.TextCustom = "587";
                chkSSL.Checked = true;
            }
        }
    }
}
