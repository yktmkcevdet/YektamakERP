using ApiService.Interfaces;
using Models;
using Models.DTO;
using Models.Models;
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
            universalGrid1.kullanici = _cache.kullanici;
            clbStokGrupId.textBox.PlaceholderText = "Stok Grubu";
            clbMalzemeGrupId.textBox.PlaceholderText = "Malzeme Grubu";
            clbMalzemeAltGrupId.textBox.PlaceholderText = "Malzeme Alt Grubu";
            ctbBeginTalepTarihi.textBox.PlaceholderText = "Başlangıç Talep Tarihi";
            ctbEndTalepTarihi.textBox.PlaceholderText = "Bitiş Talep Tarihi";
            ctxBeginTeslimTarihi.textBox.PlaceholderText = "Başlangıç Teslim Tarihi";
            ctxEndTeslimTarihi.textBox.PlaceholderText = "Bitiş Teslim Tarihi";
            ComboBoxListFill.GetLookupAd(_cache.stokGrups, ref clbStokGrupId);
            ComboBoxListFill.GetLookupAd(_cache.malzemeGrups, ref clbMalzemeGrupId);
            customDataGrid = new CustomDataGrid<DataControlFirma>(2, 30, new Point(0, 0), new Size(650, 300));
            this.panel1.Controls.Add(customDataGrid.headerPanel);
            this.panel1.Controls.Add(customDataGrid.detailPanel);
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
        }
        List<SatinalmaTalepDetayDTO> _satinalmaTalepDetayDTOs;
        List<SatinalmaTalepDetayDTO> satinalmaTalepDetayDTOs { 
            get { if (_satinalmaTalepDetayDTOs == null) { _satinalmaTalepDetayDTOs = new(); } return _satinalmaTalepDetayDTOs; } 
            set { _satinalmaTalepDetayDTOs = value; }
        }
        private async void SatinalmaTalepTeklifFormu_Load(object sender, EventArgs e)
        {
            try
            {
                Binding();
                string jsonResult = await _satinalmaService.GetSatinalmaTalepDetay(new SatinalmaTalepDetay());
                Result result = _jsonConverter.DeserializeToModelList<Result>(jsonResult).FirstOrDefault();
                List<SatinalmaTalepDetay> satinalmaTalepDetay = _jsonConverter.ToModelList<SatinalmaTalepDetay>(result.result);
                foreach (var item in satinalmaTalepDetay)
                {
                    var detay = ConvertHelper.ToDTO<SatinalmaTalepDetayDTO>(item);
                    satinalmaTalepDetayDTOs.Add(detay);
                }
                universalGrid1.SetData(satinalmaTalepDetayDTOs, this.Name, false, false, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void Binding()
        {
            clbMalzemeAltGrupId.DataBindings.Clear();
            clbMalzemeAltGrupId.DataBindings.Add(nameof(clbMalzemeAltGrupId.selectedDataRowId), filter, nameof(filter.stokKartmalzemeAltGrupId), true, DataSourceUpdateMode.OnPropertyChanged);
            clbStokGrupId.DataBindings.Clear();
            clbStokGrupId.DataBindings.Add(nameof(clbStokGrupId.selectedDataRowId), filter, nameof(filter.stokKartstokGrupId), true, DataSourceUpdateMode.OnPropertyChanged);
            clbMalzemeGrupId.DataBindings.Clear();
            clbMalzemeGrupId.DataBindings.Add(nameof(clbMalzemeGrupId.selectedDataRowId), filter, nameof(filter.stokKartmalzemeGrupId), true, DataSourceUpdateMode.OnPropertyChanged);
        }
        private void SatinalmaTalepTeklifFormu_FormClosing(object sender, FormClosingEventArgs e)
        {
            universalGrid1.SaveSettings();
        }

        private async void btnTeklif_Click(object sender, EventArgs e)
        {
            try
            {
                var workbook = await GetExcelWorkbook();
                if (workbook == null)
                {
                    ShowError("Excel dosyası alınamadı.");
                    return;
                }

                var sheet = workbook.GetSheetAt(0);
                var selectedRows = GetSelectedRows();

                if (!selectedRows.Any())
                {
                    ShowError("Lütfen en az bir satır seçin.");
                    return;
                }
                FillExcelData(sheet, selectedRows);
                await CreateOrderFile();
                string fileName;
                SaveExcelFile(workbook, out fileName);
                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName);
                byte[] excelFileData = File.ReadAllBytes(filePath);
                filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"{clbMalzemeGrupId.selectedDataRowValue}");
                byte[] zipFileData = ZipDirectoryAndRead(filePath, $"{clbMalzemeGrupId.selectedDataRowValue}.zip");
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

                    mailGonder.mail.attachmentData.Add(new MailAttachament
                    {
                        fileName = $"Malzeme Talep Formu {DateTime.Now:yyyy-MM-dd HH-mm-ss}.zip",
                        fileData = zipFileData
                    });
                    mailGonder.mail.To = firm.mail;
                    SatinalmaTeklifBaslik satinalmaTeklifBaslik = new SatinalmaTeklifBaslik();
                    satinalmaTeklifBaslik.teklifFirma.Id = firm.Id.selectedDataRowId;
                    satinalmaTeklifBaslik.teklifTalepTarihi = DateTime.Now;
                    foreach (var satinalmaTalep in (IEnumerable<SatinalmaTalepDetayDTO>)universalGrid1.GetCheckedRows<SatinalmaTalepDetayDTO>())
                    {
                        satinalmaTeklifBaslik.satinalmaTeklifDetayList.Add(new SatinalmaTeklifDetay { satinalmaTalepDetay = ConvertHelper.ToEntity<SatinalmaTalepDetay>(satinalmaTalep) });

                    }
                    mailGonder.UpdateMode(satinalmaTeklifBaslik);
                    mailGonder.ShowDialog();
                }

            }
            catch (Exception ex)
            {
                ShowError($"Bir hata oluştu: {ex.Message}");
            }
        }
        private async Task CreateOrderFile()
        {
            var selectedRows = GetSelectedRows();
            foreach (var row in selectedRows)
            {
                foreach (var satinalmaTalepSatirDetay in satinalmaTalepDetayDTOs[row.Index].satinalmaTalepSatirDetays)
                {
                    StokKart stokKart = new StokKart { Id = satinalmaTalepSatirDetay.stokKart.Id };
                    string jsonResult = await _stokService.GetStokKartPdf(stokKart);
                    Result result = _jsonConverter.DeserializeToModelList<Result>(jsonResult)[0];
                    stokKart = _jsonConverter.ToModelList<StokKart>(result.result)[0];
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
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"{clbMalzemeGrupId.selectedDataRowValue}\\{path}", $"{skd.dosyaAd}.{skd.dosyaUzanti}");
            string directoryPath = Path.GetDirectoryName(filePath);
            // Dizin yoksa oluştur
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            File.WriteAllBytes(filePath, skd.dosya);
        }

        private async Task<XSSFWorkbook> GetExcelWorkbook()
        {
            var excelForm = new ExcelForm { formAd = "Malzeme Talep Formu" };
            string jsonResult = await _anaVeriService.GetExcelForm(excelForm);
            excelForm = _jsonConverter.DeserializeToModelList<ExcelForm>(jsonResult)[0];

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
            SetCellValue(sheet, 5, 4, firstRow.Cells[SatinalmaTalepDetayDTOHeader.TalepEdenHeader].Value?.ToString());
            SetCellValue(sheet, 5, 16, firstRow.Cells[SatinalmaTalepDetayDTOHeader.TalepTarihiHeader].Value?.ToString());
            SetCellValue(sheet, 6, 16, firstRow.Cells[SatinalmaTalepDetayDTOHeader.ProjeKoduHeader].Value?.ToString());
        }

        private void SetRowData(ISheet sheet, DataGridViewRow row, int rowIndex)
        {
            SetCellValue(sheet, rowIndex, 1, row.Cells[SatinalmaTalepDetayDTOHeader.StokKartKoduHeader].Value?.ToString());
            SetCellValue(sheet, rowIndex, 2, row.Cells[SatinalmaTalepDetayDTOHeader.StokKartAdiHeader].Value?.ToString());
            SetCellValue(sheet, rowIndex, 6, row.Cells[SatinalmaTalepDetayDTOHeader.TalepMiktariHeader].Value?.ToString());
        }

        private void SetCellValue(ISheet sheet, int rowIndex, int cellIndex, string value)
        {
            var row = sheet.GetRow(rowIndex) ?? sheet.CreateRow(rowIndex);
            var cell = row.GetCell(cellIndex) ?? row.CreateCell(cellIndex);
            cell.SetCellValue(value ?? string.Empty);
        }

        private void SaveExcelFile(XSSFWorkbook workbook, out string fileName)
        {
            fileName = $"Malzeme Talep Formu {DateTime.Now:yyyy-MM-dd HH-mm-ss}.xlsx";
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName);

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
            ComboBoxListFill.GetLookupAd(_cache.malzemeGrups.Where(c => c.stokGrup.Id == clbStokGrupId.selectedDataRowId).ToList(), ref clbMalzemeGrupId);
            ComboBoxListFill.GetLookupAd(_cache.malzemeAltGrups.Where(c => c.malzemeGrup.Id == clbMalzemeGrupId.selectedDataRowId).ToList(), ref clbMalzemeAltGrupId);
            universalGrid1.Filtrele(filter, this.Name);
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
                                        , this.Name, false, false, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veri tablosu yenilenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbxMalzemeGrupId_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxListFill.GetLookupAd(_cache.malzemeAltGrups.Where(c => c.malzemeGrup.Id == clbMalzemeGrupId.selectedDataRowId).ToList(), ref clbMalzemeAltGrupId);
            universalGrid1.Filtrele(filter, this.Name);
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
            public override List<SatinalmaTalepSatirDetay> satinalmaTalepSatirDetays { get => null; }
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
            private CustomComboListBox _Id;
            public CustomComboListBox Id { get { if (_Id == null) { _Id = new(); } return _Id; } set { _Id = value; } }
            private string _mail;
            public string mail { get { return _mail; } set { _mail = value; } }
            public DataControlFirma()
            {
                Id = new() { TabIndex = 1, Width = 300, Visible = true, Tag = "Id" };
                Id.textBox.PlaceholderText = "Firma Seçiniz";
                ComboBoxListFill.GetLookupAd(DIContainer.GetService<DataControl>()._cache.firmaList, ref _Id);

                Id.SelectedIndexChanged += Id_SelectedIndexChanged;
            }

            private void Id_SelectedIndexChanged(object sender, EventArgs e)
            {
                mail = DIContainer.GetService<DataControl>()._cache.firmaList.First(f => f.Id == Id.selectedDataRowId).mail;
                newRec = false; // Yeni kayıt değil, var olan bir firma seçildiğinde
            }
        }

        private void clbMalzemeAltGrupId_SelectedIndexChanged(object sender, EventArgs e)
        {
            universalGrid1.Filtrele(filter, this.Name);
        }
    }

}
