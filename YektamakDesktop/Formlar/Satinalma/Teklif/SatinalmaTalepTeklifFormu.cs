using ApiService.Interfaces;
using Models;
using Models.DTO;
using Models.Models;
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
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities.Interfaces;
using YektamakDesktop.Abstracts;
using YektamakDesktop.Common;
using YektamakDesktop.CustomControls;

namespace YektamakDesktop.Formlar.Satinalma
{
    public partial class SatinalmaTalepTeklifFormu : Form
    {
        private readonly IJsonConverter _jsonConverter;
        private readonly ISatinalmaTalepService _satinalmaService;
        private readonly IDataTableMapper _dataTableMapper;
        private readonly ICache _cache;
        private readonly IAnaVeriService _anaVeriService;
        private readonly IStokService _stokService;
        public SatinalmaTalepTeklifFormu(IJsonConverter jsonConverter, ISatinalmaTalepService satinalmaService, IDataTableMapper dataTableMapper,
            ICache cache, IAnaVeriService anaVeriService, IStokService stokService)
        {
            _jsonConverter = jsonConverter;
            _satinalmaService = satinalmaService;
            _dataTableMapper = dataTableMapper;
            _cache = cache;
            _anaVeriService = anaVeriService;
            _stokService = stokService;
            InitializeComponent();
            Initialize();
            Load += async (s, e) => await SatinalmaTalepTeklifFormu_Load(s, e);
            ctbBeginTalepTarihi.textBox.PlaceholderText = "Başlangıç Talep Tarihi";
            ctbEndTalepTarihi.textBox.PlaceholderText = "Bitiş Talep Tarihi";
            ctxBeginTeslimTarihi.textBox.PlaceholderText = "Başlangıç Teslim Tarihi";
            ctxEndTeslimTarihi.textBox.PlaceholderText = "Bitiş Teslim Tarihi";
            clbStokGrupId.SetDataSource(_cache.stokGrups);
            clbMalzemeGrupId.SetDataSource(_cache.malzemeGrups);
            clbMalzemeAltGrupId.SetDataSource(_cache.malzemeAltGrup2List);
            clbProjeKod.SetDataSource(_cache.projes);
            fcbMalzemeAltGrup2.SetDataSource(_cache.malzemeAltGrup2List);
            fcbBoyut.SetDataSource(_cache.boyutList);
            customDataGrid = new CustomDataGrid<DataControlFirma>(2, 30, new Point(0, 0), new Size(650, 300));
            this.panel1.Controls.Add(customDataGrid.headerPanel);
            this.panel1.Controls.Add(customDataGrid.detailPanel);
            customDataGrid.dataSource = dataControlFirmas;
        }
        private void Initialize()
        {
            Controls.Remove(universalGrid1);
            universalGrid1 = DIContainer.GetService<UniversalGrid>();
            universalGrid1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            universalGrid1.Location = new System.Drawing.Point(-2, 329);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new System.Drawing.Size(1097, 418);
            universalGrid1.TabIndex = 15;
            universalGrid1.MouseDown1 += universalGrid1_MouseDown;
            Controls.Add(universalGrid1);
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
            set { _filter = value; }
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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private async Task GridDoldur()
        {
            SatinalmaTalepDetay satinalmaTalepDetay = new SatinalmaTalepDetay { onayDurum = true, isTeklif = false };
            string jsonResult = await _satinalmaService.GetSatinalmaTalepDetay(satinalmaTalepDetay);
            satinalmaTalepDetayDTOs.Clear();
            if (!String.IsNullOrEmpty(jsonResult) && !jsonResult.Contains("error", StringComparison.OrdinalIgnoreCase))
            {
                List<SatinalmaTalepDetay> satinalmaTalepDetayList = JsonConvert.DeserializeObject<List<SatinalmaTalepDetay>>(jsonResult);
                foreach (var item in satinalmaTalepDetayList)
                {
                    var detay = ConvertHelper.ToDTO<SatinalmaTalepDetayDTO>(item);
                    satinalmaTalepDetayDTOs.Add(detay);
                }
                await universalGrid1.SetData(satinalmaTalepDetayDTOs, this.Name, true);
            }
        }
        private async Task Binding()
        {
            BindHelper.BindData(clbProjeKod, filter, nameof(filter.projeId));
            BindHelper.BindData(clbMalzemeAltGrupId, filter, nameof(filter.stokKartmalzemeAltGrupId));
            BindHelper.BindData(clbStokGrupId, filter, nameof(filter.stokKartstokGrupId));
            BindHelper.BindData(clbMalzemeGrupId, filter, nameof(filter.stokKartmalzemeGrupId));
            BindHelper.BindData(fcbMalzemeAltGrup2, filter, nameof(filter.stokKartmalzemeAltGrup2Id));
            //BindHelper.BindData(fcbBoyut, filter, nameof(filter.stokKartboyutTanimId));
            await universalGrid1.SetData(satinalmaTalepDetayDTOs, this.Name, true);
        }
        private void SatinalmaTalepTeklifFormu_FormClosing(object sender, FormClosingEventArgs e)
        {
            universalGrid1.SaveSettings();
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
                string directoryPath = clbMalzemeGrupId.SelectedItem.GetType().GetProperty("ad").GetValue(clbMalzemeGrupId.SelectedItem).ToString().Trim();
                directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), directoryPath);
                if (Directory.Exists(directoryPath))
                {
                    Directory.Delete(directoryPath, true);
                }
                Directory.CreateDirectory(directoryPath);
                await CreateOrderFile();
                SaveExcelFile(workbook, directoryPath, out fileName);
                string filePath = Path.Combine(directoryPath, fileName);
                byte[] excelFileData = File.ReadAllBytes(filePath);
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
                    var item2 = clbMalzemeAltGrupId.SelectedItem as MalzemeAltGrup;
                    if ((item != null && (item.Id == 28 || item.Id == 30)) || (item2 != null && (item2.Id == 39 || item2.Id == 40 || item2.Id == 41 || item2.Id == 42)))
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
                        satinalmaTeklifBaslik.satinalmaTeklifDetayList.Add(new SatinalmaTeklifDetay { satinalmaTalepDetay = ConvertHelper.ToEntity<SatinalmaTalepDetay>(satinalmaTalep) });

                    }
                    mailGonder.UpdateMode(satinalmaTeklifBaslik);
                    mailGonder.ShowDialog();
                }
                await GridDoldur();
                universalGrid1.Filtrele(filter);
            }
            catch (Exception ex)
            {
                ShowError($"Bir hata oluştu: {ex.Message}");
            }
        }

        private bool ValidateControl()
        {
            bool isValid = true;
            isValid &= GlobalData.CheckField("Malzeme grubu seçilmelidir.", clbMalzemeGrupId);
            isValid &= GlobalData.CheckField("En az bir firma seçilmelidir.", customDataGrid);
            return isValid;
        }

        private async Task CreateOrderFile()
        {
            var selectedRows = universalGrid1.GetCheckedRows<SatinalmaTalepDetayDTO>();
            foreach (var row in selectedRows)
            {
                foreach (var satinalmaTalepSatirDetay in row.satinalmaTalepSatirDetays)
                {
                    StokKart stokKart = new StokKart { Id = satinalmaTalepSatirDetay.stokKart.Id };
                    string jsonResult = await _stokService.GetStokKartPdf(stokKart);
                    stokKart = JsonConvert.DeserializeObject<List<StokKart>>(jsonResult)[0];
                    foreach (var skd in stokKart.dosyaList)
                    {
                        // Eğer stok kartı malzeme grubu talaşlı hammadde ise pdf dosyasını kaydet
                        if (stokKart.malzemeGrup.Id == 28 && skd.dosyaTip.Id == 2)
                        {
                            SaveMaterialFile(skd, "DXF");
                        }
                        // Eğer LAZER malzeme grubu ise dxf dosyasını kaydet
                        if (stokKart.malzemeGrup.Id == 30 && skd.dosyaTip.Id == 1)
                        {
                            SaveMaterialFile(skd, "");
                        }
                        // Eğer bükümlü malzeme grubu ise pdf dosyasını kaydet
                        if ((stokKart.malzemeAltGrup.Id == 39 ||
                            stokKart.malzemeAltGrup.Id == 40 ||
                            stokKart.malzemeAltGrup.Id == 41 ||
                            stokKart.malzemeAltGrup.Id == 42) && skd.dosyaTip.Id == 1)
                        {
                            SaveMaterialFile(skd, "BÜKÜM");
                        }
                    }
                }
            }
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
        private void SaveMaterialFile(StokKartDosya skd, string path)
        {
            string fileName = $"Malzeme Talep Formu {DateTime.Now:yyyy-MM-dd HH-mm-ss}.xlsx";
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"{clbMalzemeGrupId.SelectedItem.GetType().GetProperty("ad").GetValue(clbMalzemeGrupId.SelectedItem).ToString().Trim()}\\{path}", $"{skd.dosyaAd}.{skd.dosyaUzanti}");
            string directoryPath = Path.GetDirectoryName(filePath);
            // Dizin yoksa oluştur
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            File.WriteAllBytes(filePath, skd.dosya);
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
            SetCellValue(sheet, rowIndex, 6, row.Cells[SatinalmaTalepDetayDTOHeader.TalepMiktariHeader].FormattedValue?.ToString());
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

        private void SaveExcelFile(XSSFWorkbook workbook, string directoryPath, out string fileName)
        {
            fileName = $"Malzeme Talep Formu {DateTime.Now:yyyy-MM-dd HH-mm-ss}.xlsx";
            string filePath = Path.Combine(directoryPath, fileName);

            using (var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                workbook.Write(fs);
            }
        }

        private void ShowSuccess(string message)
        {
            MessageBox.Show(message, "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void cbxStokGrupId_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxListFill.GetLookupAd(_cache.malzemeGrups.Where(c => c.stokGrup.Id == filter.stokKartstokGrupId).ToList(), ref clbMalzemeGrupId);
            ComboBoxListFill.GetLookupAd(_cache.malzemeAltGrups.Where(c => c.malzemeGrup.Id == filter.stokKartmalzemeGrupId).ToList(), ref clbMalzemeAltGrupId);
            universalGrid1.Filtrele(filter);
        }

        private void DataRefresh()
        {
            try
            {
                universalGrid1.SetData(FilterByNonNullProperties(satinalmaTalepDetayDTOs, filter)
                                                                    //.Where(x =>
                                                                    //        (!filter.beginTalepTarihi.HasValue || x.talepTarihi >= filter.beginTalepTarihi.Value) &&
                                                                    //        (!filter.endTalepTarihi.HasValue || x.talepTarihi <= filter.endTalepTarihi.Value)
                                                                    //    )
                                                                    //    .ToList()
                                                                    //.Where(x =>
                                                                    //        (!filter.beginTeslimTarihi.HasValue || x.teslimTarihi >= filter.beginTeslimTarihi.Value) &&
                                                                    //        (!filter.endTeslimTarihi.HasValue || x.teslimTarihi <= filter.endTeslimTarihi.Value)
                                                                    //    )
                                                                    .ToList()
                                        , this.Name, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veri tablosu yenilenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbxMalzemeGrupId_SelectedIndexChanged(object sender, EventArgs e)
        {
            clbMalzemeAltGrupId.SetDataSource(_cache.malzemeAltGrups.Where(c => c.malzemeGrup.Id == filter.stokKartmalzemeGrupId).ToList());
            fcbBoyut.SetDataSource(_cache.boyutList.Where(b => b.malzemeGrupId.ToString() == clbMalzemeGrupId.SelectedValue.ToString()).ToList());
            universalGrid1.Filtrele(filter);
        }

        public static List<T> FilterByNonNullProperties<T>(List<T> source, T filter)
        {
            var props = typeof(T).GetProperties();
            return source.Where(item =>
            {
                foreach (var prop in props)
                {
                    var filterValue = prop.GetValue(filter);
                    if (filterValue == null) continue;

                    var itemValue = prop.GetValue(item);

                    // Eğer property başka bir nesne (örneğin stokGrup) ise, iç ID'sine bak
                    if (prop.PropertyType.IsPrimitive && prop.PropertyType != typeof(string))
                    {
                        var subProp = prop.PropertyType.GetProperty("Id");
                        var filterSubValue = subProp?.GetValue(filterValue);
                        var itemSubValue = subProp?.GetValue(itemValue);
                        if (filterSubValue != null && !filterSubValue.Equals(itemSubValue))
                            return false;
                    }
                    else
                    {
                        if (!filterValue.Equals(itemValue))
                            return false;
                    }
                }
                return true;
            }).ToList();
        }
        private class Filter : SatinalmaTalepDetayDTO
        {
            //Filtre işlemine dahil edilmemesi için satinalmaTalepSatirDetays null olarak getiriliyor.
            public List<SatinalmaTalepSatirDetay> satinalmaTalepSatirDetays { get => null; }
            public DateTime? beginTalepTarihi { get; set; }
            public DateTime? endTalepTarihi { get; set; }
            public DateTime? beginTeslimTarihi { get; set; }
            public DateTime? endTeslimTarihi { get; set; }
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
            var menuItem = (ToolStripMenuItem)sender;
            var contextMenu = (ContextMenuStrip)menuItem.Owner;
            var universalGrid = (UniversalGrid)contextMenu.SourceControl;
            var dataGridView = universalGrid.Grid;
            if (dataGridView.CurrentRow == null || dataGridView.CurrentRow.DataBoundItem == null)
                return;
            var talepDTO = (SatinalmaTalepDetayDTO)dataGridView.CurrentRow.DataBoundItem;
        }

        private void cbxFirma_SelectedIndexChanged(object sender, EventArgs e)
        {
            CustomComboListBox firma = (CustomComboListBox)sender;
            firmaList.Add(_cache.firmaList.First(f => f.Id == firma.selectedDataRowId));
            CustomComboListBox customComboListBox = new CustomComboListBox();
            customComboListBox.Location = new Point(firma.Location.X, firma.Location.Y + firma.Height);
            customComboListBox.Size = firma.Size;
            ComboBoxListFill.GetLookupAd(_cache.firmaList, ref customComboListBox);
            customComboListBox.SelectedIndexChanged += cbxFirma_SelectedIndexChanged;
            this.Controls.Add(customComboListBox);
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
                ComboBoxListFill.GetLookupAd(_cache.firmaList, ref _Id);
            }
            public DataControlFirma() { }

            private void Id_SelectedIndexChanged(object sender, EventArgs e)
            {
                mail = _cache.firmaList.First(f => f.Id == int.Parse(Id.SelectedValue.ToString())).mail;
                newRec = false; // Yeni kayıt değil, var olan bir firma seçildiğinde
            }
        }

        private void clbMalzemeAltGrupId_SelectedIndexChanged(object sender, EventArgs e)
        {
            universalGrid1.Filtrele(filter);
            if (clbMalzemeAltGrupId.SelectedValue == null) return;
            fcbMalzemeAltGrup2.SetDataSource(_cache.malzemeAltGrup2List.Where(m => m.malzemeAltGrup.Id.ToString() == clbMalzemeAltGrupId.SelectedValue.ToString()).ToList());
            fcbBoyut.SetDataSource(_cache.boyutList.Where(b => b.malzemeAltGrupId.ToString() == clbMalzemeAltGrupId.SelectedValue.ToString()).ToList());
        }

        private void clbProjeKod_SelectedIndexChanged(object sender, EventArgs e)
        {
            universalGrid1.Filtrele(filter);
        }

        private void fcbMalzemeAltGrup2_SelectedIndexChanged(object sender, EventArgs e)
        {
            universalGrid1.Filtrele(filter);
            if (fcbMalzemeAltGrup2.SelectedValue == null) return;
            fcbBoyut.SetDataSource(_cache.boyutList.Where(b => b.malzemeAltGrup2Id.ToString() == fcbMalzemeAltGrup2.SelectedValue.ToString()).ToList());
        }

        private void fcbBoyut_SelectedIndexChanged(object sender, EventArgs e)
        {
            universalGrid1.Filtrele(filter);
        }
    }

}
