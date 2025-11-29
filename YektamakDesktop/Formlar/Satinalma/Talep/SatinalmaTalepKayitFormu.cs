using ApiService.Interfaces;
using Models;
using Models.DTO;
using Newtonsoft.Json;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities.Interfaces;
using YektamakDesktop.Common;
using YektamakDesktop.CustomControls;
using YektamakDesktop.Formlar.Stok;
using YektamakDesktop.Helpers;

namespace YektamakDesktop.Formlar.Satinalma
{
    public partial class SatinalmaTalepKayitFormu : Form
    {
        private readonly ICache _cache;
        private readonly ISatinalmaTalepService _satinalmaTalepService;
        private readonly IJsonConverter _jsonConverter;
        private readonly IProjeService _projeService;
        private readonly IAnaVeriService _anaVeriService;
        public SatinalmaTalepKayitFormu(ICache cache, ISatinalmaTalepService satinalmaTalepService, IJsonConverter jsonConverter, IProjeService projeService, IAnaVeriService anaVeriService)
        {
            _cache = cache;
            _satinalmaTalepService = satinalmaTalepService;
            _jsonConverter = jsonConverter;
            _projeService = projeService;
            _anaVeriService = anaVeriService;
            InitializeComponent();
            Initialize();
            clbProjeKodu.ReadOnly = true;
            ctbTalepTarihi.Enabled = false;
            ctbTalepNo.Enabled = false;
            clbKullaniciId.ReadOnly = true;
        }
        private async void Initialize()
        {
            Controls.Remove(universalGrid1);
            universalGrid1 = DIContainer.GetService<UniversalGrid>();
            universalGrid1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            universalGrid1.Location = new System.Drawing.Point(8, 270);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new System.Drawing.Size(1273, 474);
            universalGrid1.TabIndex = 124;
            universalGrid1.MouseDown1 += universalGrid1_MouseClick;
            Controls.Add(universalGrid1);
            fcbTalepNeden.SetDataSource(_cache.talepNedenList);
            clbKullaniciId.SetDataSource(_cache.kullaniciList.Select(k => k with { ad = k.personel.adSoyad }).ToList());
            clbProjeKodu.SetDataSource(_cache.projeList.Where(x => x.sorumluList.Where(s => s.Id == _cache.kullanici.personel.Id).Count() > 0).ToList());
            FormClosing += async (s, e) => await SatinalmaTalepKayitFormu_FormClosing(s, e);
            satinalmaTalep.talepEdenKullanici = _cache.kullanici;
            satinalmaTalep.talepTarihi = DateTime.Today;
            await universalGrid1.SetData(new List<SatinalmaTalepDetayDTO>(), this.Name, true);
        }
        public event EventHandler<SatinalmaTalepDTO> TalepOnaylandi;
        private SatinalmaTalep _satinalmaTalep;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SatinalmaTalep satinalmaTalep
        {
            get
            {
                if (_satinalmaTalep == null)
                {
                    _satinalmaTalep = new SatinalmaTalep();
                }
                return _satinalmaTalep;
            }
            set
            {
                _satinalmaTalep = value;
                Binding();
            }
        }

        private async Task Binding()
        {
            BindHelper.BindData(fcbTalepNeden, satinalmaTalep.talepNeden, "Id");
            BindHelper.BindData(clbProjeKodu, satinalmaTalep.proje, "Id");
            BindHelper.BindData(clbKullaniciId, satinalmaTalep.talepEdenKullanici, "Id");
            BindHelper.BindData(ctbTalepTarihi, satinalmaTalep, "talepTarihi");
            BindHelper.BindData(ctbTeslimTarihi, satinalmaTalep, "teslimTarihi");
            BindHelper.BindData(ctbTalepNo, satinalmaTalep, "satinalmaTalepNo");
            BindHelper.BindData(ctbAciklama, satinalmaTalep, "aciklama");
            BindHelper.BindData(ctbSetAdet, satinalmaTalep, "setAdet");
            List<SatinalmaTalepDetayDTO> satinalmaTalepDetayList = new();
            foreach (var std in _satinalmaTalep.satinalmaTalepDetays)
            {
                satinalmaTalepDetayList.Add(ConvertHelper.ToDTO<SatinalmaTalepDetayDTO>(std));
            }
            await universalGrid1.SetData(satinalmaTalepDetayList, this.Name, true);

        }
        private async void roundedButton4_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                if (!ValidateInputs())
                    return;

