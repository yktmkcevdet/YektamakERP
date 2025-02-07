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
using System.Globalization;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.VisualBasic.Devices;
using Newtonsoft.Json.Linq;
using System.Linq;
using YektamakDesktop.CustomControls;
using YektamakDesktop.Formlar.Ortak;
using ApiService;

namespace YektamakDesktop.Formlar.Satis
{
    public partial class ProjeSafhaGridForm : Form, IForm
    {
        private WebMethods _webMethods;
        private static ProjeSafhaGridForm _satisProjeSafhaGridForm;
        public static ProjeSafhaGridForm projeSafhaGridForm
        {
            get
            {
                if (_satisProjeSafhaGridForm == null)
                {
                    _satisProjeSafhaGridForm = new ProjeSafhaGridForm();
                    GlobalData.Yetki(ref _satisProjeSafhaGridForm);
                }
                return _satisProjeSafhaGridForm;
            }
        }
        private List<Control> _controlsToDisable;
        public List<Control> controlsToDisable { get => _controlsToDisable; set => _controlsToDisable = value; }

        /// <summary>
        /// CheckFields metodu çalıştığında hatalı kayıt olan satırların yanına eklenen uyarı label'larını tutar.
        /// </summary>
        private List<Control> warningLabels;

        private bool _activeForm;
        public bool activeForm { get => _activeForm; set => _activeForm = value; }
        /// <summary>
        /// dataSet ve grid içeriği aynı olmalı
        /// </summary>
        private DataSet dataSet;
        private DateTime selectedDate;
        private DataGridViewCell selectedDataGridViewCell;
        private List<ProjeSafha> satisProjeSafhaList;

        public int _projeId;
        ToolTip buttonVarsayilanProjeAsamalariToolTip;
        ToolTip buttonSafhaEkleToolTip;
        private ProjeSafhaGridForm()
        {
            InitializeComponent();
            SetToolTips();
            monthCalendar.Visible = false;
            controlsToDisable = new List<Control>
            {
                buttonSafhaEkle,
                dataGridViewSatisProjeSafha,
                rButtonCikis,
                rButtonKaydet
            };

        }

        public ProjeSafhaGridForm(WebMethods webMethods)
        {
            _webMethods = webMethods;
        }

        /// <summary>
        /// Form kontrollerinin ToolTip ayarlarını yapar
        /// </summary>
        public void SetToolTips()
        {
            buttonVarsayilanProjeAsamalariToolTip = new ToolTip()
            {
                ToolTipTitle = "Varsayılan Proje Aaşamaları",
                ToolTipIcon = ToolTipIcon.Info,
                AutoPopDelay = 20000
            };
            buttonVarsayilanProjeAsamalariToolTip.SetToolTip(buttonVarsayilanProjeAsamalari, "Varsayılan proje aşamalarını gride ekler");
            buttonSafhaEkleToolTip = new ToolTip()
            {
                ToolTipTitle = "Yeni Satır",
                ToolTipIcon = ToolTipIcon.Info,
                AutoPopDelay = 20000
            };
            buttonSafhaEkleToolTip.SetToolTip(buttonSafhaEkle, "Gride boş bir satır ekler");
        }
        #region MouseDrag

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

