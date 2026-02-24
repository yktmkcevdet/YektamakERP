using ApiService.Interfaces;
using Models;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Utilities.Implementations;
using Utilities.Interfaces;
using YektamakDesktop.Abstracts;
using YektamakDesktop.Common;
using YektamakDesktop.CustomControls;
using YektamakDesktop.Formlar.Stok;

namespace YektamakDesktop.Formlar.Satinalma
{
    public partial class SatinalmaTalepOlusturmaFormu : Form, IUstForm
    {
        private readonly ICache _cache;
        private readonly ISatinalmaTalepService _satinalmaTalepService;
        private readonly IConvertHelper _convertHelper;
        private readonly ISatinalmaTalepHelper _satinalmaTalepHelper;
        public SatinalmaTalepOlusturmaFormu(ICache cache, ISatinalmaTalepService satinalmaTalepService, 
            IConvertHelper convertHelper, ISatinalmaTalepHelper satinalmaTalepHelper)
        {
            _cache = cache;
            _satinalmaTalepService = satinalmaTalepService;
            InitializeComponent();
            ctbTalepNo.Enabled = false;
            customDataGrid = new CustomDataGrid<DataControlSatinalmaTalepDetay>(2, 30, new Point(0, 0), new Size(990, 300));
            customDataGrid.SetUstForm(this);
            panel1.Controls.Add(customDataGrid.headerPanel);
            panel1.Controls.Add(customDataGrid.detailPanel);
            fcbProjeKod.SetDataSource(_cache.projeList.Where(x => x.sorumluList.Where(s => s.personel.Id == _cache.kullanici.personel.Id).Count() > 0).ToList());
            fcbStokGrup.SetDataSource(_cache.stokGrups);
            fcbStokTip.SetDataSource(_cache.stokTips);
            fcbMalzemeGrup.SetDataSource(_cache.malzemeGrups);
            fcbTalepNeden.SetDataSource(_cache.talepNedenList);
            satinalmaTalep.talepEdenKullanici.Id = _cache.kullanici.Id;
            BindData();
            _convertHelper = convertHelper;
            _satinalmaTalepHelper = satinalmaTalepHelper;
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
            BindHelper.BindData(fcbMalzemeGrup, satinalmaTalep.malzemeGrup, nameof(satinalmaTalep.malzemeGrup.Id));
            BindHelper.BindData(fcbStokTip, satinalmaTalep.stokTip, nameof(satinalmaTalep.stokTip.Id));
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
            fcbMalzemeGrup.SetDataSource(_cache.malzemeGrups.Where(x => x.stokGrup.Id == int.Parse(fcbStokGrup.SelectedValue.ToString())).ToList());
        }

        private void clbMalzemeGrup_SelectedIndexChanged(object sender, EventArgs e)
        {
            VeriDegisti?.Invoke(this, satinalmaTalep);
        }

