using ApiService.Interfaces;
using Models;
using Models.DTO;
using Newtonsoft.Json;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities.Implementations;
using Utilities.Interfaces;
using YektamakDesktop.Abstracts;
using YektamakDesktop.Common;
using YektamakDesktop.CustomControls;
using YektamakDesktop.Formlar.Satinalma.Siparis;
using YektamakDesktop.Formlar.Stok;

namespace YektamakDesktop.Formlar.Satinalma
{
    public partial class SatinalmaTalepTeklifFormu : Form
    {
        private readonly IConvertHelper _convertHelper;
        private readonly ISatinalmaTalepService _satinalmaService;
        private readonly IConfigurationService _configurationService;
        private readonly ICache _cache;
        private readonly IAnaVeriService _anaVeriService;
        private readonly IStokService _stokService;
        private readonly IProjeService _projeService;
        private readonly IFileService _fileService;
        private readonly IDosyalamaService _dosyalamaService;
        private ExpandableGridAnimator mgr;
        public SatinalmaTalepTeklifFormu(IConvertHelper convertHelper, ISatinalmaTalepService satinalmaService, IConfigurationService configurationService,
            ICache cache, IAnaVeriService anaVeriService, IStokService stokService, IProjeService projeService, IFileService fileService, IDosyalamaService dosyalamaService)
        {
            _convertHelper = convertHelper;
            _satinalmaService = satinalmaService;
            _configurationService = configurationService;
            _cache = cache;
            _anaVeriService = anaVeriService;
            _stokService = stokService;
            _projeService = projeService;
            _fileService = fileService;
            _dosyalamaService = dosyalamaService;
            InitializeComponent();
            Initialize();
            isTeklif.CheckStateChanged += async (s, e) => await isTeklif_CheckedChanged(s, e);
            Load += async (s, e) => await SatinalmaTalepTeklifFormu_Load(s, e);
            ctbBeginTalepTarihi.textBox.PlaceholderText = "Başlangıç Talep Tarihi";
            ctbEndTalepTarihi.textBox.PlaceholderText = "Bitiş Talep Tarihi";
            ctxBeginTeslimTarihi.textBox.PlaceholderText = "Başlangıç Teslim Tarihi";
            ctxEndTeslimTarihi.textBox.PlaceholderText = "Bitiş Teslim Tarihi";
            fcbBoyut.PlaceholderText = "Boyut Seçimleri...";
            clbStokGrupId.SetDataSource(_cache.stokGrups);
            clbMalzemeGrupId.SetDataSource(_cache.malzemeGrups);
            clbProjeKod.SetDataSource(_cache.projeList.GroupBy(p => p.Id).Select(g => g.First()).ToList());
            fcbBoyut.SetDataSource(_cache.boyutList);
        }
        private void Initialize()
        {
            InitializeCustomGrid();

            int sizeX = universalGrid1.Size.Width;
            int sizeY = universalGrid1.Size.Height;
            int locationY = universalGrid1.Location.Y;
            int locationX = universalGrid1.Location.X;
            Controls.Remove(universalGrid1);
            universalGrid1 = DIContainer.GetService<UniversalGrid>();
            universalGrid1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            universalGrid1.Location = new System.Drawing.Point(locationX, locationY);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new System.Drawing.Size(sizeX, sizeY);
            universalGrid1.TabIndex = 13;
            Controls.Add(universalGrid1);
            universalGrid1.SetData(new List<SatinalmaTalepDetayDTO>(), this.Name, true);
            universalGrid1.MouseDown1 += universalGrid1_MouseDown;
        }
        private void InitializeCustomGrid()
        {
            int dataControlHeight = panel1.Height;
            int dataControlWidth = panel1.Width;
            customDataGrid = new CustomDataGrid<DataControlFirma>(2, 27, new Point(0, 0), new Size(dataControlWidth, dataControlHeight));
            panel1.Controls.Add(customDataGrid.detailPanel);
            panel1.Controls.Add(customDataGrid.headerPanel);
            customDataGrid.dataSource = dataControlFirmas;
        }
        CustomDataGrid<DataControlFirma> customDataGrid;

