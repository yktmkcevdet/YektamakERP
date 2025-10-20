using Models;
using Models.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public LogoEntegrasyon(IJsonConverter jsonConverter)
        {
            _jsonConverter = jsonConverter;
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            this.Controls.Remove(universalGrid1);
            universalGrid1 = DIContainer.GetService<UniversalGrid>();
            universalGrid1.Location = new System.Drawing.Point(31, 196);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new System.Drawing.Size(1124, 498);
            universalGrid1.TabIndex = 0;
            this.Controls.Add(universalGrid1);
            universalGrid1.MouseDown1 += UniversalGrid1_MouseDown1; ;
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
            token = await LogoHelper.GetAccessTokenAsync("http://172.16.9.132:32001/api/v1/token", "OBJE", "OBJE", "226");
            var clCard = (LogoClCard)universalGrid1.Grid.CurrentRow.DataBoundItem;
            string itemListJSON = await LogoHelper.HttpGetAsync($"http://172.16.9.132:32001/api/v1/Arps/{clCard.LOGICALREF}", token);
            using JsonDocument doc = JsonDocument.Parse(itemListJSON);

            JsonElement root = doc.RootElement;
            var clCard1 = _jsonConverter.DeserializeObject<LogoCariKart>(itemListJSON);
        }
    }
}
