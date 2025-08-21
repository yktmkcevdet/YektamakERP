using ApiService.Interfaces;
using Models;
using Models.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using Utilities.Interfaces;
using YektamakDesktop.Common;
using YektamakDesktop.CustomControls;

namespace YektamakDesktop.Formlar.Genel
{
    public partial class PersonelKayitFormu : Form
    {
        private readonly IPersonelService _personelService;
        private readonly ICache _cache;
        private readonly IJsonConverter _jsonConverter;
        public PersonelKayitFormu(IPersonelService personelService, ICache cache, IJsonConverter jsonConverter)
        {
            _personelService = personelService;
            _cache = cache;
            _jsonConverter = jsonConverter;
            InitializeComponent();
            Initialize();
            Binding();
        }
        private void Initialize()
        {
            Controls.Remove(universalGrid1);
            universalGrid1 = DIContainer.GetService<UniversalGrid>();
            universalGrid1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            universalGrid1.Location = new Point(0, 354);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new Size(992, 352);
            universalGrid1.TabIndex = 55;
            universalGrid1.MouseDown1 += Grid_MouseClick;
            Controls.Add(universalGrid1);
            clbFirma.SetDataSource(_cache.firmaList);
            clbPozisyon.SetDataSource(_cache.pozisyonList);
            clbYonetici.SetDataSource(_cache.personelList);
        }

        private void Grid_MouseClick(object sender, MouseEventArgs e)
        {
            personel = (Personel)universalGrid1.Grid.CurrentRow.DataBoundItem;
            //personel = ConvertHelper.ToEntity<Personel>(personelDTO);
        }

        //Firma ekranından + butonuyla yeni eklenen personelin firma bilgisini tutması için

        private bool yeniResim = false;
        private byte[] yeniResimBytes;
        private string yeniResimFormat;
        private Personel _personel;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Personel personel
        {
            get { if (_personel == null) { _personel = new(); } return _personel; }
            set
            {
                _personel = value;
                Binding();
            }
        }
        private PersonelKayitFormu()
        {
            InitializeComponent();
            Binding();
        }
        private void Binding()
        {
            BindHelper.BindData(ctbId, personel, "Id");
            BindHelper.BindData(ctbPersonelAd, personel, "ad");
            BindHelper.BindData(ctbPersonelSoyad, personel, "soyad");
            BindHelper.BindData(ctbTelefon, personel, "telefon");
            BindHelper.BindData(ctbMail, personel, "mail");
            BindHelper.BindData(clbFirma, personel.firma, "Id");
            BindHelper.BindData(clbPozisyon, personel.pozisyon, "Id");
            BindHelper.BindData(clbYonetici, personel, "yoneticiPersonelId");
        }
        public void UpdateMode(Personel personelUpdate)
        {
            personel = personelUpdate;
        }
        private void buttonResimSec_Click(object sender, EventArgs e)
        {
            openFileDialogResim.ShowDialog();
        }
        private void openFileDialogResim_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                Image loadedImage = Image.FromFile(openFileDialogResim.FileName);
                if (loadedImage != null)
                {
                    pictureBoxPersonel.Image = loadedImage;
                    ImageFormat format = ImageWorks.GetImageFileFormatFromPath(openFileDialogResim.FileName);
                    personel.personelResim.resimData = ImageWorks.GetBytesFromImage(loadedImage, format);
                    personel.personelResim.imageFormat = format.ToString();
                }
                else
                {
                    pictureBoxPersonel.Image = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        /// <summary>
        /// Bütün alanlardaki veriler doğru yazılmış mı onun kontrol yapılacak
        /// Yanlış varsa alanın yanındaki label'larda uyarı mesajı olarak belirtilecek
        /// </summary>
        private bool CheckFields()
        {
            bool result = true;
            result = result & GlobalData.CheckField("*İsim alanı boş bırakılamaz!",  ctbPersonelAd);
            result = result & GlobalData.CheckField("*Soyisim alanı boş bırakılamaz!",  ctbPersonelSoyad);
            result = result & GlobalData.CheckField("*Firma seçimi yapılmalıdır!",  clbFirma);
            return result;
        }
        private async void buttonPersonelKaydet_Click(object sender, EventArgs e)
        {
            if (CheckFields())
            {
                string jsonResult = await _personelService.SavePersonel(personel);
                if (String.IsNullOrEmpty(jsonResult) || jsonResult.Contains("error", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show(jsonResult,"Personel kaydederken hata");
                }
                else
                {
                    personel = JsonConvert.DeserializeObject<List<Personel>>(jsonResult).FirstOrDefault();
                    if (!_cache.personelList.Any(p => p.Id == personel.Id))
                    {
                        _cache.personelList.Add(personel);
                    }
                    else
                    {
                        var index = _cache.personelList.FindIndex(p => p.Id == personel.Id);
                        if (index != -1)
                        {
                            _cache.personelList[index] = personel;
                        }
                    }
                    List<PersonelDTO> personelList = new();
                    foreach (var item in _cache.personelList)
                    {
                        personelList.Add(ConvertHelper.ToDTO<PersonelDTO>(item));
                    }
                    universalGrid1.SetData(personelList, this.Name);
                }
            }
        }

        private void PersonelKayitFormu_Load(object sender, EventArgs e)
        {
            List<Personel> personelList = new();
            //foreach (var item in _cache.personelList)
            //{
            //    personelList.Add(ConvertHelper.ToDTO<PersonelDTO>(item));
            //}
            universalGrid1.SetData(_cache.personelList, this.Name);
        }

        private void PersonelKayitFormu_FormClosing(object sender, FormClosingEventArgs e)
        {
            universalGrid1.SaveSettings();
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            personel=new Personel();
        }
    }
}
