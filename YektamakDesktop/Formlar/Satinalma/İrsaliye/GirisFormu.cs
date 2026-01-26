using ApiService.Implementations;
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
using Utilities.Implementations;
using Utilities.Interfaces;
using YektamakDesktop.Common;
using YektamakDesktop.CustomControls;

namespace YektamakDesktop.Formlar.Satinalma.İrsaliye
{
    public partial class GirisFormu : Form
    {
        private readonly ICache _cache;
        private readonly ISatinalmaSiparisService _satinalmaSiparisService;
        private readonly IConvertHelper _convertHelper;
        public GirisFormu(ICache cache, ISatinalmaSiparisService satinalmaSiparisService, IConvertHelper convertHelper)
        {
            _convertHelper = convertHelper;
            _cache = cache;
            _satinalmaSiparisService = satinalmaSiparisService;
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
            universalGrid1.SetData(new List<Models.DTO.SatinalmaSiparisDetayDTO>(), this.Name);
            fcbFirma.SetDataSource(_cache.firmaList);
        }

        private async void GirisFormu_Load(object sender, EventArgs e)
        {
            var satinalmaSiparisList = await _satinalmaSiparisService.GetSatinalmaSiparisDetayAsync(new SatinalmaSiparisDetay());
            await universalGrid1.SetData(satinalmaSiparisList.CastToDTO<SatinalmaSiparisDetayDTO>(_convertHelper).ToList(), this.Name);
        }
    }
}
