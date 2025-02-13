using Models;
using Newtonsoft.Json;
using ApiService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using Utilities.Implementations;
using Utilities.Interfaces;

namespace YektamakDesktop.Formlar.Genel
{
    public partial class PersonelKayitFormu : Form, IForm
    {

        private static PersonelKayitFormu _personelKayitFormu;

        public static PersonelKayitFormu personelKayitFormu
        {
            get
            {
                if (_personelKayitFormu == null)
                {
                    _personelKayitFormu = new PersonelKayitFormu();
                    GlobalData.Yetki(ref _personelKayitFormu);
                }
                return _personelKayitFormu;
            }
        }
        //Firma ekranından + butonuyla yeni eklenen personelin firma bilgisini tutması için
        private Personel _personelToSave;
        public Personel personelToSave { get { if (_personelToSave == null) { _personelToSave = new(); } return _personelToSave; } set { _personelToSave = value; } }
        private Personel _personelToUpdate;
        public Personel personelToUpdate { get { if (_personelToUpdate == null) { _personelToUpdate = new(); } return _personelToUpdate; } set { _personelToUpdate = value; } }

        private List<Control> _controlsToDisable;
        public List<Control> controlsToDisable { get => _controlsToDisable; set => _controlsToDisable = value; }
        private bool _activeForm;
        public bool activeForm { get => _activeForm; set => _activeForm = value; }
        private bool yeniResim = false;
        private byte[] yeniResimBytes;
        private string yeniResimFormat;
        #region mouseMove
        bool mouseDown;
        private Point offset;
        private void panelHeader_MouseDown(object sender, MouseEventArgs e)
        {
            offset.X = e.X;
            offset.Y = e.Y;
            mouseDown = true;
        }