        private static SatinalmaTalepTeklifFormu _satinalmaTalepTeklifFormu;
        List<DataControlFirma> dataControlFirmas = new List<DataControlFirma>();
        private List<Firma> _firmaList;
        public List<Firma> firmaList
        {
            get
            {
                if (_firmaList == null)
                {
                    _firmaList = new List<Firma>();
                }
                return _firmaList;
            }
        }
        private SatinalmaTalepDetayDTO _filter;
        private SatinalmaTalepDetayDTO filter
        {
            get
            {
                if (_filter == null)
                {
                    _filter = new SatinalmaTalepDetayDTO();
                }
                return _filter;
            }
            set { _filter = value; Binding(); }
        }
        List<SatinalmaTalepDetayDTO> _satinalmaTalepDetayDTOs;
        List<SatinalmaTalepDetayDTO> satinalmaTalepDetayDTOs
        {
            get { if (_satinalmaTalepDetayDTOs == null) { _satinalmaTalepDetayDTOs = new(); } return _satinalmaTalepDetayDTOs; }
            set { _satinalmaTalepDetayDTOs = value; }
        }
        private async Task SatinalmaTalepTeklifFormu_Load(object sender, EventArgs e)
        {
            try
            {
                await Binding();
                await GridDoldur();
                GrupGridDoldur();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void GrupGridDoldur()
        {
            mgr = new ExpandableGridAnimator(dgv);
            var grupList = GetData();

            foreach (var grup in grupList)
            {
                var detayList = GetGrupData(grup.projeKod);

                var gorunumModel = new SatinalmaTalepForGrup
                {
                    Grup = grup.projeKod,
                    satirSayisi = grup.satirSayisi,
                    teklifSayisi = grup.teklifSayisi,
                    Details = detayList,
                    Filtrele = (e) => FiltreGrid(detayList[(int)e].projeId, detayList[(int)e].malzemeGrupId)
                };

                int rowIndex = dgv.Rows.Add(grup.projeKod, grup.satirSayisi, grup.teklifSayisi, grup.yuzde());

                mgr.BindRow(dgv.Rows[rowIndex], gorunumModel);
            }
        }

        private void FiltreGrid(int? projeId, int? malzemeGrupId)
        {
            filter = new SatinalmaTalepDetayDTO { projeId = projeId, projeStokKartstokKartmalzemeGrupId = malzemeGrupId };
            universalGrid1.Filtrele(filter);
        }


        private List<SatinalmaTalepForProje> GetData()
        {
            return satinalmaTalepDetayDTOs.GroupBy(s =>
                s.projekod
            ).Select(g => new SatinalmaTalepForProje
            {
                projeKod = g.First().projekod,
                satirSayisi = g.Count(),
                teklifSayisi = g.Where(x => x.isTeklif == true).Count()
            }).ToList();
        }
        private List<SatinalmaTalepForGrup> GetGrupData(string projeKod)
        {
            return satinalmaTalepDetayDTOs.Where(s => s.projekod == projeKod).GroupBy(s =>
                s.projeStokKartstokKartmalzemeGrupId
            ).Select(g => new SatinalmaTalepForGrup
            {
                Grup = _cache.malzemeGrups.Where(m => m.Id == g.First().projeStokKartstokKartmalzemeGrupId).First().ad,
                projeId = g.First().projeId,
                malzemeGrupId = g.First().projeStokKartstokKartmalzemeGrupId,
                satirSayisi = g.Count(),
                teklifSayisi = g.Where(x => x.isTeklif == true).Count()
            }).ToList();
        }
        private async Task GridDoldur()
        {
            bool? teklif = (isTeklif.Checked == true ? null : false);
            SatinalmaTalepDetay satinalmaTalepDetay = new SatinalmaTalepDetay { onayDurum = true, isTeklif = teklif };
            string jsonResult = await _satinalmaService.GetSatinalmaTalepDetay(satinalmaTalepDetay);
            universalGrid1.binding.Clear();
            satinalmaTalepDetayDTOs.Clear();

            if (!string.IsNullOrEmpty(jsonResult) && !jsonResult.Contains("error", StringComparison.OrdinalIgnoreCase))
            {
                List<SatinalmaTalepDetay> satinalmaTalepDetayList = JsonConvert.DeserializeObject<List<SatinalmaTalepDetay>>(jsonResult);
                satinalmaTalepDetayDTOs = satinalmaTalepDetayList.CastToDTO<SatinalmaTalepDetayDTO>(_convertHelper).ToList();
                await universalGrid1.SetData(satinalmaTalepDetayDTOs, this.Name, true);
            }
            universalGrid1.Filtrele(filter);
        }
        private async Task Binding()
        {
            BindHelper.BindData(clbProjeKod, filter, nameof(filter.projeId));
            BindHelper.BindData(clbStokGrupId, filter, nameof(filter.projeStokKartstokKartstokGrupId));
            BindHelper.BindData(clbMalzemeGrupId, filter, nameof(filter.projeStokKartstokKartmalzemeGrupId));
            BindHelper.BindData(chkBukum, filter, nameof(filter.projeStokKartstokKartisBukum));
            //BindHelper.BindData(fcbBoyut, filter, nameof(filter.stokKartboyutTanimId));
            await universalGrid1.SetData(satinalmaTalepDetayDTOs, this.Name, true);
        }
        private void SatinalmaTalepTeklifFormu_FormClosing(object sender, FormClosingEventArgs e)
        {
            universalGrid1.SaveGridSettings();
        }
        private async void btnTeklif_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateControl()) return;
                var selectedRows = GetSelectedRows();
                int? satirSayisi = selectedRows.Count > 25 ? selectedRows.Count : 25;
                var workbook = await GetExcelWorkbook(satirSayisi);
                if (workbook == null)
                {
                    ShowError("Excel dosyası alınamadı.");
                    return;
                }

                var sheet = workbook.GetSheetAt(0);


                if (!selectedRows.Any())
                {
                    ShowError("Lütfen en az bir satır seçin.");
                    return;
                }
                FillExcelData(sheet, selectedRows);
                string fileName;
                string directoryPath = clbProjeKod.SelectedItem.GetType().GetProperty("kod").GetValue(clbProjeKod.SelectedItem).ToString().Trim();
                directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), directoryPath + "_Dosyalar");
                if (Directory.Exists(directoryPath))
                {
                    Directory.Delete(directoryPath, true);
                }
                Directory.CreateDirectory(directoryPath);
                List<SatinalmaTalepDetay> satinalmaTalepDetays = new List<SatinalmaTalepDetay>();
                satinalmaTalepDetays = universalGrid1.GetCheckedRows<SatinalmaTalepDetayDTO>().CastToEntity<SatinalmaTalepDetay>(_convertHelper).ToList();
                await _dosyalamaService.CreateOrderFile(satinalmaTalepDetays.Select(s => s.projeStokKart).ToList(), directoryPath);
                foreach (var satinalmaTalepSatirDetayList in satinalmaTalepDetays.Select(s => s.satinalmaTalepSatirDetays))
                {
                    await _dosyalamaService.CreateOrderFile(satinalmaTalepSatirDetayList.Select(d => d.projeStokKart).ToList());
                }
                SaveExcelFile(workbook, directoryPath, out fileName);
                string filePath = Path.Combine(directoryPath, fileName);
                byte[] excelFileData = File.ReadAllBytes(filePath);
                File.Delete(filePath);
                filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), directoryPath);
                byte[] zipFileData = ZipDirectoryAndRead(filePath, $"{directoryPath}.zip");
                foreach (var firm in dataControlFirmas.Where(dc => dc.newRec == false))
                {
                    MailGonder mailGonder = FormFactory.CreateForm<MailGonder>();
                    mailGonder.mail.Body = "Malzeme Talep formu";
                    mailGonder.mail.Subject = "Malzeme Talep formu";
                    mailGonder.mail.attachmentData.Add(new MailAttachament
                    {
                        fileName = fileName,
                        fileData = excelFileData
                    });
                    var item = clbMalzemeGrupId.SelectedItem as MalzemeGrup;
                    //var item2 = clbMalzemeAltGrupId.SelectedItem as MalzemeAltGrup;
                    var item2 = fccMalzemeAltGrupId.SelectedValues.Cast<int>().ToList();
                    //(item2 != null && (item2.Id == 39 || item2.Id == 40 || item2.Id == 41 || item2.Id == 42))
                    var allowed = new List<int> { 29, 39, 40, 41, 42 };
                    if ((item != null && (item.Id == 28 || item.Id == 30)) || (item2 != null && item2.Any(i => allowed.Contains(i))))
                    {
                        mailGonder.mail.attachmentData.Add(new MailAttachament
                        {
                            fileName = $"Malzeme Talep Formu {DateTime.Now:yyyy-MM-dd HH-mm-ss}.zip",
                            fileData = zipFileData
                        });
                    }

                    mailGonder.mail.To = firm.mail;
                    SatinalmaTeklifBaslik satinalmaTeklifBaslik = new SatinalmaTeklifBaslik();
                    satinalmaTeklifBaslik.teklifFirma.Id = int.Parse(firm.Id.SelectedValue.ToString());
                    satinalmaTeklifBaslik.teklifTalepTarihi = DateTime.Now;
                    foreach (var satinalmaTalep in (IEnumerable<SatinalmaTalepDetayDTO>)universalGrid1.GetCheckedRows<SatinalmaTalepDetayDTO>())
                    {
                        satinalmaTeklifBaslik.satinalmaTeklifDetayList.Add(new SatinalmaTeklifDetay { satinalmaTalepDetay = _convertHelper.ToEntity<SatinalmaTalepDetay>(satinalmaTalep) });

                    }
                    mailGonder.UpdateMode(satinalmaTeklifBaslik);
                    mailGonder.ShowDialog();
                }
                await GridDoldur();
                await universalGrid1.Filtrele(filter);
                BoyutFiltrele();
            }
            catch (Exception ex)
            {
                ShowError($"Bir hata oluştu: {ex.Message}");
            }
        }
        private bool ValidateControl()
        {
            bool isValid = true;
            isValid &= CheckFieldHelper.CheckField("Malzeme grubu seçilmelidir.", clbMalzemeGrupId);
            isValid &= CheckFieldHelper.CheckField("En az bir firma seçilmelidir.", customDataGrid);
            return isValid;
        }

        public byte[] ZipDirectoryAndRead(string directoryPath, string zipFileName)
        {
            zipFileName = Path.GetFileName(directoryPath.TrimEnd(Path.DirectorySeparatorChar)) + ".zip";
            string zipPath = Path.Combine(Path.GetTempPath(), zipFileName);

            if (File.Exists(zipPath))
                File.Delete(zipPath);

            ZipFile.CreateFromDirectory(directoryPath, zipPath, CompressionLevel.Fastest, includeBaseDirectory: true);

            return File.ReadAllBytes(zipPath); // byte[] olarak oku
        }



        private void SaveExcelFile(XSSFWorkbook workbook, string directoryPath, out string fileName)
        {
            fileName = $"Malzeme Talep Formu {DateTime.Now:yyyy-MM-dd HH-mm-ss}.xlsx";
            string filePath = Path.Combine(directoryPath, fileName);

            using (var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                workbook.Write(fs);
            }
        }
        private void ShowError(string message)
        {
            MessageBox.Show(message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void SetHeaderData(ISheet sheet, DataGridViewRow firstRow)
        {
            // Talep Eden ve Talep Tarihi
            SetCellValue(sheet, 5, 4, firstRow.Cells[SatinalmaTalepDetayDTOHeader.TalepEdenHeader].FormattedValue?.ToString());
            SetCellValue(sheet, 6, 4, firstRow.Cells[SatinalmaTalepDetayDTOHeader.TalepNedenHeader].FormattedValue?.ToString());
            SetCellValue(sheet, 5, 16, firstRow.Cells[SatinalmaTalepDetayDTOHeader.TalepTarihiHeader].FormattedValue?.ToString());
            SetCellValue(sheet, 6, 16, firstRow.Cells[SatinalmaTalepDetayDTOHeader.ProjeIdHeader].FormattedValue?.ToString());
        }
        private void SetRowData(ISheet sheet, DataGridViewRow row, int rowIndex)
        {
            SetCellValue(sheet, rowIndex, 1, row.Cells[SatinalmaTalepDetayDTOHeader.StokKartKoduHeader].FormattedValue?.ToString());
            SetCellValue(sheet, rowIndex, 2, row.Cells[SatinalmaTalepDetayDTOHeader.StokKartIdHeader].FormattedValue?.ToString());
            SetCellValue(sheet, rowIndex, 6, row.Cells[SatinalmaTalepDetayDTOHeader.TalepOnaylananMiktarHeader].FormattedValue?.ToString());
            SetCellValue(sheet, rowIndex, 8, row.Cells[SatinalmaTalepDetayDTOHeader.MalzemeStandartdHeader].FormattedValue?.ToString());
            //SetCellValue(sheet, rowIndex, 10, row.Cells[SatinalmaTalepDetayDTOHeader.ProjeStokKartAdet].FormattedValue?.ToString());
            SetCellValue(sheet, rowIndex, 13, row.Cells[SatinalmaTalepDetayDTOHeader.StokKartBoyutHeader].FormattedValue?.ToString());
            SetCellValue(sheet, rowIndex, 15, row.Cells[SatinalmaTalepDetayDTOHeader.StokKartUzunlukHeader].FormattedValue?.ToString());
            SetCellValue(sheet, rowIndex, 17, row.Cells[SatinalmaTalepDetayDTOHeader.StokKartAgirlikHeader].FormattedValue?.ToString());
            SetCellValue(sheet, rowIndex, 19, row.Cells[SatinalmaTalepDetayDTOHeader.AgirlikHeader].FormattedValue?.ToString());
            SetCellValue(sheet, rowIndex, 21, row.Cells[SatinalmaTalepDetayDTOHeader.StokKartAciklamaHeader].FormattedValue?.ToString());

        }
        private void SetCellValue(ISheet sheet, int rowIndex, int cellIndex, string value)
        {
            var row = sheet.GetRow(rowIndex) ?? sheet.CreateRow(rowIndex);
            var cell = row.GetCell(cellIndex) ?? row.CreateCell(cellIndex);
            cell.SetCellValue(value ?? string.Empty);
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
        private List<DataGridViewRow> GetSelectedRows()
        {

            return universalGrid1.Grid.Rows
                .Cast<DataGridViewRow>()
                .Where(row => Convert.ToBoolean(row.Cells["Sec"].Value))
                .ToList();
        }
        private void FillExcelData(ISheet sheet, List<DataGridViewRow> selectedRows)
        {
            // Header bilgilerini doldur
            SetHeaderData(sheet, selectedRows.First());

            // Satır verilerini doldur
            int currentRow = 10;
            foreach (var row in selectedRows)
            {
                SetRowData(sheet, row, currentRow);
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



        private void universalGrid1_MouseDown(object sender, MouseEventArgs e)
        {
            var hit = universalGrid1.Grid.HitTest(e.X, e.Y);
            int rowIndex = hit.RowIndex;
            if (e.Button == MouseButtons.Right && rowIndex != -1)
            {
                contextMenuStrip2.Show(universalGrid1, e.Location);
            }
        }
        private void parçaListesiniGösterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //var menuItem = (ToolStripMenuItem)sender;
            //var contextMenu = (ContextMenuStrip)menuItem.Owner;
            //var universalGrid = (UniversalGrid)contextMenu.SourceControl;
            //var dataGridView = universalGrid.Grid;
            //if (dataGridView.CurrentRow == null || dataGridView.CurrentRow.DataBoundItem == null)
            //    return;
            //var talepDTO = (SatinalmaTalepDetayDTO)dataGridView.CurrentRow.DataBoundItem;
            var satinalmaTalepDetayDTO = (SatinalmaTalepDetayDTO)universalGrid1.Grid.CurrentRow.DataBoundItem;
            SatinalmaTalepDetay satinalmaTalepDetay = _convertHelper.ToEntity<SatinalmaTalepDetay>(satinalmaTalepDetayDTO);
            SatinalmaTalepSatirDetayForm satinalmaTalepSatirDetayForm = FormFactory.CreateForm<SatinalmaTalepSatirDetayForm>();
            satinalmaTalepSatirDetayForm.UpdateMode(satinalmaTalepDetay.satinalmaTalepSatirDetays);
            satinalmaTalepSatirDetayForm.Show();
        }
        private async void stokKartınıGörüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var satinalmaTalepDetayDTO = (SatinalmaTalepDetayDTO)universalGrid1.Grid.CurrentRow.DataBoundItem;
            ProjeStokKart projeStokKart = (await _projeService.GetProjeStokKart(new ProjeStokKart { stokKart = { Id = satinalmaTalepDetayDTO.projeStokKartstokKartId }, proje = { Id = satinalmaTalepDetayDTO.projeId } })).FirstOrDefault();
            StokKartKayitFormu stokKartKayitFormu = FormFactory.CreateForm<StokKartKayitFormu>();
            stokKartKayitFormu.UpdateMode(projeStokKart);
            stokKartKayitFormu.ShowDialog();
        }

        private void cbxStokGrupId_SelectedIndexChanged(object sender, EventArgs e)
        {
            universalGrid1.Filtrele(filter);
            if(clbStokGrupId.SelectedValue == null)
            {
                clbMalzemeGrupId.SetDataSource(_cache.malzemeGrups);
                return;
            }
            clbMalzemeGrupId.SetDataSource(_cache.malzemeGrups.Where(m => m.stokGrup.Id == int.Parse(clbStokGrupId.SelectedValue.ToString())).ToList());
        }
        private async void cbxMalzemeGrupId_SelectedIndexChanged(object sender, EventArgs e)
        {
            fccMalzemeAltGrupId.SetDataSource(satinalmaTalepDetayDTOs
                .Where(s => s.projeStokKartstokKartmalzemeGrupId.ToString() == clbMalzemeGrupId.SelectedValue?.ToString() && !string.IsNullOrEmpty(s.projeStokKartstokKartmalzemeAltGrupId.ToString()))
                .Select(s => new { Id = s.projeStokKartstokKartmalzemeAltGrupId, _cache.malzemeAltGrups.Where(m => m.Id == s.projeStokKartstokKartmalzemeAltGrupId).First().ad })
                .DistinctBy(b => b.Id)
                .ToList());
            fcbBoyut.SetDataSource((satinalmaTalepDetayDTOs.CastToEntity<SatinalmaTalepDetay>(_convertHelper))
                .Where(s => s.projeStokKart.stokKart.malzemeGrup.Id.ToString() == clbMalzemeGrupId.SelectedValue?.ToString() && s.proje.Id == int.Parse(clbProjeKod.SelectedValue.ToString()))
                .Select(s => s.projeStokKart.stokKart.boyutTanim)
                .DistinctBy(b => b.Id)
                .ToList());
            universalGrid1.Filtrele(filter);
        }
        private void cbxFirma_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterableComboBox firma = (FilterableComboBox)sender;
            firmaList.Add(_cache.firmaList.First(f => f.Id.ToString() == firma.SelectedValue.ToString()));
            FilterableComboBox customComboListBox = new FilterableComboBox();
            customComboListBox.Location = new Point(firma.Location.X, firma.Location.Y + firma.Height);
            customComboListBox.Size = firma.Size;
            customComboListBox.SetDataSource(_cache.firmaList);
            customComboListBox.SelectedIndexChanged += cbxFirma_SelectedIndexChanged;
            this.Controls.Add(customComboListBox);
        }
        private void clbProjeKod_SelectedIndexChanged(object sender, EventArgs e)
        {
            universalGrid1.Filtrele(filter);
        }
        private void fcbBoyut_SelectedIndexChanged(object sender, EventArgs e)
        {
            BoyutFiltrele();
        }
        private async Task isTeklif_CheckedChanged(object sender, EventArgs e)
        {
            await GridDoldur();
            GrupGridDoldur();
        }
        private void fccMalzemeAltGrupId_ItemsChanged(object sender, EventArgs e)
        {
            universalGrid1.Filtrele(filter);
            MalzemeAltGrupFiltrele();
            //fcbBoyut.SetDataSource(_cache.boyutList.
            //    Where(m => { foreach (var id in fccMalzemeAltGrupId.SelectedValues.Cast<int>()) { if (m.malzemeAltGrupId == id) { return true; } } return false; }).ToList());
            fcbBoyut.SetDataSource(satinalmaTalepDetayDTOs
                .Where(m => { foreach (var id in fccMalzemeAltGrupId.SelectedValues.Cast<int>()) { if (m.projeStokKartstokKartmalzemeAltGrupId == id) { return true; } } return false; })
                .Select(s => new { Id = s.projeStokKartstokKartboyutTanimId, ad = s.projeStokKartstokKartboyut })
                .DistinctBy(b => new { b.Id })
                .ToList());
        }
        private void fccMalzemeAltGrup2_ItemsChanged(object sender, EventArgs e)
        {
            MalzemeAltGrup2Filtrele();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            BukumFiltrele();
            universalGrid1.Filtrele(filter);
            MalzemeAltGrupFiltrele();
            MalzemeAltGrup2Filtrele();
        }
        private void BukumFiltrele()
        {
            filter.projeStokKartstokKartisBukum = chkBukum.CheckState == CheckState.Indeterminate ? (bool?)null :
                (chkBukum.CheckState == CheckState.Checked ? true : false);
            //// 1. DataSource'u doğru tipe cast et
            //var data = universalGrid1.Grid.DataSource as IEnumerable<SatinalmaTalepDetayDTO>;
            //if (data == null) return;

            //// 2. Filtre uygula
            //IEnumerable<SatinalmaTalepDetayDTO> filtered = data;
            //if (chkBukum.CheckState == CheckState.Checked)
            //{
            //    filtered = data.Where(x => x.projeStokKartstokKartisBukum == true);
            //}
            //else if (chkBukum.CheckState == CheckState.Unchecked)
            //{
            //    filtered = data.Where(x => x.projeStokKartstokKartisBukum == false);
            //}

            //// 3. BindingSource oluştur ve ata
            //var bindingSource = new BindingSource();
            //bindingSource.DataSource = new SortableBindingList<SatinalmaTalepDetayDTO>(filtered.ToList());

            //universalGrid1.Grid.DataSource = bindingSource;
            //universalGrid1.lblGosterilenKayitSayisi.Text = $"Filtrelenen kayıt sayısı : {filtered.Count()}";
            //return;
        }
        private bool BoyutFiltrele()
        {
            var seciliBoyutlar = fcbBoyut.SelectedValues.Cast<int>().ToList();
            //if (seciliBoyutlar.Count == 0)
            //{
            //    universalGrid1.Filtrele(filter);
            //    MalzemeAltGrupFiltrele();
            //    MalzemeAltGrup2Filtrele();
            //    return true;
            //}
            // 1. DataSource'u doğru tipe cast et
            var data = universalGrid1.DataBindings.Cast<SatinalmaTalepDetayDTO>;
            if (data == null) return false;

            // 2. Filtre uygula
            SortableBindingList<SatinalmaTalepDetayDTO> filtered = data;
            //if (seciliBoyutlar.Count > 0)
            //{
                filtered = new SortableBindingList<SatinalmaTalepDetayDTO>(data.Where(x => seciliBoyutlar.Contains(x.projeStokKartstokKartboyutTanimId ?? 0)).ToList());
            //}

            // 3. BindingSource oluştur ve ata
            var bindingSource = new BindingSource();
            bindingSource.DataSource = new SortableBindingList<SatinalmaTalepDetayDTO>(filtered.ToList());

            universalGrid1.Grid.DataSource = bindingSource;
            universalGrid1.lblGosterilenKayitSayisi.Text = $"Filtrelenen kayıt sayısı : {filtered.Count()}";
            return true;
        }
        private void MalzemeAltGrupFiltrele()
        {
            var seciliMalzemeAltGrups = fccMalzemeAltGrupId.SelectedValues.Cast<int>().ToList();
            if (seciliMalzemeAltGrups.Count == 0)
            {
                universalGrid1.Filtrele(filter);
                return;
            }
            // 1. DataSource'u doğru tipe cast et
            var data = universalGrid1.Grid.DataSource as IEnumerable<SatinalmaTalepDetayDTO>;
            if (data == null) return;

            // 2. Filtre uygula
            IEnumerable<SatinalmaTalepDetayDTO> filtered = data;
            if (seciliMalzemeAltGrups.Count > 0)
            {
                filtered = data.Where(x => seciliMalzemeAltGrups.Contains(x.projeStokKartstokKartmalzemeAltGrupId ?? 0));
            }

            // 3. BindingSource oluştur ve ata
            var bindingSource = new BindingSource();
            bindingSource.DataSource = new SortableBindingList<SatinalmaTalepDetayDTO>(filtered.ToList());

            universalGrid1.Grid.DataSource = bindingSource;
            universalGrid1.lblGosterilenKayitSayisi.Text = $"Filtrelenen kayıt sayısı : {filtered.Count()}";
            fccMalzemeAltGrup2.SetDataSource(_cache.malzemeAltGrup2List.Where(m => { foreach (var id in seciliMalzemeAltGrups) { if (m.malzemeAltGrup.Id == id) { return true; } } return false; }).ToList());
        }
        private void MalzemeAltGrup2Filtrele()
        {
            var seciliMalzemeAltGrup2s = fccMalzemeAltGrup2.SelectedValues.Cast<int>().ToList();
            if (seciliMalzemeAltGrup2s.Count == 0)
            {
                universalGrid1.Filtrele(filter);
                MalzemeAltGrupFiltrele();
                return;
            }
            // 1. DataSource'u doğru tipe cast et
            var data = universalGrid1.binding.DataSource as IEnumerable<SatinalmaTalepDetayDTO>;
            if (data == null) return;

            // 2. Filtre uygula
            IEnumerable<SatinalmaTalepDetayDTO> filtered = data;
            if (seciliMalzemeAltGrup2s.Count > 0)
            {
                filtered = data.Where(x => seciliMalzemeAltGrup2s.Contains(x.projeStokKartstokKartmalzemeAltGrupId ?? 0));
            }

            // 3. BindingSource oluştur ve ata
            var bindingSource = new BindingSource();
            bindingSource.DataSource = new SortableBindingList<SatinalmaTalepDetayDTO>(filtered.ToList());

            universalGrid1.Grid.DataSource = bindingSource;
            universalGrid1.lblGosterilenKayitSayisi.Text = $"Filtrelenen kayıt sayısı : {filtered.Count()}";
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            if (!ValidateControl())
            {
                return;
            }
            Firma firma = (Firma)dataControlFirmas.First(dc => dc.newRec == false).Id.SelectedItem;
            SatinalmaSiparisDTO satinalmaSiparis = new SatinalmaSiparisDTO();
            satinalmaSiparis.siparisTarihi = DateTime.Today;
            satinalmaSiparis.firmaId = firma.Id;
            satinalmaSiparis.kdvId = 1;
            satinalmaSiparis.projeId = int.Parse(clbProjeKod.SelectedValue.ToString());
            satinalmaSiparis.malzemeGrupId = int.Parse(clbMalzemeGrupId.SelectedValue.ToString());
            var detays = universalGrid1.GetCheckedRows<SatinalmaTalepDetayDTO>().CastToEntity<SatinalmaTalepDetay>(_convertHelper);
            foreach (var item in detays)
            {
                SatinalmaSiparisDetay satinalmaSiparisDetay = new SatinalmaSiparisDetay();
                satinalmaSiparisDetay.miktar = item.miktar;
                satinalmaSiparisDetay.aciklama = item.aciklama;
                satinalmaSiparisDetay.projeStokKart = item.projeStokKart;
                satinalmaSiparisDetay.satinalmaTalepDetay.Id = item.Id;
                satinalmaSiparis.satinalmaSiparisDetay.Add(satinalmaSiparisDetay);
            }
            var satinalmaSiparisKayitFormu = FormFactory.CreateForm<SatinalmaSiparisKayitFormu>();
            satinalmaSiparisKayitFormu.UpdateMode(satinalmaSiparis);
            satinalmaSiparisKayitFormu.ShowDialog();
        }
    }
    public class SatinalmaTalepForProje
    {
        public string projeKod { get; set; }
        public int satirSayisi { get; set; }
        public int teklifSayisi { get; set; }
        
        public decimal yuzde ()=> teklifSayisi == 0 ? 0 : Math.Round(((decimal)teklifSayisi / satirSayisi) * 100, 2);
    }

    public class SatinalmaTalepForGrup
    {
        public int? projeId { get; set; }
        public string projeKod { get; set; }
        public List<SatinalmaTalepForGrup> Details { get; set; }
        public DataGridView DetailGrid { get; set; }
        public bool IsExpanded { get; set; }
        public string Grup { get; set; }
        public int? malzemeGrupId { get; set; }
        public int satirSayisi { get; set; }
        public int teklifSayisi { get; set; }
        public decimal yuzde ()=> teklifSayisi == 0 ? 0 : Math.Round(((decimal)teklifSayisi / satirSayisi) * 100, 2);
        public Action<int> Filtrele { get; set; }
    }
    public class Filter : SatinalmaTalepDetayDTO
    {
        //Filtre işlemine dahil edilmemesi için satinalmaTalepSatirDetays null olarak getiriliyor.
        public List<SatinalmaTalepSatirDetay> satinalmaTalepSatirDetays { get => null; }
        public DateTime? beginTalepTarihi { get; set; }
        public DateTime? endTalepTarihi { get; set; }
        public DateTime? beginTeslimTarihi { get; set; }
        public DateTime? endTeslimTarihi { get; set; }
    }
    public class DataControlFirma : DataControl, IEntity
    {
        private readonly ICache _cache;
        private FilterableComboBox _Id;
        public FilterableComboBox Id { get { if (_Id == null) { _Id = new(); } return _Id; } set { _Id = value; } }
        private string _mail;
        public string mail { get { return _mail; } set { _mail = value; } }
        public DataControlFirma(ICache cache)
        {
            Id = new() { TabIndex = 1, Width = 300, Visible = true, Tag = "Id" };
            Id.PlaceholderText = "Firma Seçiniz";

            Id.SelectedIndexChanged += Id_SelectedIndexChanged;
            _cache = cache;
            _Id.SetDataSource(_cache.firmaList);
        }
        public DataControlFirma() { }

        private void Id_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Id.SelectedValue == null) return;
            mail = _cache.firmaList.First(f => f.Id == int.Parse(Id.SelectedValue.ToString())).mail;
            //newRec = false; // Yeni kayıt değil, var olan bir firma seçildiğinde
        }
    }
}
