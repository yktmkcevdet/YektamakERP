using ApiService.Interfaces;
using Models;
using Models.DTO;
using System.Collections.Generic;
using System.Windows.Forms;
using YektamakDesktop.Common;
using YektamakDesktop.CustomControls;

namespace YektamakDesktop.Formlar.Genel
{
    public partial class BoyutTanimFormu : Form
    {
        private readonly ICache _cache;
        public BoyutTanimFormu(ICache cache)
        {
            _cache = cache;
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            int sizeX = universalGrid1.Size.Width;
            int sizeY = universalGrid1.Size.Height;
            int locationY = universalGrid1.Location.Y;
            int locationX = universalGrid1.Location.X;
            int tabIndex = universalGrid1.TabIndex;
            Controls.Remove(universalGrid1);
            universalGrid1 = DIContainer.GetService<UniversalGrid>();
            universalGrid1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            universalGrid1.Location = new System.Drawing.Point(locationX, locationY);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new System.Drawing.Size(sizeX, sizeY);
            universalGrid1.TabIndex = tabIndex;
            Controls.Add(universalGrid1);
            universalGrid1.MouseDown1 += UniversalGrid1_MouseDown1;
            universalGrid1.SetData(_cache.boyutList, this.Name);

        }

        private void UniversalGrid1_MouseDown1(object sender, MouseEventArgs e)
        {
            boyut = (Boyut)universalGrid1.Grid.CurrentRow.DataBoundItem;
        }

        private Boyut _boyut;
        private Boyut boyut {  get { if (_boyut == null) { _boyut = new();  }; return _boyut; } set { _boyut = value; Binding(); } }
        private void Binding()
        {
            BindHelper.BindData(ctbId, boyut, nameof(boyut.Id));
            BindHelper.BindData(ctbKod, boyut, nameof(boyut.kod));
            BindHelper.BindData(ctbAd, boyut, nameof(boyut.ad));
            BindHelper.BindData(fcbMalzemeGrup, boyut, nameof(boyut.malzemeGrupId));
            BindHelper.BindData(fcbMalzemeAltGrup, boyut, nameof(boyut.malzemeAltGrupId));
            BindHelper.BindData(fcbMalzemeAltGrup2, boyut, nameof(boyut.malzemeAltGrup2Id));
        }
    }
}
