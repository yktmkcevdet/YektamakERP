using Models;
using Newtonsoft.Json;
using ApiService;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Utilities.Implementations;
using Utilities.Interfaces;

namespace YektamakDesktop.Formlar.Genel
{
    public partial class FirmaKayitFormu : Form, IForm
    {
        private static FirmaKayitFormu _firmaKayitFormu;
        public static FirmaKayitFormu firmaKayitFormu
        {
            get
            {
                if (_firmaKayitFormu == null)
                {
                    _firmaKayitFormu = new FirmaKayitFormu();
                    GlobalData.Yetki(ref _firmaKayitFormu);
                }
                return _firmaKayitFormu;
            }
        }
        private List<Control> _controlsToDisable;
        public List<Control> controlsToDisable { get => _controlsToDisable; set => _controlsToDisable = value; }
        private bool _activeForm;
        public bool activeForm { get => _activeForm; set => _activeForm = value; }
        private Firma firmaToSave;
        private Firma _firmaToUpdate;
        public Firma firmaToUpdate { get { if (_firmaToUpdate == null) { _firmaToUpdate = new(); } return _firmaToUpdate; } set { _firmaToUpdate = value; } }
		private FirmaKayitFormu()
		{
			InitializeComponent();
   //         for (int i = 0; i < GlobalData.sektorList.Count; i++)
   //         {
   //             customCheckedComboBoxSektorler.AddDataRow(GlobalData.sektorList[i].Id, GlobalData.sektorList[i].ad);
   //         }
   //         controlsToDisable = new List<Control>
			//{

			//};
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

        /// <summary>
        /// Formu kapatma işlemlerini yapar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rButtonKapat_Click(object sender, EventArgs e)
        {
            CloseForm(sender,e);
        }
        /// <summary>
        /// Bütün alanlardaki veriler doğru yazılmış mı onun kontrol yapılacak
        /// Yanlış varsa alanın yanındaki label'larda uyarı mesajı olarak belirtilecek
        /// </summary>
        private bool CheckFields()
        {
            bool result = true;

            GlobalData.ClearWarningLabels(this);
            result = GlobalData.CheckField("*Firma ünvanı boş bırakılamaz", this, textBoxFirmaUnvan) && result;
            result = GlobalData.CheckField("*Vergi Dairesi boş bırakılamaz", this, textBoxVergiDairesi) && result;
            result = GlobalData.CheckField("*Vergi Numarası boş bırakılamaz", this, textBoxVergiNumarasi) && result;
            result = GlobalData.CheckField("*En az 1 faaliyet alanı seçilmelidir", this, customCheckedComboBoxSektorler) && result;
            result = GlobalData.CheckField("*Adres alanı boş bırakılamaz", this, textBoxAdres) && result;
            result = GlobalData.CheckField("*Ülke alanı boş bırakılamaz", this, textBoxUlke) && result;
            result = GlobalData.CheckField("*Şehir alanı boş bırakılamaz", this, textBoxSehir) && result;
            return result;
        }
        private void GetCurrentFirma()
        {
            firmaToSave = new();
            firmaToSave.Id = firmaToUpdate.Id;
            firmaToSave.ad = textBoxFirmaUnvan.TextCustom;
            firmaToSave.vergiDairesi = textBoxVergiDairesi.TextCustom;
            firmaToSave.vergiNumarasi = textBoxVergiNumarasi.TextCustom;
            int sektorCount = 0;
            for (int i = 0; i < customCheckedComboBoxSektorler.listBoxDataRows.Count; i++)
            {
                if (customCheckedComboBoxSektorler.listBoxDataRows[i].isChecked)
                {
                    firmaToSave.sektorIdList.Add(new Sektor { Id = customCheckedComboBoxSektorler.listBoxDataRows[i].id,ad= customCheckedComboBoxSektorler.listBoxDataRows[i].value });
                    sektorCount++;
                }
            }
            firmaToSave.adres.ulke = textBoxUlke.Text;
            firmaToSave.adres.sehir = textBoxSehir.Text;
            firmaToSave.adres.postaKodu = textBoxPostaKodu.Text;
            firmaToSave.adres.acikAdres = textBoxAdres.Text;
            firmaToSave.telefon = customTextBoxTelefon.TextCustom;
            firmaToSave.faks = customTextBoxFaks.TextCustom;
            firmaToSave.mail = customTextBoxMail.TextCustom;
        }
        /// <summary>
        /// Yeni kayıt
        /// Banka Hesapları ve Yetkili tanımlama aktif değil
        /// </summary>
        public void SaveMode()
        {
            GetCurrentFirma();
            firmaToUpdate=JsonConvert.DeserializeObject<Firma>(JsonConvert.SerializeObject(firmaToSave));
            rButtonFirmaGuncelle.Visible = false;
        }
        /// <summary>
        /// Formun kayıt güncelleme moduna geçmesini sağlar
        /// </summary>
        /// <param name="firma"></param>
        public void UpdateMode(Firma firma)
        {
            firmaToUpdate = JsonConvert.DeserializeObject<Firma>(JsonConvert.SerializeObject(firma));
            firmaToSave = JsonConvert.DeserializeObject<Firma>(JsonConvert.SerializeObject(firma));
            rButtonFirmaGuncelle.Visible = true;
            firmaToSave.Id = firmaToUpdate.Id;
            textBoxFirmaUnvan.TextCustom = firmaToUpdate.ad;
            textBoxVergiDairesi.TextCustom = firmaToUpdate.vergiDairesi;
            textBoxVergiNumarasi.TextCustom = firmaToUpdate.vergiNumarasi;
            textBoxUlke.Text = firmaToUpdate.adres.ulke;
            textBoxSehir.Text = firmaToUpdate.adres.sehir;
            textBoxPostaKodu.Text = firmaToUpdate.adres.postaKodu;
            textBoxAdres.Text = firmaToUpdate.adres.acikAdres;
            customTextBoxTelefon.TextCustom = firmaToUpdate.telefon;
            customTextBoxFaks.TextCustom = firmaToUpdate.faks;
            customTextBoxMail.TextCustom = firmaToUpdate.mail;
            foreach(Sektor sektor in firmaToUpdate.sektorIdList)
            {
                customCheckedComboBoxSektorler.listBoxDataRows.Find(x => x.id == sektor.Id).isChecked = true;
            }
            customCheckedComboBoxSektorler.RefreshListBox();
        }
            /// <summary>
            /// Form üzerinde girilen bilgileri firma nesnesine doldurur ve veritabanına kaydeder
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
        private async void rButtonFirmaKaydet_Click(object sender, EventArgs e)
        {
            if (CheckFields())
            {
                GetCurrentFirma();
                if (firmaToSave != null)
                {
                    string result = await WebMethods.SaveFirma(firmaToSave);
                    if (result.Contains("error", StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show(result);
                    }
                    else
                    {
                        IDataTableHelper dataTableConverter = new DataTableHelper();
                        IJsonConvertHelper jsonConverter = new JsonConvertHelper();
                        firmaToSave = dataTableConverter.DataRowToModel<Firma>(jsonConverter.JsonStringToDataSet(result).Tables[0].Rows[0]);
                        if (GlobalData.activeFormStack.Skip(1).First().GetType() == typeof(FirmaGridForm))
                        {
                            if (firmaToSave != null && firmaToSave.Id != 0)
                            {
                                FirmaGridForm.firmaGridForm.UpdateRow(firmaToSave);
                            }
                        }
                        UpdateMode(firmaToSave);
                        MessageBox.Show("Kayıt başarılı");
                    }
                }
            }
        }
        /// <summary>
        /// Firmaya bağlı banka hesabı eklemek için banka hesabı kayıt formunu açar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBankaHesabiEkle_Click(object sender, EventArgs e)
        {
            BankaHesabiKayitFormu bankaHesabiKayitFormu = BankaHesabiKayitFormu.bankaHesabiKayitFormu;
            if (bankaHesabiKayitFormu != null)
            {
                bankaHesabiKayitFormu.Show();
                bankaHesabiKayitFormu.SaveMode(firmaToUpdate);
            }
        }
        /// <summary>
        /// Firmaya bağlı yetkili personel eklemek için personel kayıt formunu açar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonYetkiliEkle_Click(object sender, EventArgs e)
        {
            PersonelKayitFormu personelKayitFormu = PersonelKayitFormu.personelKayitFormu;
            if(personelKayitFormu != null)
            {
                Personel personel = new();
                personel.firma.Id= firmaToUpdate.Id;
                personelKayitFormu.Show();
                personelKayitFormu.SaveMode(personel);
            }
        }
        /// <summary>
        /// Firmaya bağlı banka hesabı eklendiği zaman combobox listesine ekler
        /// </summary>
        /// <param name="bankaHesabi"></param>
        public void AddNewBankaHesabi(BankaHesabi bankaHesabi)
        {
            if (firmaToUpdate != null)//Update dışında bir seçenekle BankaKayitFormu açamaz
            {
                AddNewBankaHesabiToComboList(bankaHesabi);
            }
        }
        /// <summary>
        /// Banka hesabı bilgilerini combobox'a ekler
        /// </summary>
        /// <param name="bankaHesabi"></param>
        private void AddNewBankaHesabiToComboList(BankaHesabi bankaHesabi)
        {
            comboListBoxBankaHesaplari.AddDataRow(bankaHesabi.hesapId,
            ListBoxStringFormat.FormatString(bankaHesabi.hesapAdi, 20, HorizontalAlignment.Left) +
            //ListBoxStringFormat.FormatString(GlobalData.GetSymbolFromDovizId(bankaHesabi.dovizCinsi.id), 5, HorizontalAlignment.Left) +
            ListBoxStringFormat.FormatString(bankaHesabi.IBAN, 30, HorizontalAlignment.Left));
        }
        /// <summary>
        /// Firmaya bağlı yetkili personel tanımlandığı zaman combobox'a ekler
        /// </summary>
        /// <param name="personel"></param>
        public void AddNewPersonel(Personel personel)
        {
            if (firmaToUpdate != null)//Update dışında bir seçenekle PersonelKayitFormu açamaz
            {
                AddNewPersonelToComboList(personel);
            }
        }
        /// <summary>
        /// Personel bilgilerini combobox'a ekler
        /// </summary>
        /// <param name="personel"></param>
        private void AddNewPersonelToComboList(Personel personel)
        {
            comboListBoxYetililer.AddDataRow(personel.Id, ListBoxStringFormat.FormatString(personel.ad, 20, HorizontalAlignment.Left) +
                ListBoxStringFormat.FormatString(personel.soyad, 20, HorizontalAlignment.Left));
            //Console.WriteLine("Added personel id : "+personel.id.ToString()+", ad : "+personel.ad+", soyad : "+personel.soyad);
        }
       
        public void UpdateBankaHesabiOnComboList(BankaHesabi bankaHesabi)
        {
            int listIndex = comboListBoxBankaHesaplari.listBoxDataRows.FindIndex(x => x.id == bankaHesabi.hesapId);
            comboListBoxBankaHesaplari.listBoxDataRows[listIndex].value = ListBoxStringFormat.FormatString(bankaHesabi.hesapAdi, 20, HorizontalAlignment.Left) +
                //ListBoxStringFormat.FormatString(GlobalData.GetSymbolFromDovizId(bankaHesabi.dovizCinsi.id), 5, HorizontalAlignment.Left) +
                ListBoxStringFormat.FormatString(bankaHesabi.IBAN, 30, HorizontalAlignment.Left);
            comboListBoxBankaHesaplari.RefreshListBox();
        }
        /// <summary>
        /// Firma kayıt formunu kapatır
        /// </summary>
        private void CloseForm(object sender, EventArgs e)
        {
            GetCurrentFirma();
            if (!GlobalData.CompareClass(firmaToSave,firmaToUpdate))
            {
                DialogResult dialogReault = MessageBox.Show("Yapılan değişiklikler kaydedilsin mi","Formdaki Değişiklikler",MessageBoxButtons.YesNoCancel);
                if(dialogReault == DialogResult.Yes)
                {
                    rButtonFirmaKaydet_Click(sender, e);
                }
                else
                {
                    GlobalData.CloseForm(ref _firmaKayitFormu);
                }
            }
            else
            {
                GlobalData.CloseForm(ref _firmaKayitFormu);
            }
        }
        /// <summary>
        /// Seçili banka hesabını siler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void buttonBankaHesabiSil_Click(object sender, EventArgs e)
        {
            BankaHesabi bankaHesabi=new BankaHesabi();
            bankaHesabi.hesapId = comboListBoxBankaHesaplari.selectedDataRowId;
            if (bankaHesabi.hesapId <= 0)
            {
                MessageBox.Show("Lütfen silmek istediğiniz banka hesabını seçiniz");
            }
            else
            {

                DialogResult dialogResult = MessageBox.Show(string.Format("{0} hesabını silmek istediğinizden emin misiniz",
                    comboListBoxBankaHesaplari.selectedDataRowValue), "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    var httpTask = WebMethods.DeleteBankaHesabi(bankaHesabi);
                    this.Enabled = false;
                    string result = await httpTask;
                    if (result.Length > 6 && result.Substring(0, 5) == "error")
                    {
                        MessageBox.Show(result);
                    }
                    else
                    {
                        MessageBox.Show("Silme İşlemi Başarılı");
                        comboListBoxBankaHesaplari.RemoveDataRow(bankaHesabi.hesapId);
                    }
                    this.Enabled = true;
                }
            }
        }
        /// <summary>
        /// Seçili personeli siler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPersonelSil_Click(object sender, EventArgs e)
        {
            Personel personel = new Personel(); ;
            personel.Id = comboListBoxYetililer.selectedDataRowId;
            if (personel.Id < 0)
            {
                MessageBox.Show("Lütfen silmek istediğiniz yetkiliyi seçiniz");
            }
            else
            {

                DialogResult dialogResult = MessageBox.Show(string.Format("{0} isimli yetkiliyi silmek istediğinizden emin misiniz",
                    comboListBoxYetililer.selectedDataRowValue), "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    string result = WebMethods.DeletePersonel(personel);
                    this.Enabled = false;
                    if (result.Length > 6 && result.Substring(0, 5) == "error")
                    {
                        MessageBox.Show(result);
                    }
                    else
                    {
                        MessageBox.Show("Silme İşlemi Başarılı");
                        comboListBoxYetililer.RemoveDataRow(personel.Id);
                    }
                    this.Enabled = true;
                }
            }
        }
        /// <summary>
        /// Firmaya bağlı personellerin listesinin yer aldığı grid formunu açar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPersonelGrid_Click(object sender, EventArgs e)
        {
            PersonelGridFormu personelGridFormu = PersonelGridFormu.personelGridFormu;
            if (personelGridFormu != null)
            {
                Personel personelFilter = new();
                personelFilter.firma.Id = firmaToUpdate.Id;
                personelGridFormu.FirmaMode(personelFilter);
                personelGridFormu.Show();
            }
        }
        /// <summary>
        /// Firmaya bağlı banka hesaplarının listesinin yer aldığı grid formunu açar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBankaHesabiGrid_Click(object sender, EventArgs e)
        {
            BankaHesabiGridFormu bankaHesabiGridFormu = BankaHesabiGridFormu.bankaHesabiGridFormu;
            if(bankaHesabiGridFormu != null)
            {
                bankaHesabiGridFormu.FirmaMode(firmaToUpdate.Id);
                bankaHesabiGridFormu.Show();
            }
        }

        private void buttomMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            CloseForm(sender,e);
        }
    }

    enum FirmaKayitMode
    {
        SaveMode = 0,
        UpdateMode = 1
    }
}