        private void panelHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Point currentScreepPos = PointToScreen(e.Location);
                Location = new Point(currentScreepPos.X - offset.X, currentScreepPos.Y - offset.Y);
            }
        }

        private void panelHeader_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        #endregion mouseMove
        private PersonelKayitFormu()
        {
            InitializeComponent();
            controlsToDisable = new List<Control>
            {
                buttonKapat,
                buttonPersonelKaydet,
                buttonPersonelGuncelle,
                buttonResimSec,
                textBoxEmail,
                comboListBoxFirma,
                textBoxIsim,
                textBoxPozisyon,
                textBoxSoyisim,
                textBoxTelefon
            };
        }
        public void UpdateMode(Personel personel)
        {
            buttonPersonelGuncelle.Visible = true;
            personelToUpdate=personel;
            comboListBoxFirma.SelectDataRowId(personel.firma.Id);
            textBoxIsim.TextCustom = personel.ad;
            textBoxSoyisim.TextCustom = personel.soyad;
            textBoxTelefon.TextCustom = personel.telefon;
            textBoxEmail.TextCustom = personel.mail;
            textBoxPozisyon.TextCustom = personel.pozisyon;
            ImageFormat ımageFormat = ImageWorks.GetImageFormatFromString(personel.personelResim.imageFormat);
            pictureBoxPersonel.Image = ImageWorks.GetImageFromBytes(personel.personelResim.resimData, ımageFormat);
            yeniResimBytes = personel.personelResim.resimData;
            yeniResimFormat=personel.personelResim.imageFormat;
            GetCurrentPersonel();
            personelToUpdate = JsonConvert.DeserializeObject<Personel>(JsonConvert.SerializeObject(personelToSave));
        }
        public void SaveMode()
        {
            buttonPersonelGuncelle.Visible = false;
            personelToUpdate.firma.Id = -1;
            personelToUpdate.firma.Id= -1;
        }

        /// <summary>
        /// Firma güncelleme penceresinden personel eklemek istenilirse kullanılacak
        /// </summary>
        /// <param name="firma"></param>
        public void SaveMode(Personel personel)
        {
            buttonPersonelGuncelle.Visible = false;
            personelToSave=JsonConvert.DeserializeObject<Personel>(JsonConvert.SerializeObject(personel));
            personelToUpdate= JsonConvert.DeserializeObject<Personel>(JsonConvert.SerializeObject(personel));
            comboListBoxFirma.SelectDataRowId(personel.firma.Id);
            comboListBoxFirma.Enabled= false;
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
                    yeniResim = true;
                    ImageFormat format = ImageWorks.GetImageFileFormatFromPath(openFileDialogResim.FileName);
                    yeniResimBytes = ImageWorks.GetBytesFromImage(loadedImage, format);
                    yeniResimFormat = format.ToString();
                }
                else
                {
                    pictureBoxPersonel.Image = null;
                    yeniResim = false;
                }
            }
            catch
            {
                yeniResim = false;
            }


        }
        private Personel GetCurrentPersonel()
        {
            personelToSave.Id=personelToUpdate.Id;
            personelToSave.firma.Id = comboListBoxFirma.selectedDataRowId;
            personelToSave.firma.ad = comboListBoxFirma.selectedDataRowValue;
            personelToSave.ad = string.IsNullOrEmpty(textBoxIsim.TextCustom)?null: textBoxIsim.TextCustom;
            personelToSave.soyad = string.IsNullOrEmpty(textBoxSoyisim.TextCustom)?null:textBoxSoyisim.TextCustom;
            personelToSave.telefon = string.IsNullOrEmpty(textBoxTelefon.TextCustom) ? null : textBoxTelefon.TextCustom;
            personelToSave.mail = string.IsNullOrEmpty(textBoxEmail.TextCustom) ? null : textBoxEmail.TextCustom;
            personelToSave.pozisyon = string.IsNullOrEmpty(textBoxPozisyon.TextCustom) ? null : textBoxPozisyon.TextCustom;
            personelToSave.personelResim.resimData = yeniResimBytes;
            personelToSave.personelResim.imageFormat = yeniResimFormat;

            return personelToSave;
        }
        /// <summary>
        /// Bütün alanlardaki veriler doğru yazılmış mı onun kontrol yapılacak
        /// Yanlış varsa alanın yanındaki label'larda uyarı mesajı olarak belirtilecek
        /// </summary>
        private bool CheckFields()
        {
            GlobalData.ClearWarningLabels(this);
            bool result = true;
            result = result & GlobalData.CheckField("*İsim alanı boş bırakılamaz!", this, textBoxIsim);
            result = result & GlobalData.CheckField("*Soyisim alanı boş bırakılamaz!", this, textBoxSoyisim);
            result = result & GlobalData.CheckField("*Firma seçimi yapılmalıdır!", this, comboListBoxFirma);
            return result;
        }
        private void buttonPersonelKaydet_Click(object sender, EventArgs e)
        {
            if (CheckFields())
            {
                personelToSave = GetCurrentPersonel();
                string result = WebMethods.SavePersonel(personelToSave);
                this.Enabled = false;
                if (result.Contains("error", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show(result);
                }
                else
                {
                    IJsonConvertHelper jsonConverter = new JsonConvertHelper();
                    DataSet datasetPersonel = jsonConverter.JsonStringToDataSet(result);
                    int personelId = int.Parse(datasetPersonel.Tables[0].Rows[0][0].ToString());
                    personelToSave.Id = personelId;
                    if (GlobalData.activeFormStack.Skip(1).First().GetType() == typeof(FirmaKayitFormu))//FirmaKayitFormu tarafından çağırılmışsa
                    {
                        FirmaKayitFormu.firmaKayitFormu.AddNewPersonel(personelToSave);
                    }
                    else if (GlobalData.activeFormStack.Skip(1).First().GetType() == typeof(PersonelGridFormu))
                    {
                        PersonelGridFormu.personelGridFormu.UpdateRow(personelToSave);
                    }
                    //GlobalData.personelList.Remove(GlobalData.personelList.Find(x => x.Id == personelToUpdate.Id));
                    //GlobalData.personelList.Add(personelToUpdate);
                    personelToUpdate = personelToSave;
                    MessageBox.Show("Kayıt başarılı");
                }
                this.Enabled = true;
            }
        }
        private void buttonKapat_Click(object sender, EventArgs e)
        {
            CloseForm(sender, e);
        }


        private void CloseForm(object sender, EventArgs e)
        {
            GetCurrentPersonel();
            if (!GlobalData.CompareClass(personelToSave,personelToUpdate))
            {
                DialogResult dialogResult = MessageBox.Show("Formda yapılan değişiklikler kaydedilsin mi","",MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    buttonPersonelKaydet_Click(sender, e);
                }
                else
                {
                    GlobalData.CloseForm(ref _personelKayitFormu);
                }
            }
            else
            {
                GlobalData.CloseForm(ref _personelKayitFormu);
            }
        }


        private void buttomMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            CloseForm(sender, e);
        }

        private void PersonelKayitFormu_Load(object sender, EventArgs e)
        {
            //foreach(Firma firma in GlobalData.firmaUnvanList)
            //{
            //    comboListBoxFirma.AddDataRow(firma.Id, firma.unvan);
            //}
        }
    }
}
