using ApiService.Interfaces;
using Models;
using Models.DTO;
using Newtonsoft.Json;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities.Interfaces;
using YektamakDesktop.Abstracts;
using YektamakDesktop.Common;
using YektamakDesktop.CustomControls;
using YektamakDesktop.Formlar.Stok;
using YektamakDesktop.Helpers;

namespace YektamakDesktop.Formlar.Satinalma
{
    public partial class SatinalmaTalepOlusturmaFormu : Form, IUstForm
    {
        private readonly ICache _cache;
        private readonly ISatinalmaTalepService _satinalmaTalepService;
        private readonly IAnaVeriService _anaVeriService;
        private readonly IJsonConverter _jsonConverter;
        private readonly IProjeService _projeService;
        public SatinalmaTalepOlusturmaFormu(ICache cache, ISatinalmaTalepService satinalmaTalepService, IAnaVeriService anaVeriService, IJsonConverter jsonConverter, IProjeService projeService)
        {
            _cache = cache;
            _satinalmaTalepService = satinalmaTalepService;
            _anaVeriService = anaVeriService;
            _jsonConverter = jsonConverter;
            _projeService = projeService;
            InitializeComponent();
            ctbTalepNo.Enabled = false;
            customDataGrid = new CustomDataGrid<DataControlSatinalmaTalepDetay>(2, 30, new Point(0, 0), new Size(990, 300));
            customDataGrid.SetUstForm(this);
            panel1.Controls.Add(customDataGrid.headerPanel);
            panel1.Controls.Add(customDataGrid.detailPanel);
            ComboBoxListFill.GetLookupKod(_cache.projeList.Where(x => x.sorumluList.Where(s => s.Id == _cache.kullanici.personel.Id).Count() > 0).ToList(), ref fcbProjeKod);
            ComboBoxListFill.GetLookupAd(_cache.stokGrups, ref clbStokGrup);
            ComboBoxListFill.GetLookupAd(_cache.stokTips, ref clbStokTip);
            ComboBoxListFill.GetLookupAd(_cache.malzemeGrups, ref clbMalzemeGrup);
            ComboBoxListFill.GetLookupAd(_cache.talepNedenList, ref fcbTalepNeden);
            satinalmaTalep.talepEdenKullanici.Id = _cache.kullanici.Id;
            BindData();
        }
        public event EventHandler<object> VeriDegisti;
        public event EventHandler<SatinalmaTalepDTO> TalepOnaylandi;
        CustomDataGrid<DataControlSatinalmaTalepDetay> customDataGrid;
        SatinalmaTalep _satinalmaTalep;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SatinalmaTalep satinalmaTalep
        {
            get { if (_satinalmaTalep == null) { _satinalmaTalep = new(); } return _satinalmaTalep; }
            set
            {
                _satinalmaTalep = value;
                BindData();
            }
        }
        public void UpdateMode(SatinalmaTalep satinalmaTalep)
        {
            this.satinalmaTalep = satinalmaTalep;
        }
        private void BindData()
        {
            BindHelper.BindData(clbMalzemeGrup, satinalmaTalep.malzemeGrup, nameof(satinalmaTalep.malzemeGrup.Id));
            BindHelper.BindData(clbStokTip, satinalmaTalep.stokTip, nameof(satinalmaTalep.stokTip.Id));
            BindHelper.BindData(ctbAciklama, satinalmaTalep, nameof(satinalmaTalep.aciklama));
            BindHelper.BindData(ctbTalepNo,satinalmaTalep, nameof(satinalmaTalep.satinalmaTalepNo));
            BindHelper.BindData(ctbTeslimTarihi, satinalmaTalep, nameof(satinalmaTalep.teslimTarihi));
            BindHelper.BindData(fcbProjeKod, satinalmaTalep.proje, nameof(satinalmaTalep.proje.Id));
            BindHelper.BindData(fcbTalepNeden, satinalmaTalep.talepNeden, nameof(satinalmaTalep.talepNeden.Id));
            satinalmaTalep.talepTarihi = DateTime.Today;
            satinalmaTalep.talepEdenKullanici = _cache.kullanici;
            List<DataControlSatinalmaTalepDetay> dataControlSatinalmaTalepDetays = new();
            foreach (var satinalmaTalepDetay in satinalmaTalep.satinalmaTalepDetays)
            {
                DataControlSatinalmaTalepDetay dataControlSatinalmaTalepDetay = DIContainer.GetService<DataControlSatinalmaTalepDetay>();
                if (!dataControlSatinalmaTalepDetay.ValidateFields()) return;
                dataControlSatinalmaTalepDetay.satinalmaTalepDetay = satinalmaTalepDetay;
                dataControlSatinalmaTalepDetays.Add(dataControlSatinalmaTalepDetay);
            }
            customDataGrid.dataSource = dataControlSatinalmaTalepDetays;
        }
        private void clbStokGrup_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxListFill.GetLookupAd(_cache.malzemeGrups.Where(x => x.stokGrup.Id == int.Parse(clbStokGrup.SelectedValue.ToString())).ToList(), ref clbMalzemeGrup);
        }

