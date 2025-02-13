using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Threading.Tasks;
using ApiService;

namespace YektamakDesktop.Formlar.Temp
{
    /// <summary>
    /// FirmaGridFormunun kopyasıdır. DataGrid pencereleri için bir template gibi değiştirilerek kullanılması için oluşturulmuştur.
    /// </summary>
    public partial class SatisSafhaGridForm : Form, IForm
    {
        private static SatisSafhaGridForm _templateGridFormu;
        public static SatisSafhaGridForm templateGridFormu
        {
            get
            {
                if (_templateGridFormu == null)
                {
                    _templateGridFormu = new SatisSafhaGridForm();
                    GlobalData.Yetki(ref _templateGridFormu);
                }
                return _templateGridFormu;
            }
        }
        private List<Control> _controlsToDisable;
        public List<Control> controlsToDisable { get => _controlsToDisable; set => _controlsToDisable = value; }
        private bool _activeForm;
        public bool activeForm { get => _activeForm; set => _activeForm = value; }

        /// <summary>
        /// dataSet ve grid içeriği aynı olmalı
        /// </summary>
        private DataSet dataSet;


        ToolTip buttonFiltreToolTip;
        public SatisSafhaGridForm()
        {
            InitializeComponent();
            SetToolTips();
            controlsToDisable = new List<Control>
            {
                buttonFiltre,
                buttonTumKayitlariGetir,
                dataGridViewFirma,
                rButtonCikis,
            };

        }
        /// <summary>
        /// Form kontrollerinin ToolTip ayarlarını yapar
        /// </summary>
        public void SetToolTips()
        {
            buttonFiltreToolTip = new ToolTip();
            buttonFiltreToolTip.ToolTipTitle = "Firma Filtreleme";
            buttonFiltreToolTip.SetToolTip(buttonFiltre, "Sol taraftaki ifadeleri içeren filtrelenmiş sonuçları getirir");
            buttonFiltreToolTip.ToolTipIcon = ToolTipIcon.Info;
            buttonFiltreToolTip.AutoPopDelay = 20000;
        }

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

        private void rButtonCikis_Click(object sender, EventArgs e)
        {
            GlobalData.RemoveLastForm();
            this.Close();
            _templateGridFormu = null;
        }

