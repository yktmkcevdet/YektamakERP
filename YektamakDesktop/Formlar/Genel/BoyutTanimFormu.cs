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
        private readonly IAnaVeriService _anaVerisService;
        public BoyutTanimFormu(ICache cache, IAnaVeriService anaVeriService)
        {
            _cache = cache;
            _anaVerisService = anaVeriService;
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
            universalGrid1.SetData(new List<Boyut>(), this.Name);
            fcbMalzemeAltGrup.SetDataSource(_cache.malzemeAltGrups);
            fcbMalzemeAltGrup2.SetDataSource(_cache.malzemeAltGrup2List);
            fcbMalzemeGrup.SetDataSource(_cache.malzemeGrups);
        }

        private void UniversalGrid1_MouseDown1(object sender, MouseEventArgs e)
        {
            boyut = (Boyut)universalGrid1.Grid.CurrentRow.DataBoundItem;
        }

        private Boyut _boyut;
        private Boyut boyut { get { if (_boyut == null) { _boyut = new(); }; return _boyut; } set { _boyut = value; Binding(); } }
        private void Binding()
        {
            BindHelper.BindData(ctbId, boyut, nameof(boyut.Id));
            BindHelper.BindData(ctbKod, boyut, nameof(boyut.kod));
            BindHelper.BindData(ctbAd, boyut, nameof(boyut.ad));
            BindHelper.BindData(fcbMalzemeGrup, boyut, nameof(boyut.malzemeGrupId));
            BindHelper.BindData(fcbMalzemeAltGrup, boyut, nameof(boyut.malzemeAltGrupId));
            BindHelper.BindData(fcbMalzemeAltGrup2, boyut, nameof(boyut.malzemeAltGrup2Id));
            BindHelper.BindData(ctbKlasor, boyut, nameof(boyut.klasorAd));
            BindHelper.BindData(ctbPath, boyut, nameof(boyut.path));
        }

        private void BoyutTanimFormu_Load(object sender, System.EventArgs e)
        {
            GridDoldur();
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            _anaVerisService.SaveBoyut(boyut);
            _cache.boyutList = null;
        }
        private void btnNew_Click(object sender, System.EventArgs e)
        {
            boyut = new Boyut();
        }
        private void GridDoldur()
        {
            universalGrid1.SetData(_cache.boyutList, this.Name);
        }
    }
}
