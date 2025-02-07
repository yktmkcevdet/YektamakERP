using YektamakDesktop.CustomControls;
using Models;
using Newtonsoft.Json;
using ApiService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utilities.Implementations;
using Utilities.Interfaces;

namespace YektamakDesktop.Formlar.Finans
{
    public partial class CariOdemeKayitFormu : Form, IForm
    {
        private WebMethods _webMethods;
        private static CariOdemeKayitFormu _cariOdemeKayitFormu;
        public static CariOdemeKayitFormu cariOdemeKayitFormu
        {
            get
            {
                if (_cariOdemeKayitFormu == null)
                {
                    _cariOdemeKayitFormu = new CariOdemeKayitFormu();
                    GlobalData.Yetki(ref _cariOdemeKayitFormu);
                }
                return _cariOdemeKayitFormu;
            }
        }
        private List<Control> _controlsToDisable;
        public List<Control> controlsToDisable { get => _controlsToDisable; set => _controlsToDisable = value; }
        private List<Control> _controlsToVisible;
        /// <summary>
        /// Form tipine göre gürünür olacak kontrollerin listesini tutar.
        /// </summary>
        public List<Control> controlsToVisible { get => _controlsToVisible; set => _controlsToVisible = value; }
        /// <summary>
        /// Form tipine göre görünür olacak kontrolleri tutar
        /// </summary>
        private List<Control> _controlsToEdit;
        /// <summary>
        /// Form tipine göre görünür olacak kontrolleri tutar
        /// </summary>
        public List<Control> controlsToEdit { get => _controlsToEdit; set => _controlsToEdit = value; }

        private bool _activeForm;
        public bool activeForm { get => _activeForm; set => _activeForm = value; }
        private CariOdeme _cariOdemeToSave;
        public CariOdeme cariOdemeToSave { get { if (_cariOdemeToSave == null) { _cariOdemeToSave = new(); } return _cariOdemeToSave; } set { _cariOdemeToSave = value; } }
        private CariOdeme _cariOdemeToUpdate;
        public CariOdeme cariOdemeToUpdate { get { if (_cariOdemeToUpdate == null) { _cariOdemeToUpdate = new(); } return _cariOdemeToUpdate; } set { _cariOdemeToUpdate = value; } }
        private int _formType;
        private OdemeYonu _odemeYonu;
        private OdemeSekli _odemeSekli;
        private OdemeTuru _odemeTuru;
        public CariOdemeKayitFormu()
        {
            InitializeComponent();
            controlsToDisable = new List<Control>()
            {
                rButtonKapat,
                rButtonGuncelle,
                rButtonKaydet,

                customComboListBoxOdemeYapanFirma,
                customComboListBoxTutarDovizCinsi,
                customTextBoxOdemeTarihi,
                customComboListBoxOdemeTanimi,
                customComboListBoxOdemeninGeldigiKasa,
                textBoxAciklama,
                customComboListBoxMahsupEdilenTutarDovizCinsi,
                customTextBoxMahsupEdilenTutar,
                customTextBoxKur,
                buttonKur,
                customTextBoxCekNo,
                buttonCekKaydet,
                buttonCekSec,
                customTextBoxTaksitSayisi,
                buttonTaksit,
                customComboListBoxKrediKarti,
                customComboListBoxOdemeninCiktigiKasa
            };
            controlsToEdit = new List<Control>()
            {
                labelProjeKodu,
                customComboListBoxProjeKodu,
                labelOdemeYapanFirma,
                customComboListBoxOdemeYapanFirma,
                labelTutar,
                customTextBoxTutar,
                customComboListBoxTutarDovizCinsi,
                labelOdemeTarihi,
                customTextBoxOdemeTarihi,
                labelOdemeTanimi,
                customComboListBoxOdemeTanimi,
                labelOdemeninGeldigiKasa,
                customComboListBoxOdemeninGeldigiKasa,
                labelAciklama,
                textBoxAciklama,
                labelMahsupEdilenTutar,
                customComboListBoxMahsupEdilenTutarDovizCinsi,
                customTextBoxMahsupEdilenTutar,
                labelKur,
                customTextBoxKur,
                buttonKur,
                labelCekNo,
                customTextBoxCekId,
                customTextBoxCekNo,
                buttonCekKaydet,
                buttonCekSec,
                labelTaksitSayisi,
                customTextBoxTaksitSayisi,
                buttonTaksit,
                labelKrediKarti,
                customComboListBoxKrediKarti,
                labelOdemeninCiktigiKasa,
                customComboListBoxOdemeninCiktigiKasa,
                labelOdemeYapilanHesap,
                customComboListBoxOdemeYapilanHesap,
            };
            //foreach (DovizCinsi dovizCinsi in GlobalData.dovizList)
            //{
            //    customComboListBoxMahsupEdilenTutarDovizCinsi.AddDataRow(dovizCinsi.id, dovizCinsi.sembol);
            //    customComboListBoxTutarDovizCinsi.AddDataRow(dovizCinsi.id, dovizCinsi.sembol);
            //}
        }

        public CariOdemeKayitFormu(WebMethods webMethods)
        {
            _webMethods = webMethods;
        }


        #region mouseDrag
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
        #endregion mouseDrag