        private void buttonTumKayitlariGetir_Click(object sender, EventArgs e)
        {
            string result = WebMethods.GetFilteredFirma(new Firma());
            if (result.Length > 6 && result.Substring(0, 5) == "error")
            {
                MessageBox.Show(result);
            }
            else
            {
                try
                {
                    byte[] bytes = JsonConvert.DeserializeObject<byte[]>(result);
                    string json = Encoding.UTF8.GetString(bytes);
                    dataSet = JsonConvert.DeserializeObject<DataSet>(json);
                    //MessageBox.Show("DataRow Count : " + dataSet.Tables[0].Rows.Count.ToString());
                    //[PersonelId],[Ad],[Soyad],[Telefon],[Mail],[Pozisyon],[FirmaId] FROM[dbo].[Personel]
                    dataGridViewFirma.Rows.Clear();
                    for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                    {
                        DataGridViewRow dataGridRow = new DataGridViewRow();
                        dataGridRow.CreateCells(dataGridViewFirma);

                        dataGridRow.Cells[0].Value = dataSet.Tables[0].Rows[i][0].ToString();
                        dataGridRow.Cells[1].Value = dataSet.Tables[0].Rows[i]["Unvan"].ToString();
                        dataGridRow.Cells[2].Value = dataSet.Tables[0].Rows[i]["VergiDairesi"].ToString();
                        dataGridRow.Cells[3].Value = dataSet.Tables[0].Rows[i]["Sehir"].ToString();
                        int sektor1, sektor2, sektor3, sektor4, sektor5;
                        sektor1 = int.Parse(dataSet.Tables[0].Rows[i]["Sektor1"].ToString());
                        sektor2 = int.Parse(dataSet.Tables[0].Rows[i]["Sektor2"].ToString());
                        sektor3 = int.Parse(dataSet.Tables[0].Rows[i]["Sektor3"].ToString());
                        sektor4 = int.Parse(dataSet.Tables[0].Rows[i]["Sektor4"].ToString());
                        sektor5 = int.Parse(dataSet.Tables[0].Rows[i]["Sektor5"].ToString());
                        string sektorler = "";
                        if (sektor1 != 0)
                        {
                            //sektorler += GlobalData.sektorList.Find(x => x.Id == sektor1).ad;
                            //if (sektor2 != 0)
                            //{
                            //    sektorler += " & " + GlobalData.sektorList.Find(x => x.Id == sektor2).ad;
                            //    if (sektor3 != 0)
                            //    {
                            //        sektorler += " & " + GlobalData.sektorList.Find(x => x.Id == sektor3).ad;
                            //        if (sektor4 != 0)
                            //        {
                            //            sektorler += " & " + GlobalData.sektorList.Find(x => x.Id == sektor4).ad;
                            //            if (sektor5 != 0)
                            //            {
                            //                sektorler += " & " + GlobalData.sektorList.Find(x => x.Id == sektor5).ad;
                            //            }
                            //        }
                            //    }
                            //}
                        }
                        dataGridRow.Cells[4].Value = sektorler;

                        dataGridViewFirma.Rows.Add(dataGridRow);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dataGridViewFirma_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (dataSet == null || e.RowIndex < 0) return;
            if (e.ColumnIndex == 5 && e.RowIndex >= 0 && e.RowIndex < dataSet.Tables[0].Rows.Count)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                float r1 = (float)Properties.Resources.update_icon.Width / Properties.Resources.update_icon.Height;
                float r2 = (float)e.CellBounds.Width / e.CellBounds.Height;
                int w = e.CellBounds.Width;
                int h = e.CellBounds.Height;
                if (r1 > r2)
                {
                    w = e.CellBounds.Width;
                    h = (int)(w / r1);
                }
                else if (r1 < r2)
                {
                    h = e.CellBounds.Height;
                    w = (int)(r1 * h);
                }
                int x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                int y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;
                e.Graphics.DrawImage(Properties.Resources.update_icon, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
            else if (e.ColumnIndex == 6 && e.RowIndex >= 0 && e.RowIndex < dataSet.Tables[0].Rows.Count)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                float r1 = (float)Properties.Resources.delete_icon.Width / Properties.Resources.delete_icon.Height;
                float r2 = (float)e.CellBounds.Width / e.CellBounds.Height;
                int w = e.CellBounds.Width;
                int h = e.CellBounds.Height;
                if (r1 > r2)
                {
                    w = e.CellBounds.Width;
                    h = (int)(w / r1);
                }
                else if (r1 < r2)
                {
                    h = e.CellBounds.Height;
                    w = (int)(r1 * h);
                }
                int x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                int y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;
                e.Graphics.DrawImage(Properties.Resources.delete_icon, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private async Task FirmaDelete(Firma firma)
        {
            DialogResult dialogResult = MessageBox.Show(string.Format("{0} firmasını silmek istediğinizden emin misiniz", firma.ad), "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                var httpTask = WebMethods.DeleteFirma(firma);
                this.Enabled = false;
                string result = httpTask;
                if (result.Length > 6 && result.Substring(0, 5) == "error")
                {
                    MessageBox.Show(result);
                }
                else
                {
                    MessageBox.Show("Silme İşlemi Başarılı");
                    //Console.WriteLine("FirmaSil result : " + result);
                    //Grid'de kullandığımız datasetten de silip gridi güncelleyelim
                    int dataSetIndex = IndexOfDataSetRow(firma.Id);
                    dataSet.Tables[0].Rows.RemoveAt(dataSetIndex);
                    int dataGridViewIndex = IndexOfGridRow(firma.Id);
                    dataGridViewFirma.Rows.RemoveAt(dataGridViewIndex);
                }
                this.Enabled = true;
            }
        }

        private void dataGridViewFirma_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataSet == null || e.RowIndex < 0) return;
            if (e.RowIndex >= dataSet.Tables[0].Rows.Count) return;
            if (e.ColumnIndex == 5 || e.ColumnIndex == 6)
            {

                if (dataGridViewFirma.Rows[e.RowIndex].Cells[0].Value == null)
                    return;

                Firma firma = new Firma();
                int firmaId = int.Parse(dataGridViewFirma.Rows[e.RowIndex].Cells[0].Value.ToString());
                int dataSetIndex = IndexOfDataSetRow(firmaId);
                firma.Id = firmaId;
                firma.ad = dataSet.Tables[0].Rows[dataSetIndex]["Unvan"].ToString();
                firma.vergiDairesi = dataSet.Tables[0].Rows[dataSetIndex]["VergiDairesi"].ToString();
                firma.vergiNumarasi = dataSet.Tables[0].Rows[dataSetIndex]["VergiNumarasi"].ToString();
                firma.adres = new Adres();
                firma.adres.ulke = dataSet.Tables[0].Rows[dataSetIndex]["Ulke"].ToString();
                firma.adres.sehir = dataSet.Tables[0].Rows[dataSetIndex]["Sehir"].ToString();
                firma.adres.postaKodu = dataSet.Tables[0].Rows[dataSetIndex]["PostaKodu"].ToString();
                firma.adres.acikAdres = dataSet.Tables[0].Rows[dataSetIndex]["AcikAdres"].ToString();
                firma.sektorIdList = new List<Sektor>();
                Sektor sektor1 = new Sektor { Id = int.Parse(dataSet.Tables[0].Rows[dataSetIndex]["Sektor1"].ToString()) };
                if (sektor1.Id > 0)
                {
                    firma.sektorIdList.Add(sektor1);
					Sektor sektor2 = new Sektor { Id = int.Parse(dataSet.Tables[0].Rows[dataSetIndex]["Sektor2"].ToString()) };
                    if (sektor2.Id > 0)
                    {
                        firma.sektorIdList.Add(sektor2);
						Sektor sektor3 = new Sektor { Id = int.Parse(dataSet.Tables[0].Rows[dataSetIndex]["Sektor3"].ToString()) };
                        if (sektor3.Id > 0)
                        {
                            firma.sektorIdList.Add(sektor3);
							Sektor sektor4 = new Sektor { Id = int.Parse(dataSet.Tables[0].Rows[dataSetIndex]["Sektor4"].ToString()) };
                            if (sektor4.Id > 0)
                            {
                                firma.sektorIdList.Add(sektor4);
								Sektor sektor5 = new Sektor { Id = int.Parse(dataSet.Tables[0].Rows[dataSetIndex]["Sektor5"].ToString()) };
                                if (sektor5.Id > 0)
                                {
                                    firma.sektorIdList.Add(sektor5);
                                }
                            }
                        }
                    }
                }
                
                if (e.ColumnIndex == 5)//Update
                {
                    UpdateFirmaForm(firma);
                }
                else if (e.ColumnIndex == 6)//Delete
                {
                    FirmaDelete(firma);
                }
            }
        }

        /// <summary>
        /// Kayıt Formunu Update modunda çalıştıran metod
        /// </summary>
        /// <param name="firma"></param>
        private void UpdateFirmaForm(Firma firma)
        {



        }

        /// <summary>
        /// FirmaKayıtFormu tarafından yeni bir firma eklendiğinde çağırılarak dataset ve grid'e yeni firma ekler
        /// </summary>
        /// <param name="firma"></param>
        public void AddNewFirmaOnGrid(Firma firma)
        {
            #region AddToDataSet
            DataRow newFirmaDataRow = dataSet.Tables[0].Rows.Add();
            newFirmaDataRow["FirmaId"] = firma.Id;
            newFirmaDataRow["Unvan"] = firma.ad;
            newFirmaDataRow["VergiDairesi"] = firma.vergiDairesi;
            newFirmaDataRow["VergiNumarasi"] = firma.vergiNumarasi;
            if (firma.adres != null)
            {
                newFirmaDataRow["Ulke"] = firma.adres.ulke;
                newFirmaDataRow["Sehir"] = firma.adres.sehir;
                newFirmaDataRow["PostaKodu"] = firma.adres.postaKodu;
                newFirmaDataRow["AcikAdres"] = firma.adres.acikAdres;
            }

            if (firma.sektorIdList.Count > 0)
            {
                for (int i = 0; i < firma.sektorIdList.Count; i++)
                {
                    newFirmaDataRow["Sektor" + (i + 1).ToString()] = firma.sektorIdList[i];
                }
            }

            #endregion AddToDataSet

            #region AddToDataGridView
            DataGridViewRow dataGridRow = new DataGridViewRow();
            dataGridRow.CreateCells(dataGridViewFirma);

            dataGridRow.Cells[0].Value = firma.Id;
            dataGridRow.Cells[1].Value = firma.ad;
            dataGridRow.Cells[2].Value = firma.vergiDairesi;
            if (firma.adres != null)
            {
                dataGridRow.Cells[3].Value = firma.adres.sehir;
            }
            string sektorler = "";
            for (int i = 0; i < firma.sektorIdList.Count; i++)
            {
                if (firma.sektorIdList[i].Id == 0)
                {
                    break;
                }
                //sektorler += GlobalData.GetSektorNameFromId(firma.sektorIdList[i].Id);
                if (i < firma.sektorIdList.Count - 1)
                {
                    sektorler += " & ";
                }
            }
            dataGridRow.Cells[3].Value = sektorler;

            dataGridViewFirma.Rows.Add(dataGridRow);

            #endregion AddToDataGridView

        }

        /// <summary>
        /// Veritabanında güncellenen firmayı dataset ve gridde de günceller
        /// </summary>
        /// <param name="firma"></param>
        public void UpdateFirmaOnGrid(Firma firma)
        {
            #region UpdateDataSet
            int dataSetIndex = IndexOfDataSetRow(firma.Id);

            dataSet.Tables[0].Rows[dataSetIndex]["Unvan"] = firma.ad;
            dataSet.Tables[0].Rows[dataSetIndex]["VergiDairesi"] = firma.vergiDairesi;
            dataSet.Tables[0].Rows[dataSetIndex]["VergiNumarasi"] = firma.vergiNumarasi;
            if (firma.adres != null)
            {
                dataSet.Tables[0].Rows[dataSetIndex]["Ulke"] = firma.adres.ulke;
                dataSet.Tables[0].Rows[dataSetIndex]["Sehir"] = firma.adres.sehir;
                dataSet.Tables[0].Rows[dataSetIndex]["PostaKodu"] = firma.adres.postaKodu;
                dataSet.Tables[0].Rows[dataSetIndex]["AcikAdres"] = firma.adres.acikAdres;
            }
            if (firma.sektorIdList.Count > 0)
            {
                for (int i = 0; i < firma.sektorIdList.Count; i++)
                {
                    dataSet.Tables[0].Rows[dataSetIndex]["Sektor" + (i + 1).ToString()] = firma.sektorIdList[i];
                }
            }

            //FirmaData'yı özellikle ihmal ediyoruz. İleride tamamen kaldıracağız

            #endregion UpdateDataSet

            #region UpdateDataGridView

            int dataGridRowIndex = IndexOfGridRow(firma.Id);
            //Console.WriteLine($"dataGridRowIndex : {dataGridRowIndex.ToString()}");
            dataGridViewFirma.Rows[dataGridRowIndex].Cells[1].Value = firma.ad;
            dataGridViewFirma.Rows[dataGridRowIndex].Cells[2].Value = firma.vergiDairesi;
            dataGridViewFirma.Rows[dataGridRowIndex].Cells[3].Value = firma.adres != null ? firma.adres.sehir : string.Empty;
            string sektorler = "";
            for (int i = 0; i < firma.sektorIdList.Count; i++)
            {
                if (firma.sektorIdList[i].Id == 0)
                {
                    break;
                }
                if (i > 0)
                {
                    sektorler += " & ";
                }
                //sektorler += GlobalData.GetSektorNameFromId(firma.sektorIdList[i].Id);
            }
            dataGridViewFirma.Rows[dataGridRowIndex].Cells[4].Value = sektorler;
            #endregion UpdateDataGridView
        }

        private void buttonKayitEkle_Click(object sender, EventArgs e)
        {

        }

        public int IndexOfGridRow(int id)
        {
            int index = -1;
            if (dataSet != null)
            {
                if (dataGridViewFirma.Rows.Count > 0)
                {
                    //Console.WriteLine($"dataGridViewFirma.Rows[0].Cells[1].Value : {dataGridViewFirma.Rows[0].Cells[1].Value.ToString()}");
                    for (int i = 0; i < dataGridViewFirma.Rows.Count; i++)
                    {
                        if (id == int.Parse(dataGridViewFirma.Rows[i].Cells[0].Value.ToString()))
                        {
                            return i;
                        }
                    }
                }
            }
            return index;
        }
        public int IndexOfDataSetRow(int id)
        {
            int index = -1;
            if (dataSet != null)
            {
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    if (int.Parse(dataSet.Tables[0].Rows[i][0].ToString()) == id)
                    {
                        return i;
                    }
                }
            }
            return index;
        }

        private async void buttonFiltre_Click(object sender, EventArgs e)
        {
            FiltreFirma filtreFirma = new FiltreFirma();


            var httpTask = WebMethods.FiltrelenmisFirmalar(filtreFirma);
            this.Enabled = false;
            string result = await httpTask;
            this.Enabled = true;
            if (result.Length > 6 && result.Substring(0, 5) == "error")
            {
                MessageBox.Show(result);
            }
            else
            {
                try
                {
                    byte[] bytes = JsonConvert.DeserializeObject<byte[]>(result);
                    string json = Encoding.UTF8.GetString(bytes);
                    dataSet = JsonConvert.DeserializeObject<DataSet>(json);
                    //MessageBox.Show("DataRow Count : " + dataSet.Tables[0].Rows.Count.ToString());
                    //[PersonelId],[Ad],[Soyad],[Telefon],[Mail],[Pozisyon],[FirmaId] FROM[dbo].[Personel]
                    dataGridViewFirma.Rows.Clear();
                    for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                    {
                        DataGridViewRow dataGridRow = new DataGridViewRow();
                        dataGridRow.CreateCells(dataGridViewFirma);

                        dataGridRow.Cells[0].Value = dataSet.Tables[0].Rows[i][0].ToString();
                        dataGridRow.Cells[1].Value = dataSet.Tables[0].Rows[i]["Unvan"].ToString();
                        dataGridRow.Cells[2].Value = dataSet.Tables[0].Rows[i]["VergiDairesi"].ToString();
                        dataGridRow.Cells[3].Value = dataSet.Tables[0].Rows[i]["Sehir"].ToString();
                        int sektor1, sektor2, sektor3, sektor4, sektor5;
                        sektor1 = int.Parse(dataSet.Tables[0].Rows[i]["Sektor1"].ToString());
                        sektor2 = int.Parse(dataSet.Tables[0].Rows[i]["Sektor2"].ToString());
                        sektor3 = int.Parse(dataSet.Tables[0].Rows[i]["Sektor3"].ToString());
                        sektor4 = int.Parse(dataSet.Tables[0].Rows[i]["Sektor4"].ToString());
                        sektor5 = int.Parse(dataSet.Tables[0].Rows[i]["Sektor5"].ToString());
                        string sektorler = "";
                        if (sektor1 != 0)
                        {
                            //sektorler += GlobalData.sektorList.Find(x => x.Id == sektor1).ad;
                            //if (sektor2 != 0)
                            //{
                            //    sektorler += " & " + GlobalData.sektorList.Find(x => x.Id == sektor2).ad;
                            //    if (sektor3 != 0)
                            //    {
                            //        sektorler += " & " + GlobalData.sektorList.Find(x => x.Id == sektor3).ad;
                            //        if (sektor4 != 0)
                            //        {
                            //            sektorler += " & " + GlobalData.sektorList.Find(x => x.Id == sektor4).ad;
                            //            if (sektor5 != 0)
                            //            {
                            //                sektorler += " & " + GlobalData.sektorList.Find(x => x.Id == sektor5).ad;
                            //            }
                            //        }
                            //    }
                            //}
                        }
                        dataGridRow.Cells[4].Value = sektorler;

                        dataGridViewFirma.Rows.Add(dataGridRow);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }
        private void CloseForm()
        {
            this.Close();
            GlobalData.RemoveLastForm();
            _templateGridFormu = null;
        }
    }
}