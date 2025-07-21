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
            ComboBoxListFill.GetLookupAd(_cache.pozisyonList, ref clbPozisyon);
            ComboBoxListFill.GetLookupAd(_cache.firmaList, ref clbFirma);
            ComboBoxListFill.GetLookupAd(_cache.personelList, ref clbYonetici);
            universalGrid1.kullanici = _cache.kullanici;
            universalGrid1.Grid.MouseClick += Grid_MouseClick;
            Binding();
        }

        private void Grid_MouseClick(object sender, MouseEventArgs e)
        {
            var personelDTO = (PersonelDTO)universalGrid1.binding.Current;
            personel = ConvertHelper.ToEntity<Personel>(personelDTO);
        }

        //Firma ekranından + butonuyla yeni eklenen personelin firma bilgisini tutması için

        private bool yeniResim = false;
        private byte[] yeniResimBytes;
        private string yeniResimFormat;
        private Personel _personel;
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
            ctbPersonelAd.DataBindings.Clear();
            ctbPersonelSoyad.DataBindings.Clear();
            ctbTelefon.DataBindings.Clear();
            ctbMail.DataBindings.Clear();
            clbPozisyon.DataBindings.Clear();
            clbFirma.DataBindings.Clear();
            clbYonetici.DataBindings.Clear();
            pictureBoxPersonel.DataBindings.Clear();
            ctbId.DataBindings.Clear();
            ctbId.DataBindings.Add("TextCustom", personel , $"{nameof(personel.Id)}", true ,DataSourceUpdateMode.OnPropertyChanged);
            ctbPersonelAd.DataBindings.Add("TextCustom", personel, $"{nameof(personel.ad)}", true, DataSourceUpdateMode.OnPropertyChanged);
            ctbPersonelSoyad.DataBindings.Add("TextCustom", personel, $"{nameof(personel.soyad)}", true, DataSourceUpdateMode.OnPropertyChanged);
            ctbTelefon.DataBindings.Add("TextCustom", personel, $"{nameof(personel.telefon)}", true, DataSourceUpdateMode.OnPropertyChanged);
            ctbMail.DataBindings.Add("TextCustom", personel, $"{nameof(personel.mail)}", true, DataSourceUpdateMode.OnPropertyChanged);
            clbFirma.DataBindings.Add("selectedDataRowId", personel, $"{nameof(personel.firma)}.{nameof(personel.firma.Id)}", true, DataSourceUpdateMode.OnPropertyChanged);
            clbPozisyon.DataBindings.Add("selectedDataRowId", personel, $"{nameof(personel.pozisyon)}.{nameof(personel.pozisyon.Id)}", true, DataSourceUpdateMode.OnPropertyChanged);
            clbYonetici.DataBindings.Add("selectedDataRowId", personel, $"{nameof(personel.yoneticiPersonelId)}", true, DataSourceUpdateMode.OnPropertyChanged);
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
            result = result & GlobalData.CheckField("*İsim alanı boş bırakılamaz!", this, ctbPersonelAd);
            result = result & GlobalData.CheckField("*Soyisim alanı boş bırakılamaz!", this, ctbPersonelSoyad);
            result = result & GlobalData.CheckField("*Firma seçimi yapılmalıdır!", this, clbFirma);
            return result;
        }
        private async void buttonPersonelKaydet_Click(object sender, EventArgs e)
        {
            if (CheckFields())
            {
                string jsonResult = await _personelService.SavePersonel(personel);
                Result result = _jsonConverter.DeserializeToModelList<Result>(jsonResult).FirstOrDefault();
                if (result?.result != null)
                {
                    personel = _jsonConverter.ToModelList<Personel>(result.result).FirstOrDefault();
                    _cache.personelList.Add(personel);
                }
            }
        }

        private void PersonelKayitFormu_Load(object sender, EventArgs e)
        {
            List<PersonelDTO> personelList = new();
            foreach (var item in _cache.personelList)
            {
                personelList.Add(ConvertHelper.ToDTO<PersonelDTO>(item));
            }
            universalGrid1.SetData(personelList, this.Name);
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
