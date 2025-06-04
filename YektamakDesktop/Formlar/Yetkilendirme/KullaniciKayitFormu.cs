using ApiService.Interfaces;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Utilities.Implementations;
using Utilities.Interfaces;
using YektamakDesktop.Common;

namespace YektamakDesktop.Formlar.Yetkilendirme
{
    public partial class KullaniciKayitFormu : Form, IForm
    {
        private static IKullaniciYetkiService _kullaniciYetkiService;
        private static IPasswordService _passwordService;
        private static ICache _cache;
        public KullaniciKayitFormu(IKullaniciYetkiService kullaniciYetkiService, IPasswordService passwordService, ICache cache)
        {
            _kullaniciYetkiService = kullaniciYetkiService;
            _passwordService = passwordService;
            _cache = cache;
        }
        private static KullaniciKayitFormu _kullaniciKayitFormu;
        public static KullaniciKayitFormu kullaniciKayitFormu
        {
            get
            {
                if (_kullaniciKayitFormu == null)
                {
                    _kullaniciKayitFormu = new KullaniciKayitFormu();
                    GlobalData.Yetki(ref _kullaniciKayitFormu);
                }
                return _kullaniciKayitFormu;
            }
            set
            {
                _kullaniciKayitFormu = value;
            }
        }
        private List<Control> _controlsToDisable;
        public List<Control> controlsToDisable { get => _controlsToDisable; set => _controlsToDisable = value; }
        private bool _activeForm;
        public bool activeForm { get => _activeForm; set => _activeForm = value; }
        private int _kullaniciId;
        public KullaniciKayitFormu()
        {
            InitializeComponent();
            //foreach (Personel personel in GlobalData.personelList)
            //{
            //    comboListBoxPersonel.AddDataRow(personel.Id, string.Concat(personel.ad, " ", personel.soyad));
            //}
            foreach (Rol rol in Enum.GetValues(typeof(Rol)))
            {
                comboListBoxRol.AddDataRow((int)rol, Enum.GetName(rol));
            }
            ComboBoxListFill.GetLookupAd(_cache.personelList, ref cbxPersonel);
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

        private void CloseForm()
        {
            kullaniciKayitFormu = null;
            this.Close();
            GlobalData.RemoveLastForm();
        }

        private void rButtonKullaniciKaydet_Click(object sender, EventArgs e)
        {
            if (!CheckFields()) return;
            GlobalData.HandleException(async () =>
            {
                string salt = GlobalData.GenerateSalt();
                string password = customTextBoxSifre.TextCustom;
                string kullaniciAdi = textBoxKullaniciAdi.TextCustom;
                //string hashedPassword = GlobalData.HashPassword(password, salt);
                string hashedPassword = _passwordService.HashPassword(password).CombinedHash;
                Kullanici kullanici = new Kullanici();
                kullanici.Id = _kullaniciId;
                kullanici.ad = kullaniciAdi;
                kullanici.sifre = hashedPassword;
                kullanici.salt = salt;
                kullanici.personel.Id = cbxPersonel.selectedDataRowId;
                kullanici.rolId = comboListBoxRol.selectedDataRowId;
                kullanici.isSifreDegisti = false;
                string httpResult = _kullaniciYetkiService.SaveKullanici(kullanici);
                if (httpResult.Contains("error", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show(httpResult);
                }
                else
                {
                    IMailHandler mailHandler = new MailHandler();
                    mailHandler.SendMail("cevdet.oguz@yektamak.com.tr", "şifre değişti", "");
                    MessageBox.Show("Kayıt başarılı");
                }

            });
        }

        private void roundedButton3_Click(object sender, EventArgs e)
        {
            CloseForm();
        }
        private void roundedButton1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private async void buttonFiltre_Click(object sender, EventArgs e)
        {
            Kullanici kullanici = new Kullanici();
            kullanici.ad = textBoxKullaniciAdi.TextCustom;
            kullanici.rolId = comboListBoxRol.selectedDataRowId == -1 ? 0 : comboListBoxRol.selectedDataRowId;
            int boslukIndex = cbxPersonel.selectedDataRowId == -1 ? 0 : cbxPersonel.selectedDataRowValue.IndexOf(' ');
            string personelAdi = cbxPersonel.selectedDataRowValue;
            kullanici.personel.ad = cbxPersonel.selectedDataRowId == -1 ? "" : personelAdi.Substring(0, boslukIndex);
            kullanici.personel.soyad = cbxPersonel.selectedDataRowId == -1 ? "" : personelAdi.Substring(boslukIndex + 1, personelAdi.Length - boslukIndex - 1);
            string result = _kullaniciYetkiService.GetKullanici(kullanici);
            byte[] bytes = JsonConvert.DeserializeObject<byte[]>(result);
            string json = Encoding.UTF8.GetString(bytes);
            DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(json);
            int i = 0;
            dataGridView1.Rows.Clear();
            foreach (DataRow dr in dataSet.Tables[0].Rows)
            {
                i = dataGridView1.Rows.Count;
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells["Id"].Value = int.Parse(dr["Id"].ToString());
                dataGridView1.Rows[i].Cells["ad"].Value = dr["ad"].ToString();
                dataGridView1.Rows[i].Cells["RolId"].Value = dr["RolId"].ToString();
                dataGridView1.Rows[i].Cells["RolAdi"].Value = dr["Rol"].ToString();
                dataGridView1.Rows[i].Cells["PersonelId"].Value = dr["PersonelId"].ToString();
                dataGridView1.Rows[i].Cells["PersonelAd"].Value = dr["PersonelAd"].ToString();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dataGridView1.Rows[e.RowIndex].Selected = true;
                _kullaniciId = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                textBoxKullaniciAdi.TextCustom = dataGridView1.Rows[e.RowIndex].Cells["ad"].Value.ToString();
                cbxPersonel.SelectDataRowId(int.Parse(dataGridView1.Rows[e.RowIndex].Cells["PersonelId"].Value.ToString()));
                comboListBoxRol.SelectDataRowId(int.Parse(dataGridView1.Rows[e.RowIndex].Cells["RolId"].Value.ToString()));
            }
        }
        private bool CheckFields()
        {
            labelUyariKulllaniciAdi.Text = "";
            labelUyariSifre.Text = "";
            labelUyariSifreTekrar.Text = "";
            labelUyariPersonel.Text = "";
            labelUyariRol.Text = "";
            bool result = true;
            if (string.IsNullOrWhiteSpace(textBoxKullaniciAdi.TextCustom))
            {
                result = false;
                labelUyariKulllaniciAdi.Text = "Kullanıcı adı girilmelidir!";
            }
            if (string.IsNullOrWhiteSpace(customTextBoxSifre.TextCustom))
            {
                result = false;
                labelUyariSifre.Text = "Şifre girilmelidir!";
            }
            if (customTextBoxSifre.TextCustom != customTextBoxSifreTekrar.TextCustom)
            {
                result = false;
                labelUyariSifreTekrar.Text = "Şifre uyuşmuyor!";
            }
            if (cbxPersonel.selectedDataRowId == -1)
            {
                result = false;
                labelUyariPersonel.Text = "Personel seçilmelidir!";
            }
            if (comboListBoxRol.selectedDataRowId == -1)
            {
                result = false;
                labelUyariRol.Text = "Rol seçilmelidir!";
            }
            return result;
        }
        private void ClearFields()
        {
            labelUyariKulllaniciAdi.Text = "";
            labelUyariSifre.Text = "";
            labelUyariSifreTekrar.Text = "";
            labelUyariPersonel.Text = "";
            labelUyariRol.Text = "";
            textBoxKullaniciAdi.TextCustom = "";
            customTextBoxSifre.TextCustom = "";
            customTextBoxSifreTekrar.TextCustom = "";
            cbxPersonel.SelectDataRowId(-1);
            comboListBoxRol.SelectDataRowId(-1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
    }
}
