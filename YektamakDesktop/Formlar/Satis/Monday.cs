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

namespace YektamakDesktop.Formlar.Satis
{
    public partial class Monday : Form, IForm
    {
        private static ISatisService _satisService;
        private readonly ICache _cache;
        public Monday(ISatisService satisService, ICache cache)
        {
            _satisService = satisService;
            _cache = cache;
        }
        private Monday()
        {
            this.Shown += Form1_Shown;
            InitializeComponent();
        }
        private static Monday _monday;
        public static Monday monday
        {
            get
            {
                if (_monday == null || _monday.IsDisposed)
                {
                    _monday = new Monday();
                    GlobalData.Yetki(ref _monday);
                }
                return _monday;
            }
        }
        public List<Control> controlsToDisable { get; set; }
        public bool activeForm { get; set; }

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
                //dataGridView1.DataSource = teklifler;
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