        private void clbStokTip_SelectedIndexChanged(object sender, EventArgs e)
        {
            fcbMalzemeGrup.SetDataSource(_cache.malzemeGrups.Where(x => x.stokGrup.Id == int.Parse(fcbStokTip.SelectedValue.ToString())).ToList());
            fcbStokGrup.SetDataSource(_cache.stokGrups);
            VeriDegisti?.Invoke(this, satinalmaTalep);
        }
        private bool Validate()
        {
            bool isValid = true;
            isValid &= CheckFieldHelper.CheckField("Proje seçilmelidir", fcbProjeKod);
            isValid &= CheckFieldHelper.CheckField("Stok tipi seçilmelidir", fcbStokTip);
            isValid &= CheckFieldHelper.CheckField("Malzeme grubu seçilmelidir", fcbMalzemeGrup);
            isValid &= CheckFieldHelper.CheckField("Talep nedeni seçilmelidir", fcbTalepNeden);
            isValid &= CheckFieldHelper.CheckField("Teslim tarihi girilmelidir", ctbTeslimTarihi);
            isValid &= CheckFieldHelper.CheckField("En az bir satır eklenmelidir", customDataGrid);
            return isValid;
        }
        private async void customButtonSave1_SaveButtonClick(object sender, EventArgs e)
        {
            if (!Validate()) return;
            satinalmaTalep.satinalmaTalepDetays.Clear();
            List<SatinalmaTalepDetay> talepList = new List<SatinalmaTalepDetay>();
            foreach (var dataControlSatinalmaTalepDetay in customDataGrid.dataSource.Where(x => x.newRec == false))
            {
                if (!dataControlSatinalmaTalepDetay.ValidateFields()) return;
                SatinalmaTalepDetay projeStokKartDTO = dataControlSatinalmaTalepDetay.satinalmaTalepDetay;
                projeStokKartDTO.miktar = double.Parse(dataControlSatinalmaTalepDetay.miktar.TextCustom.ToString());
                talepList.Add(projeStokKartDTO);
                //SatinalmaTalepDetay satinalmaTalepDetay = new();
                //satinalmaTalepDetay = dataControlSatinalmaTalepDetay.satinalmaTalepDetay;
                //satinalmaTalep.satinalmaTalepDetays.Add(satinalmaTalepDetay);
            }
            Proje proje = new Proje { Id = int.TryParse(fcbProjeKod.SelectedValue.ToString(), out int projeId) ? projeId : null };
            MalzemeGrup malzemeGrup = new MalzemeGrup { Id = int.TryParse(fcbMalzemeGrup.SelectedValue.ToString(), out int malzemeGrupId) ? malzemeGrupId : null };
            satinalmaTalep.talepTarihi = DateTime.Today;
            satinalmaTalep.teslimTarihi = DateTime.Parse(ctbTeslimTarihi.TextCustom.ToString());
            _satinalmaTalepHelper.CreateSatinalmaTalep(talepList, proje, malzemeGrup);

            
            
            if (!ValidateTalepList(satinalmaTalep.satinalmaTalepDetays)) return;
            // CreateSatinalmaTalep();
            // string jsonResult = await _satinalmaTalepService.SaveSatinalmaTalep(satinalmaTalep);
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
                    TalepOnaylandi?.Invoke(this, _convertHelper.ToDTO<SatinalmaTalepDTO>(satinalmaTalep));
                }
            }
            //await HandleSaveResult(jsonResult);
        }
        private void fcbProjeKod_SelectedIndexChanged(object sender, EventArgs e)
        {
            VeriDegisti?.Invoke(this, satinalmaTalep);
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
        private readonly IConvertHelper _convertHelper;
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
            stokKartId.SetDataSource(stokKarts.CastToDTO<ProjeStokKartDTO>(_convertHelper).Select(item => item with { stokKartad = $"{item.stokKartkod} - {item.stokKartad} - {item.stokKartboyut}" }).ToList());
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
            _stokKartId.SetDataSource(stokKarts.CastToDTO<ProjeStokKartDTO>(_convertHelper).Select(item => item with { stokKartad = $"{item.stokKartkod} - {item.stokKartad} - {item.stokKartboyut}" }).ToList());
        }
        public DataControlSatinalmaTalepDetay(IProjeService projeService,IConvertHelper convertHelper)
        {
            _projeService = projeService;
            _convertHelper = convertHelper;
            Initialize();
        }
        private void StokKartId_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = stokKartId.SelectedItem as ProjeStokKartDTO;
            if (selected == null) return;
            olcuBirimi.TextCustom = selected.stokKartolcuBirimad;
            satinalmaTalepDetay.projeStokKart = _convertHelper.ToEntity<ProjeStokKart>(selected);
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
            isValid &= CheckFieldHelper.CheckField("Stok kartı seçilmelidir", stokKartId);
            isValid &= CheckFieldHelper.CheckField("Miktar girilmelidir", miktar);
            return isValid;
        }
    }
}
