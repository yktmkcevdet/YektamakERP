using ApiService.Interfaces;
using Models;
using Models.Configuration;
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
using System.Linq.Dynamic.Core;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.TextFormatting;
using Utilities.Interfaces;
using YektamakDesktop.Abstracts;
using YektamakDesktop.Common;
using YektamakDesktop.CustomControls;
using YektamakDesktop.Formlar.Stok;

namespace YektamakDesktop.Formlar.Satinalma
{
    public partial class SatinalmaTalepTeklifFormu : Form
    {
        private readonly IJsonConverter _jsonConverter;
        private readonly ISatinalmaTalepService _satinalmaService;
        private readonly IConfigurationService _configurationService;
        private readonly ICache _cache;
        private readonly IAnaVeriService _anaVeriService;
        private readonly IStokService _stokService;
        private readonly IProjeService _projeService;
        public SatinalmaTalepTeklifFormu(IJsonConverter jsonConverter, ISatinalmaTalepService satinalmaService, IConfigurationService configurationService,
            ICache cache, IAnaVeriService anaVeriService, IStokService stokService, IProjeService projeService)
        {
            _jsonConverter = jsonConverter;
            _satinalmaService = satinalmaService;
            _configurationService = configurationService;
            _cache = cache;
            _anaVeriService = anaVeriService;
            _stokService = stokService;
            _projeService = projeService;
            InitializeComponent();
            Initialize();
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
            customDataGrid = new CustomDataGrid<DataControlFirma>(2, 30, new Point(0, 0), new Size(650, 300));
            this.panel1.Controls.Add(customDataGrid.headerPanel);
            this.panel1.Controls.Add(customDataGrid.detailPanel);
            customDataGrid.dataSource = dataControlFirmas;
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
            universalGrid1.Location = new System.Drawing.Point(locationX, locationY);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new System.Drawing.Size(sizeX, sizeY);
            universalGrid1.TabIndex = 13;
            Controls.Add(universalGrid1);
            universalGrid1.SetData(new List<SatinalmaTalepDetayDTO>(), this.Name, true);
            universalGrid1.MouseDown1 += universalGrid1_MouseDown;
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
                dgv.Parent = this;
                //dgv.Dock = DockStyle.Fill;
                dgv.AllowUserToAddRows = false;
                dgv.RowHeadersVisible = false;
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv.MultiSelect = false;
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                dgv.Columns.Clear();
                dgv.Columns.Add("Expand", "");
                dgv.Columns.Add("projeKod", "Müşteri");
                dgv.Columns.Add("yuzde", "yuzde");

                dgv.Columns["Expand"].Width = 40;
                dgv.Columns["yuzde"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv.Columns["yuzde"].DefaultCellStyle.Format = "N2";


                dgv.CellClick += Dgv_CellClick;
                dgv.CellPainting += dataGridView1_CellPainting;
                FillGrid();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void FillGrid()
        {
            dgv.Rows.Clear();

            var data = GetData().GroupBy(x => x.projeKod).ToList();

            foreach (var grup in data)
            {
                int rowIndex = dgv.Rows.Add("+", grup.Key, grup.Sum(x => x.satirSayisi));
                dgv.Rows[rowIndex].Tag = new SatinalmaTalepForGrup
                {
                    projeKod = grup.Key,
                    Details = grup.ToList(),
                    IsExpanded = false,
                    DetailGrid = null
                };
                dgv.Rows[rowIndex].DefaultCellStyle.Font = new Font(dgv.Font, FontStyle.Bold);
                dgv.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightGray;
            }
        }
        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex != 0) return;

            var row = dgv.Rows[e.RowIndex];
            if (row.Tag is not SatinalmaTalepForGrup info) return;

            if (info.IsExpanded)
            {
                CollapseGroup(row, info);
            }
            else
            {
                ExpandGroup(row, info);
            }
        }
        private void ExpandGroup(DataGridViewRow row, SatinalmaTalepForGrup info)
        {
            // Daha önce grid oluşturulmuş mu kontrol et
            if (info.DetailGrid == null)
            {
                var subGrid = new DataGridView
                {
                    AllowUserToAddRows = false,
                    RowHeadersVisible = false,
                    AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                    ReadOnly = true,
                    BackgroundColor = Color.White,
                    BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
                };

                subGrid.Columns.Add("projeKod", "Ürün");
                subGrid.Columns.Add("satirSayisi", "Adet");
                subGrid.Columns.Add("yuzde", "yuzde");
                subGrid.Columns["yuzde"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                subGrid.Columns["yuzde"].DefaultCellStyle.Format = "N2";

                foreach (var d in info.Details)
                {
                    subGrid.Rows.Add(d.projeKod, d.satirSayisi, d.yuzde);
                }

                // Alt grid tasarımı
                subGrid.Height = info.Details.Count * 24 + 25;
                subGrid.Width = dgv.Width - 60;
                subGrid.ScrollBars = ScrollBars.None;
                subGrid.ReadOnly = true;
                subGrid.CellPainting += dataGridView1_CellPainting;
                // Form üzerine ekle
                this.Controls.Add(subGrid);
                info.DetailGrid = subGrid;
            }

            // Grup satırının hemen altına konumlandır
            var rect = dgv.GetCellDisplayRectangle(0, row.Index, true);
            var nextRowBottom = rect.Bottom;
            info.DetailGrid.Location = new Point(rect.Left + 40, nextRowBottom);
            info.DetailGrid.BringToFront();
            info.DetailGrid.Visible = true;

            row.Cells[0].Value = "-";
            info.IsExpanded = true;
        }
        private void CollapseGroup(DataGridViewRow row, SatinalmaTalepForGrup info)
        {
            if (info.DetailGrid != null)
                info.DetailGrid.Visible = false;

            row.Cells[0].Value = "+";
            info.IsExpanded = false;
        }
        private List<SatinalmaTalepForMusteri> GetData()
        {
            return satinalmaTalepDetayDTOs.GroupBy(s =>
                s.projekod
            ).Select(g => new SatinalmaTalepForMusteri {projeKod= g.First().projekod,yuzde = g.Count()}).ToList();
        }
        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Başlık satırlarını veya boş alanları boyama
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            // Yüzde değeri hangi sütundaysa kontrol et (örneğin "Yuzde" isimli sütun)
            if (dgv.Columns[e.ColumnIndex].Name == "yuzde")
            {
                e.Handled = true; // Varsayılan boyamayı engelle
                e.PaintBackground(e.CellBounds, true);
                e.PaintContent(e.CellBounds);

                // Hücredeki değeri al
                if (e.Value != null && double.TryParse(e.Value.ToString().Replace("%", ""), out double value))
                {
                    // 0–100 aralığına çek
                    value = Math.Max(0, Math.Min(100, value));

                    // Dolum oranına göre genişlik hesapla
                    int fillWidth = (int)(e.CellBounds.Width * (value / 100.0));

                    // Renk (örneğin yeşil)
                    using (Brush b = new SolidBrush(Color.LightGreen))
                    {
                        Rectangle fillRect = new Rectangle(e.CellBounds.X, e.CellBounds.Y, fillWidth, e.CellBounds.Height);
                        e.Graphics.FillRectangle(b, fillRect);
                    }

                    // Kenarlık ve metni yeniden çiz
                    e.PaintContent(e.CellBounds);
                    e.Graphics.DrawRectangle(Pens.Gray, e.CellBounds);
                }
            }
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
                satinalmaTalepDetayDTOs = satinalmaTalepDetayList.CastToDTO<SatinalmaTalepDetayDTO>().ToList();
                await universalGrid1.SetData(satinalmaTalepDetayDTOs, this.Name, true);
            }
        }
        private async Task Binding()
        {
            BindHelper.BindData(clbProjeKod, filter, nameof(filter.projeId));
            BindHelper.BindData(clbStokGrupId, filter, nameof(filter.projeStokKartstokKartstokGrupId));
            BindHelper.BindData(clbMalzemeGrupId, filter, nameof(filter.projeStokKartstokKartmalzemeGrupId));
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
                        satinalmaTeklifBaslik.satinalmaTeklifDetayList.Add(new SatinalmaTeklifDetay { satinalmaTalepDetay = ConvertHelper.ToEntity<SatinalmaTalepDetay>(satinalmaTalep) });

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
            isValid &= GlobalData.CheckField("Malzeme grubu seçilmelidir.", clbMalzemeGrupId);
            isValid &= GlobalData.CheckField("En az bir firma seçilmelidir.", customDataGrid);
            return isValid;
        }
        private async Task CreateOrderFile()
        {
            string jsonResult = await _configurationService.GetDosyalamaYapisi(new DosyalamaYapisi());
            var dosyalamaYapisiList = JsonConvert.DeserializeObject<List<DosyalamaYapisi>>(jsonResult);
            var selectedRows = universalGrid1.GetCheckedRows<SatinalmaTalepDetayDTO>();
            foreach (var row in selectedRows)
            {
                StokKart stokKart = new StokKart { Id = row.projeStokKartstokKartId };
                jsonResult = _stokService.GetStokKartPdf(stokKart);
                stokKart = JsonConvert.DeserializeObject<List<StokKart>>(jsonResult)[0];
                foreach (var skd in stokKart.dosyaList)
                {
                    foreach (var dosyalamaYapisi in dosyalamaYapisiList)
                    {
                        if (row.projeStokKartstokKartmalzemeGrupId == dosyalamaYapisi.malzemeGrupId
                            && (dosyalamaYapisi.malzemeAltGrupId is null || dosyalamaYapisi.malzemeAltGrupId == row.projeStokKartstokKartmalzemeAltGrupId)
                            && (dosyalamaYapisi.boyutId is null || dosyalamaYapisi.boyutId == row.projeStokKartstokKartboyutTanimId)
                            && dosyalamaYapisi.isBukum == row.projeStokKartstokKartisBukum
                            )
                        {
                            if (dosyalamaYapisi.pdf && skd.dosyaTip.Id == 1)
                                SaveMaterialFile(skd, Path.Combine(dosyalamaYapisi.path, dosyalamaYapisi.klasorAd));
                            if (dosyalamaYapisi.dxf && skd.dosyaTip.Id == 2)
                                SaveMaterialFile(skd, Path.Combine(dosyalamaYapisi.path, dosyalamaYapisi.klasorAd));
                            if (dosyalamaYapisi.step && skd.dosyaTip.Id == 3)
                                SaveMaterialFile(skd, Path.Combine(dosyalamaYapisi.path, dosyalamaYapisi.klasorAd));
                        }
                    }
                }
                foreach (var satinalmaTalepSatirDetay in row.satinalmaTalepSatirDetays)
                {
                    stokKart = new StokKart { Id = row.projeStokKartstokKartId };
                    jsonResult = _stokService.GetStokKartPdf(stokKart);
                    stokKart = JsonConvert.DeserializeObject<List<StokKart>>(jsonResult)[0];
                    foreach (var skd in stokKart.dosyaList)
                    {
                        foreach (var dosyalamaYapisi in dosyalamaYapisiList)
                        {
                            if (row.projeStokKartstokKartmalzemeGrupId == dosyalamaYapisi.malzemeGrupId)
                            {
                                if (dosyalamaYapisi.pdf && skd.dosyaTip.Id == 1)
                                    SaveMaterialFile(skd, Path.Combine(dosyalamaYapisi.path, dosyalamaYapisi.klasorAd));
                                if (dosyalamaYapisi.dxf && skd.dosyaTip.Id == 2)
                                    SaveMaterialFile(skd, Path.Combine(dosyalamaYapisi.path, dosyalamaYapisi.klasorAd));
                                if (dosyalamaYapisi.step && skd.dosyaTip.Id == 3)
                                    SaveMaterialFile(skd, Path.Combine(dosyalamaYapisi.path, dosyalamaYapisi.klasorAd));
                            }
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
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), path, $"{skd.dosyaAd}.{skd.dosyaUzanti}");
            string directoryPath = Path.GetDirectoryName(filePath);
            // Dizin yoksa oluştur
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            File.WriteAllBytes(filePath, skd.dosya);
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
            SatinalmaTalepDetay satinalmaTalepDetay = ConvertHelper.ToEntity<SatinalmaTalepDetay>(satinalmaTalepDetayDTO);
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
            ComboBoxListFill.GetLookupAd(_cache.malzemeGrups.Where(c => c.stokGrup.Id == filter.projeStokKartstokKartstokGrupId).ToList(), ref clbMalzemeGrupId);
            //ComboBoxListFill.GetLookupAd(_cache.malzemeAltGrups.Where(c => c.malzemeGrup.Id == filter.projeStokKartstokKartmalzemeGrupId).ToList(), ref clbMalzemeAltGrupId);
            universalGrid1.Filtrele(filter);
        }
        private async void cbxMalzemeGrupId_SelectedIndexChanged(object sender, EventArgs e)
        {
            fccMalzemeAltGrupId.SetDataSource(satinalmaTalepDetayDTOs
                .Where(s => s.projeStokKartstokKartmalzemeGrupId.ToString() == clbMalzemeGrupId.SelectedValue?.ToString() && !string.IsNullOrEmpty(s.projeStokKartstokKartmalzemeAltGrupId.ToString()))
                .Select(s => new { Id = s.projeStokKartstokKartmalzemeAltGrupId, _cache.malzemeAltGrups.Where(m => m.Id == s.projeStokKartstokKartmalzemeAltGrupId).First().ad })
                .DistinctBy(b => b.Id)
                .ToList());
            fcbBoyut.SetDataSource((await _projeService.GetProjeStokKart(new ProjeStokKart ()))
                .Where(s => s.stokKart.malzemeGrup.Id.ToString() == clbMalzemeGrupId.SelectedValue?.ToString())
                .Select(s => s.stokKart.boyutTanim)
                .DistinctBy(b => b.Id)
                .ToList());
            universalGrid1.Filtrele(filter);
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
        private void clbProjeKod_SelectedIndexChanged(object sender, EventArgs e)
        {
            universalGrid1.Filtrele(filter);
        }
        private void fcbBoyut_SelectedIndexChanged(object sender, EventArgs e)
        {
            BoyutFiltrele();
        }
        private void isTeklif_CheckedChanged(object sender, EventArgs e)
        {
            GridDoldur();
        }
        private void fccMalzemeAltGrupId_ItemsChanged(object sender, EventArgs e)
        {
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
            universalGrid1.Filtrele(filter);
            MalzemeAltGrupFiltrele();
            MalzemeAltGrup2Filtrele();
            BukumFiltrele();
        }
        private void BukumFiltrele()
        {
            // 1. DataSource'u doğru tipe cast et
            var data = universalGrid1.binding.DataSource as IEnumerable<SatinalmaTalepDetayDTO>;
            if (data == null) return;

            // 2. Filtre uygula
            IEnumerable<SatinalmaTalepDetayDTO> filtered = data;
            if (chkBukum.CheckState == CheckState.Checked)
            {
                filtered = data.Where(x => x.projeStokKartstokKartisBukum == true);
            }
            else if (chkBukum.CheckState == CheckState.Unchecked)
            {
                filtered = data.Where(x => x.projeStokKartstokKartisBukum == false);
            }

            // 3. BindingSource oluştur ve ata
            var bindingSource = new BindingSource();
            bindingSource.DataSource = new SortableBindingList<SatinalmaTalepDetayDTO>(filtered.ToList());

            universalGrid1.Grid.DataSource = bindingSource;
            universalGrid1.lblGosterilenKayitSayisi.Text = $"Filtrelenen kayıt sayısı : {filtered.Count()}";
            return;
        }
        private bool BoyutFiltrele()
        {
            var seciliBoyutlar = fcbBoyut.SelectedValues.Cast<int>().ToList();
            if (seciliBoyutlar.Count == 0)
            {
                universalGrid1.Filtrele(filter);
                MalzemeAltGrupFiltrele();
                MalzemeAltGrup2Filtrele();
                return true;
            }
            // 1. DataSource'u doğru tipe cast et
            var data = universalGrid1.binding.DataSource as IEnumerable<SatinalmaTalepDetayDTO>;
            if (data == null) return false;

            // 2. Filtre uygula
            IEnumerable<SatinalmaTalepDetayDTO> filtered = data;
            if (seciliBoyutlar.Count > 0)
            {
                filtered = data.Where(x => seciliBoyutlar.Contains(x.projeStokKartstokKartboyutTanimId ?? 0));
            }

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
            var data = universalGrid1.binding.DataSource as IEnumerable<SatinalmaTalepDetayDTO>;
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
    }
    public class SatinalmaTalepForMusteri
    {
        public string projeKod { get; set; }
        public int satirSayisi { get; set; }
        public int teklifSayisi { get; set; }
        public decimal yuzde { get; set; }
    }

    public class SatinalmaTalepForGrup
    {
        public string projeKod { get; set; }
        public List<SatinalmaTalepForMusteri> Details { get; set; }
        public DataGridView DetailGrid { get; set; }
        public bool IsExpanded { get; set; }
        public string Grup { get; set; }
        public int satirSayisi { get; set; }
        public int teklifSayisi { get; set; }
        public decimal yuzde { get; set; }
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
            ComboBoxListFill.GetLookupAd(_cache.firmaList, ref _Id);
        }
        public DataControlFirma() { }

        private void Id_SelectedIndexChanged(object sender, EventArgs e)
        {
            mail = _cache.firmaList.First(f => f.Id == int.Parse(Id.SelectedValue.ToString())).mail;
            //newRec = false; // Yeni kayıt değil, var olan bir firma seçildiğinde
        }
    }
}
