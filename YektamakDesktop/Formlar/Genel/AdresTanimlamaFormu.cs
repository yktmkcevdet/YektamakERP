using ApiService.Interfaces;
using Models;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YektamakDesktop.Common;
using YektamakDesktop.CustomControls;

namespace YektamakDesktop.Formlar.Genel
{
    public partial class AdresTanimlamaFormu : Form
    {
        private readonly IFirmaService _firmaService;
        public AdresTanimlamaFormu(IFirmaService firmaService)
        {
            _firmaService = firmaService;
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
            universalGrid1.Location = new Point(locationX, locationY);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new Size(sizeX, sizeY);
            universalGrid1.TabIndex = 13;
            Controls.Add(universalGrid1);
            universalGrid1.SetData(new List<Adres>(), this.Name);
            universalGrid1.MouseDown1 += UniversalGrid1_MouseDown1;
            headerPanel1.Baslik = "Malzeme Grup Tanımlama";
            Binding();
        }

        private void UniversalGrid1_MouseDown1(object sender, MouseEventArgs e)
        {
            adres = (Adres)universalGrid1.Grid.CurrentRow.DataBoundItem;
            if(e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(universalGrid1, e.Location);
            }
        }

        private Adres _adres;
        private Adres adres
        {
            get { if (_adres == null) { _adres = new(); } return _adres; }
            set { _adres = value; Binding(); }
        }
        private void Binding()
        {
            BindHelper.BindData(ctbAdresId, adres, nameof(adres.Id));
            BindHelper.BindData(ctbUlke, adres, nameof(adres.ulke));
            BindHelper.BindData(ctbSehir, adres, nameof(adres.sehir));
            BindHelper.BindData(ctbIlce, adres, nameof(adres.ilce));
            BindHelper.BindData(ctbMahalle, adres, nameof(adres.mahalle));
            BindHelper.BindData(ctbSokak, adres, nameof(adres.sokak));
            BindHelper.BindData(ctbPostaKodu, adres, nameof(adres.postaKodu));
            BindHelper.BindData(ctbAcikAdres, adres, nameof(adres.acikAdres));
        }

        private void AdresTanimlamaFormu_Load(object sender, EventArgs e)
        {
            universalGrid1.SetData(_firmaService.GetAdres(new Adres()), this.Name);
        }

        private void adresSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var jsonString = _firmaService.DeleteAdres(adres);
            universalGrid1.binding.Remove(adres);
        }

        private void customButtonSave1_SaveButtonClick(object sender, EventArgs e)
        {
            universalGrid1.binding.Add(_firmaService.SaveAdres(adres).FirstOrDefault());
        }
        public void UpdateMode(Adres _adres)
        {
            adres = _adres;
        }
    }
}
