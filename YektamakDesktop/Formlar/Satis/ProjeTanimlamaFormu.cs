using ApiService.Interfaces;
using Models;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Utilities.Interfaces;
using YektamakDesktop.Abstracts;
using YektamakDesktop.Common;
using YektamakDesktop.CustomControls;
using YektamakDesktop.Properties;

namespace YektamakDesktop.Formlar.Satis
{
    public partial class ProjeTanimlamaFormu : Form
    {
        private readonly ICache _cache;
        private readonly IProjeService _projeService;
        private readonly IJsonConverter _jsonConverter;
        private readonly IConvertHelper _convertHelper;
        private CustomDataGrid<DataControlProjeDosya> customDataGrid;
        public ProjeTanimlamaFormu(ICache cache, IProjeService projeService, IJsonConverter jsonConverter, IConvertHelper convertHelper)
        {
            _cache = cache;
            _projeService = projeService;
            _jsonConverter = jsonConverter;
            _convertHelper = convertHelper;
            InitializeComponent();
            customDataGrid = new CustomDataGrid<DataControlProjeDosya>(2, 30, new Point(0, 0), new Size(990, 300));
            panel1.Controls.Add(customDataGrid.detailPanel);
            panel1.Controls.Add(customDataGrid.headerPanel);
            Initialize();
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
            universalGrid1.Location = new Point(locationX, locationY);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new Size(sizeX, sizeY);
            universalGrid1.TabIndex = 13;
            Controls.Add(universalGrid1);
            universalGrid1.MouseDown1 += universalGrid1_CellClick;

            universalGrid1.SetData(new List<Proje>(), this.Name);
            universalGrid1.SetData(_cache.projeList
                .GroupBy(p => p.Id)
                .Select(g => (g.First())).ToList(), this.Name);
            fcbProjeTip.SetDataSource(_cache.projeTipList);
            fcbMarka.SetDataSource(_cache.markaList);
            fcbMarkaAltGrup.SetDataSource(_cache.markaAltGrupList);
            fcbMirasProje.SetDataSource(_cache.projeList);
            Binding();
        }
        private Proje _proje;
        private Proje proje
        {
            get
            {
                if (_proje == null)
                {
                    _proje = new();
                }
                return _proje;
            }
            set
            {
                _proje = value;
                Binding();
            }
        }
        private void Binding()
        {
            BindHelper.BindData(ctbId, proje, nameof(proje.Id));
            BindHelper.BindData(fcbProjeTip, proje, p=>p.projeTip);
            BindHelper.BindData(fcbMarka, proje, p => p.marka);
            BindHelper.BindData(ctbProjeNo, proje, nameof(proje.projeNo));
            BindHelper.BindData(fcbMirasProje, proje, nameof(proje.mirasProjeId));
            BindHelper.BindData(fcbMarkaAltGrup, proje, p=>p.markaAltGrup);
            BindHelper.BindData(fcbMarkaAltGrupKategori, proje, p=>p.markaAltGrupKategori);
            BindHelper.BindData(ctbAd, proje, nameof(proje.ad));
            BindHelper.BindData(ctbAciklama, proje, nameof(proje.aciklama));
            BindHelper.BindData(ctbVersiyon, proje, nameof(proje.versiyon));
            List<DataControlProjeDosya> dataControlProjeDosyas = new();
            foreach (var projeDosya in proje.projeDosyaList.Where(p => p.active == true))
            {
                DataControlProjeDosya dataControlProjeDosya = DIContainer.GetService<DataControlProjeDosya>();
                dataControlProjeDosya.proje = proje;
                dataControlProjeDosya.projeDosya = projeDosya;
                dataControlProjeDosyas.Add(dataControlProjeDosya);
            }
            customDataGrid.dataSource = dataControlProjeDosyas;
        }
        private void customButtonSave1_SaveButtonClick(object sender, EventArgs e)
        {
            foreach (var dc in customDataGrid.dataSource.Where(d => d.newRec == false))
            {
                dc.projeDosya.projeId = int.Parse(ctbId.TextCustom);
                proje.projeDosyaList.Add(dc.projeDosya);
            }
            //string jsonResultMarka = _projeService.GetMarka();
            //proje.marka = _jsonConverter.DeserializeObject<List<Marka>>(jsonResultMarka).FirstOrDefault(m => m.Id == proje.marka.Id);
            string jsonResult = _projeService.SaveProje(_convertHelper.ToEntity<Proje>(proje));
            if (String.IsNullOrEmpty(jsonResult) || jsonResult.Contains("error", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show($"Kaydederken hata: {jsonResult}");
            }
            else
            {
                _cache.projeList.Clear();

                universalGrid1.SetData(_cache.projeList
                    .GroupBy(p => p.Id)
                    .Select(g => (g.First())).ToList(), this.Name);
            }
        }
        private void universalGrid1_CellClick(object sender, MouseEventArgs e)
        {
            proje = (Proje)universalGrid1.Grid.CurrentRow.DataBoundItem;
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(universalGrid1.Grid, e.Location);
            }
        }

        private void projeSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var projeDTO = (ProjeDTO)universalGrid1.Grid.CurrentRow.DataBoundItem;
            string jsonResult = _projeService.DeleteProje(_convertHelper.ToEntity<Proje>(proje));
            if (String.IsNullOrEmpty(jsonResult) || jsonResult.Contains("error", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Sonuç boş geldi.");
            }
            else
            {
                proje = new();
                universalGrid1.binding.Remove(projeDTO);
                _cache.projeList.Remove(_cache.projeList.FirstOrDefault(p => p.Id == proje.Id));
            }
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            proje = new();
        }

