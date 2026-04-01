using ApiService.Interfaces;
using Models;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using YektamakDesktop.Formlar.ProjeModul;
using YektamakDesktop.Formlar.Satinalma;

namespace YektamakDesktop.Formlar.Genel
{
    public partial class GirisOzetEkran : Form
    {
        private readonly ISatinalmaTalepService _satinalmaTalepService;
        private readonly IProjeService _projeService;
        private readonly ICache _cache;
        public GirisOzetEkran(ISatinalmaTalepService satinalmaTalepService, ICache cache, IProjeService projeService)
        {
            _satinalmaTalepService = satinalmaTalepService;
            _cache = cache;
            _projeService = projeService;
            InitializeComponent();
        }
        private async void GirisOzetEkran_Load(object sender, EventArgs e)
        {
            int x = 20;
            int y = 20;
            this.Controls.Clear();
            var satinalmaTaleps = await _satinalmaTalepService.GetSatinalmaTalep(new SatinalmaTalep());
            var projeStokKarts = await _projeService.GetProjeStokKart(new ProjeStokKart());
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
                y = y + 30;
                lblSatinalmaTalep.Click += (s, args) =>
                {
                    var mainForm = FormFactory.CreateForm<MainForm>();
                    Menu menuItem = new Menu
                    {
                        formAd = nameof(SatinalmaTalepOnayFormu),
                        ad = "SatinalmaTalepOnayFormu"
                    };
                    mainForm.OpenFormInTab(menuItem);
                };
                this.Controls.Add(lblSatinalmaTalep);
            }
            if (satinalmaTaleps.Any(s => s.onayDurum == true) && _cache.kullanici.Id==35)
            {
                Label lblSatinalmaOnayliTalep = new Label();
                lblSatinalmaOnayliTalep.Text = $"Onaylanmış Talepler ({satinalmaTaleps.Count.ToString()})";
                lblSatinalmaOnayliTalep.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(162)));
                lblSatinalmaOnayliTalep.ForeColor = Color.DarkBlue;
                lblSatinalmaOnayliTalep.Cursor = Cursors.Hand;
                lblSatinalmaOnayliTalep.AutoSize = true;
                lblSatinalmaOnayliTalep.Location = new Point(x, y);
                y = y + 30;
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
            if (projeStokKarts.Any(p=> p.isSatinalma==false && _cache.projeList.Any(l=>l.Id==p.proje.Id && l.sorumluList.Any(s=>s.personel.Id==_cache.kullanici.Id))))
            {
                Label lblProjeDosyalari = new Label();
                lblProjeDosyalari.Text = $"Satınalma talebi açılacak projeler ({projeStokKarts.Where(p => _cache.projeList.Any(l =>l.sorumluList.Any(s => s.personel.Id == _cache.kullanici.personel.Id) && l.Id == p.proje.Id) && p.isSatinalma == false).GroupBy(p=>p.proje.Id).ToList().Count.ToString()})";
                lblProjeDosyalari.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(162)));
                lblProjeDosyalari.ForeColor = Color.DarkBlue;
                lblProjeDosyalari.Cursor = Cursors.Hand;
                lblProjeDosyalari.AutoSize = true;
                lblProjeDosyalari.Location = new Point(x, y);
                y = y + 30;
                this.Controls.Add(lblProjeDosyalari);
                foreach (var proje in projeStokKarts.Where(p => _cache.projeList.Any(l => l.sorumluList.Any(s => s.personel.Id == _cache.kullanici.personel.Id) && l.Id == p.proje.Id) && p.isSatinalma == false && p.stokKart.dosyaList.Any(d=>d.onaySonucu==true)).GroupBy(p => p.proje.Id))
                {
                    Label lblProje = new Label();
                    lblProje.Text = $" - {proje.FirstOrDefault().proje.kod}";
                    lblProje.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(162)));
                    lblProje.ForeColor = Color.DarkBlue;
                    lblProje.Cursor = Cursors.Hand;
                    lblProje.AutoSize = true;
                    lblProje.Location = new Point(x + 20, y);
                    y = y + 30;
                    lblProje.Click += (s, args) =>
                    {
                        var mainForm = FormFactory.CreateForm<MainForm>();
                        Menu menuItem = new Menu
                        {
                            formAd = nameof(ProjeDosyalari),
                            ad = "ProjeDosyalari",
                            args = proje.FirstOrDefault().proje.Id
                        };
                        mainForm.OpenFormInTab(menuItem);
                    };
                    this.Controls.Add(lblProje);
                }
            }
        }
    }
}
