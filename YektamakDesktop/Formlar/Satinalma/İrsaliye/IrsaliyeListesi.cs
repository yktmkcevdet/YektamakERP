using ApiService.Interfaces;
using Models;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Utilities.Implementations;
using Utilities.Interfaces;
using YektamakDesktop.Helpers;

namespace YektamakDesktop.Formlar.Satinalma.İrsaliye
{
    public partial class IrsaliyeListesi : Form
    {
        private readonly ISatinalmaIrsaliyeService _satinalmaIrsaliyeService;
        private readonly IConvertHelper _convertHelper;
        public IrsaliyeListesi(ISatinalmaIrsaliyeService satinalmaIrsaliyeService, IConvertHelper convertHelper)
        {
            _satinalmaIrsaliyeService = satinalmaIrsaliyeService;
            _convertHelper = convertHelper;
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            UniversalGridHelper.Replace(ref universalGrid1, this);
            universalGrid1.SetData(new List<SatinalmaIrsaliyeBaslikDTO>(), this.Name);
            universalGrid1.MouseDown1 += UniversalGrid1_MouseDown1;
        }

        private void UniversalGrid1_MouseDown1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hit = universalGrid1.Grid.HitTest(e.X, e.Y);
                if (hit.RowIndex >= 0)
                {
                    universalGrid1.Grid.ClearSelection();
                    universalGrid1.Grid.Rows[hit.RowIndex].Selected = true;
                    contextMenuStrip1.Show(universalGrid1.Grid, e.Location);
                }
            }
        }

        private async void IrsaliyeListesi_Load(object sender, EventArgs e)
        {
            var result = await _satinalmaIrsaliyeService.GetSatinalmaIrsaliye(new SatinalmaIrsaliyeBaslik());
            if (result == null)
            {
                universalGrid1.SetData(new List<SatinalmaIrsaliyeBaslikDTO>(), this.Name);
            }
            else
            {
                universalGrid1.SetData(result.CastToDTO<SatinalmaIrsaliyeBaslikDTO>(_convertHelper).ToList(), this.Name);
            }
        }

        private async void irsaiyeyiSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selected = (SatinalmaIrsaliyeBaslikDTO)universalGrid1.Grid.CurrentRow.DataBoundItem;
            if (selected != null)
            {
                var dialogResult = MessageBox.Show($"{selected.irsaliyeNo} numaralı irsaliye silinecektir. Onaylıyor musunuz?", "Onay", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    var result = await _satinalmaIrsaliyeService.DeleteSatinalmaIrsaliye(_convertHelper.ToEntity<SatinalmaIrsaliyeBaslik>(selected));
                    if (!string.IsNullOrEmpty(result) && !result.Contains("error", StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show("İrsaliye başarıyla silindi.");
                        IrsaliyeListesi_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show($"İrsaliye silinirken bir hata oluştu.\r\n{result}");
                    }
                }
            }
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            IrsaliyeListesi_Load(null,null);
        }
    }
}
