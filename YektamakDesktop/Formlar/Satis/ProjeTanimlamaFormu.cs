using ApiService.Implementations;
using ApiService.Interfaces;
using Models;
using Models.DTO;
using Newtonsoft.Json;
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
using YektamakDesktop.Formlar.Satinalma;
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
            panel1.Controls.Add(customDataGrid.headerPanel);
            panel1.Controls.Add(customDataGrid.detailPanel);
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
            universalGrid1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom |  AnchorStyles.Left | AnchorStyles.Right;
            universalGrid1.Location = new Point(locationX, locationY);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new System.Drawing.Size(sizeX, sizeY);
            universalGrid1.TabIndex = 13;
            Controls.Add(universalGrid1);
            universalGrid1.MouseDown1 += universalGrid1_CellClick;

            universalGrid1.SetData(new List<ProjeDTO>(), this.Name);
            universalGrid1.SetData(_cache.projeList
                .GroupBy(p =>  p.Id )
                .Select(g => _convertHelper.ToDTO<ProjeDTO>(g.First())).ToList(), this.Name);
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
            BindHelper.BindData(fcbProjeTip, proje.projeTip, nameof(proje.projeTip.Id));
            BindHelper.BindData(fcbMarka, proje.marka, nameof(proje.marka.Id));
            BindHelper.BindData(ctbProjeNo, proje, nameof(proje.projeNo));
            BindHelper.BindData(fcbMirasProje, proje, nameof(proje.mirasProjeId));
            BindHelper.BindData(fcbMarkaAltGrup, proje.markaAltGrup, nameof(proje.markaAltGrup.Id));
            BindHelper.BindData(fcbMarkaAltGrupKategori, proje.markaAltGrupKategori, nameof(proje.markaAltGrupKategori.Id));
            BindHelper.BindData(ctbAd, proje, nameof(proje.ad));
            BindHelper.BindData(ctbAciklama, proje, nameof(proje.aciklama));
            BindHelper.BindData(ctbVersiyon, proje, nameof(proje.versiyon));

        }
        private void customButtonSave1_SaveButtonClick(object sender, EventArgs e)
        {
            string jsonResultMarka = _projeService.GetMarka();
            proje.marka = _jsonConverter.DeserializeObject<List<Marka>>(jsonResultMarka).FirstOrDefault(m => m.Id == proje.marka.Id);
            string jsonResult = _projeService.SaveProje(proje);
            if (String.IsNullOrEmpty(jsonResult) || jsonResult.Contains("error", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show($"Kaydederken hata: {jsonResult}");
            }
            else
            {
                _cache.projeList.Clear();
                proje = JsonConvert.DeserializeObject<List<Proje>>(jsonResult)[0];
                _cache.projeList.Add(proje);
                universalGrid1.SetData(_cache.projeList
                    .GroupBy(p =>  p.Id )
                    .Select(g => _convertHelper.ToDTO<ProjeDTO>(g.First())).ToList(), this.Name);
            }
        }
        private void universalGrid1_CellClick(object sender, MouseEventArgs e)
        {
            proje = _convertHelper.ToEntity<Proje>(((ProjeDTO)universalGrid1.Grid.CurrentRow.DataBoundItem));
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(universalGrid1.Grid, e.Location);
            }
        }

        private void projeSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var projeDTO = (ProjeDTO)universalGrid1.Grid.CurrentRow.DataBoundItem;
            proje = _convertHelper.ToEntity<Proje>(projeDTO);
            string jsonResult = _projeService.DeleteProje(proje);
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
    public class DataControlProjeDosya : DataControl, IEntity, IAltForm
    {
        public CustomTextBoxSayisal ctbId { get; set; } = new() { TabIndex = 3, Width = 0, Visible = false, Tag = "Id"};
        public CustomTextBoxSayisal ctbProjeId { get; set; } = new() { TabIndex = 4, Width = 0, Visible = false, Tag = "ProjeId"};
        public CustomTextBox ctbTanim { get; set; } = new() { TabIndex = 5, Width = 200, Visible = true, Tag = "Dosya Tanımı"};
        public CustomTextBox ctbDosyaYolu { get; set; } = new() {TabIndex = 6, Width = 300, Visible = true, Tag = "Dosya Yolu" };
        public CustomTextBox ctbDosyaUzanti { get; set; } = new() {TabIndex = 6, Width = 50, Visible = true, Tag = "Uzantı" };
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
        public DataControlProjeDosya(IProjeService projeService, IFileHelper fileHelper, IFileService fileService)
        {
            _projeService = projeService;
            _fileHelper = fileHelper;
            _fileService = fileService;
            btnAdd = new()
            {
                TabIndex = 6,
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
                TabIndex = 7,
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

        public DataControlProjeDosya()
        {
        }

        private void ButtonSil_Click(object sender, EventArgs e)
        {
            ProjeDosya projeDosya = new();
            if (ctbId.TextCustom != "") projeDosya.Id = Convert.ToInt32(ctbId.TextCustom.Replace(".", ""));
            string jsonResult = _projeService.DeleteProjeFile(projeDosya);
            if (!string.IsNullOrEmpty(jsonResult))
            {
                MessageBox.Show(jsonResult);
            }
        }

        private async void ButtonDosyaGoruntule_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ctbId.TextCustom))
                return;
            ProjeStokKart stokKart = new ProjeStokKart() { Id = int.Parse(ctbId.TextCustom) };

            dosyaVeri = await _fileService.GetFileDecompress(ctbDosyaYolu.TextCustom);

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

        private void ButtonDosyaEkle_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //projeDosya.tanim = File.ReadAllBytes(openFileDialog.FileName);
                projeDosya.tanim = Path.GetFileNameWithoutExtension(openFileDialog.FileName);
                projeDosya.dosyaYolu = openFileDialog.FileName;
                projeDosya.uzanti = Path.GetExtension(openFileDialog.FileName).Replace(".", "");
                Binding();
                //dosyaAdControl.TextCustom = Path.GetFileNameWithoutExtension(openFileDialog.FileName);
                //dosyaUzantiControl.TextCustom = Path.GetExtension(openFileDialog.FileName).Replace(".", "");
            }
        }

        public void UstFormuBagla(IUstForm ustForm)
        {
            throw new System.NotImplementedException();
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
