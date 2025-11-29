using ApiService.Interfaces;
using Models;
using Models.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities.Interfaces;
using YektamakDesktop.Common;
using YektamakDesktop.CustomControls;

namespace YektamakDesktop.Formlar.Genel
{
    public partial class MailAyarlari : Form
    {
        private readonly ICache _cache;
        private readonly IKullaniciYetkiService _kullaniciYetkiService;
        private readonly IPasswordService _passwordService;
        public MailAyarlari(ICache cache, IKullaniciYetkiService kullaniciYetkiService,IPasswordService passwordService)
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
            universalGrid1.SetData(new List<MailAdres>(), this.Name);
            headerPanel1.Baslik = "Malzeme Grup Tanımlama";
            this.Load += async (s, e) => await MailAyarlari_Load(s, e);
            universalGrid1.MouseDown1 += UniversalGrid1_MouseDown1;
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
        private async Task MailAyarlari_Load(object sender, EventArgs e)
        {
            await universalGrid1.SetData(JsonConvert.DeserializeObject<List<MailAdres>>(await _kullaniciYetkiService.GetMailAdres(new MailAdres())), this.Name);
        }
        private void UniversalGrid1_MouseDown1(object sender, MouseEventArgs e)
        {
            mailAdres = (MailAdres)universalGrid1.Grid.CurrentRow.DataBoundItem;
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(universalGrid1, e.Location);
            }
        }

        private async void customButtonSave1_SaveButtonClick(object sender, EventArgs e)
        {
            if (CheckFields())
            {
                string jsonResult = await _kullaniciYetkiService.SaveMailAdres(mailAdres);
                mailAdres = JsonConvert.DeserializeObject<List<MailAdres>>(jsonResult)[0];
                (await _cache.mailAdresList).Clear();
                universalGrid1.SetData(JsonConvert.DeserializeObject<List<MailAdres>>(jsonResult), this.Name);
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

        private async void mailTanımınıSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string jsonString = await _kullaniciYetkiService.DeleteMailAdres(mailAdres);
            if(!jsonString.Contains("error",StringComparison.OrdinalIgnoreCase) || !String.IsNullOrEmpty(jsonString))
            {
                universalGrid1.binding.Remove(mailAdres);
            }
        }
    }
}