        public void SaveMode()
        {
            rButtonGuncelle.Visible = false;
            GetCurrentCariOdeme();
            cariOdemeToUpdate = JsonConvert.DeserializeObject<CariOdeme>(JsonConvert.SerializeObject(cariOdemeToSave));
        }
        /// <summary>
        /// radiButtonların herhangi biri seçildiğinde form tipini belirler
        /// form tipine göre gerekli kontrolleri gösterir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (customRadioButtonGelenOdeme.Checked == true) _odemeYonu = OdemeYonu.GELEN;
            if (customRadioButtonGidenOdeme.Checked == true) _odemeYonu = OdemeYonu.GIDEN;
            if (customRadioButtonKendiHesaplarimizArasi.Checked == true) _odemeYonu = OdemeYonu.KASAVIRMAN;
            if (customRadioButtonVirman.Checked == true) _odemeYonu = OdemeYonu.HESAPVIRMAN;
            if (customRadioButtonAyniDovizCinsinden.Checked == true) _odemeTuru = OdemeTuru.AyniDovizCinsinden;
            if (customRadioButtonFarkliDovizCinsinden.Checked == true) _odemeTuru = OdemeTuru.FarkliDovizCinsinden;
            if (customRadioButtonNakit.Checked == true) _odemeSekli = OdemeSekli.NAKIT;
            if (customRadioButtonCek.Checked == true) _odemeSekli = OdemeSekli.CEK;
            if (customRadioButtonCekTahsilati.Checked == true) _odemeSekli = OdemeSekli.CEKTAHSILAT;
            if (customRadioButtonKrediKarti.Checked == true) _odemeSekli = OdemeSekli.KREDIKARTI;
            //Kendi hesaplarımız arası ödeme yönü seçildiğinde döviz comboboxları değişir.
            customComboListBoxMahsupEdilenTutarDovizCinsi.SelectDataRowId(0);
            customComboListBoxTutarDovizCinsi.SelectDataRowId(0);
            FormTipi();
            KontrolleriYerlestir();
        }
        /// <summary>
        /// form tipine göre görünür olacak kontrolleri belirler
        /// </summary>
        private void FormTipi()
        {
            _formType = (int)_odemeYonu * 100 + (int)_odemeTuru * 10 + (int)_odemeSekli;
            switch (_formType)
            {
                case 111:
                    {
                        controlsToVisible = new List<Control>()
                        {
                            labelOdemeTarihi,
                            customTextBoxOdemeTarihi,
                            labelOdemeYapanFirma,
                            customComboListBoxOdemeYapanFirma,
                            labelOdemeninGeldigiKasa,
                            customComboListBoxOdemeninGeldigiKasa,
                            labelTutar,
                            customTextBoxTutar,
                            customComboListBoxTutarDovizCinsi,
                        };
                        labelOdemeYapanFirma.Text = "Ödeme Yapan Firma";
                        labelTutar.Text = "Gelen Tutar";
                        labelOdemeTarihi.Text = "Ödeme Tarihi";
                        labelOdemeTanimi.Text = "Ödeme Tanımı";
                        labelOdemeninGeldigiKasa.Text = "Ödemenin Geldiği Kasa";
                        break;
                    }
                case 112:
                    {
                        controlsToVisible = new List<Control>()
                        {
                            labelOdemeTarihi,
                            customTextBoxOdemeTarihi,
                            labelOdemeYapanFirma,
                            customComboListBoxOdemeYapanFirma,
                            labelCekNo,
                            customTextBoxCekNo,
                            buttonCekSec,
                            labelTutar,
                            customTextBoxTutar,
                            customComboListBoxTutarDovizCinsi,
                        };
                        labelOdemeYapanFirma.Text = "Ödeme Yapan Firma";
                        labelCekNo.Text = "Çek";
                        labelOdemeTarihi.Text = "Ödeme Tarihi";
                        break;
                    }
                case 113:
                    {
                        controlsToVisible = new List<Control>()
                        {
                            labelOdemeTarihi,
                            customTextBoxOdemeTarihi,
                            labelOdemeninGeldigiKasa,
                            customComboListBoxOdemeninGeldigiKasa,
                            labelCekNo,
                            customTextBoxCekNo,
                            buttonCekSec,
                            labelTutar,
                            customTextBoxTutar,
                            customComboListBoxTutarDovizCinsi,
                        };
                        labelOdemeninGeldigiKasa.Text = "Ödemenin Geldiği Kasa";
                        labelCekNo.Text = "Çek";
                        labelOdemeTarihi.Text = "Tahsilat Tarihi";
                        break;
                    }
                case 114:
                    {
                        controlsToVisible = new List<Control>()
                        {

                        };
                        break;
                    }
                case 121:
                    {
                        controlsToVisible = new List<Control>()
                        {
                            labelOdemeTarihi,
                            customTextBoxOdemeTarihi,
                            labelOdemeYapanFirma,
                            customComboListBoxOdemeYapanFirma,
                            labelOdemeninGeldigiKasa,
                            customComboListBoxOdemeninGeldigiKasa,
                            labelTutar,
                            customTextBoxTutar,
                            customComboListBoxTutarDovizCinsi,
                            labelMahsupEdilenTutar,
                            customTextBoxMahsupEdilenTutar,
                            customComboListBoxMahsupEdilenTutarDovizCinsi,
                            labelKur,
                            customTextBoxKur,
                            buttonKur
                        };
                        labelOdemeYapanFirma.Text = "Ödeme Yapan Firma";
                        labelTutar.Text = "Gelen Tutar";
                        labelMahsupEdilenTutar.Text = "Mahsup Edilen Tutar";
                        labelKur.Text = "Kur";
                        labelOdemeTarihi.Text = "Ödeme Tarihi";
                        labelOdemeTanimi.Text = "Ödeme Tanımı";
                        labelOdemeninGeldigiKasa.Text = "Ödemenin Geldiği Kasa";
                        break;
                    }
                case 122:
                    {
                        controlsToVisible = new List<Control>()
                        {
                            labelOdemeTarihi,
                            customTextBoxOdemeTarihi,
                            labelOdemeYapanFirma,
                            customComboListBoxOdemeYapanFirma,
                            labelCekNo,
                            customTextBoxCekNo,
                            buttonCekSec,
                            labelTutar,
                            customTextBoxTutar,
                            customComboListBoxTutarDovizCinsi,
                            labelMahsupEdilenTutar,
                            customTextBoxMahsupEdilenTutar,
                            customComboListBoxMahsupEdilenTutarDovizCinsi,
                            labelKur,
                            customTextBoxKur,
                            buttonKur
                        };
                        labelOdemeYapanFirma.Text = "Ödeme Yapan Firma";
                        labelTutar.Text = "Gelen Tutar";
                        labelCekNo.Text = "Verilen Çek";
                        break;
                    }
                case 123:
                    {
                        controlsToVisible = new List<Control>()
                        {
                            labelOdemeTarihi,
                            customTextBoxOdemeTarihi,
                            labelOdemeninGeldigiKasa,
                            customComboListBoxOdemeninGeldigiKasa,
                            labelCekNo,
                            customTextBoxCekNo,
                            buttonCekSec,
                            labelTutar,
                            customTextBoxTutar,
                            customComboListBoxTutarDovizCinsi,
                            labelMahsupEdilenTutar,
                            customTextBoxMahsupEdilenTutar,
                            customComboListBoxMahsupEdilenTutarDovizCinsi,
                            labelKur,
                            customTextBoxKur,
                            buttonKur
                        };
                        labelOdemeYapanFirma.Text = "Ödeme Yapan Firma";
                        labelCekNo.Text = "Tahsil Edilen Çek";
                        labelTutar.Text = "Çek Tutarı";
                        labelMahsupEdilenTutar.Text = "Mahsup Edilen Tutar";
                        labelKur.Text = "Kur";
                        labelOdemeTarihi.Text = "Ödeme Tarihi";
                        labelOdemeTanimi.Text = "Ödeme Tanımı";
                        labelOdemeninGeldigiKasa.Text = "Ödemenin Geldiği Kasa";
                        break;
                    }
                case 124:
                    {
                        controlsToVisible = new List<Control>()
                        {

                        };
                        break;
                    }
                case 211:
                    {
                        controlsToVisible = new List<Control>()
                        {
                            labelOdemeYapanFirma,
                            customComboListBoxOdemeYapanFirma,
                            labelTutar,
                            customTextBoxTutar,
                            customComboListBoxTutarDovizCinsi,
                            labelOdemeTarihi,
                            customTextBoxOdemeTarihi,
                            labelOdemeTanimi,
                            customComboListBoxOdemeTanimi,
                            labelOdemeninGeldigiKasa,
                            customComboListBoxOdemeninGeldigiKasa,
                        };
                        labelOdemeYapanFirma.Text = "Ödeme Yapılan Firma";
                        labelTutar.Text = "Tutar";
                        labelOdemeTarihi.Text = "Ödeme Tarihi";
                        labelOdemeTanimi.Text = "Ödeme Tanımı";
                        labelOdemeninGeldigiKasa.Text = "Ödemenin Çıktığı Kasa";
                        break;
                    }
                case 212:
                    {
                        controlsToVisible = new List<Control>()
                        {
                            labelOdemeTarihi,
                            customTextBoxOdemeTarihi,
                            labelOdemeYapanFirma,
                            customComboListBoxOdemeYapanFirma,
                            labelCekNo,
                            customTextBoxCekNo,
                            buttonCekSec,
                            labelTutar,
                            customTextBoxTutar,
                            customComboListBoxTutarDovizCinsi,
                        };
                        labelOdemeYapanFirma.Text = "Ödeme Yapılan Firma";
                        labelCekNo.Text = "Verilen Çek";
                        break;
                    }
                case 213:
                    {
                        controlsToVisible = new List<Control>()
                        {
                            
                        };
                        
                        break;
                    }
                case 214:
                    {
                        controlsToVisible = new List<Control>()
                        {
                            labelOdemeTarihi,
                            customTextBoxOdemeTarihi,
                            labelOdemeYapanFirma,
                            customComboListBoxOdemeYapanFirma,
                            labelKrediKarti,
                            customComboListBoxKrediKarti,
                            labelTutar,
                            customTextBoxTutar,
                            customComboListBoxTutarDovizCinsi,
                            labelTaksitSayisi,
                            customTextBoxTaksitSayisi,
                            buttonTaksit,
                        };
                        labelOdemeYapanFirma.Text = "Ödeme Yapılan Firma";
                        labelKrediKarti.Text = "Kredi Kartı";
                        labelTutar.Text = "Toplam Tutar";
                        labelTaksitSayisi.Text = "Taksit Sayısı";
                        labelOdemeTarihi.Text = "Ödeme Tarihi";
                        break;
                    }
                case 221:
                    {
                        controlsToVisible = new List<Control>()
                        {
                            labelOdemeYapanFirma,
                            customComboListBoxOdemeYapanFirma,
                            labelTutar,
                            customTextBoxTutar,
                            customComboListBoxTutarDovizCinsi,
                            labelMahsupEdilenTutar,
                            customTextBoxMahsupEdilenTutar,
                            customComboListBoxMahsupEdilenTutarDovizCinsi,
                            labelKur,
                            customTextBoxKur,
                            buttonKur,
                            labelOdemeTarihi,
                            customTextBoxOdemeTarihi,
                            labelOdemeTanimi,
                            customComboListBoxOdemeTanimi,
                            labelOdemeninGeldigiKasa,
                            customComboListBoxOdemeninGeldigiKasa,
                        };
                        labelOdemeYapanFirma.Text = "Ödeme Yapılan Firma";
                        labelTutar.Text = "Ödenen Tutar";
                        labelMahsupEdilenTutar.Text = "Mahsup Edilen Tutar";
                        labelKur.Text = "Kur";
                        labelOdemeTarihi.Text = "Ödeme Tarihi";
                        labelOdemeTanimi.Text = "Ödeme Tanımı";
                        labelOdemeninGeldigiKasa.Text = "Ödemenin Çıktığı Kasa";
                        break;
                    }
                case 222:
                    {
                        controlsToVisible = new List<Control>()
                        {
                            labelOdemeYapanFirma,
                            customComboListBoxOdemeYapanFirma,
                            labelCekNo,
                            customTextBoxCekNo,
                            buttonCekSec,
                            labelTutar,
                            customTextBoxTutar,
                            customComboListBoxTutarDovizCinsi,
                            labelMahsupEdilenTutar,
                            customTextBoxMahsupEdilenTutar,
                            customComboListBoxMahsupEdilenTutarDovizCinsi,
                            labelKur,
                            customTextBoxKur,
                            buttonKur,
                        };
                        labelOdemeYapanFirma.Text = "Ödeme Yapılan Firma";
                        labelCekNo.Text = "Çek";
                        break;
                    }
                case 223:
                    {
                        controlsToVisible = new List<Control>()
                        {
                            
                        };
                        break;
                    }
                case 224:
                    {
                        controlsToVisible = new List<Control>()
                        {

                        };
                        break;
                    }
                case 311:
                    {
                        controlsToVisible = new List<Control>()
                        {
                            labelOdemeTarihi,
                            customTextBoxOdemeTarihi,
                            labelOdemeninCiktigiKasa,
                            customComboListBoxOdemeninCiktigiKasa,
                            labelOdemeninGeldigiKasa,
                            customComboListBoxOdemeninGeldigiKasa,
                            labelTutar,
                            customTextBoxTutar,
                            customComboListBoxTutarDovizCinsi,
                            labelAciklama,
                            textBoxAciklama
                        };
                        labelOdemeninCiktigiKasa.Text = "Ödemenin Çıktığı Kasa";
                        labelOdemeninGeldigiKasa.Text = "Ödemenin Girdiği Kasa";
                        labelTutar.Text = "Tutar";
                        labelOdemeTarihi.Text = "Ödeme Tarihi";
                        labelAciklama.Text = "Açıklama";
                        break;
                    }
                case 312:
                    {
                        controlsToVisible = new List<Control>()
                        {

                        };
                        break;
                    }
                case 313:
                    {
                        controlsToVisible = new List<Control>()
                        {

                        };
                        break;
                    }
                case 314:
                    {
                        controlsToVisible = new List<Control>()
                        {

                        };
                        break;
                    }
                case 321:
                    {
                        controlsToVisible = new List<Control>()
                        {
                            labelOdemeTarihi,
                            customTextBoxOdemeTarihi,
                            labelOdemeninCiktigiKasa,
                            customComboListBoxOdemeninCiktigiKasa,
                            labelOdemeninGeldigiKasa,
                            customComboListBoxOdemeninGeldigiKasa,
                            labelTutar,
                            customTextBoxTutar,
                            customComboListBoxTutarDovizCinsi,
                            labelMahsupEdilenTutar,
                            customTextBoxMahsupEdilenTutar,
                            customComboListBoxMahsupEdilenTutarDovizCinsi,
                            labelKur,
                            customTextBoxKur,
                            buttonKur,
                            labelAciklama,
                            textBoxAciklama
                        };
                        labelOdemeninCiktigiKasa.Text = "Ödemenin Çıktığı Kasa";
                        labelOdemeninGeldigiKasa.Text = "Ödemenin Girdiği Kasa";
                        labelTutar.Text = "Çıkan Tutar";
                        labelMahsupEdilenTutar.Text = "Giren Tutar";
                        labelKur.Text = "KUR";
                        labelOdemeTarihi.Text = "Tarih";
                        labelAciklama.Text = "Açıklama";
                        break;
                    }
                case 322:
                    {
                        controlsToVisible = new List<Control>()
                        {

                        };
                        break;
                    }
                case 323:
                    {
                        controlsToVisible = new List<Control>()
                        {

                        };
                        break;
                    }
                case 324:
                    {
                        controlsToVisible = new List<Control>()
                        {

                        };
                        break;
                    }
                case 411:
                    {
                        controlsToVisible = new List<Control>()
                        {
                            labelOdemeTarihi,
                            customTextBoxOdemeTarihi,
                            labelOdemeYapanFirma,
                            customComboListBoxOdemeYapanFirma,
                            labelOdemeYapilanHesap,
                            customComboListBoxOdemeYapilanHesap,
                            labelTutar,
                            customTextBoxTutar,
                            customComboListBoxTutarDovizCinsi,
                            labelAciklama,
                            textBoxAciklama
                        };
                        labelOdemeYapanFirma.Text = "Ödeme Yapan Hesap";
                        labelTutar.Text = "Tutar";
                        labelOdemeTarihi.Text = "Tarih";
                        labelOdemeTanimi.Text = "Ödeme Tanımı";
                        labelOdemeYapilanHesap.Text = "Ödemeyi Alan Hesap";
                        labelAciklama.Text = "Açıklama";
                        break;
                    }
                case 412:
                    {
                        controlsToVisible = new List<Control>()
                        {

                        };
                        break;
                    }
                case 413:
                    {
                        controlsToVisible = new List<Control>()
                        {

                        };
                        break;
                    }
                case 414:
                    {
                        controlsToVisible = new List<Control>()
                        {

                        };
                        break;
                    }
                case 421:
                    {
                        controlsToVisible = new List<Control>()
                        {

                        };
                        break;
                    }
                case 422:
                    {
                        controlsToVisible = new List<Control>()
                        {

                        };
                        break;
                    }
                case 423:
                    {
                        controlsToVisible = new List<Control>()
                        {

                        };
                        break;
                    }
                case 424:
                    {
                        controlsToVisible = new List<Control>()
                        {

                        };
                        break;
                    }
            }
        }
        /// <summary>
        /// Görünür kontrolleri form tipine göre konumlandırır
        /// </summary>
        private void KontrolleriYerlestir()
        {
            int locationX = 45;
            int locationY = 180;
            foreach (Control control1 in controlsToEdit)
            {
                control1.Visible = false;//form tipine göre görünür özelliği değişecek olan tüm kontrolleri gizle
            }
            foreach (Control control in controlsToVisible)
            {
                if (!control.Name.Contains("labelUyari")) // Uyarı etikeleri haricindeki kontrolleri dolaş
                {
                    control.Visible = true;//form tipine göre görünür olacak kontrolleri göster
                }
                //görünür olacak kontrollerin konumunu ayarla
                if (control is Label && !control.Name.Contains("labelUyari"))//eğer label ise fakat uyari labeli değilse yeni satıra geç
                {
                    locationX = 45; //x değerini başa al
                    locationY = locationY + 41; //yeni satır için y değerini arttır
                    control.Location = new Point(locationX, locationY);//control konumunu ata
                    locationX = locationX + 240;//control eğer label ise x değerini sabit olarak arttır
                }
                else
                {
                    control.Location = new Point(locationX, locationY);//yeni konumunu ata
                    locationX = locationX + control.Width + 10;//control eğer label değilse x değerini control genişliği kadar arttır
                }
            }
        }
        /// <summary>
        /// Form yüklenirken combolist'lerin datalarını yükler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void CariOdemeKayitFormu_Load(object sender, EventArgs e)
        {
            Opacity = 0; //Formdaki combolist'lerin dataları yüklenene kadar formu görünmez yap
            radioButton_CheckedChanged(null, null);
            string httpTask = _webMethods.GetCariOdemeComboLists();
            byte[] bytes = JsonConvert.DeserializeObject<byte[]>(httpTask);
            string result = Encoding.UTF8.GetString(bytes);
            DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(result);
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                int projeKodId = Convert.ToInt32(row["projeKodId"]);
                int markaId = Convert.ToInt32(row["markaId"]);
                int projeNo = Convert.ToInt32(row["projeNo"]);
                string projeKodu = row["kod"].ToString();
                customComboListBoxProjeKodu.AddDataRow(projeKodId, projeKodu);
            }
            foreach (DataRow row in dataSet.Tables[1].Rows)
            {
                customComboListBoxOdemeninCiktigiKasa.AddDataRow(Convert.ToInt32(row["KasaId"]), row["kasaAdi"].ToString());
                customComboListBoxOdemeninGeldigiKasa.AddDataRow(Convert.ToInt32(row["KasaId"]), row["kasaAdi"].ToString());
            }
            foreach (DataRow row in dataSet.Tables[2].Rows)
            {
                customComboListBoxKrediKarti.AddDataRow(Convert.ToInt32(row["KrediKartiId"]), row["KartSahibi"].ToString() + " " + row["hesapAdi"].ToString());
            }
            foreach (DataRow row in dataSet.Tables[3].Rows)
            {
                customComboListBoxOdemeTanimi.AddDataRow(Convert.ToInt32(row["OdemeTanimiId"]), row["OdemeTanimi"].ToString());
            }
            foreach (DataRow row in dataSet.Tables[4].AsEnumerable())
            {
                customComboListBoxOdemeYapanFirma.AddDataRow(Convert.ToInt32(row["CariKartId"]), row["CariAdi"].ToString());
                customComboListBoxOdemeYapilanHesap.AddDataRow(Convert.ToInt32(row["CariKartId"]), row["CariAdi"].ToString());
            }
            
