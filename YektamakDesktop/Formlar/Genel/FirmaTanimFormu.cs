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
using System.Windows.Media.TextFormatting;
using YektamakDesktop.Common;
using YektamakDesktop.CustomControls;

namespace YektamakDesktop.Formlar.Genel
{
    public partial class FirmaTanimFormu : Form
    {
        private readonly IFirmaService _firmaService;
        public FirmaTanimFormu(IFirmaService firmaService)
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
            universalGrid1.SetData(new List<Firma>(), this.Name);
            fcbAdres.SetDataSource(_firmaService.GetAdres(new Adres()));
            universalGrid1.MouseDown1 += UniversalGrid1_MouseDown1;
        }

        private void UniversalGrid1_MouseDown1(object sender, MouseEventArgs e)
        {
            firma = (Firma)universalGrid1.Grid.CurrentRow.DataBoundItem;
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(universalGrid1, e.Location);
            }
        }

        private Firma _firma;
        private Firma firma
        {
            get { if (_firma == null) { _firma = new(); } return _firma; }
            set { _firma = value; Binding(); }
        }
        private void Binding()
        {
            BindHelper.BindData(ctbFirmaId, firma, nameof(firma.Id));
            BindHelper.BindData(ctbFirmaAd, firma, nameof(firma.ad));
            BindHelper.BindData(ctbFirmaKod, firma, nameof(firma.kod));
            BindHelper.BindData(ctbTelefon, firma, nameof(firma.telefon));
            BindHelper.BindData(ctbFaks, firma, nameof(firma.faks));
            BindHelper.BindData(ctbMail, firma, nameof(firma.mail));
            BindHelper.BindData(ctbVergiDairesi, firma, nameof(firma.vergiDairesi));
            BindHelper.BindData(ctbVergiNumarasi, firma, nameof(firma.vergiNumarasi));
        }

        private void FirmaTanimFormu_Load(object sender, EventArgs e)
        {
            universalGrid1.SetData(_firmaService.GetFirma(new Firma()), this.Name);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = FormFactory.CreateForm<AdresTanimlamaFormu>();
            if (fcbAdres.SelectedValue != null)
            {
                form.UpdateMode(_firmaService.GetAdres(new Adres { Id = int.TryParse(fcbAdres.SelectedValue.ToString(), out int adresId) ? adresId : null }).FirstOrDefault());
            }
            else
            {
                form.UpdateMode(new Adres());
            }
            form.ShowDialog();
        }

        private void customButtonSave1_SaveButtonClick(object sender, EventArgs e)
        {
            universalGrid1.binding.Add(_firmaService.SaveFirma(firma).FirstOrDefault());
        }

        private void firmaSilToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tbxFiltreFirmaAd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                universalGrid1.Filtrele(new Firma { ad = tbxFiltreFirmaAd.Text });
            }
        }
    }
}