                CreateSatinalmaTalep();
                string jsonResult = await _satinalmaTalepService.SaveSatinalmaTalep(satinalmaTalep);
                if (satinalmaTalep.onayKullanici.Id == _cache.kullanici.Id)
                {
                    satinalmaTalep.onayDurum = true;
                    string jsonResultOnay = await _satinalmaTalepService.SatinalmaTalepOnay(satinalmaTalep);
                    if (jsonResultOnay.Contains("error", StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show($"Onaylama işlemi başarısız oldu. {jsonResultOnay}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        TalepOnaylandi?.Invoke(this, ConvertHelper.ToDTO<SatinalmaTalepDTO>(satinalmaTalep));
                    }
                }
                await HandleSaveResult(jsonResult);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Beklenmeyen bir hata oluştu: {ex.Message}", "Hata",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Enabled = true;
            }
        }
        private bool ValidateInputs()
        {
            bool isValid = true;
            isValid &= GlobalData.CheckField("Teslim tarihi girilmelidir", ctbTeslimTarihi);
            isValid &= GlobalData.CheckField("Talep Nedeni seçilmelidir", fcbTalepNeden);
            isValid &= GlobalData.CheckField("Set Adet girilmelidir", ctbSetAdet);
            isValid &= GlobalData.CheckField("Teslim tarihi girilmelidir", ctbTeslimTarihi);
            isValid &= GlobalData.CheckField("Talep tarihi girilmelidir", ctbTalepTarihi);
            isValid &= GlobalData.CheckField("Proje kodu seçilmelidir", clbProjeKodu);
            isValid &= GlobalData.CheckField("Talep eden kullanıcı seçilmelidir", clbKullaniciId);
            return isValid;
        }
        private void CreateSatinalmaTalep()
        {
            _satinalmaTalep.satinalmaTalepDetays.Clear();
            foreach (var item in universalGrid1.binding.OfType<SatinalmaTalepDetayDTO>())
            {
                item.miktar = item.miktar * int.Parse(ctbSetAdet.TextCustom);
                //item.agirlik = item.agirlik * int.Parse(ctbSetAdet.TextCustom);
                _satinalmaTalep.satinalmaTalepDetays.Add(ConvertHelper.ToEntity<SatinalmaTalepDetay>(item));
            }
        }
        private async Task<XSSFWorkbook> GetExcelWorkbook(int? satirSayisi)
        {
            var excelForm = new ExcelForm { formAd = "Malzeme Talep Formu", satirSayisi = satirSayisi };
            string jsonResult = await _anaVeriService.GetExcelForm(excelForm);
            excelForm = JsonConvert.DeserializeObject<List<ExcelForm>>(jsonResult)[0];

            if (string.IsNullOrEmpty(excelForm.excel))
                return null;

            var excelBytes = Convert.FromBase64String(excelForm.excel);
            return new XSSFWorkbook(new MemoryStream(excelBytes));
        }
        private void FillExcelData(IWorkbook workbook, ISheet sheet, IEnumerable<SatinalmaTalepDetayDTO> selectedRows)
        {
            // Header bilgilerini doldur
            SetHeaderData(workbook, sheet, selectedRows.First());

            // Satır verilerini doldur
            int currentRow = 10;
            foreach (var row in selectedRows)
            {
                SetRowData(workbook, sheet, row, currentRow);
                currentRow++;
            }
            if (currentRow < 151)
            {
                for (int i = 150; i > currentRow - 1; i--)
                {
                    IRow row = sheet.GetRow(i);
                    if (row != null)
                    {
                        row.ZeroHeight = true; // Satırı gizler
                    }
                }
            }
        }
        private void SetHeaderData(IWorkbook workbook, ISheet sheet, SatinalmaTalepDetayDTO firstRow)
        {
            // Talep Eden ve Talep Tarihi
            SetCellValue(workbook, sheet, 5, 4, clbKullaniciId.SelectedDisplayValue.ToString());
            SetCellValue(workbook, sheet, 6, 4, fcbTalepNeden.SelectedDisplayValue.ToString());
            SetCellValue(workbook, sheet, 5, 16, DateTime.Parse(ctbTalepTarihi.TextCustom.ToString()).ToShortDateString());
            SetCellValue(workbook, sheet, 6, 16, clbProjeKodu.SelectedDisplayValue.ToString());
        }

