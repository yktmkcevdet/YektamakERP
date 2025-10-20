using ApiService.Interfaces;
using Models;
using Models.DTO;
using Newtonsoft.Json;
using Org.BouncyCastle.Utilities.Encoders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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
            universalGrid1.SetData(new List<PersonelDTO>(), this.Name);
            universalGrid1.MouseDown1 += Grid_MouseClick;
            clbFirma.SetDataSource(_cache.firmaList);
            clbPozisyon.SetDataSource(_cache.pozisyonList);
            clbYonetici.SetDataSource(_cache.personelList);
            //pictureBoxPersonel.DataBindings["Image"].Format += (s, e) =>
            //{
            //    if (e.DesiredType == typeof(Image) && e.Value is byte[] bytes && bytes.Length > 0)
            //    {
            //        using (var ms = new MemoryStream(bytes))
            //        {
            //            e.Value = Image.FromStream(ms);
            //        }
            //    }
            //    else
            //    {
            //        e.Value = null; // resim yoksa boş bırak
            //    }
            //};
        }
        private void Grid_MouseClick(object sender, MouseEventArgs e)
        {
            personelDTO = (PersonelDTO)universalGrid1.Grid.CurrentRow.DataBoundItem;
        }
        private PersonelDTO _personelDTO;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PersonelDTO personelDTO
        {
            get { if (_personelDTO == null) { _personelDTO = new(); } return _personelDTO; }
            set{ _personelDTO = value; Binding(); }
        }
        private PersonelKayitFormu()
        {
            InitializeComponent();
            Binding();
        }
        private void Binding()
        {
            BindHelper.BindData(ctbId, personelDTO, nameof(personelDTO.Id));
            BindHelper.BindData(ctbPersonelAd, personelDTO, nameof(personelDTO.ad));
            BindHelper.BindData(ctbPersonelSoyad, personelDTO, nameof(personelDTO.soyad));
            BindHelper.BindData(ctbTelefon, personelDTO, nameof(personelDTO.telefon));
            BindHelper.BindData(ctbMail, personelDTO, nameof(personelDTO.mail));
            BindHelper.BindData(clbFirma, personelDTO, nameof(personelDTO.firmaId));
            BindHelper.BindData(clbPozisyon, personelDTO, nameof(personelDTO.pozisyonId));
            BindHelper.BindData(clbYonetici, personelDTO, nameof(personelDTO.yoneticiPersonelId));
            pictureBoxPersonel.DataBindings.Clear();
            pictureBoxPersonel.DataBindings.Add("Image", personelDTO, nameof(personelDTO.personelResimdata), true, DataSourceUpdateMode.OnPropertyChanged);
        }
        public void UpdateMode(PersonelDTO personelUpdate)
        {
            personelDTO = personelUpdate;
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
                    personelDTO.personelResimdata = ImageWorks.GetBytesFromImage(loadedImage, format);
                    personelDTO.personelResimformat = format.ToString();
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
                string jsonResult = await _personelService.SavePersonel(ConvertHelper.ToEntity<Personel>(personelDTO));
                if (String.IsNullOrEmpty(jsonResult) || jsonResult.Contains("error", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show(jsonResult,"Personel kaydederken hata");
                }
                else
                {
                    var personel = JsonConvert.DeserializeObject<List<Personel>>(jsonResult).FirstOrDefault();
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
            universalGrid1.SetData(_cache.personelList.CastToDTO<PersonelDTO>().ToList(), this.Name);
        }

        private void PersonelKayitFormu_FormClosing(object sender, FormClosingEventArgs e)
        {
            universalGrid1.SaveSettings();
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            personelDTO=new PersonelDTO();
        }
    }
}
