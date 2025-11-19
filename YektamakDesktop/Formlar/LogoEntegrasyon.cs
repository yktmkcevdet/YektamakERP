using ApiService.Interfaces;
using Models;
using Models.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text.Json;
using System.Windows.Forms;
using Utilities.Interfaces;
using YektamakDesktop.Common;
using YektamakDesktop.CustomControls;
using YektamakDesktop.Helpers;

namespace YektamakDesktop.Formlar
{
    public partial class LogoEntegrasyon : Form
    {
        private readonly IJsonConverter _jsonConverter;
        private readonly IFirmaService _firmaService;
        public LogoEntegrasyon(IJsonConverter jsonConverter, IFirmaService firmaService)
        {
            _firmaService = firmaService;
            _jsonConverter = jsonConverter;
            InitializeComponent();
            Initialize();
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
            universalGrid1.MouseDown1 += UniversalGrid1_MouseDown1;
            universalGrid1.SetData(new List<LogoClCard>(), this.Name);
        }

        private LogoClCard _logoClCard;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public LogoClCard logoClCard
        {
            get { return _logoClCard; }
            set { _logoClCard = value; }
        }

        private void UniversalGrid1_MouseDown1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(universalGrid1, e.Location);
            }
        }
        string token = "";
        private async void roundedButton1_Click(object sender, EventArgs e)
        {
            token = await LogoHelper.GetAccessTokenAsync("http://172.16.9.132:32001/api/v1/token", "OBJE", "OBJE", "226");

            string postUrl = "http://172.16.9.132:32001/api/v1/queries/unsafe";

            string JSSqlText = "\"SELECT * FROM LG_226_CLCARD\"";

            string result = await LogoHelper.HttpPostAsync(postUrl, JSSqlText, token);
            dynamic resJSON = JsonConvert.DeserializeObject(result.ToString());

            //string itemListJSON = await LogoHelper.HttpGetAsync("http://172.16.9.132:32001/api/v1/items?limit=10",token);
            using JsonDocument doc = JsonDocument.Parse(result);

            JsonElement root = doc.RootElement;
            JsonElement items = root.GetProperty("items");
            var list = _jsonConverter.DeserializeObject<List<LogoClCard>>(items.GetRawText());
            universalGrid1.SetData(list, this.Name);
        }

        private async void kaydıAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //token = await LogoHelper.GetAccessTokenAsync("http://172.16.9.132:32001/api/v1/token", "OBJE", "OBJE", "226");
            //var clCard = (LogoClCard)universalGrid1.Grid.CurrentRow.DataBoundItem;
            //string itemListJSON = await LogoHelper.HttpGetAsync($"http://172.16.9.132:32001/api/v1/Arps/{clCard.LOGICALREF}", token);
            //using JsonDocument doc = JsonDocument.Parse(itemListJSON);

            //JsonElement root = doc.RootElement;
            //var clCard1 = _jsonConverter.DeserializeObject<LogoCariKart>(itemListJSON);
            logoClCard = (LogoClCard)universalGrid1.Grid.CurrentRow.DataBoundItem;
            Firma firma = new Firma();
            firma.kod = logoClCard.CODE;
            firma.ad = logoClCard.DEFINITION_;
            firma.logoFirmaId = logoClCard.LOGICALREF;
            firma.vergiDairesi = logoClCard.TAXOFFICE;
            firma.vergiNumarasi = logoClCard.TAXNR;
            _firmaService.SaveFirma(firma);
        }

        private void ctbDefinition_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                universalGrid1.Focus();
                universalGrid1.Filtrele(new LogoClCard { DEFINITION_=ctbDefinition.TextCustom});
            }
        }
    }
}
