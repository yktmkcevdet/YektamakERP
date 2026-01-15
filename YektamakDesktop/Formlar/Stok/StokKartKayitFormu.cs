using ApiService.Implementations;
using ApiService.Interfaces;
using Models;
using Models.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Utilities.Interfaces;
using YektamakDesktop.Abstracts;
using YektamakDesktop.Common;
using YektamakDesktop.CustomControls;
using YektamakDesktop.Formlar.Genel;
using YektamakDesktop.Properties;

namespace YektamakDesktop.Formlar.Stok
{
    public partial class StokKartKayitFormu : Form
    {
        private readonly IStokService _stokService;
        private readonly ICache _cache;
        private readonly IDataTableMapper _dataTableHelper;
        private readonly IJsonConverter _jsonConverter;
        private readonly IProjeService _projeService;
        private readonly IFileService _fileService;
        private readonly IConvertHelper _convertHelper;
        public StokKartKayitFormu(ICache cache, IDataTableMapper dataTableHelper, IJsonConverter jsonConvertHelper,
            IStokService stokService, IProjeService projeService, IFileService fileService, IConvertHelper convertHelper)
        {
            _cache = cache;
            _dataTableHelper = dataTableHelper;
            _jsonConverter = jsonConvertHelper;
            _stokService = stokService;
            _projeService = projeService;
            _fileService = fileService;
            InitializeComponent();
            clbStokTip.SetDataSource(_cache.stokTips);
            clbOlcuBirim.SetDataSource(_cache.olcuBirims);
            clbMalzemeStandart.SetDataSource(_cache.malzemeStandarts);
            clbProjeKod.SetDataSource(_cache.projeList.Where(x => x.sorumluList.Where(s => s.personel.Id == _cache.kullanici.personel.Id).Count() > 0).ToList());
            
            clbStokGrup.SetDataSource(_cache.stokGrups);
            clbMalzemeGrup.SetDataSource(_cache.malzemeGrups);
            clbMalzemeAltGrup.SetDataSource(_cache.malzemeAltGrups);
            clbMalzemeAltGrup2.SetDataSource(_cache.malzemeAltGrup2List);
            fcbBoyut.SetDataSource(_cache.boyutList);
            Binding();
            
            _fileService = fileService;
            _convertHelper = convertHelper;
        }
        public event EventHandler<object> AfterSave;
        private ProjeStokKart _projeStokKart;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ProjeStokKart projeStokKart
        {
            get
            {
                if (_projeStokKart == null) { _projeStokKart = new ProjeStokKart(); }
                return _projeStokKart;
            }
            set
            {
                _projeStokKart = value;
                Binding();
            }
        }
        public void UpdateMode(ProjeStokKart stokKartToUpdate)
        {
            projeStokKart = stokKartToUpdate;

        }