        private void ProjeTanimlamaFormu_FormClosing(object sender, FormClosingEventArgs e)
        {
            universalGrid1.SaveGridSettings();
        }

    }
    public class DataControlProjeDosya : DataControl, IEntity
    {
        public Proje proje;
        public CustomTextBoxSayisal ctbId { get; set; } = new() { TabIndex = 3, Width = 0, Visible = true, Tag = "Id"};
        public CustomTextBoxSayisal ctbProjeId { get; set; } = new() { TabIndex = 4, Width = 0, Visible = true, Tag = "ProjeId"};
        public CustomTextBox ctbTanim { get; set; } = new() { TabIndex = 5, Width = 180, Visible = true, Tag = "Dosya Tanımı"};
        public CustomTextBox ctbDosyaYolu { get; set; } = new() {TabIndex = 6, Width = 280, Visible = true, Tag = "Dosya Yolu" };
        public CustomTextBox ctbDosyaUzanti { get; set; } = new() {TabIndex = 7, Width = 30, Visible = true, Tag = "Uzantı" };
        public RoundedIconButton btnAdd { get; set; }
        public RoundedIconButton btnView { get; set; }
        public byte[] dosyaVeri { get; set; }
        private ProjeDosya _projeDosya;
        public ProjeDosya projeDosya
        {
            get
            {
                if (_projeDosya == null)
                {
                    _projeDosya = new();
                    Binding();
                }
                return _projeDosya;
            }
            set
            {
                _projeDosya = value;
                Binding();
            }
        }
        private readonly IProjeService _projeService;
        private readonly IFileHelper _fileHelper;
        private readonly IFileService _fileService;
        private readonly ICache _cache;
        public DataControlProjeDosya()
        {
        }
        public DataControlProjeDosya(IProjeService projeService, IFileHelper fileHelper, IFileService fileService, ICache cache)
        {
            _projeService = projeService;
            _fileHelper = fileHelper;
            _fileService = fileService;
            _cache = cache;
            btnAdd = new()
            {
                TabIndex = 8,
                Width = 35,
                Height = 25,
                Tag = " Ekle",
                BackgroundImage = Resources.ekle,
                BackColor = Color.Transparent,
                BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom,
                CornerRadius = 5,
            };
            btnAdd.Click += ButtonDosyaEkle_Click;
            btnView = new()
            {
                TabIndex = 9,
                Width = 35,
                Height = 25,
                Tag = "Göster",
                BackgroundImage = Resources.pngegg,
                BackColor = Color.Transparent,
                BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom,
                CornerRadius = 5,
            };
            btnView.Click += ButtonDosyaGoruntule_Click;
            buttonSil.Click += ButtonSil_Click;
        }



        private void ButtonSil_Click(object sender, EventArgs e)
        {
            if (ctbId.TextCustom != "") projeDosya.Id = Convert.ToInt32(ctbId.TextCustom.Replace(".", ""));
            string jsonResult = _projeService.DeleteProjeFile(projeDosya);
            if (!string.IsNullOrEmpty(jsonResult) && !jsonResult.Contains("error",StringComparison.OrdinalIgnoreCase))
            {
                proje.projeDosyaList.RemoveAll(p=>p.Id==projeDosya.Id);
                MessageBox.Show(jsonResult);
            }
        }

        private async void ButtonDosyaGoruntule_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ctbId.TextCustom))
                return;
            ProjeStokKart stokKart = new ProjeStokKart() { Id = int.Parse(ctbId.TextCustom) };

            dosyaVeri = await _fileService.GetFileDecompress(projeDosya.dosyaFullPath);

            string tempFilePath = Path.GetTempFileName() + "." + ctbDosyaUzanti.TextCustom;
            if (dosyaVeri != null)
            {
                using (MemoryStream ms = new MemoryStream(dosyaVeri))
                {
                    File.WriteAllBytes(tempFilePath, ms.ToArray());
                    Process.Start(new ProcessStartInfo(tempFilePath) { UseShellExecute = true });
                }
            }
            else
            {
                MessageBox.Show("Dosya bulunamadı.");
            }
        }

        private async void ButtonDosyaEkle_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(projeDosya.dosyaFullPath))
                {
                    await _fileService.DeleteFile(projeDosya.dosyaFullPath);
                }
                projeDosya.tanim = Path.GetFileNameWithoutExtension(openFileDialog.FileName);
                projeDosya.dosyaYolu = openFileDialog.FileName;
                projeDosya.uzanti = Path.GetExtension(openFileDialog.FileName).Replace(".", "");
                var content = await _fileHelper.ReadFileAsBinaryAsync(openFileDialog.FileName);
                if (content == null) return;
                projeDosya.dosyaFullPath = Path.Combine(Guid.NewGuid() + Path.GetExtension(openFileDialog.FileName));
                _fileService.SaveFile(content, projeDosya.dosyaFullPath);
                Binding();
            }
        }
        private void Binding()
        {
            BindHelper.BindData(ctbId, projeDosya, nameof(projeDosya.Id));
            BindHelper.BindData(ctbProjeId, projeDosya, nameof(projeDosya.projeId));
            BindHelper.BindData(ctbTanim, projeDosya, nameof(projeDosya.tanim));
            BindHelper.BindData(ctbDosyaYolu, projeDosya, nameof(projeDosya.dosyaYolu));
            BindHelper.BindData(ctbDosyaUzanti, projeDosya, nameof(projeDosya.uzanti));
        }
    }
}
