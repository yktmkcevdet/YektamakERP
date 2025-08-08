using ApiService.Interfaces;
using Models;
using Models.DTO;
using Models.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Utilities.Interfaces;
using YektamakDesktop.Common;

namespace YektamakDesktop.Formlar.Satinalma
{
    public partial class SatinalmaTalepler : Form, IForm
    {
        private static ISatinalmaTalepService _satinalmaService;
        private static IJsonConverter _jsonConverter;
        private static ICache _cache;
        public SatinalmaTalepler(ISatinalmaTalepService satinalmaService, IJsonConverter jsonConverter, ICache cache)
        {
            _satinalmaService = satinalmaService;
            _jsonConverter = jsonConverter;
            _cache = cache;
            InitializeComponent();
            Binding();
        }

        private async void Binding()
        {
            await universalGrid1.SetData(satinalmaTalepDTOs, this.Name, false);
        }

        private List<SatinalmaTalepDetayDTO> _satinalmaTalepDTOs;
        public List<SatinalmaTalepDetayDTO> satinalmaTalepDTOs
        {
            get
            {
                if (_satinalmaTalepDTOs == null)
                {
                    _satinalmaTalepDTOs = new List<SatinalmaTalepDetayDTO>();
                }
                return _satinalmaTalepDTOs;
            }
            set
            {
                Binding();
                _satinalmaTalepDTOs = value;
            }
        }
        private List<Control> _controlsToDisable;
        public List<Control> controlsToDisable { get => _controlsToDisable; set => _controlsToDisable = value; }
        private bool _activeForm;
        public bool activeForm { get => _activeForm; set => _activeForm = value; }

        private SatinalmaTalep _satinalmaTalepFilter;
        private SatinalmaTalep satinalmaTalepFilter
        {
            get
            {
                if (_satinalmaTalepFilter == null)
                {
                    _satinalmaTalepFilter = new SatinalmaTalep();
                }
                return _satinalmaTalepFilter;
            }
            set { _satinalmaTalepFilter = value; }
        }
        private async void SatinalmaTalepler_Load(object sender, EventArgs e)
        {
            string jsonresult = await _satinalmaService.GetSatinalmaTalep(satinalmaTalepFilter);
            Result result = _jsonConverter.DeserializeToModelList<Result>(jsonresult)[0];
            if (result.result != null)
            {
                List<SatinalmaTalep> satinalmaTaleps = _jsonConverter.ToModelList<SatinalmaTalep>(result.result);
                List<SatinalmaTalepDTO> satinalmaTalepDTOs = new List<SatinalmaTalepDTO>();
                foreach (var item in satinalmaTaleps)
                {
                    satinalmaTalepDTOs.Add(ConvertHelper.ToDTO<SatinalmaTalepDTO>(item));
                }
                universalGrid1.SetData(satinalmaTalepDTOs, this.Name, false);
            }
        }
        private async void talebiOnaylaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            satinalmaTalepFilter = ConvertHelper.ToEntity<SatinalmaTalep>((SatinalmaTalepDTO)universalGrid1.binding.Current);
            satinalmaTalepFilter.onayKullanici.Id = _cache.kullanici.Id;
            string result = await _satinalmaService.SatinalmaTalepOnay(satinalmaTalepFilter);
            Result resultModel = _jsonConverter.DeserializeToModelList<Result>(result).FirstOrDefault();
            MessageBox.Show(resultModel.result);
        }
        private async void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1) return;
                if (e.ColumnIndex == universalGrid1.Grid.Rows[e.RowIndex].Cells["Guncelle"].ColumnIndex || e.ColumnIndex == universalGrid1.Grid.Rows[e.RowIndex].Cells["Sil"].ColumnIndex)
                {
                    if (universalGrid1.Grid.Rows[e.RowIndex].Cells[1].Value == null)
                        return;
                    var satinalmaTalepDTO = (SatinalmaTalepDTO)universalGrid1.Grid.CurrentRow.DataBoundItem;
                    //var aaa = (SatinalmaTeklifBaslikDTO)universalGrid1.binding.Current;
                    SatinalmaTalep satinalmaTalep = ConvertHelper.ToEntity<SatinalmaTalep>(satinalmaTalepDTO);
                    if (e.ColumnIndex == universalGrid1.Grid.Rows[e.RowIndex].Cells["Guncelle"].ColumnIndex)//Update
                    {
                        SatinalmaTalepOlusturmaFormu satinalmaTalepKayitFormu = FormFactory.CreateForm<SatinalmaTalepOlusturmaFormu>();
                        satinalmaTalepKayitFormu.UpdateMode(satinalmaTalep);
                        satinalmaTalepKayitFormu.Show();
                    }
                    if (e.ColumnIndex == universalGrid1.Grid.Rows[e.RowIndex].Cells["Sil"].ColumnIndex)//Sil
                    {
                        var onay = MessageBox.Show("Talebi silmek istediğinizden emin misiniz", "Talep Silme Onay", MessageBoxButtons.YesNo);
                        if (onay == DialogResult.Yes)
                        {
                            string jsonResult = await _satinalmaService.DeleteSatinalmaTalep(satinalmaTalep);
                            Result result = _jsonConverter.DeserializeToModelList<Result>(jsonResult).FirstOrDefault();
                            MessageBox.Show(result.result);
                            universalGrid1.binding.RemoveAt(e.RowIndex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}");
            }
        }

        private void SatinalmaTalepler_FormClosing(object sender, FormClosingEventArgs e)
        {
            universalGrid1.SaveSettings();
        }

        private void görüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var satinalmaTalepDTO = (SatinalmaTalepDTO)universalGrid1.Grid.CurrentRow.DataBoundItem;
            SatinalmaTalep satinalmaTalep = ConvertHelper.ToEntity<SatinalmaTalep>(satinalmaTalepDTO);
            SatinalmaTalepKayitFormu satinalmaTalepKayitFormu = FormFactory.CreateForm<SatinalmaTalepKayitFormu>();
            satinalmaTalepKayitFormu.UpdateMode(satinalmaTalep);
            satinalmaTalepKayitFormu.Show();
        }

        private void universalGrid1_MouseDown1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(universalGrid1.Grid, e.Location);
            }
        }

        private async void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var satinalmaTalepDTO = (SatinalmaTalepDTO)universalGrid1.Grid.CurrentRow.DataBoundItem;
            SatinalmaTalep satinalmaTalep = ConvertHelper.ToEntity<SatinalmaTalep>(satinalmaTalepDTO);
            if(satinalmaTalep.talepEdenKullanici.Id != _cache.kullanici.Id)
            {
                MessageBox.Show("Bu talebi sadece talep eden silebilir.");
                return;
            }
            var onay = MessageBox.Show("Talebi silmek istediğinizden emin misiniz", "Talep Silme Onay", MessageBoxButtons.YesNo);
            if (onay == DialogResult.Yes)
            {
                string jsonResult = await _satinalmaService.DeleteSatinalmaTalep(satinalmaTalep);
                Result result = _jsonConverter.DeserializeToModelList<Result>(jsonResult).FirstOrDefault();
                if (result?.result!=null && result.result.Contains(satinalmaTalep.satinalmaTalepNo, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show(result.result);
                    universalGrid1.binding.RemoveAt(universalGrid1.Grid.CurrentRow.Index);
                }
                else
                {
                    MessageBox.Show("Silme işlemi başarısız"+result.result);
                }
            }
        }
    }
}