            Opacity = 1;//formu görünür yap
        }

        private async void rButtonKaydet_Click(object sender, EventArgs e)
        {
            if (CheckFields())
            {
                GetCurrentCariOdeme();
                string result = await WebMethods.SaveCariOdeme(cariOdemeToSave);
                if (result.Contains("error", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show(result);
                }
                else
                {
                    IDataTableConverter dataTableConverter = new DataTableConverter();
                    IJsonConvertHelper jsonConverter = new JsonConvertHelper();
                    DataSet dataSet = jsonConverter.JsonStringToDataSet(result);
                    cariOdemeToSave = dataTableConverter.DataRowToModel<CariOdeme>(dataSet.Tables[0].Rows[0]);
                    if (GlobalData.activeFormStack.Skip(1).First().GetType() == typeof(CariOdemelerGridForm))
                    {
                        CariOdemelerGridForm.cariOdemelerGridForm.UpdateRow(cariOdemeToSave);
                    }
                    MessageBox.Show("Cari ödeme kaydedildi", "Kayıt Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UpdateMode(cariOdemeToSave);
                }
            }
        }
        private void GetCurrentCariOdeme()
        {
            //Görünür olan denetimlerdeki veriler kaydedilmek üzere cariOdeme'ye aktarılıyor. 
            //visible özelliği false olan denetimlerde veri varsa bile cariOdeme'ye yüklenmez.
            cariOdemeToSave.cariOdemeId = cariOdemeToUpdate.cariOdemeId;
            cariOdemeToSave.cariKart.cariKartId = (customComboListBoxOdemeYapanFirma.Visible) ? customComboListBoxOdemeYapanFirma.selectedDataRowId : 0;
            cariOdemeToSave.cariKart.cariAdi = (customComboListBoxOdemeYapanFirma.Visible) ? customComboListBoxOdemeYapanFirma.selectedDataRowValue : null;
            cariOdemeToSave.projeKod.Id = (customComboListBoxProjeKodu.Visible) ? customComboListBoxProjeKodu.selectedDataRowId : 0;
            cariOdemeToSave.projeKod.kod = (customComboListBoxProjeKodu.Visible) ? customComboListBoxProjeKodu.selectedDataRowValue : null;
            cariOdemeToSave.tutar.tutar = (customTextBoxTutar.Visible) ? (float.TryParse(customTextBoxTutar.TextCustom.ToString(), out float tutar) ? tutar : 0) : 0;
            cariOdemeToSave.tutar.dovizCinsi.id = (customComboListBoxTutarDovizCinsi.Visible) ? customComboListBoxTutarDovizCinsi.selectedDataRowId : 0;
            cariOdemeToSave.tutar.dovizCinsi.sembol = (customComboListBoxTutarDovizCinsi.Visible) ? customComboListBoxTutarDovizCinsi.selectedDataRowValue : null;
            cariOdemeToSave.mahsupEdilenTutar.tutar = (customTextBoxMahsupEdilenTutar.Visible) ? (float.TryParse(customTextBoxMahsupEdilenTutar.TextCustom.ToString(), out float mahsupTutar) ? mahsupTutar : 0) : float.Parse(customTextBoxTutar.TextCustom.ToString());
            cariOdemeToSave.mahsupEdilenTutar.dovizCinsi.id = (customComboListBoxMahsupEdilenTutarDovizCinsi.Visible) ? customComboListBoxMahsupEdilenTutarDovizCinsi.selectedDataRowId : customComboListBoxTutarDovizCinsi.selectedDataRowId;
            cariOdemeToSave.mahsupEdilenTutar.dovizCinsi.sembol = (customComboListBoxMahsupEdilenTutarDovizCinsi.Visible) ? customComboListBoxMahsupEdilenTutarDovizCinsi.selectedDataRowValue : null;
            cariOdemeToSave.odemeTarihi = (customTextBoxOdemeTarihi.Visible) ? (DateTime.TryParse(customTextBoxOdemeTarihi.TextCustom, out DateTime odemeTarihi) ? odemeTarihi : DateTime.MinValue) : DateTime.MinValue;
            cariOdemeToSave.odemeTuru = _odemeTuru;
            cariOdemeToSave.odemeSekli = _odemeSekli;
            cariOdemeToSave.odemeYonu = _odemeYonu;
            cariOdemeToSave.cek.cekId = (customTextBoxCekNo.Visible) ? (int.TryParse(customTextBoxCekId.TextCustom.ToString(), out int cekId) ? cekId : 0) : 0;
            cariOdemeToSave.cek.cekNumarasi = (customTextBoxCekNo.Visible) ? customTextBoxCekNo.TextCustom.ToString() : null;
            cariOdemeToSave.krediKarti.krediKartiId = (customComboListBoxKrediKarti.Visible) ? customComboListBoxKrediKarti.selectedDataRowId : 0;
            cariOdemeToSave.krediKarti.kartSahibi = (customComboListBoxKrediKarti.Visible) ? customComboListBoxKrediKarti.selectedDataRowValue : null;
            cariOdemeToSave.taksitOdemesi.taksitOdemesiId = (customTextBoxTaksitSayisi.Visible) ? (int.TryParse(customTextBoxTaksitSayisi.ToString(), out int taksitOdemesiId) ? taksitOdemesiId : 0) : 0;
            cariOdemeToSave.odemeninCiktigiKasa.kasaId = (customComboListBoxOdemeninCiktigiKasa.Visible) ? customComboListBoxOdemeninCiktigiKasa.selectedDataRowId : 0;
            cariOdemeToSave.odemeninCiktigiKasa.kasaAdi = (customComboListBoxOdemeninCiktigiKasa.Visible) ? customComboListBoxOdemeninCiktigiKasa.selectedDataRowValue : null;
            cariOdemeToSave.odemeninGirdigiKasa.kasaId = (customComboListBoxOdemeninGeldigiKasa.Visible) ? customComboListBoxOdemeninGeldigiKasa.selectedDataRowId : 0;
            cariOdemeToSave.odemeninGirdigiKasa.kasaAdi = (customComboListBoxOdemeninGeldigiKasa.Visible) ? customComboListBoxOdemeninGeldigiKasa.selectedDataRowValue : null;
            cariOdemeToSave.odemeTanimi.odemeTanimiId = (customComboListBoxOdemeTanimi.Visible) ? customComboListBoxOdemeTanimi.selectedDataRowId : 0;
            cariOdemeToSave.odemeTanimi.odemeTanimi = (customComboListBoxOdemeTanimi.Visible) ? customComboListBoxOdemeTanimi.selectedDataRowValue : null;
            cariOdemeToSave.aciklama = textBoxAciklama.Text;
            cariOdemeToSave.odemeYapilanCariKart.cariKartId = (customComboListBoxOdemeYapilanHesap.Visible) ? customComboListBoxOdemeYapilanHesap.selectedDataRowId : 0;
            cariOdemeToSave.odemeYapilanCariKart.cariAdi = (customComboListBoxOdemeYapilanHesap.Visible) ? customComboListBoxOdemeYapilanHesap.selectedDataRowValue : null;
        }
        private bool CheckFields()
        {
            bool result = true;
            //form tipine göre görünür olacak kontrolleri dolaşır. Boş olan CustomTextBox veya CustomComboListBox varsa sonucu false yapar ve uyarı mesajlarını yazdırır.
            foreach (Control control in controlsToVisible)
            {
                if (control is CustomTextBox customTextBox)
                {
                    string labelName = "label" + customTextBox.Name.Substring(13);
                    Control[] foundControls = this.Controls.Find(labelName, true);
                    if (foundControls != null && foundControls.Length > 0)
                    {
                        GlobalData.CheckField("*" + foundControls[0].Text + " girilmelidir", this, customTextBox);
                    }
                }
                if (control is CustomComboListBox customComboListBox)
                {
                    string labelName = "label" + customComboListBox.Name.Substring(18);
                    Control[] foundControls = this.Controls.Find(labelName, true);
                    if(foundControls != null && foundControls.Length > 0)
                    {
                        GlobalData.CheckField("*" + foundControls[0].Text + " girilmelidir", this, customComboListBox);
                    }
                }
                if (control is CustomTextBoxTarih customTextBoxTarih)
                {
                    string labelName = "label" + customTextBoxTarih.Name.Substring(13);
                    Control[] foundControls = this.Controls.Find(labelName, true);
                    if (foundControls != null && foundControls.Length > 0)
                    {
                        GlobalData.CheckField("*" + foundControls[0].Text + " girilmelidir", this, customTextBoxTarih);
                    }
                }
                if (control is CustomTextBoxSayisal customTextBoxSayisal)
                {
                    string labelName = "label" + customTextBoxSayisal.Name.Substring(13);
                    Control[] foundControls = this.Controls.Find(labelName, true);
                    if (foundControls != null && foundControls.Length > 0)
                    {
                        GlobalData.CheckField("*" + foundControls[0].Text + " girilmelidir", this, customTextBoxSayisal);
                    }
                }
            }
            if (_odemeTuru == OdemeTuru.AyniDovizCinsinden)
            {
                Kasa kasa = new();
                kasa.kasaId = customComboListBoxOdemeninGeldigiKasa.selectedDataRowId;
                kasa = GlobalData.GetModelFromDatabase(WebMethods.GetFilteredKasa, kasa);
                if (kasa.bakiye.dovizCinsi.id != customComboListBoxMahsupEdilenTutarDovizCinsi.selectedDataRowId)
                {
                    MessageBox.Show("Mahsup edilen döviz cinsi ile kasa döviz cinsi farklı olmamalıdır.");
                    result = false;
                }
            }
            return result;
        }

        private void buttonTaksit_Click(object sender, EventArgs e)
        {
            TaksitliOdeme taksitliOdeme = new();
            taksitliOdeme.cari = new CariKart();
            taksitliOdeme.cari.cariKartId = (customComboListBoxOdemeYapanFirma.selectedDataRowId == -1) ? -1 : customComboListBoxOdemeYapanFirma.selectedDataRowId;
            taksitliOdeme.islemTarihi = DateTime.TryParse(customTextBoxOdemeTarihi.TextCustom.ToString(), out DateTime tarih) ? tarih : DateTime.MinValue;
            taksitliOdeme.toplamTutar = new Tutar();
            taksitliOdeme.toplamTutar.tutar = float.TryParse(customTextBoxTutar.TextCustom.ToString(), out float tutar) ? tutar : 0;
            taksitliOdeme.toplamTutar.dovizCinsi.id = customComboListBoxTutarDovizCinsi.selectedDataRowId;
            taksitliOdeme.taksitliOdemeTuru = TaksitliOdemeTuru.KREDIKARTI;
            TaksitliOdemeKayitFormu taksitliIslemKayitFormu = TaksitliOdemeKayitFormu.taksitliOdemeKayitFormu;
            taksitliIslemKayitFormu.Show();
            taksitliIslemKayitFormu.SaveMode(taksitliOdeme);
        }
        private void rButtonKapat_Click(object sender, EventArgs e)
        {
            CloseForm(sender,e);
        }
        private void CloseForm(object sender,EventArgs e)
        {
            GetCurrentCariOdeme();
            if (!GlobalData.CompareClass(cariOdemeToSave, cariOdemeToUpdate))
            {
                DialogResult dialogResult = MessageBox.Show("Formda yapılan değişiklikler kaydedilsin mi", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    rButtonKaydet_Click(sender, e);
                }
                else
                {
                    GlobalData.CloseForm(ref _cariOdemeKayitFormu);
                }
            }
            else
            {
                GlobalData.CloseForm(ref _cariOdemeKayitFormu);
            }
        }
        private void buttonKur_Click(object sender, EventArgs e)
        {
            //DovizKurlari dovizKurlari = new DovizKurlari();
            //dovizKurlari.Show();
            float kur = float.Parse(customTextBoxKur.TextCustom);
            customTextBoxKur.TextCustom = (1 / kur).ToString("N4");
        }

        private void buttonCekKaydet_Click(object sender, EventArgs e)
        {
            CekKayitFormu cekKayitFormu = CekKayitFormu.cekKayitFormu;
            if(cekKayitFormu!=null)
            {
                cekKayitFormu.Show();
                cekKayitFormu.SaveMode();
            }
        }

        private void buttonCekSec_Click(object sender, EventArgs e)
        {
            cariOdemeToUpdate = new CariOdeme();
            cariOdemeToUpdate.cek = new Cek();
            CekKayitlariGridForm cekKayitlariGridFormu = CekKayitlariGridForm.cekKayitlariGridForm;
            if (cekKayitlariGridFormu != null)
            {
                cekKayitlariGridFormu.Show();
            }
        }
        public void UpdateMode(CariOdeme cariOdeme)
        {
            cariOdemeToUpdate = cariOdeme;
            switch (cariOdemeToUpdate.odemeYonu)
            {
                case OdemeYonu.GELEN: customRadioButtonGelenOdeme.Checked = true; break;
                case OdemeYonu.GIDEN: customRadioButtonGidenOdeme.Checked = true; break;
                case OdemeYonu.KASAVIRMAN: customRadioButtonKendiHesaplarimizArasi.Checked = true; break;
                case OdemeYonu.HESAPVIRMAN: customRadioButtonVirman.Checked = true; break;
            }
            switch (cariOdemeToUpdate.odemeSekli)
            {
                case OdemeSekli.NAKIT: customRadioButtonNakit.Checked = true; break;
                case OdemeSekli.CEK: customRadioButtonCek.Checked = true; break;
                case OdemeSekli.CEKTAHSILAT: customRadioButtonCekTahsilati.Checked = true; break;
                case OdemeSekli.KREDIKARTI: customRadioButtonKrediKarti.Checked = true; break;
            }
            switch (cariOdemeToUpdate.odemeTuru)
            {
                case OdemeTuru.AyniDovizCinsinden: customRadioButtonAyniDovizCinsinden.Checked = true; break;
                case OdemeTuru.FarkliDovizCinsinden: customRadioButtonFarkliDovizCinsinden.Checked = true; break;
            }
            customTextBoxCekId.TextCustom = cariOdemeToUpdate.cek.cekId.ToString();
            customTextBoxCekNo.TextCustom = cariOdemeToUpdate.cek.cekNumarasi??"".ToString();
            customTextBoxTutar.TextCustom = cariOdemeToUpdate.tutar.tutar.ToString();
            customComboListBoxTutarDovizCinsi.SelectDataRowId(cariOdemeToUpdate.tutar.dovizCinsi.id);
            customComboListBoxProjeKodu.SelectDataRowId(cariOdemeToUpdate.projeKod.Id);
            customTextBoxMahsupEdilenTutar.TextCustom = cariOdemeToUpdate.mahsupEdilenTutar.tutar.ToString();
            customComboListBoxMahsupEdilenTutarDovizCinsi.SelectDataRowId(cariOdemeToUpdate.mahsupEdilenTutar.dovizCinsi.id);
            customComboListBoxKrediKarti.SelectDataRowId(cariOdemeToUpdate.krediKarti.krediKartiId);
            customComboListBoxOdemeninCiktigiKasa.SelectDataRowId(cariOdemeToUpdate.odemeninCiktigiKasa.kasaId);
            customComboListBoxOdemeninGeldigiKasa.SelectDataRowId(cariOdemeToUpdate.odemeninGirdigiKasa.kasaId);
            customComboListBoxOdemeYapanFirma.SelectDataRowId(cariOdemeToUpdate.cariKart.cariKartId);
            customTextBoxOdemeTarihi.TextCustom = cariOdemeToUpdate.odemeTarihi.ToShortDateString();
            customComboListBoxOdemeTanimi.SelectDataRowId(cariOdemeToUpdate.odemeTanimi.odemeTanimiId);
            customComboListBoxOdemeYapilanHesap.SelectDataRowId(cariOdemeToUpdate.odemeYapilanCariKart.cariKartId);
            textBoxAciklama.Text = cariOdemeToUpdate.aciklama;
            GetCurrentCariOdeme();
            cariOdemeToUpdate = JsonConvert.DeserializeObject<CariOdeme>(JsonConvert.SerializeObject(cariOdemeToSave));
        }

        private void customTextBoxMahsupEdilenTutar_TextChanged(object sender, EventArgs e)
        {
            KurHesapla();
        }

        private void customComboListBoxOdemeYapanFirma_SelectedIndexChanged(object sender, EventArgs e)
        {
            CariKart cariKart = new();
            cariKart.cariKartId = customComboListBoxOdemeYapanFirma.selectedDataRowId;
            cariKart = GlobalData.GetModelFromDatabase(WebMethods.GetFilteredCariKartlar, cariKart);
            customComboListBoxMahsupEdilenTutarDovizCinsi.SelectDataRowId(cariKart.guncelCari.dovizCinsi.id);
        }

        private async void customComboListBoxOdemeninGeldigiKasa_SelectedIndexChanged(object sender, EventArgs e)
        {
            Kasa kasa = new();
            kasa.kasaId = customComboListBoxOdemeninGeldigiKasa.selectedDataRowId;
            string httpResult = WebMethods.GetFilteredKasa(kasa);
            byte[] bytes = JsonConvert.DeserializeObject<byte[]>(httpResult);
            string json = Encoding.UTF8.GetString(bytes);
            DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(json);
            //int dovizId = GlobalData.dovizList.Find(x => x.id == int.Parse(dataSet.Tables[0].Rows[0]["bakiye_dovizCinsi_id"].ToString())).id;
            //if (customRadioButtonKendiHesaplarimizArasi.Checked == true)
            //{
            //    customComboListBoxMahsupEdilenTutarDovizCinsi.SelectDataRowId(dovizId);
            //}
            //else
            //{
            //    customComboListBoxTutarDovizCinsi.SelectDataRowId(dovizId);
            //}
        }

        private async void customComboListBoxOdemeninCiktigiKasa_SelectedIndexChanged(object sender, EventArgs e)
        {
            Kasa kasa = new();
            kasa.kasaId = customComboListBoxOdemeninCiktigiKasa.selectedDataRowId;
            string httpResult = WebMethods.GetFilteredKasa(kasa);
            byte[] bytes = JsonConvert.DeserializeObject<byte[]>(httpResult);
            string json = Encoding.UTF8.GetString(bytes);
            DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(json);
            //int dovizId = GlobalData.dovizList.Find(x => x.id == int.Parse(dataSet.Tables[0].Rows[0]["dovizId"].ToString())).id;
            //if (customRadioButtonKendiHesaplarimizArasi.Checked == true)
            //{
            //    customComboListBoxTutarDovizCinsi.SelectDataRowId(dovizId);
            //}
            //else
            //{
            //    customComboListBoxMahsupEdilenTutarDovizCinsi.SelectDataRowId(dovizId);
            //}
        }

        private void customTextBoxTutar_TextChanged(object sender, EventArgs e)
        {
            KurHesapla();
        }
        private void KurHesapla()
        {
            float tutar = float.TryParse(customTextBoxTutar.TextCustom.ToString(), out float resultTutar) ? resultTutar : 0;
            float mahsupEdilenTutar = float.TryParse(customTextBoxMahsupEdilenTutar.TextCustom.ToString(), out float resultMahsupEdilenTutar) ? resultMahsupEdilenTutar : 0;
            if (tutar > 0 && mahsupEdilenTutar > 0)
            {
                float kur = tutar / mahsupEdilenTutar;
                customTextBoxKur.TextCustom = kur.ToString("N4");
            }
        }

        private void roundedButton3_Click(object sender, EventArgs e)
        {
            CloseForm(sender,e);
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