        private bool CheckFields()
        {
            bool result = true;
            result = CheckFieldHelper.CheckField("*", ctbStokAd) && result;
            result = CheckFieldHelper.CheckField("*", clbStokTip) && result;
            result = CheckFieldHelper.CheckField("*", clbStokGrup) && result;
            result = CheckFieldHelper.CheckField("*", clbMalzemeGrup) && result;
            if (clbMalzemeGrup.SelectedIndex != -1) result = CheckFieldHelper.CheckField("*", clbMalzemeAltGrup2) && result;
            if (clbMalzemeAltGrup.SelectedIndex != -1) result = CheckFieldHelper.CheckField("*", clbMalzemeAltGrup) && result;
            result = CheckFieldHelper.CheckField("*", clbOlcuBirim) && result;
            result = CheckFieldHelper.CheckField("*", clbProjeKod) && result;
            if (_cache.kullanici.Id != 1)
            {
                if (!_cache.projeList.Any(p => p.sorumluList.Where(s => s.personel.Id == _cache.kullanici.personel.Id).Count() > 0 && p.Id == projeStokKart.proje.Id))
                {
                    MessageBox.Show("Bu stok kartı için seçilen proje, kullanıcının projeleri arasında bulunmamaktadır. Lütfen geçerli bir proje seçiniz.");
                    result = false;
                }
            }
            return result;
        }
        private async void rButtonKaydet_Click(object sender, EventArgs e)
        {
            if (!CheckFields())
            {
                MessageBox.Show("Lütfen zorunlu alanları doldurunuz.");
                return;
            }

            var data = customDataGrid.dataSource;
            projeStokKart.stokKart.dosyaList.Clear();
            foreach (var dataControlStokKartDosya in data.Where(s => s.newRec == false))
            {
                if (!dataControlStokKartDosya.Validate()) return;
                projeStokKart.stokKart.dosyaList.Add(dataControlStokKartDosya.stokKartDosya);
                var filePath = Path.Combine(Guid.NewGuid() + "." + dataControlStokKartDosya.stokKartDosya.dosyaUzanti);
                dataControlStokKartDosya.stokKartDosya.dosyaFullPath = filePath;
                _fileService.SaveFile(dataControlStokKartDosya.dosyaVeri, filePath);
            }
            string jsonResult = await _projeService.SaveProjeStokKart(projeStokKart);
            if (String.IsNullOrEmpty(jsonResult) || jsonResult.Contains("error", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Stok kart kaydı sırasında bir hata oluştu: " + jsonResult);
            }
            else
            {
                ProjeStokKart savedProjeStokKart = JsonConvert.DeserializeObject<List<ProjeStokKart>>(jsonResult).FirstOrDefault();
                projeStokKart = savedProjeStokKart;
                AfterSave?.Invoke(this, savedProjeStokKart);
                MessageBox.Show("Stok Kartı Kayıt Edildi");
            }
        }
        private void Binding()
        {
            BindHelper.BindData(ctbId, projeStokKart, nameof(projeStokKart.Id));
            BindHelper.BindData(ctbStokKartId, projeStokKart.stokKart, nameof(projeStokKart.stokKart.Id));
            BindHelper.BindData(ctbStokKartNo, projeStokKart, nameof(projeStokKart.no));
            BindHelper.BindData(clbProjeKod, projeStokKart.proje, nameof(projeStokKart.proje.Id));
            BindHelper.BindData(ctbKod, projeStokKart.stokKart, nameof(projeStokKart.stokKart.kod));
            BindHelper.BindData(ctbTedarikciKod, projeStokKart.stokKart, nameof(projeStokKart.stokKart.tedarikciKod));
            BindHelper.BindData(ctbStokAd, projeStokKart.stokKart, nameof(projeStokKart.stokKart.ad));
            BindHelper.BindData(ctbBoyut, projeStokKart.stokKart, nameof(projeStokKart.stokKart.boyut));
            BindHelper.BindData(ctbUzunluk, projeStokKart.stokKart, nameof(projeStokKart.stokKart.uzunluk));
            BindHelper.BindData(ctbAciklama, projeStokKart.stokKart, nameof(projeStokKart.stokKart.aciklama));
            BindHelper.BindData(ctbAgirlik, projeStokKart.stokKart, nameof(projeStokKart.stokKart.agirlik));
            BindHelper.BindData(ctbBoy, projeStokKart.stokKart, nameof(projeStokKart.stokKart.boy));
            BindHelper.BindData(ctbEn, projeStokKart.stokKart, nameof(projeStokKart.stokKart.en));
            BindHelper.BindData(ctbYukseklik, projeStokKart.stokKart, nameof(projeStokKart.stokKart.yukseklik));
            BindHelper.BindData(ctbCap, projeStokKart.stokKart, nameof(projeStokKart.stokKart.cap));
            BindHelper.BindData(ctbEtKalinlik, projeStokKart.stokKart, nameof(projeStokKart.stokKart.etKalinligi));
            BindHelper.BindData(checkBoxIsSatinalma, projeStokKart.stokKart, nameof(projeStokKart.stokKart.isSatinalma));
            BindHelper.BindData(checkBoxIsPdf, projeStokKart.stokKart, nameof(projeStokKart.stokKart.isPdf));
            BindHelper.BindData(checkBoxIsFromExcel, projeStokKart.stokKart, nameof(projeStokKart.stokKart.isFromExcel));
            BindHelper.BindData(checkBoxIsStep, projeStokKart.stokKart, nameof(projeStokKart.stokKart.isStep));
            BindHelper.BindData(checkBoxIsDxf, projeStokKart.stokKart, nameof(projeStokKart.stokKart.isDxf));
            BindHelper.BindData(clbStokTip, projeStokKart.stokKart.stokTip, nameof(projeStokKart.stokKart.stokTip.Id));
            BindHelper.BindData(clbOlcuBirim, projeStokKart.stokKart.olcuBirim, nameof(projeStokKart.stokKart.olcuBirim.Id));
            BindHelper.BindData(clbMalzemeStandart, projeStokKart.stokKart.malzemeStandart, nameof(projeStokKart.stokKart.malzemeStandart.Id));
            BindHelper.BindData(clbMalzemeAltGrup2, projeStokKart.stokKart.malzemeAltGrup2, nameof(projeStokKart.stokKart.malzemeAltGrup2.Id));
            BindHelper.BindData(clbMalzemeAltGrup, projeStokKart.stokKart.malzemeAltGrup, nameof(projeStokKart.stokKart.malzemeAltGrup.Id));
            BindHelper.BindData(clbMalzemeGrup, projeStokKart.stokKart.malzemeGrup, nameof(projeStokKart.stokKart.malzemeGrup.Id));
            BindHelper.BindData(clbStokGrup, projeStokKart.stokKart.stokGrup, nameof(projeStokKart.stokKart.stokGrup.Id));
            BindHelper.BindData(ctbProjeAdet, projeStokKart, nameof(projeStokKart.adet));
            BindHelper.BindData(fcbBoyut, projeStokKart.stokKart.boyutTanim, nameof(projeStokKart.stokKart.boyutTanim.Id));
            BindHelper.BindData(chkTalasli, projeStokKart.stokKart, nameof(projeStokKart.stokKart.isTalasli));
            BindHelper.BindData(chkBukum, projeStokKart.stokKart, nameof(projeStokKart.stokKart.isBukum));
            List<DataControlStokKartDosya> dataControlStokKartDosyaList = new List<DataControlStokKartDosya>();
            for (int i = 0; i < projeStokKart.stokKart.dosyaList.Count; i++)
            {
                DataControlStokKartDosya dataControlStokKartDosya = DIContainer.GetService<DataControlStokKartDosya>();
                dataControlStokKartDosya.stokKartDosya = projeStokKart.stokKart.dosyaList[i];
                dataControlStokKartDosyaList.Add(dataControlStokKartDosya);
            }
            customDataGrid = new CustomDataGrid<DataControlStokKartDosya>(2, 27, new Point(5, 5), new Size(700, 250));

            panel1.Controls.Clear();
            panel1.Controls.Add(customDataGrid.headerPanel);
            panel1.Controls.Add(customDataGrid.detailPanel);
            customDataGrid.dataSource = dataControlStokKartDosyaList;
        }

        private void StokKartTanimlamaFormu_Load(object sender, EventArgs e)
        {
            if (_cache.projeList.Where(x => x.sorumluList.Where(s => s.personel.Id == _cache.kullanici.personel.Id).Count() > 0).ToList().Count == 1)
            {
                clbProjeKod.SelectedValue = _cache.projeList.Where(x => x.sorumluList.Where(s => s.personel.Id == _cache.kullanici.personel.Id).Count() > 0).First().Id;
            }
        }
        private void cbxStokGrup_SelectedIndexChanged(object sender, EventArgs e)
        {
            clbMalzemeGrup.SetDataSource(_cache.malzemeGrups.Where(x => x.stokGrup.Id == projeStokKart.stokKart.stokGrup.Id).ToList());
        }
        private void cbxMalzemeGrup_SelectedIndexChanged(object sender, EventArgs e)
        {
            clbMalzemeAltGrup.SetDataSource(_cache.malzemeAltGrups.Where(x => x.malzemeGrup.Id == projeStokKart.stokKart.malzemeGrup.Id).ToList());
            clbMalzemeAltGrup2.SetDataSource(_cache.malzemeAltGrup2List.Where(x => x.malzemeAltGrup.Id == projeStokKart.stokKart.malzemeAltGrup.Id).ToList());
            if (_cache.malzemeAltGrups.Count(x => x.malzemeGrup.Id == projeStokKart.stokKart.malzemeGrup.Id) == 0)
            {
                clbMalzemeAltGrup.Enabled = false;
                clbMalzemeAltGrup2.Enabled = false;
            }
            else
            {
                clbMalzemeAltGrup.Enabled = true;
            }
        }
        private void cbxMalzemeAltGrup_SelectedIndexChanged(object sender, EventArgs e)
        {
            clbMalzemeAltGrup2.SetDataSource(_cache.malzemeAltGrup2List.Where(x => x.malzemeAltGrup.Id == projeStokKart.stokKart.malzemeAltGrup.Id).ToList());
            if (_cache.malzemeAltGrup2List.Count(x => x.malzemeAltGrup.Id == projeStokKart.stokKart.malzemeAltGrup.Id) == 0)
            {
                clbMalzemeAltGrup2.Enabled = false;
            }
            else
            {
                clbMalzemeAltGrup2.Enabled = true;
            }
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            projeStokKart = new ProjeStokKart();
        }
        private void malzemeGrupTanımlarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var malzemeGrupTanimFormu = FormFactory.CreateForm<MalzemeGrupTanimFormu>();
            malzemeGrupTanimFormu.UpdateMode(new MalzemeGrupDTO { stokGrupId = projeStokKart.stokKart.stokGrup.Id });
            malzemeGrupTanimFormu.AfterSave += MalzemeGrupTanimFormu_AfterSave;
            malzemeGrupTanimFormu.ShowDialog();
        }

