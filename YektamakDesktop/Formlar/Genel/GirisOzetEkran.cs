using ApiService.Interfaces;
using Models;
using System;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using YektamakDesktop.Formlar.Satinalma;

namespace YektamakDesktop.Formlar.Genel
{
    public partial class GirisOzetEkran : Form
    {
        private readonly ISatinalmaTalepService _satinalmaTalepService;
        private readonly ICache _cache;
        public GirisOzetEkran(ISatinalmaTalepService satinalmaTalepService, ICache cache)
        {
            _satinalmaTalepService = satinalmaTalepService;
            _cache = cache;
            InitializeComponent();
        }
        private async void GirisOzetEkran_Load(object sender, EventArgs e)
        {
            int x = 20;
            int y = 20;
            this.Controls.Clear();
            var satinalmaTaleps = await _satinalmaTalepService.GetSatinalmaTalep(new SatinalmaTalep());
            Label lblHosgeldiniz = new Label();
            lblHosgeldiniz.Text = $"Hoşgeldiniz {_cache.kullanici.ad} ";
            lblHosgeldiniz.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            lblHosgeldiniz.ForeColor = System.Drawing.Color.DarkGreen;
            lblHosgeldiniz.Location = new System.Drawing.Point(x, y);
            y= lblHosgeldiniz.Location.Y + lblHosgeldiniz.Height + 10;
            lblHosgeldiniz.AutoSize = true;
            this.Controls.Add(lblHosgeldiniz);
            if (satinalmaTaleps.Any(s => s.onayKullanici.Id == _cache.kullanici.Id))
            {
                Label lblSatinalmaTalep = new Label();
                lblSatinalmaTalep.Text = $"Onaylayacağım Talepler {satinalmaTaleps.Count.ToString()}";
                lblSatinalmaTalep.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                lblSatinalmaTalep.ForeColor = System.Drawing.Color.DarkBlue;
                lblSatinalmaTalep.Cursor = Cursors.Hand;
                lblSatinalmaTalep.AutoSize = true;
                lblSatinalmaTalep.Location = new System.Drawing.Point(x, y);
                lblSatinalmaTalep.Click += (s, args) =>
                {
                    var mainForm = FormFactory.CreateForm<MainForm>();
                    Menu menuItem = new Menu
                    {
                        formAd = nameof(SatinalmaTalepler),
                        ad = "Satınalma Talepleri"
                    };
                    mainForm.OpenFormInTab(menuItem);
                };
                this.Controls.Add(lblSatinalmaTalep);
            }
        }
    }
}
