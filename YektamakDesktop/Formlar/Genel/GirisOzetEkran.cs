using ApiService.Interfaces;
using Models;
using System;
using System.Drawing;
using System.Linq;
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
            lblHosgeldiniz.Text = $"Hoşgeldiniz {_cache.kullanici.personel.adSoyad} ";
            lblHosgeldiniz.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(162)));
            lblHosgeldiniz.ForeColor = Color.DarkGreen;
            lblHosgeldiniz.Location = new Point(x, y);
            y= lblHosgeldiniz.Location.Y + lblHosgeldiniz.Height + 30;
            x = x + 30;
            lblHosgeldiniz.AutoSize = true;
            this.Controls.Add(lblHosgeldiniz);
            if (satinalmaTaleps.Any(s => s.onayKullanici.Id == _cache.kullanici.Id && s.onayDurum==null))
            {
                Label lblSatinalmaTalep = new Label();
                lblSatinalmaTalep.Text = $"Onaylayacağım Talepler ({satinalmaTaleps.Count.ToString()})";
                lblSatinalmaTalep.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(162)));
                lblSatinalmaTalep.ForeColor = Color.DarkBlue;
                lblSatinalmaTalep.Cursor = Cursors.Hand;
                lblSatinalmaTalep.AutoSize = true;
                lblSatinalmaTalep.Location = new Point(x, y);
                y = lblSatinalmaTalep.Height + 10;
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
            if (satinalmaTaleps.Any(s => s.onayDurum == true))
            {
                Label lblSatinalmaOnayliTalep = new Label();
                lblSatinalmaOnayliTalep.Text = $"Onaylanmış Talepler ({satinalmaTaleps.Count.ToString()})";
                lblSatinalmaOnayliTalep.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(162)));
                lblSatinalmaOnayliTalep.ForeColor = Color.DarkBlue;
                lblSatinalmaOnayliTalep.Cursor = Cursors.Hand;
                lblSatinalmaOnayliTalep.AutoSize = true;
                lblSatinalmaOnayliTalep.Location = new Point(x, y);
                y = lblSatinalmaOnayliTalep.Height + 10;
                lblSatinalmaOnayliTalep.Click += (s, args) =>
                {
                    var mainForm = FormFactory.CreateForm<MainForm>();
                    Menu menuItem = new Menu
                    {
                        formAd = nameof(SatinalmaTalepTeklifFormu),
                        ad = "Teklif Oluşturma"
                    };
                    mainForm.OpenFormInTab(menuItem);
                };
                this.Controls.Add(lblSatinalmaOnayliTalep);
            }
        }
    }
}