        private void MalzemeGrupTanimFormu_AfterSave(object sender, object e)
        {
            clbMalzemeGrup.SetDataSource(_cache.malzemeGrups.Where(x => x.stokGrup.Id == projeStokKart.stokKart.stokGrup.Id).ToList());
        }

        private void StokKartKayitFormu_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ctxSagClickMenu.Show(this, e.Location);
            }
        }

        private void clbMalzemeGrup_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ctxSagClickMenu.Show(clbMalzemeGrup, e.Location);
            }
        }

        private void stokGrupTanımlamaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var stokGrupTanimFormu = FormFactory.CreateForm<StokGrupTanimFormu>();
            stokGrupTanimFormu.AfterSave += StokGrupTanimFormu_AfterSave;
            stokGrupTanimFormu.ShowDialog();
        }
        private void StokGrupTanimFormu_AfterSave(object sender, object e)
        {
            clbStokGrup.SetDataSource(_cache.stokGrups.ToList());
        }

        private void malzemeAltGrupTanımlamaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var malzemeAltGrupGrupTanimFormu = FormFactory.CreateForm<MalzemeAltGrupTanimFormu>();
            malzemeAltGrupGrupTanimFormu.AfterSave += MalzemeAltGrupGrupTanimFormu_AfterSave;
            MalzemeAltGrup malzemeAltGrup = new MalzemeAltGrup();
            malzemeAltGrup.malzemeGrup = projeStokKart.stokKart.malzemeGrup;
            malzemeAltGrup.malzemeGrup.stokGrup = projeStokKart.stokKart.stokGrup;
            malzemeAltGrupGrupTanimFormu.UpdateMode(_convertHelper.ToDTO<MalzemeAltGrupDTO>(malzemeAltGrup));
            malzemeAltGrupGrupTanimFormu.ShowDialog();
        }

        private void MalzemeAltGrupGrupTanimFormu_AfterSave(object sender, object e)
        {
            clbMalzemeAltGrup.SetDataSource(_cache.malzemeAltGrups.Where(x => x.malzemeGrup.Id == projeStokKart.stokKart.malzemeGrup.Id).ToList());
        }

        private void malzemeAltGrup2TanımlamaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var malzemeAltGrup2GrupTanimFormu = FormFactory.CreateForm<MalzemeAltGrup2TanimFormu>();
            malzemeAltGrup2GrupTanimFormu.AfterSave += MalzemeAltGrup2GrupTanimFormu_AfterSave;
            malzemeAltGrup2GrupTanimFormu.UpdateMode(new MalzemeAltGrup2 { malzemeAltGrup = { Id = projeStokKart.stokKart.malzemeAltGrup.Id, malzemeGrup = { Id = projeStokKart.stokKart.malzemeGrup.Id, stokGrup = projeStokKart.stokKart.stokGrup } } });
            malzemeAltGrup2GrupTanimFormu.ShowDialog();
        }

        private void MalzemeAltGrup2GrupTanimFormu_AfterSave(object sender, object e)
        {
            clbMalzemeAltGrup2.SetDataSource(_cache.malzemeAltGrup2List.Where(x => x.malzemeAltGrup.Id == projeStokKart.stokKart.malzemeAltGrup.Id).ToList());
        }

        private void clbStokTip_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (clbStokTip.SelectedItem != null && ((StokTip)clbStokTip.SelectedItem).ad.Contains("SARF", StringComparison.OrdinalIgnoreCase))
            {
                clbStokGrup.SelectedValue = 7;// Sarf
                ctbKod.Enabled = false;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void clbProjeKod_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            // Eğer birden fazla dosya bırakıldıysa ilkini al
            string sourceFile = files[0];
            var d = File.ReadAllBytes(sourceFile);
            customDataGrid.dataSource.Where(ds => ds.newRec == true).FirstOrDefault().stokKartDosya = new StokKartDosya
            {
                dosyaAd = Path.GetFileNameWithoutExtension(sourceFile),
                dosyaUzanti = Path.GetExtension(sourceFile).Replace(".", ""),
                dosyaTip = new DosyaTip { Id = _cache.dosyaTipList.FirstOrDefault(dt => dt.ad.Equals(Path.GetExtension(sourceFile).Replace(".", ""), StringComparison.OrdinalIgnoreCase))?.Id ?? 0 },
                dosya = d
            };
            customDataGrid.dataSource.Where(ds => ds.newRec == true).FirstOrDefault().dosyaVeri = d;
        }

        private void roundedButton1_Click_1(object sender, EventArgs e)
        {
            var stokKartHamVeriForm = FormFactory.CreateForm<StokKartHamVeri>();
            if (projeStokKart.hamVeri == null)
            {
                stokKartHamVeriForm.UpdateMode(JsonConvert.DeserializeObject<ExcelFormat>(JsonConvert.SerializeObject(new ExcelFormat())));
            }
            else
            {
                stokKartHamVeriForm.UpdateMode(JsonConvert.DeserializeObject<ExcelFormat>(projeStokKart.hamVeri));
            }
            stokKartHamVeriForm.ShowDialog();
        }
    }
    public class DataControlStokKartDosya : DataControl, IEntity
    {
        private readonly ICache _cache;
        private readonly IStokService _stokService;
        private readonly IJsonConverter _jsonConverter;
        private readonly IFileHelper _fileHelper;
        private readonly IFileService _fileService;
        private StokKartDosya _stokKartDosya;
        public StokKartDosya stokKartDosya
        {
            get
            {
                if (_stokKartDosya == null)
                {
                    _stokKartDosya = new();
                }
                return _stokKartDosya;
            }
            set
            {
                _stokKartDosya = value;
                Binding();
            }
        }
        public DataControlStokKartDosya(ICache cache, IStokService stokService, IJsonConverter jsonConverter, IFileHelper fileHelper, IFileService fileService)
        {
            _fileHelper = fileHelper;
            _cache = cache;
            _stokService = stokService;
            _jsonConverter = jsonConverter;
            _fileService = fileService;
            InitializeComponents();
        }
        private void Binding()
        {
            BindHelper.BindData(ctbId,stokKartDosya,nameof(stokKartDosya.Id));
            BindHelper.BindData(ctbStokKartId,stokKartDosya,nameof(stokKartDosya.stokKartId));
            BindHelper.BindData(ctbDosyaUzanti, stokKartDosya, nameof(stokKartDosya.dosyaUzanti));
            BindHelper.BindData(ctbDosyaAd, stokKartDosya, nameof(stokKartDosya.dosyaAd));
            BindHelper.BindData(fcbDosyaTip, stokKartDosya.dosyaTip, nameof(stokKartDosya.dosyaTip.Id));
        }
        public DataControlStokKartDosya()
        {
            InitializeComponents();
        }
        public CustomTextBox ctbId { get; set; }
        public CustomTextBox ctbStokKartId { get; set; }
        private FilterableComboBox _dosyaTipControl;
        public FilterableComboBox fcbDosyaTip
        { get { if (_dosyaTipControl == null) { _dosyaTipControl = new(); } return _dosyaTipControl; } set { _dosyaTipControl = value; } }
        public CustomTextBox ctbDosyaAd { get; set; }
        public CustomTextBox ctbDosyaUzanti { get; set; }
        public byte[] dosyaVeri { get; set; }
        public RoundedIconButton iconButton { get; set; }
        public RoundedIconButton iconButtonView { get; set; }
        private void InitializeComponents()
        {
            ctbId = new() { TabIndex = 1, Width = 0, Visible = true, Tag = "Id" };
            ctbStokKartId = new() { TabIndex = 2, Width = 0, Visible = true, Tag = "StokKartId" };
            fcbDosyaTip = new() { TabIndex = 3, Width = 60, Visible = true, Tag = "DosyaTip", DisplayMember = "ad", ValueMember = "Id" };
            ctbDosyaAd = new() { TabIndex = 4, Width = 350, Tag = "Dosya Adı" };
            ctbDosyaUzanti = new() { TabIndex = 5, Width = 50, Tag = "Dosya Uzantı" };
            iconButton = new()
            {
                TabIndex = 6,
                Width = 35,
                Height = 25,
                Tag = " Ekle",
                BackgroundImage = Resources.ekle,
                BackColor = Color.Transparent,
                BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom,
                CornerRadius = 5
            };
            iconButton.Click += ButtonDosyaEkle_Click;
            iconButtonView = new()
            {
                TabIndex = 7,
                Width = 35,
                Height = 25,
                Tag = "Göster",
                BackgroundImage = Resources.pngegg,
                BackColor = Color.Transparent,
                BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom,
                CornerRadius = 5
            };
            iconButtonView.Click += ButtonDosyaGoruntule_Click;
            dosyaVeri = new byte[0];

            buttonSil.Click += ButtonSil_Click;
            if (stokKartDosya == null)
            {
                stokKartDosya = new StokKartDosya();
            }

            _dosyaTipControl.SetDataSource(_cache.dosyaTipList);
        }
        private void ButtonDosyaEkle_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                stokKartDosya.dosya = File.ReadAllBytes(openFileDialog.FileName);
                stokKartDosya.dosyaAd = Path.GetFileNameWithoutExtension(openFileDialog.FileName);
                stokKartDosya.dosyaUzanti = Path.GetExtension(openFileDialog.FileName).Replace(".", "");
                Binding();
            }
        }
        private async void ButtonSil_Click(object sender, EventArgs e)
        {
            StokKartDosya stokKartDosya = new();
            if (ctbId.TextCustom != "") stokKartDosya.Id = Convert.ToInt32(ctbId.TextCustom.Replace(".", ""));
            string jsonResult = await _stokService.DeleteStokKartDosya(stokKartDosya);
            if (string.IsNullOrEmpty(jsonResult))
            {
                MessageBox.Show(jsonResult);
            }
        }
        private async void ButtonDosyaGoruntule_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ctbStokKartId.TextCustom))
                return;
            StokKart stokKart = new StokKart() { Id = int.Parse(ctbStokKartId.TextCustom) };
            string jsonResult = _stokService.GetStokKart(stokKart);
            if (!string.IsNullOrEmpty(jsonResult))
            {
                stokKart = JsonConvert.DeserializeObject<List<StokKart>>(jsonResult)[0];
            }

            dosyaVeri = await _fileService.GetFileDecompress(stokKart.dosyaList.First(d => d.Id == int.Parse(ctbId.TextCustom)).dosyaFullPath);
            //dosyaVeri = stokKart.dosyaList.First(d => d.Id == int.Parse(IdControl.TextCustom)).dosya;

            string tempFilePath = Path.GetTempFileName() + "." + ctbDosyaUzanti.TextCustom;
            if (dosyaVeri != null)
            {
                using (MemoryStream ms = new MemoryStream(dosyaVeri))
                {
                    File.WriteAllBytes(tempFilePath, ms.ToArray());
                    try
                    {
                        Process.Start(new ProcessStartInfo(tempFilePath)
                        {
                            UseShellExecute = true
                        });
                    }
                    catch (Win32Exception)
                    {
                        var result = MessageBox.Show(
                            "Bu dosya için varsayılan bir uygulama bulunamadı.\n" +
                            "Birlikte Aç penceresi açılsın mı?",
                            "Uygulama Seç",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question
                        );

                        if (result == DialogResult.Yes)
                        {
                            try
                            {
                                Process.Start(new ProcessStartInfo
                                {
                                    FileName = "rundll32.exe",
                                    Arguments = $"shell32.dll,OpenAs_RunDLL \"{tempFilePath}\"",
                                    UseShellExecute = true
                                });
                            }
                            catch (Win32Exception ex)
                            {
                                MessageBox.Show($"Hata: {ex.Message}\nNativeErrorCode: {ex.NativeErrorCode}");
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Dosya bulunamadı.");
            }
        }
        public bool Validate()
        {
            bool isValid = true;
            isValid &= CheckFieldHelper.CheckField("Dosya Tipi seçilmelidir", fcbDosyaTip);
            isValid &= CheckFieldHelper.CheckField("Dosya Adı boş olmamalıdır", ctbDosyaAd);
            isValid &= CheckFieldHelper.CheckField("Dosya Uzantısı boş olmamalıdır", ctbDosyaUzanti);
            return isValid;
        }
    }
}