        private void SetRowData(IWorkbook workbook, ISheet sheet, SatinalmaTalepDetayDTO row, int rowIndex)
        {
            SetCellValue(workbook, sheet, rowIndex, 1, row.projeStokKartstokKartkod?.ToString());
            SetCellValue(workbook, sheet, rowIndex, 2, row.projeStokKartstokKartad?.ToString());
            SetCellValue(workbook, sheet, rowIndex, 6, row.miktar.ToString());
            SetCellValue(workbook, sheet, rowIndex, 8, row.projeStokKartstokKartmalzemeStandart?.ToString());
            //SetCellValue(sheet, rowIndex, 10, row.Cells[SatinalmaTalepDetayDTOHeader.ProjeStokKartAdet].FormattedValue?.ToString());
            SetCellValue(workbook, sheet, rowIndex, 13, row.projeStokKartstokKartboyut?.ToString());
            SetCellValue(workbook, sheet, rowIndex, 15, row.projeStokKartstokKartuzunluk?.ToString());
            SetCellValue(workbook, sheet, rowIndex, 17, row.projeStokKartstokKartagirlik?.ToString("N1"));
            SetCellValue(workbook, sheet, rowIndex, 19, row.agirlik?.ToString("N1"));
            SetCellValue(workbook, sheet, rowIndex, 21, row.projeStokKartstokKartaciklama?.ToString());

        }
        private void SetCellValue(IWorkbook workbook, ISheet sheet, int rowIndex, int cellIndex, string value)
        {
            var row = sheet.GetRow(rowIndex) ?? sheet.CreateRow(rowIndex);
            var cell = row.GetCell(cellIndex) ?? row.CreateCell(cellIndex);
            ICellStyle cellStyle = cell.CellStyle;
            IDataFormat format = workbook.CreateDataFormat();
            cell.CellStyle.DataFormat = format.GetFormat("0.#");
            cell.SetCellValue(value ?? string.Empty);
        }
        private async Task HandleSaveResult(string jsonResult)
        {
            var selectedRows = universalGrid1.binding.OfType<SatinalmaTalepDetayDTO>();
            int? satirSayisi = selectedRows.Count() > 25 ? selectedRows.Count() : 25;
            var workbook = await GetExcelWorkbook(satirSayisi);
            if (workbook == null)
            {
                MessageBox.Show("Excel dosyası alınamadı.");
                return;
            }

            var sheet = workbook.GetSheetAt(0);

            FillExcelData(workbook, sheet, selectedRows);

            if (String.IsNullOrEmpty(jsonResult) || jsonResult.Contains("error", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show($"Kaydetme işlemi başarısız oldu. {jsonResult}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                MessageBox.Show("Kaydetme işlemi başarılı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                satinalmaTalep = _jsonConverter.DeserializeObject<List<SatinalmaTalep>>(jsonResult).FirstOrDefault();
                Mail mail = new Mail();
                mail.Subject = $"{satinalmaTalep.satinalmaTalepNo} no'lu Talep Onayı Hakkında";
                mail.Body = $"{satinalmaTalep.satinalmaTalepNo} no'lu talep onayınıza sunulmuştur.";
                mail.To = _cache.kullaniciList.Where(x => x.Id == satinalmaTalep.onayKullanici.Id).Select(x => x.personel.mail).First();
                byte[] excelBytes;
                using (var ms = new MemoryStream())
                {
                    workbook.Write(ms);
                    excelBytes = ms.ToArray();
                }
                var attachment = new MailAttachament { fileName = "malzeme_talep_formu.xlsx", fileData = excelBytes };
                mail.attachmentData.Add(attachment);
                MailHelper.SendUserMail(_cache.kullanici, mail.To, mail.Subject, mail.Body, mail.attachmentData);
            }
        }
        public void UpdateMode(SatinalmaTalep satinalmaTalepUpdate)
        {
            var items = (List<Proje>)clbProjeKodu.DataSource;
            items.Add(satinalmaTalepUpdate.proje);
            clbProjeKodu.SetDataSource(items);
            ctbSetAdet.Enabled = false;
            fcbTalepNeden.ReadOnly = true;
            satinalmaTalep = satinalmaTalepUpdate;
        }

        private async Task SatinalmaTalepKayitFormu_FormClosing(object sender, FormClosingEventArgs e)
        {
            await universalGrid1.SaveSettings();
        }

        private async void SatinalmaTalepKayitFormu_Load(object sender, EventArgs e)
        {
            await Binding();
        }

        private void clbMalzemeGrubu_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var stokKart = new StokKart
            //{
            //    malzemeGrup = new MalzemeGrup { Id = int.Parse(clbMalzemeGrubu.SelectedValue.ToString()) },
            //};
            //var yeniUrunListesi = _cache.stokKartList
            //    .Where(x => x.malzemeGrup.Id == stokKart.malzemeGrup.Id)
            //    .ToList();
            //universalGrid1.SetComboColumnData("Stok Kart Id", yeniUrunListesi, "ad", "Id");
        }

        private void yeniKayıtEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<SatinalmaTalepDetayDTO> satinalmaTalepDetayList = universalGrid1.binding.OfType<SatinalmaTalepDetayDTO>().ToList();
            universalGrid1.AddRow(satinalmaTalepDetayList);
        }

