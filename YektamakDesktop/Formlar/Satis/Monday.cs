using ApiService.Interfaces;
using Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities.Interfaces;
using YektamakDesktop.Common;
using YektamakDesktop.CustomControls;

namespace YektamakDesktop.Formlar.Satis
{
    public partial class Monday : Form
    {
        private readonly ISatisService _satisService;
        private readonly ICache _cache;
        public Monday(ISatisService satisService, ICache cache)
        {
            _satisService = satisService;
            _cache = cache;
            this.Shown += Form1_Shown;
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
            universalGrid1.SetData(new List<MondayTeklif>(), this.Name);
        }
        

        private async void Monday_Load(object sender, EventArgs e)
        {
        }
        private void Monday_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void Monday_FormClosing(object sender, FormClosingEventArgs e)
        {
            universalGrid1.SaveSettings();
        }
        private async Task VerileriYukleAsync()
        {
            try
            {
                List<MondayTeklif> teklifler = await _satisService.GetMondayTeklif();
                universalGrid1.SetData(teklifler, this.Name);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }
        private async void Form1_Shown(object sender, EventArgs e)
        {
            await VerileriYukleAsync();
        }
    }
}