        private void clbMalzemeGrup_SelectedIndexChanged(object sender, EventArgs e)
        {
            VeriDegisti?.Invoke(this, satinalmaTalep);
        }

        private void clbStokTip_SelectedIndexChanged(object sender, EventArgs e)
        {
            clbMalzemeGrup.SetDataSource(_cache.malzemeGrups.Where(x => x.stokGrup.Id == int.Parse(clbStokTip.SelectedValue.ToString())).ToList());
            clbStokGrup.SetDataSource(_cache.stokGrups);
            VeriDegisti?.Invoke(this, satinalmaTalep);
        }
        private bool Validate()
        {
            bool isValid = true;
            isValid &= GlobalData.CheckField("Proje seçilmelidir", fcbProjeKod);
            isValid &= GlobalData.CheckField("Stok tipi seçilmelidir", clbStokTip);
            isValid &= GlobalData.CheckField("Malzeme grubu seçilmelidir", clbMalzemeGrup);
            isValid &= GlobalData.CheckField("Talep nedeni seçilmelidir", fcbTalepNeden);
            isValid &= GlobalData.CheckField("Teslim tarihi girilmelidir", ctbTeslimTarihi);
            isValid &= GlobalData.CheckField("En az bir satır eklenmelidir", customDataGrid);
            return isValid;
        }
        private async void customButtonSave1_SaveButtonClick(object sender, EventArgs e)
        {

            if (!Validate()) return;
            satinalmaTalep.satinalmaTalepDetays.Clear();
            foreach (var dataControlSatinalmaTalepDetay in customDataGrid.dataSource.Where(x => x.newRec == false))
            {
                if (!dataControlSatinalmaTalepDetay.ValidateFields()) return;
                SatinalmaTalepDetay satinalmaTalepDetay = new();
                satinalmaTalepDetay = dataControlSatinalmaTalepDetay.satinalmaTalepDetay;
                satinalmaTalep.satinalmaTalepDetays.Add(satinalmaTalepDetay);
            }
            satinalmaTalep.talepTarihi = DateTime.Today;
            if (!ValidateTalepList(satinalmaTalep.satinalmaTalepDetays)) return;
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
        private async void CreateSatinalmaTalep()
        {
            List<ProjeStokKartDTO> talepList = new();
            foreach (var satinalmaTalepDetay in satinalmaTalep.satinalmaTalepDetays)
            {
                ProjeStokKart projeStokKart = new ProjeStokKart();
                projeStokKart = satinalmaTalepDetay.projeStokKart;
                talepList.Add(ConvertHelper.ToDTO<ProjeStokKartDTO>(projeStokKart));
            }
            if (Validate())
            {
                List<SatinalmaTalepDetay> satinalmaTalepDetayList = new List<SatinalmaTalepDetay>();
                foreach (var item in talepList)
                {
                    //item.Id = null; //projestokKartId satinalmaTalepDetayId olarak aktarılmaması için null yapılıyor
                    SatinalmaTalepDetay satinalmaTalepdetay = new SatinalmaTalepDetay { proje = { Id = int.TryParse(fcbProjeKod.SelectedValue.ToString(), out int proje) ? proje : null } };
                    SatinalmaTalepSatirDetayDTO satinalmaTalepSatirDetay = new SatinalmaTalepSatirDetayDTO();
                    // Eğer stok kartının hammaddeId'si varsa, ve lazer grubuna ait parça değilse satınalma talep detay listesine hammadde olarak ekle
                    if (item.stokKarthammaddeId != null && item.stokKartmalzemeGrupId != 28)
                    {
                        //Hammadde ise ve listeye daha önce eklenmiş mi kontrol et, eklenmişse miktarını güncelle
                        if (satinalmaTalepDetayList.Any(x => x.projeStokKart.stokKart.Id == item.stokKarthammaddeId))
                        {
                            satinalmaTalepdetay = satinalmaTalepDetayList.FirstOrDefault(x => x.projeStokKart.stokKart.Id == item.stokKarthammaddeId);
                            if (item.stokKarthammaddeolcuBirimId == 2)
                            {
                                satinalmaTalepdetay.miktar += item.miktar * item.stokKartagirlik;
                            }
                            else
                            {
                                satinalmaTalepdetay.miktar += item.miktar;
                            }
                            satinalmaTalepdetay.agirlik += item.miktar * item.stokKartagirlik;

                            satinalmaTalepdetay.satinalmaTalepSatirDetays.Add(
                                new SatinalmaTalepSatirDetay { projeStokKart = ConvertHelper.ToEntity<ProjeStokKart>(item) });
                        }
                        // Eğer hammadde olarak eklenmemişse, yeni bir hammadde olarak ekle
                        else
                        {
                            if (satinalmaTalepdetay.projeStokKart.stokKart.hammadde.olcuBirim.Id == 2)
                            {
                                satinalmaTalepdetay.miktar = item.miktar * item.stokKartagirlik;
                            }
                            else
                            {
                                satinalmaTalepdetay.miktar = item.miktar;
                            }
                            satinalmaTalepdetay.projeStokKart = new ProjeStokKart
                            {
                                stokKart = new StokKart { Id = item.stokKarthammaddeId }
                            };
                            satinalmaTalepdetay.agirlik = item.miktar * item.stokKartagirlik;
                            satinalmaTalepdetay.satinalmaTalepSatirDetays.Add(new SatinalmaTalepSatirDetay { projeStokKart = ConvertHelper.ToEntity<ProjeStokKart>(item) });
                            satinalmaTalepdetay.projeStokKart = (await _projeService.GetProjeStokKart(new ProjeStokKart
                            {
                                proje = { Id = Convert.ToInt32(fcbProjeKod.SelectedValue) },
                                stokKart = new StokKart { Id = item.stokKarthammaddeId }
                            })).FirstOrDefault();
                            satinalmaTalepDetayList.Add(satinalmaTalepdetay);
                        }
                    }
                    // Eğer stok kartının hammaddeId'si yoksa, satınalma talep detay listesine normal stok kartı olarak ekle
                    else
                    {
                        satinalmaTalepdetay = new SatinalmaTalepDetay { projeStokKart = ConvertHelper.ToEntity<ProjeStokKart>(item) };
                        satinalmaTalepdetay.miktar = item.miktar;
                        satinalmaTalepdetay.onaylananMiktar = item.miktar;
                        satinalmaTalepdetay.agirlik = item.miktar * item.stokKartagirlik;
                        satinalmaTalepDetayList.Add(satinalmaTalepdetay);
                    }
                }
                SatinalmaTalep satinalmaTalep = new SatinalmaTalep
                {
                    proje = { Id = int.TryParse(fcbProjeKod.SelectedValue.ToString(), out int projeId) ? projeId : null },
                    //malzemeGrup = new MalzemeGrup { Id = int.TryParse(clbMalzemeGrup.SelectedValue.ToString(), out int malzemegrupId) ? malzemegrupId : null },
                    talepTarihi = DateTime.Today,
                    teslimTarihi = null,
                    aciklama = "Otomatik oluşturulan satınalma talebi",
                    talepEdenKullanici = _cache.kullanici,
                    satinalmaTalepDetays = satinalmaTalepDetayList
                };
            }
        }
        private void fcbProjeKod_SelectedIndexChanged(object sender, EventArgs e)
        {
            VeriDegisti?.Invoke(this, satinalmaTalep);
        }
        private async Task HandleSaveResult(string jsonResult)
        {
            if (String.IsNullOrEmpty(jsonResult) || jsonResult.Contains("error", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show($"Kaydetme işlemi başarısız oldu. {jsonResult}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            satinalmaTalep = _jsonConverter.DeserializeObject<List<SatinalmaTalep>>(jsonResult).FirstOrDefault();
            var selectedRows = satinalmaTalep.satinalmaTalepDetays.CastToDTO<SatinalmaTalepDetayDTO>();
            int? satirSayisi = selectedRows.Count() > 25 ? selectedRows.Count() : 25;
            var workbook = await GetExcelWorkbook(satirSayisi);
            if (workbook == null)
            {
                MessageBox.Show("Excel dosyası alınamadı.");
                return;
            }

            var sheet = workbook.GetSheetAt(0);

            FillExcelData(sheet, selectedRows);

            if (String.IsNullOrEmpty(jsonResult) || jsonResult.Contains("error", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show($"Kaydetme işlemi başarısız oldu. {jsonResult}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                MessageBox.Show("Kaydetme işlemi başarılı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MailHelper.SendSystemMail(mail.To, mail.Subject, mail.Body, mail.attachmentData);
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
        private void FillExcelData(ISheet sheet, IEnumerable<SatinalmaTalepDetayDTO> selectedRows)
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
        private void SetHeaderData(ISheet sheet, SatinalmaTalepDetayDTO firstRow)
        {
            // Talep Eden ve Talep Tarihi
            SetCellValue(sheet, 5, 4, satinalmaTalep.talepEdenKullanici.personel.adSoyad);
            SetCellValue(sheet, 6, 4, satinalmaTalep.talepNeden.ad);
            SetCellValue(sheet, 5, 16, satinalmaTalep.talepTarihi?.ToShortDateString());
            SetCellValue(sheet, 6, 16, satinalmaTalep.proje.kod);
        }

        private void SetRowData(ISheet sheet, SatinalmaTalepDetayDTO row, int rowIndex)
        {
            SetCellValue(sheet, rowIndex, 1, row.projeStokKartstokKartkod?.ToString());
            SetCellValue(sheet, rowIndex, 2, row.projeStokKartstokKartad?.ToString());
            SetCellValue(sheet, rowIndex, 6, row.miktar?.ToString("N0"));
            SetCellValue(sheet, rowIndex, 8, row.projeStokKartstokKartmalzemeStandart?.ToString());
            SetCellValue(sheet, rowIndex, 13, row.projeStokKartstokKartboyut?.ToString());
            SetCellValue(sheet, rowIndex, 15, row.projeStokKartstokKartuzunluk?.ToString());
            SetCellValue(sheet, rowIndex, 17, row.projeStokKartstokKartagirlik?.ToString("N1"));
            SetCellValue(sheet, rowIndex, 19, row.agirlik?.ToString("N1"));
            SetCellValue(sheet, rowIndex, 21, row.projeStokKartstokKartaciklama?.ToString());

        }
        private void SetCellValue(ISheet sheet, int rowIndex, int cellIndex, string value)
        {
            var row = sheet.GetRow(rowIndex) ?? sheet.CreateRow(rowIndex);
            var cell = row.GetCell(cellIndex) ?? row.CreateCell(cellIndex);
            cell.SetCellValue(value ?? string.Empty);
        }
        public bool ValidateTalepList(List<SatinalmaTalepDetay> stokKarts)
        {
            // Formdaki gerekli alanların dolu olup olmadığını kontrol et
            if (!stokKarts.Any())
            {
                MessageBox.Show("Satınalma talebi oluşturulacak satırlar seçilmelidir.");
                return false;
            }
            if (stokKarts.Any(x => {
                if (x.projeStokKart.stokKart.isPdf == false)
                {
                    MessageBox.Show($"{x.projeStokKart.stokKart.kod} kodlu parçanın PDF dosyası yok.");
                    return true;
                }
                else if (x.projeStokKart.stokKart.isDxf == false)
                {
                    MessageBox.Show($"{x.projeStokKart.stokKart.kod} kodlu parçanın DXF dosyası yok.");
                    return true;
                }
                else if (x.projeStokKart.stokKart.isStep == false)
                {
                    DialogResult dialogResult = MessageBox.Show("STEP dosyası olmayan kayıtlar var devam edilsin mi?", "STEP Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.No)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if ( x.projeStokKart.stokKart.isSatinalma == true)
                {
                    DialogResult dialogResult = MessageBox.Show("Satınalma talebi açılmış kayıtlar seçildi. Devam etmek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.No)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }))
            {
                return false;
            }
            return true;
        }
    }

    public class DataControlSatinalmaTalepDetay : DataControl, IEntity, IAltForm
    {
        private readonly IProjeService _projeService;
        public DataControlSatinalmaTalepDetay(SatinalmaTalep satinalmaTalep)
        {
            _satinalmaTalep = satinalmaTalep;
            Initialize();
        }
        public DataControlSatinalmaTalepDetay()
        {
        }
        private void Initialize()
        {
            stokKartId.SetDataSource(stokKarts.CastToDTO<ProjeStokKartDTO>().Select(item => item with { stokKartad = $"{item.stokKartkod} - {item.stokKartad} - {item.stokKartboyut}" }).ToList());
            stokKartId.SelectedIndexChanged += StokKartId_SelectedIndexChanged;
            BindData();
        }
        public void UstFormuBagla(IUstForm ustForm)
        {
            ustForm.VeriDegisti += UstVerisiDegisti;
        }
        private static List<ProjeStokKart> _stokKarts;
        public static List<ProjeStokKart> stokKarts
        {
            get { if (_stokKarts == null) { _stokKarts = new(); } return _stokKarts; }
            set { _stokKarts = value; }
        }
        private async void UstVerisiDegisti(object sender, object yeniDeger)
        {
            _satinalmaTalep = (SatinalmaTalep)yeniDeger;
            stokKarts.Clear();
            ProjeStokKart projeStokKart = new ProjeStokKart();
            projeStokKart.proje.Id = satinalmaTalep.proje.Id;
            projeStokKart.stokKart.malzemeGrup.Id = satinalmaTalep.malzemeGrup.Id;
            projeStokKart.stokKart.stokTip.Id = satinalmaTalep.stokTip.Id;
            stokKarts = await _projeService.GetProjeStokKart(projeStokKart);
            _stokKartId.SetDataSource(stokKarts.CastToDTO<ProjeStokKartDTO>().Select(item => item with { stokKartad = $"{item.stokKartkod} - {item.stokKartad} - {item.stokKartboyut}" }).ToList());
        }
        public DataControlSatinalmaTalepDetay(IProjeService projeService)
        {
            _projeService = projeService;
            Initialize();
        }
        private void StokKartId_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = stokKartId.SelectedItem as ProjeStokKartDTO;
            if (selected == null) return;
            olcuBirimi.TextCustom = selected.stokKartolcuBirimad;
        }
        ContextMenuStrip cntxtMenuStrip = new ContextMenuStrip();
        private static SatinalmaTalep _satinalmaTalep;
        public static SatinalmaTalep satinalmaTalep
        {
            get { if (_satinalmaTalep == null) { _satinalmaTalep = new(); } return _satinalmaTalep; }
            set
            {
                _satinalmaTalep = value;
            }
        }
        private SatinalmaTalepDetay _satinalmaTalepDetay;
        public SatinalmaTalepDetay satinalmaTalepDetay
        {
            get { if (_satinalmaTalepDetay == null) { _satinalmaTalepDetay = new(); } return _satinalmaTalepDetay; }
            set
            {
                _satinalmaTalepDetay = value;
                BindData();
            }
        }
        public CustomTextBox Id { get; set; } = new() { TabIndex = 1, Width = 0, Visible = true, Tag = "Id" };
        public FilterableComboBox _stokKartId;
        public FilterableComboBox stokKartId
        {
            get
            {
                if (_stokKartId == null)
                {
                    _stokKartId = new() { TabIndex = 2, Width = 300, Visible = true, Tag = "Stok Kartı", DisplayMember = "stokKartad", ValueMember = "Id" };
                    _stokKartId.MouseDown += _stokKartId_MouseDown;
                    cntxtMenuStrip.Items.Add("Stok Kartını Görüntüle", null, async (s, e) =>
                    {
                        ProjeStokKart projeStokKart = satinalmaTalepDetay.projeStokKart;
                        List<ProjeStokKart> projeStokKarts = await _projeService.GetProjeStokKart(projeStokKart);
                        if (projeStokKarts.Count > 1)
                        {
                            projeStokKart = projeStokKarts.Where(p => p.proje.Id == satinalmaTalepDetay.proje.Id).FirstOrDefault();
                        }
                        else
                        {
                            projeStokKart = projeStokKarts[0];
                        }
                        StokKartKayitFormu stokKartKayitFormu = FormFactory.CreateForm<StokKartKayitFormu>();
                        stokKartKayitFormu.UpdateMode(projeStokKart);
                        stokKartKayitFormu.ShowDialog();
                    });
                }
                return _stokKartId;
            }
            set { _stokKartId = value; }
        }

        private void _stokKartId_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                cntxtMenuStrip.Show(sender as Control, e.Location);
            }
        }

        public CustomTextBoxSayisal miktar { get; set; } = new() { TabIndex = 3, Width = 100, Visible = true, Tag = "Miktar" };
        public CustomTextBox olcuBirimi { get; set; } = new() { TabIndex = 4, Width = 50, Visible = true, Tag = "Ölçü Birimi", Enabled = false };
        public CustomTextBox aciklama { get; set; } = new() { TabIndex = 5, Width = 350, Visible = true, Tag = "Açıklama" };

        private void BindData()
        {
            BindHelper.BindData(Id, satinalmaTalepDetay, nameof(satinalmaTalepDetay.Id));
            BindHelper.BindData(miktar, satinalmaTalepDetay, nameof(satinalmaTalepDetay.miktar));
            BindHelper.BindData(olcuBirimi, satinalmaTalepDetay.projeStokKart.stokKart.olcuBirim, nameof(satinalmaTalepDetay.projeStokKart.stokKart.olcuBirim.ad));
            BindHelper.BindData(stokKartId, satinalmaTalepDetay.projeStokKart, nameof(satinalmaTalepDetay.projeStokKart.Id));
            BindHelper.BindData(aciklama, satinalmaTalepDetay, nameof(satinalmaTalepDetay.aciklama));
        }
        public bool ValidateFields()
        {
            bool isValid = true;
            isValid &= GlobalData.CheckField("Stok kartı seçilmelidir", stokKartId);
            isValid &= GlobalData.CheckField("Miktar girilmelidir", miktar);
            return isValid;
        }
    }
}
