using Models;
using Newtonsoft.Json;
using ApiService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace YektamakDesktop.Formlar.Finans
{
    public partial class TaksitliOdemeKayitFormu : Form, IForm
    {
        private static TaksitliOdemeKayitFormu _taksitliOdemeKayitFormu;
        public static TaksitliOdemeKayitFormu taksitliOdemeKayitFormu
        {
            get
            {
                if (_taksitliOdemeKayitFormu == null)
                {
                    _taksitliOdemeKayitFormu = new TaksitliOdemeKayitFormu();
                    GlobalData.Yetki(ref _taksitliOdemeKayitFormu);
                }
                return _taksitliOdemeKayitFormu;
            }
        }
        private bool _activeForm;
        public bool activeForm
        {
            get
            {
                return _activeForm;
            }
            set
            {
                _activeForm = value;
            }
        }
        private List<Control> _controlsToDisable;
        public List<Control> controlsToDisable
        {
            get
            {
                return _controlsToDisable;
            }
            set
            {
                _controlsToDisable = value;
            }
        }
        private int _taksitliOdemeId;
        private int _cariId;
        private List<TaksitOdemesi> _taksitOdemesiList;
        private TaksitliOdeme _taksitliOdemeToUpdate;
        private TaksitliOdeme taksitliOdemeToUpdate
        {
            get => _taksitliOdemeToUpdate; set => _taksitliOdemeToUpdate = value;
        }
        public TaksitliOdemeKayitFormu()
        {
            InitializeComponent();
            controlsToDisable = new List<Control>
            {
                rButtonGuncelle,
                rButtonKapat,
                rButtonKaydet,
                radioButtonKrediKartiTaksidi,
                radioButtonKrediTaksidi,
                customComboListBoxCariId,
                customComboListBoxToplamTutarDovizId,
                customTextBoxOdemeTanimi,
                customTextBoxSonOdemeTarihi,
                customTextBoxToplamTutar,
                customTextBoxIslemTarihi,
                customTextBoxTaksitTutari
            };
            //foreach (DovizCinsi dovizCinsi in GlobalData.dovizList)
            //{
            //    customComboListBoxTaksitDovizId.AddDataRow(dovizCinsi.id, dovizCinsi.sembol);
            //    customComboListBoxToplamTutarDovizId.AddDataRow(dovizCinsi.id, dovizCinsi.sembol);
            //}
            customComboListBoxTaksitDovizId.SelectDataRowId(1);
            customComboListBoxToplamTutarDovizId.SelectDataRowId(1);
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
        private void rButtonOtomatikTaksitlendir_Click(object sender, EventArgs e)
        {
            rButtonKaydet_Click(null, null);
            if (taksitliOdemeToUpdate != null)
            {
                TaksitliIslemOtomatikTaksitlendirme taksitliIslemOtomatikTaksitlendirme = TaksitliIslemOtomatikTaksitlendirme.taksitliIslemOtomatikTaksitlendirme;
                if(taksitliIslemOtomatikTaksitlendirme != null)
                {
                    taksitliIslemOtomatikTaksitlendirme.Show();
                    taksitliIslemOtomatikTaksitlendirme.UpdateMode(taksitliOdemeToUpdate);
                }
            }
        }

        private void rButtonKapat_Click(object sender, EventArgs e)
        {
            CloseForm();
        }
        private void CloseForm()
        {
            this.Close();
            GlobalData.RemoveLastForm();
            _taksitliOdemeKayitFormu = null;
        }

        private void rButtonTaksitEkle_Click(object sender, EventArgs e)
        {
            int taksitAdedi = dataGridViewTaksitOdemesi.RowCount + 1;
            DataGridViewRow row = new DataGridViewRow();
            DataGridViewCell[] cells = new DataGridViewCell[8];
            for (int i = 0; i < 8; i++)
            {
                cells[i] = new DataGridViewTextBoxCell();
                row.Cells.Add(cells[i]);
            }
            cells[0].Value = 0;
            cells[1].Value = _taksitliOdemeId;
            cells[2].Value = taksitAdedi;
            cells[3].Value = DateTime.Parse(customTextBoxSonOdemeTarihi.TextCustom.ToString());
            cells[4].Value = float.Parse(customTextBoxTaksitTutari.TextCustom.ToString());
            cells[5].Value = customComboListBoxTaksitDovizId.selectedDataRowId;
            cells[6].Value = customComboListBoxTaksitDovizId.selectedDataRowValue.ToString();
            cells[7].Value = customTextBoxAciklama.TextCustom.ToString();
            dataGridViewTaksitOdemesi.Rows.Add(row);
        }

        private async void rButtonKaydet_Click(object sender, EventArgs e)
        {
            //taksitliOdemeToUpdate = GetTaksitliOdeme();
            //if (taksitliOdemeToUpdate != null)
            //{
            //    string httpResult = await WebMethods.SaveTaksitliOdeme(taksitliOdemeToUpdate, _taksitOdemesiList);
            //    if (httpResult.Substring(0, 5).Equals("error", StringComparison.OrdinalIgnoreCase))
            //    {
            //        MessageBox.Show(httpResult);
            //    }
            //    else
            //    {
            //        byte[] bytes = JsonConvert.DeserializeObject<byte[]>(httpResult);
            //        string data = Encoding.UTF8.GetString(bytes);
            //        DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(data);
            //        DataRow dr = dataSet.Tables[0].Rows[0];
            //        taksitliOdemeToUpdate.taksitliOdemeId = int.Parse(dr["TaksitliOdemeId"].ToString());
            //        taksitliOdemeToUpdate.cari.cariKartId = int.Parse(dr["CariId"].ToString());
            //        taksitliOdemeToUpdate.toplamTutar.tutar = float.Parse(dr["ToplamTutar"].ToString());
            //        taksitliOdemeToUpdate.toplamTutar.dovizCinsi.id = int.Parse(dr["DovizId"].ToString());
            //        UpdateMode(taksitliOdemeToUpdate, _taksitOdemesiList);
            //        if (sender != null) //Komut kaydet butonundan tetiklenmişse bu kod bloğu çalışacak.
            //        {
            //            MessageBox.Show("Kayıt başarılı");
            //            CloseForm();
            //        }
            //    }
            //}
        }
        private TaksitliOdeme GetTaksitliOdeme()
        {
            if (!CheckFields()) return null;
            _taksitOdemesiList = new List<TaksitOdemesi>();
            for (int i = 0; i < dataGridViewTaksitOdemesi.RowCount; i++)
            {
                TaksitOdemesi taksitOdemesi = new TaksitOdemesi();
                taksitOdemesi.taksitliOdemeId = _taksitliOdemeId;
                taksitOdemesi.taksitNo = int.Parse(dataGridViewTaksitOdemesi.Rows[i].Cells["taksitNo"].Value.ToString());
                taksitOdemesi.tutar = new Tutar();
                taksitOdemesi.tutar.tutar = float.Parse(dataGridViewTaksitOdemesi.Rows[i].Cells["tutar"].Value.ToString());
                taksitOdemesi.tutar.dovizCinsi.id = int.Parse(dataGridViewTaksitOdemesi.Rows[i].Cells["dovizId"].Value.ToString());
                taksitOdemesi.sonOdemeTarihi = DateTime.Parse(dataGridViewTaksitOdemesi.Rows[i].Cells["sonOdemeTarihi"].Value.ToString());
                taksitOdemesi.aciklama = dataGridViewTaksitOdemesi.Rows[i].Cells["aciklama"].Value?.ToString() ?? string.Empty;
                _taksitOdemesiList.Add(taksitOdemesi);
            }
            TaksitliOdeme taksitliOdeme = new TaksitliOdeme();
            taksitliOdeme.taksitliOdemeId = _taksitliOdemeId;
            taksitliOdeme.odemeTanimi = customTextBoxOdemeTanimi.TextCustom.ToString();
            taksitliOdeme.islemTarihi = DateTime.Parse(customTextBoxIslemTarihi.TextCustom.ToString());
            taksitliOdeme.cari = new CariKart();
            taksitliOdeme.cari.cariKartId = customComboListBoxCariId.selectedDataRowId;
            taksitliOdeme.toplamTutar = new Tutar();
            taksitliOdeme.toplamTutar.tutar = float.Parse(customTextBoxToplamTutar.TextCustom.ToString());
            taksitliOdeme.toplamTutar.dovizCinsi.id = customComboListBoxToplamTutarDovizId.selectedDataRowId;
            taksitliOdeme.odemeTanimi = customTextBoxOdemeTanimi.TextCustom.ToString();
            taksitliOdeme.taksitliOdemeTuru = (radioButtonKrediKartiTaksidi.Checked == true) ? TaksitliOdemeTuru.KREDIKARTI : TaksitliOdemeTuru.KREDI;
            return taksitliOdeme;

        }
        private bool CheckFields()
        {
            bool returnValue = true;
            if (string.IsNullOrWhiteSpace(customTextBoxOdemeTanimi.TextCustom))
            {
                labelUyariOdemeTanimi.Text = "* Ödeme tanımı alanı doldurulmalıdır.";
                returnValue = false;
            }
            else { labelUyariOdemeTanimi.Text = string.Empty; }
            if (customComboListBoxCariId.selectedDataRowId == -1)
            {
                labelUyariCariId.Text = "* Cari kart seçimi yapılmalıdır.";
                returnValue = false;
            }
            else { labelUyariCariId.Text = string.Empty; }
            if (string.IsNullOrWhiteSpace(customTextBoxToplamTutar.TextCustom) || customTextBoxToplamTutar.TextCustom == "0")
            {
                labelUyariToplamTutar.Text = "* Toplam Tutar alanı doldurulmalıdır.";
                returnValue = false;
            }
            else { labelUyariToplamTutar.Text = string.Empty; }
            if (radioButtonKrediKartiTaksidi.Checked == false && radioButtonKrediTaksidi.Checked == false)
            {
                labelUyariTaksitliOdemeTuru.Text = "* Taksitli ödeme türü seçimi yapılmaldır.";
                returnValue = false;
            }
            else { labelUyariTaksitliOdemeTuru.Text = string.Empty; }
            if (string.IsNullOrWhiteSpace(customTextBoxIslemTarihi.TextCustom))
            {
                labelUyariIslemTarihi.Text = "* İşlem Tarihi alanı doldurulmalıdır.";
                returnValue = false;
            }
            else { labelUyariIslemTarihi.Text = string.Empty; }
            return returnValue;
        }
        public void SaveMode(TaksitliOdeme taksitliOdeme)
        {
            taksitliOdemeToUpdate = taksitliOdeme;
            _cariId = taksitliOdeme.cari.cariKartId;
            customTextBoxToplamTutar.TextCustom = taksitliOdeme.toplamTutar.tutar.ToString();
            customTextBoxIslemTarihi.TextCustom = taksitliOdeme.islemTarihi.ToShortDateString();
            customComboListBoxToplamTutarDovizId.SelectDataRowId(taksitliOdeme.toplamTutar.dovizCinsi.id);
            customTextBoxIslemTarihi.TextCustom = taksitliOdeme.islemTarihi.ToShortDateString();
            if (taksitliOdeme.taksitliOdemeTuru == TaksitliOdemeTuru.KREDIKARTI)
            {
                radioButtonKrediKartiTaksidi.Checked = true;
            }
            else
            {
                radioButtonKrediTaksidi.Checked = true;
            }
            customComboListBoxCariId.SelectDataRowId(taksitliOdeme.cari.cariKartId);
        }
        public void UpdateMode(TaksitliOdeme taksitliOdeme, List<TaksitOdemesi> taksitOdemesiList = null)
        {
            taksitliOdemeToUpdate = taksitliOdeme;
            _taksitliOdemeId = taksitliOdeme.taksitliOdemeId;
            customTextBoxOdemeTanimi.TextCustom = taksitliOdeme.odemeTanimi.ToString();
            _cariId = taksitliOdeme.cari.cariKartId;
            customTextBoxToplamTutar.TextCustom = taksitliOdeme.toplamTutar.tutar.ToString();
            customComboListBoxToplamTutarDovizId.SelectDataRowId(taksitliOdeme.toplamTutar.dovizCinsi.id);
            customTextBoxIslemTarihi.TextCustom = taksitliOdeme.islemTarihi.ToShortDateString();
            if (taksitliOdeme.taksitliOdemeTuru == TaksitliOdemeTuru.KREDIKARTI)
            {
                radioButtonKrediKartiTaksidi.Checked = true;
            }
            else
            {
                radioButtonKrediTaksidi.Checked = true;
            }
            dataGridViewTaksitOdemesi.Rows.Clear();
            foreach (TaksitOdemesi taksitOdemesi in taksitOdemesiList)
            {
                DataGridViewRow row = new DataGridViewRow();
                DataGridViewCell[] cells = new DataGridViewCell[8];

                for (int i = 0; i < 8; i++)
                {
                    cells[i] = new DataGridViewTextBoxCell();
                    row.Cells.Add(cells[i]);
                }

                cells[0].Value = taksitOdemesi.taksitOdemesiId;
                cells[1].Value = taksitOdemesi.taksitliOdemeId;
                cells[2].Value = taksitOdemesi.taksitNo;
                cells[3].Value = taksitOdemesi.sonOdemeTarihi.ToShortDateString();
                cells[4].Value = taksitOdemesi.tutar.tutar;
                cells[5].Value = taksitOdemesi.tutar.dovizCinsi.id;
                //cells[6].Value = GlobalData.dovizList.Find(x => x.id == taksitOdemesi.tutar.dovizCinsi.id).sembol;
                cells[7].Value = taksitOdemesi.aciklama;

                dataGridViewTaksitOdemesi.Rows.Add(row);
            }
        }

        private void TaksitliIslemKayitFormu_Load(object sender, EventArgs e)
        {
            Opacity = 0;
            CariKart cariKart = new CariKart();
            string httpResult = WebMethods.GetFilteredCariKartlar(cariKart);
            byte[] bytes = JsonConvert.DeserializeObject<byte[]>(httpResult);
            string data = Encoding.UTF8.GetString(bytes);
            DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(data);
            foreach (DataRow dr in dataSet.Tables[0].Rows)
            {
                customComboListBoxCariId.AddDataRow(int.Parse(dr["CariKartId"].ToString()), dr["CariAdi"].ToString());
            }
            customComboListBoxCariId.SelectDataRowId(_cariId);
            Opacity = 1;
        }

        public void Taksitlendir(List<TaksitOdemesi> taksitOdemesiList)
        {
            dataGridViewTaksitOdemesi.Rows.Clear();
            foreach (TaksitOdemesi taksitOdemesi in taksitOdemesiList)
            {
                DataGridViewRow row = new DataGridViewRow();
                DataGridViewCell[] cells = new DataGridViewCell[8];

                for (int i = 0; i < 8; i++)
                {
                    cells[i] = new DataGridViewTextBoxCell();
                    row.Cells.Add(cells[i]);
                }

                cells[0].Value = taksitOdemesi.taksitOdemesiId;
                cells[1].Value = taksitOdemesi.taksitliOdemeId;
                cells[2].Value = taksitOdemesi.taksitNo;
                cells[3].Value = taksitOdemesi.sonOdemeTarihi.ToShortDateString();
                cells[4].Value = taksitOdemesi.tutar.tutar;
                cells[5].Value = taksitOdemesi.tutar.dovizCinsi.id;
                //cells[6].Value = GlobalData.dovizList.Find(x => x.id == taksitOdemesi.tutar.dovizCinsi.id).sembol;
                cells[7].Value = taksitOdemesi.aciklama;

                dataGridViewTaksitOdemesi.Rows.Add(row);
            }
        }

        private void dataGridViewTaksitOdemesi_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            float girilenTaksitToplami = float.TryParse(customTextBoxGirilenTaksitToplami.TextCustom, out float result) ? result : 0;
            float taksit = float.Parse(dataGridViewTaksitOdemesi.Rows[e.RowIndex].Cells["tutar"].Value.ToString());
            girilenTaksitToplami = girilenTaksitToplami + taksit;
            customTextBoxGirilenTaksitToplami.TextCustom = girilenTaksitToplami.ToString("N2");
        }

        private void customTextBoxGirilenTaksitToplami_TextChanged(object sender, EventArgs e)
        {
            float toplamTutar = float.TryParse(customTextBoxToplamTutar.TextCustom.ToString(), out float resultToplamTutar) ? resultToplamTutar : 0;
            float girilenTaksitToplami = float.TryParse(customTextBoxGirilenTaksitToplami.TextCustom.ToString(), out float resultTaksitToplami) ? resultTaksitToplami : 0;
            customTextBoxGirilecekTaksitToplami.TextCustom = (toplamTutar - girilenTaksitToplami).ToString("N2");
        }
        private float GirilenTaksitToplami()
        {
            float girilenTaksitToplami = 0;
            foreach (DataGridViewRow row in dataGridViewTaksitOdemesi.Rows)
            {
                girilenTaksitToplami = girilenTaksitToplami + float.Parse(row.Cells["tutar"].Value.ToString());
            }
            return girilenTaksitToplami;
        }

        private void dataGridViewTaksitOdemesi_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            customTextBoxGirilenTaksitToplami.TextCustom = GirilenTaksitToplami().ToString("N2");
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void buttomMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
