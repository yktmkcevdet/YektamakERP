using ApiService.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YektamakDesktop.Formlar.Satis
{
    public partial class Monday : Form, IForm
    {
        private static ISatisService _satisService;
        public Monday()
        {
            InitializeComponent();
            this.Shown += Form1_Shown;
        }
        public Monday(ISatisService satisService)
        {
            _satisService = satisService;
        }
        private static Monday _monday;
        public static Monday monday
        {
            get
            {
                if (_monday == null)
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
        private void CloseForm()
        {
            GlobalData.CloseForm(ref _monday);
        }

        private void Monday_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void Monday_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        private async Task VerileriYukleAsync()
        {
            try
            {
                var teklifler = await _satisService.GetMondayTeklif();
                dataGridView1.DataSource = teklifler;
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

        private void button1_Click(object sender, EventArgs e)
        {
            CloseForm();
        }
    }
}