        private void universalGrid1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(universalGrid1.Grid, e.Location);
            }
        }

        private void görüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var satinalmaTalepDetayDTO = (SatinalmaTalepDetayDTO)universalGrid1.Grid.CurrentRow.DataBoundItem;
            SatinalmaTalepDetay satinalmaTalepDetay = ConvertHelper.ToEntity<SatinalmaTalepDetay>(satinalmaTalepDetayDTO);
            SatinalmaTalepSatirDetayForm satinalmaTalepSatirDetayForm = FormFactory.CreateForm<SatinalmaTalepSatirDetayForm>();
            satinalmaTalepSatirDetayForm.UpdateMode(satinalmaTalepDetay.satinalmaTalepSatirDetays);
            satinalmaTalepSatirDetayForm.Show();
        }

        private async void clbProjeKodu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void stokKartıGörüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var satinalmaTalepDetayDTO = (SatinalmaTalepDetayDTO)universalGrid1.Grid.CurrentRow.DataBoundItem;
            SatinalmaTalepDetay satinalmaTalepDetay = ConvertHelper.ToEntity<SatinalmaTalepDetay>(satinalmaTalepDetayDTO);
            ProjeStokKart projeStokKart = satinalmaTalepDetay.projeStokKart;

            List<ProjeStokKart> projeStokKarts = await _projeService.GetProjeStokKart(projeStokKart);
            if (projeStokKarts.Count > 1)
            {
                projeStokKart = projeStokKarts.Where(p => p.proje.Id == satinalmaTalepDetayDTO.projeId).FirstOrDefault();
            }
            else
            {
                projeStokKart = projeStokKarts[0];
            }
            StokKartKayitFormu stokKartKayitFormu = FormFactory.CreateForm<StokKartKayitFormu>();
            stokKartKayitFormu.UpdateMode(projeStokKart);
            stokKartKayitFormu.ShowDialog();
        }

        private void seçilenKayıtlarıBirleştirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var list = universalGrid1.GetCheckedRows<SatinalmaTalepDetayDTO>();
            var stok = FormFactory.CreateForm<StokKartKayitFormu>();
            ProjeStokKart projeStokKart = new ProjeStokKart();
            projeStokKart = ConvertHelper.ToEntity<SatinalmaTalepDetay>(list[0]).projeStokKart;
            stok.UpdateMode(projeStokKart);
            stok.ShowDialog();

        }
    }
}
