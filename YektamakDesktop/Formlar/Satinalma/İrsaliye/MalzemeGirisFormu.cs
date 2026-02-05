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
using YektamakDesktop.Helpers;

namespace YektamakDesktop.Formlar.Satinalma.İrsaliye
{
    public partial class MalzemeGirisFormu : Form
    {
        private readonly ICache _cache;
        private readonly ISatinalmaSiparisService _satinalmaSiparisService;
        private readonly IConvertHelper _convertHelper;
        public MalzemeGirisFormu(ICache cache, ISatinalmaSiparisService satinalmaSiparisService, IConvertHelper convertHelper)
        {
            _convertHelper = convertHelper;
            _cache = cache;
            _satinalmaSiparisService = satinalmaSiparisService;
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            UniversalGridHelper.Replace(ref universalGrid1,this);
            universalGrid1.SetData(new List<SatinalmaSiparisDetayDTO>(), this.Name);
            fcbFirma.SetDataSource(_cache.firmaList);
        }

        private async void GirisFormu_Load(object sender, EventArgs e)
        {
            var satinalmaSiparisList = await _satinalmaSiparisService.GetSatinalmaSiparisDetayAsync(new SatinalmaSiparisDetay());
            await universalGrid1.SetData(satinalmaSiparisList.CastToDTO<SatinalmaSiparisDetayDTO>(_convertHelper).ToList(), this.Name);
        }
    }
}