        #endregion MouseDrag
        /// <summary>
        /// Form update modu ile açılır, açılırken projeye bağlı safhalar veritabanından çekilip gride doldurulur.
        /// </summary>
        public async Task UpdateMode(int projeId)
        {
            _projeId = projeId;
            satisProjeSafhaList = new List<ProjeSafha>();
            satisProjeSafhaList = await GetSatisProjeSafhaList(_projeId);
            FillSatisProjeSafhaGrid(satisProjeSafhaList);
        }
        /// <summary>
        /// Forma girilen veriler satisProjeSafhaList'e ekler ve listedeki verileri veritabanına kaydeder. 
        /// </summary>
        /// <returns></returns>
        private async Task SaveSatisProjeSafhaList()
        {
            this.Enabled = false;
            if (satisProjeSafhaList == null)
            {
                return;
            }
            SatisProje satisProje = new SatisProje();
            satisProje.projeId = _projeId;
            satisProje.projeSafhalar = satisProjeSafhaList;
            var httpTask = WebMethods.SaveSatisProjeSafha(satisProje);
            string result = await httpTask;
            if (result.Length > 6 && result.Substring(0, 5) == "error")
            {
                MessageBox.Show(result);
            }
            else
            {
                byte[] bytes = JsonConvert.DeserializeObject<byte[]>(result);
                string json = Encoding.UTF8.GetString(bytes);
                DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(json);
                satisProjeSafhaList = new List<ProjeSafha>();
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    ProjeSafha satisProjeSafha = new ProjeSafha();
                    satisProjeSafha.projeSafhaId = int.Parse(dataSet.Tables[0].Rows[i]["projeSafhaId"].ToString());
                    satisProjeSafha.projeId = int.Parse(dataSet.Tables[0].Rows[i]["projeId"].ToString());
                    satisProjeSafha.projeSafhaAdi = dataSet.Tables[0].Rows[i]["projeSafhaAdi"].ToString();
                    DateTime hedefTarih;
                    DateTime gerceklesmeTarihi;
                    satisProjeSafha.hedefTarih = DateTime.TryParse(dataSet.Tables[0].Rows[i]["hedefTarih"].ToString(), out hedefTarih) ? hedefTarih : default(DateTime);
                    satisProjeSafha.gerceklesmeTarihi = DateTime.TryParse(dataSet.Tables[0].Rows[i]["gerceklesmeTarihi"].ToString(), out gerceklesmeTarihi) ? gerceklesmeTarihi : default(DateTime);

                    object cellValue = dataSet.Tables[0].Rows[i]["safhaGerceklestiMi"];
                    bool isSafhaGerceklesti;
                    satisProjeSafha.SafhaGerceklestiMi = bool.TryParse(cellValue.ToString(), out isSafhaGerceklesti) ? isSafhaGerceklesti : false;
                    cellValue = dataSet.Tables[0].Rows[i]["IsProjeSafha"];
                    bool isProjeSafha;
                    satisProjeSafha.isProjeSafha = bool.TryParse(cellValue.ToString(), out isProjeSafha) ? isProjeSafha : false;
                    cellValue = dataSet.Tables[0].Rows[i]["IsSatisSafha"];
                    bool isSatisSafha;
                    satisProjeSafha.isSatisSafha = bool.TryParse(cellValue.ToString(), out isSatisSafha) ? isSatisSafha : false;
                    satisProjeSafhaList.Add(satisProjeSafha);
                }
            }
            this.Enabled = true;
        }
        /// <summary>
        /// Çıkış butonuna tıklanıldığında gerçekleşen işlemleri yöneten olay işleyici metodudur.
        /// Eğer Grid formunda yapılan değişiklikler varsa, ilgili formlardaki verileri günceller.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void rButtonCikis_Click(object sender, EventArgs e)
        {
            //Grid formunda yapılan değişiklikler varsa satisProjeKayitFormu'ndaki projesafhalar da güncellenmesi için bu kod çalıştırılıyor.
            SatisProjeKayitFormu satisProjeKayitFormu = SatisProjeKayitFormu.satisProjeKayitFormu;
            if (GlobalData.activeFormStack.Skip(1).First() == satisProjeKayitFormu)
            {
                satisProjeKayitFormu.FilltextBoxProjeAsamalari(satisProjeSafhaList);
            }
            TahsilatPlanKayitFormu tahsilatPlanKayitFormu = TahsilatPlanKayitFormu.tahsilatPlanKayitFormu;
            if (GlobalData.activeFormStack.Skip(1).First() == tahsilatPlanKayitFormu)
            {
                await tahsilatPlanKayitFormu.VerileriAl();
                //TahsilatPlanKayitFormu'ndaki proje safhaları güncellenmesi için bu kod çalıştırılıyor.
                foreach (Control control in tahsilatPlanKayitFormu.panelTahsilatAsama.Controls)
                {
                    if (control.Name.Contains("projeSafhaId"))
                    {
                        CustomComboListBox customComboListBox = control as CustomComboListBox;
                        customComboListBox.ClearListBox();
                        foreach (ProjeSafha projeSafha in satisProjeSafhaList)
                        {
                            if (projeSafha.isSatisSafha == true)
                            {
                                customComboListBox.AddDataRow(projeSafha.projeSafhaId, projeSafha.projeSafhaAdi);
                            }
                        }
                    }
                }
            }

            GlobalData.RemoveLastForm();
            this.Close();
            _satisProjeSafhaGridForm = null;
        }
        /// <summary>
        /// DataGridView'de kayıt silme işlemi için kullanılacak hücrelerinin içeriğini özelleştirerek silme ikonu ekler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewSatisProjeSafha_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex == 7)
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
        /// <summary>
        /// Seçilen ProjeSafha öğesini kullanıcıdan onay alarak silme işlemini gerçekleştirir ve silme işleminin sonucunu görüntüler.
        /// </summary>
        /// <param name="satisProjeSafha"></param>
        private async Task DeleteSafha(ProjeSafha satisProjeSafha)
        {
            DialogResult dialogResult = MessageBox.Show(string.Format("{0} aşamasını silmek istediğinizden emin misiniz", satisProjeSafha.projeSafhaAdi), "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                var httpTask = WebMethods.DeleteSatisProjeSafha(satisProjeSafha);
                this.Enabled = false;
                string result = await httpTask;
                this.Enabled = true;
                byte[] bytes = JsonConvert.DeserializeObject<byte[]>(result);
                string json = Encoding.UTF8.GetString(bytes);
                dataSet = JsonConvert.DeserializeObject<DataSet>(json);
                if (result.Length > 6 && result.Substring(0, 5) == "error")
                {
                    MessageBox.Show(result);
                }
                else
                {
                    MessageBox.Show("Silme İşlemi Başarılı");
                    //Grid'de kullandığımız datasetten de silip gridi güncelleyelim
                    int dataGridViewIndex = IndexOfGridRow(satisProjeSafha.projeSafhaId);
                    dataGridViewSatisProjeSafha.Rows.RemoveAt(dataGridViewIndex);
                    foreach (ProjeSafha projeSafha in satisProjeSafhaList)
                    {
                        if (projeSafha.projeSafhaId == satisProjeSafha.projeSafhaId)
                        {
                            satisProjeSafhaList.Remove(projeSafha);
                            return;
                        }
                    }
                }
                this.Enabled = true;
            }
        }
        /// <summary>
        /// DataGridView hücre tıklama olayını yöneten olay işleyici metodu.
        /// Hedef Tarih veya Gerçekleşen Tarih sütununa tıklanıldığında bir takvim görüntülenir.
        /// Silme sütununa tıklanıldığında ilgili satırı silme işlemi yapılır.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewSatisProjeSafha_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewSatisProjeSafha.Rows[e.RowIndex].Selected = true;
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex == 2 || e.ColumnIndex == 3)//Hedef Tarih veya Gerçekleşen Tarih Sütununa tıklandığında monthcalendar nesnesi açılır.
            {
                selectedDataGridViewCell = dataGridViewSatisProjeSafha.Rows[e.RowIndex].Cells[e.ColumnIndex];
                monthCalendar.Visible = !monthCalendar.Visible;
                monthCalendar.SelectionStart = DateTime.Now;
                monthCalendar.SelectionEnd = DateTime.Now;
                monthCalendar.Location = new Point(dataGridViewSatisProjeSafha.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Location.X, dataGridViewSatisProjeSafha.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Location.Y + 135);
            }
            if (e.ColumnIndex == 7)  //Satır silme işlemi.
            {
                //Id sütunu nullsa yani veritabanı kaydı yoksa gridden kaldırmna yeterli
                if (dataGridViewSatisProjeSafha.Rows[e.RowIndex].Cells[0].Value == null)
                {
                    dataGridViewSatisProjeSafha.Rows.RemoveAt(dataGridViewSatisProjeSafha.SelectedCells[0].RowIndex);
                    return;
                }

                ProjeSafha satisProjeSafha = new ProjeSafha();

                satisProjeSafha.projeSafhaId = int.Parse(dataGridViewSatisProjeSafha.Rows[e.RowIndex].Cells["ProjeSafhaId"].Value.ToString());
                satisProjeSafha.projeSafhaAdi = dataGridViewSatisProjeSafha.Rows[e.RowIndex].Cells["ProjeSafhaAdi"].Value.ToString();
                DeleteSafha(satisProjeSafha);

            }
        }
        /// <summary>
        /// Girdi alanlarını kontrol eder, satış proje safhalarını liste olarak toplar ve kaydetme işlemi gerçekleştirir.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void rButtonKaydet_Click(object sender, EventArgs e)
        {
            if (!CheckFields())
            {
                return;
            }
            satisProjeSafhaList = new List<ProjeSafha>();
            foreach (DataGridViewRow dataRow in dataGridViewSatisProjeSafha.Rows)
            {
                ProjeSafha satisProjeSafha;
                satisProjeSafha = new ProjeSafha();
                satisProjeSafha.projeSafhaId = (dataRow.Cells["ProjeSafhaId"].Value != null) ? int.Parse(dataRow.Cells["ProjeSafhaId"].Value.ToString()) : 0;
                satisProjeSafha.projeSafhaAdi = dataRow.Cells["projeSafhaAdi"].Value.ToString();
                satisProjeSafha.projeId = _projeId;

                DateTime tarih = DateTime.Parse(dataRow.Cells["HedefTarih"].Value.ToString());
                string tarihStr = tarih.ToShortDateString();
                DateTime hedefTarih;
                satisProjeSafha.hedefTarih = (DateTime.TryParse(tarihStr, out hedefTarih)) ? hedefTarih : default(DateTime);

                DateTime gerceklesmeTarihi;
                tarih = DateTime.Parse((dataRow.Cells["GerceklesmeTarihi"].Value != null) ? dataRow.Cells["GerceklesmeTarihi"].Value.ToString() : default(DateTime).ToString());
                tarihStr=tarih.ToShortDateString();
                satisProjeSafha.gerceklesmeTarihi = (dataRow.Cells["GerceklesmeTarihi"].Value != null && DateTime.TryParse(tarihStr, out gerceklesmeTarihi)) ? gerceklesmeTarihi : default(DateTime);

                satisProjeSafha.SafhaGerceklestiMi = (dataRow.Cells["isSafhaGerceklesti"].Value != null) ? bool.Parse(dataRow.Cells["isSafhaGerceklesti"].Value.ToString()) : false; //Safha Gerçekleşti mi
                satisProjeSafha.isSatisSafha = (dataRow.Cells["isSatisSafha"].Value != null) ? bool.Parse(dataRow.Cells["isSatisSafha"].Value.ToString()) : false; //isSatisSafha
                satisProjeSafha.isProjeSafha = (dataRow.Cells["isProjeSafha"].Value != null) ? bool.Parse(dataRow.Cells["isProjeSafha"].Value.ToString()) : false; //isProjeSafha

                satisProjeSafhaList.Add(satisProjeSafha);

            }

            await SaveSatisProjeSafhaList();
            //await GetSatisProjeSafhaList(projeId);
            UpdateMode(_projeId);
        }
        #region monthCalendarMouseDrag
        private Point mouseOffset;
        private bool isDragging;
        private void monthCalendar_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;
            mouseOffset = new Point(-e.X, -e.Y);
        }
        private void monthCalendar_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouseOffset);
                monthCalendar.Location = this.PointToClient(mousePos);
            }
        }
        private void monthCalendar_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }
        private void monthCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            selectedDate = e.Start;
            selectedDataGridViewCell.Value = selectedDate.ToShortDateString();
            monthCalendar.Visible = false;
        }
        #endregion monthCalendarMouseDrag
        /// <summary>
        /// Yeni bir satır ekler ve satırın hücresine varsayılan olarak "Aşama+i" şeklinde değer atanır.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSafhaEkle_Click(object sender, EventArgs e)
        {
            dataGridViewSatisProjeSafha.Rows.Add();
            dataGridViewSatisProjeSafha.Rows[dataGridViewSatisProjeSafha.RowCount - 1].Cells[1].Value = "Aşama" + dataGridViewSatisProjeSafha.RowCount;
        }
        /// <summary>
        /// Girdi alanlarının doğru bir şekilde doldurulduğunu kontrol eder.
        /// Eğer boş veya geçerli olmayan değerler varsa uyarı mesajları oluşturur ve işaretler.
        /// </summary>
        /// <returns></returns>
        private bool CheckFields()
        {
            bool result = true;
            //Mevcut uyarı label'larını sil
            if (warningLabels != null)
            {
                foreach (Control label in warningLabels)
                {
                    Controls.Remove(label);
                    label.Dispose();
                }
            }
            warningLabels = new List<Control>();

            for (int i = 0; i < dataGridViewSatisProjeSafha.RowCount; i++)
            {
                if (dataGridViewSatisProjeSafha.Rows[i].Cells[1].Value == null ||
                    string.IsNullOrWhiteSpace(dataGridViewSatisProjeSafha.Rows[i].Cells[1].Value.ToString()))//Aşama adı girilmemiş
                {
                    result = false;
                    Point labelLocation = dataGridViewSatisProjeSafha.Location;
                    labelLocation.X += dataGridViewSatisProjeSafha.Rows[i].Cells[1].Size.Width +
                        dataGridViewSatisProjeSafha.Rows[i].Cells[2].Size.Width +
                        dataGridViewSatisProjeSafha.Rows[i].Cells[3].Size.Width +
                        dataGridViewSatisProjeSafha.Rows[i].Cells[4].Size.Width +
                        dataGridViewSatisProjeSafha.Rows[i].Cells[5].Size.Width +
                        dataGridViewSatisProjeSafha.Rows[i].Cells[6].Size.Width +
                        dataGridViewSatisProjeSafha.Rows[i].Cells[7].Size.Width + 50;
                    labelLocation.Y += (int)Math.Ceiling((i + 1.2) * dataGridViewSatisProjeSafha.Rows[i].Height);
                    warningLabels.Add(CreateWarningLabelAtPoint(labelLocation, "Aşama adı giriniz!"));
                }
                else if (dataGridViewSatisProjeSafha.Rows[i].Cells[2].Value == null ||
                    string.IsNullOrWhiteSpace(dataGridViewSatisProjeSafha.Rows[i].Cells[2].Value.ToString()))//Hedef tarih girilmemiş
                {
                    result = false;
                    Point labelLocation = dataGridViewSatisProjeSafha.Location;
                    labelLocation.X += dataGridViewSatisProjeSafha.Rows[i].Cells[1].Size.Width +
                        dataGridViewSatisProjeSafha.Rows[i].Cells[2].Size.Width +
                        dataGridViewSatisProjeSafha.Rows[i].Cells[3].Size.Width +
                        dataGridViewSatisProjeSafha.Rows[i].Cells[4].Size.Width +
                        dataGridViewSatisProjeSafha.Rows[i].Cells[5].Size.Width +
                        dataGridViewSatisProjeSafha.Rows[i].Cells[6].Size.Width +
                        dataGridViewSatisProjeSafha.Rows[i].Cells[7].Size.Width + 50;
                    labelLocation.Y += (int)Math.Ceiling((i + 1.2) * dataGridViewSatisProjeSafha.Rows[i].Height);
                    warningLabels.Add(CreateWarningLabelAtPoint(labelLocation, "Hedef tarih giriniz!"));
                }
            }
            return result;
        }
        /// <summary>
        /// Grid formunun ilgili satırlarının karşısında uyarı etikleri oluşturur.
        /// </summary>
        /// <param name="point"></param>
        /// <param name="warningText"></param>
        /// <returns></returns>
        private Label CreateWarningLabelAtPoint(Point point, string warningText)
        {
            Label label = new Label();
            label.Text = warningText;
            label.AutoSize = true;
            label.BackColor = System.Drawing.Color.DarkGray;
            label.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label.ForeColor = System.Drawing.Color.Red;
            label.Location = point;
            Controls.Add(label);
            label.Visible = true;
            label.BringToFront();
            return label;
        }
        /// <summary>
        /// Projenin proje safha listesini alır.
        /// </summary>
        /// <param name="projeId"></param>
        /// <returns></returns>
        public async Task<List<ProjeSafha>> GetSatisProjeSafhaList(int projeId)
        {
            satisProjeSafhaList = new List<ProjeSafha>();
            SatisProje satisProje = new SatisProje();
            satisProje.projeId = projeId;
            var httpTask = WebMethods.GetSatisProjeSafhaList(satisProje);
            string result = await httpTask;
            if (result.Length > 6 && result.Substring(0, 5) == "error")
            {
                MessageBox.Show(result);
            }
            else
            {
                byte[] bytes = JsonConvert.DeserializeObject<byte[]>(result);
                string json = Encoding.UTF8.GetString(bytes);
                DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(json);
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    ProjeSafha satisProjeSafha = new ProjeSafha();
                    satisProjeSafha.projeSafhaId = int.Parse(dataSet.Tables[0].Rows[i]["projeSafhaId"].ToString());
                    satisProjeSafha.projeId = int.Parse(dataSet.Tables[0].Rows[i]["projeId"].ToString());
                    satisProjeSafha.projeSafhaAdi = dataSet.Tables[0].Rows[i]["projeSafhaAdi"].ToString();
                    satisProjeSafha.hedefTarih = DateTime.TryParse(dataSet.Tables[0].Rows[i]["hedefTarih"].ToString(), out DateTime hedefTarih) ? hedefTarih : default(DateTime);
                    satisProjeSafha.gerceklesmeTarihi = DateTime.TryParse(dataSet.Tables[0].Rows[i]["gerceklesmeTarihi"].ToString(), out DateTime gerceklesmeTarihi) ? gerceklesmeTarihi : default(DateTime);
                    satisProjeSafha.SafhaGerceklestiMi = bool.TryParse(dataSet.Tables[0].Rows[i]["safhaGerceklestiMi"].ToString(), out bool isSafhaGerceklesti) ? isSafhaGerceklesti : false;
                    satisProjeSafha.isProjeSafha = bool.TryParse(dataSet.Tables[0].Rows[i]["IsProjeSafha"].ToString(), out bool isProjeSafha) ? isProjeSafha : false;
                    satisProjeSafha.isSatisSafha = bool.TryParse(dataSet.Tables[0].Rows[i]["IsSatisSafha"].ToString(), out bool isSatisSafha) ? isSatisSafha : false;
                    satisProjeSafhaList.Add(satisProjeSafha);
                }
            }
            return satisProjeSafhaList;
        }
        /// <summary>
        /// Proje safha listesini Grid'e doldurur.
        /// </summary>
        /// <param name="satisProjeSafhaList"></param>
        private void FillSatisProjeSafhaGrid(List<ProjeSafha> satisProjeSafhaList)
        {
            if (satisProjeSafhaList != null)
            {
                dataGridViewSatisProjeSafha.Rows.Clear();
                int i = 0;
                foreach (ProjeSafha satisProjeSafha in satisProjeSafhaList)
                {
                    dataGridViewSatisProjeSafha.Rows.Add();
                    dataGridViewSatisProjeSafha.Rows[i].Cells["projeSafhaId"].Value = satisProjeSafhaList[i].projeSafhaId;
                    dataGridViewSatisProjeSafha.Rows[i].Cells["projeSafhaAdi"].Value = satisProjeSafhaList[i].projeSafhaAdi;
                    dataGridViewSatisProjeSafha.Rows[i].Cells["HedefTarih"].Value = satisProjeSafhaList[i].hedefTarih == default(DateTime) ? null : satisProjeSafhaList[i].hedefTarih;
                    dataGridViewSatisProjeSafha.Rows[i].Cells["GerceklesmeTarihi"].Value = satisProjeSafhaList[i].gerceklesmeTarihi == default(DateTime) ? null : satisProjeSafhaList[i].gerceklesmeTarihi;
                    dataGridViewSatisProjeSafha.Rows[i].Cells["IsProjeSafha"].Value = satisProjeSafhaList[i].isProjeSafha;
                    dataGridViewSatisProjeSafha.Rows[i].Cells["IsSatisSafha"].Value = satisProjeSafhaList[i].isSatisSafha;
                    dataGridViewSatisProjeSafha.Rows[i].Cells["IsSafhaGerceklesti"].Value = satisProjeSafhaList[i].SafhaGerceklestiMi;
                    i++;
                }
            }
        }
        /// <summary>
        /// Satırın Grid'deki indexini döndürür.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private int IndexOfGridRow(int id)
        {
            int index = -1;
            if (dataSet != null)
            {
                if (dataGridViewSatisProjeSafha.Rows.Count > 0)
                {
                    for (int i = 0; i < dataGridViewSatisProjeSafha.Rows.Count; i++)
                    {
                        if (id == int.Parse(dataGridViewSatisProjeSafha.Rows[i].Cells[0].Value.ToString()))
                        {
                            return i;
                        }
                    }
                }
            }
            return index;
        }
        private void CloseForm()
        {
            this.Close();
            GlobalData.RemoveLastForm();
            _satisProjeSafhaGridForm = null;
        }
        private async void buttonVarsayilanProjeAsamalari_Click(object sender, EventArgs e)
        {
            string httpResult = await _webMethods.GetProjeAsamaTanimlari();
            byte[] bytes = JsonConvert.DeserializeObject<byte[]>(httpResult);
            string json = Encoding.UTF8.GetString(bytes);
            DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(json);
            int i = dataGridViewSatisProjeSafha.RowCount;
            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                dataGridViewSatisProjeSafha.Rows.Add();
                dataGridViewSatisProjeSafha.Rows[i].Cells["projeSafhaAdi"].Value = dataRow["ProjeAsamaTanim"].ToString();
                dataGridViewSatisProjeSafha.Rows[i].Cells["IsProjeSafha"].Value = bool.Parse(dataRow["ProjeAsamasi"].ToString());
                dataGridViewSatisProjeSafha.Rows[i].Cells["IsSatisSafha"].Value = bool.Parse(dataRow["SatisAsamasi"].ToString());
                i++;
            }
        }

        private void buttomMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            CloseForm();
        }
    }
}