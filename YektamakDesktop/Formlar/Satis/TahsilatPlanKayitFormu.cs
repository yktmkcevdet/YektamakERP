#region using
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Models;

using Newtonsoft.Json;
using System.Threading.Tasks;
using YektamakDesktop.CustomControls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.Reflection;
using Microsoft.VisualBasic.FileIO;
using CheckBox = System.Windows.Forms.CheckBox;
using System.Runtime.Serialization.Formatters;
using System.IO;
using System.Windows.Forms.VisualStyles;
using System.Globalization;
using static System.Net.WebRequestMethods;
using System.Linq.Expressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Newtonsoft.Json.Linq;
using RadioButton = System.Windows.Forms.RadioButton;
using YektamakDesktop.Formlar.Ortak;
using ApiService;
#endregion using
namespace YektamakDesktop.Formlar.Satis
{
	public partial class TahsilatPlanKayitFormu : Form, IForm
	{
		#region decleration
		private static TahsilatPlanKayitFormu _tahsilatPlanKayitFormu;
		public static TahsilatPlanKayitFormu tahsilatPlanKayitFormu
		{
			get
			{
				if (_tahsilatPlanKayitFormu == null)
				{
					_tahsilatPlanKayitFormu = new TahsilatPlanKayitFormu();
                    GlobalData.Yetki(ref _tahsilatPlanKayitFormu);
                }
				return _tahsilatPlanKayitFormu;
			}
		}
		private TahsilatPlani _tahsilatPlaniToSave;
		public TahsilatPlani tahsilatPlaniToSave
		{
			get { return _tahsilatPlaniToSave; }
			set { _tahsilatPlaniToSave = value; }
		}
		private TahsilatPlani _tahsilatPlaniToUpdate;
		public TahsilatPlani tahsilatPlaniToUpdate
		{
			get { return _tahsilatPlaniToUpdate; }
			set { _tahsilatPlaniToUpdate = value; }
		}
		private List<Control> _controlsToDisable;
		public List<Control> controlsToDisable { get => _controlsToDisable; set => _controlsToDisable = value; }
		private bool _activeForm;
		public bool activeForm { get => _activeForm; set => _activeForm = value; }
		private int _tahsilatPlaniId;
		private int _KDVDahilMi;
		private string _dovizBirimSembol;
		private CustomTextBox _selectedTextBox;
		private DataSet _dataSetPlanOdeme;
		public DataSet dataSetPlanOdeme
		{
			get { return _dataSetPlanOdeme; }
			set { _dataSetPlanOdeme = value; }
		}
		private DataSet _tahsilatPlanData;
		public DataSet tahsilatPlanData
		{
			get => _tahsilatPlanData; set => _tahsilatPlanData = value;
		}
		private bool _unsavedChanges;
		private int _kayitSayisi = 0;
		private int _locationY = 30;
		private int _spaceX = 10;
		private int _controlHeight = 13;
		private int _controlWidth;
		private List<DataControl> _dataControlList = new List<DataControl>();
		private SatisSiparis _satisSiparis;
        #endregion decleration
        private TahsilatPlanKayitFormu()
        {
            InitializeComponent();
            controlsToDisable = new List<Control>
            {

            };
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

		#region formElementsEvents
		private async void rButtonKapat_Click(object sender, EventArgs e)
		{
			//Form kapatılırken değişiklik yapıldıysa kaydedilsin mi uyarısı verecek,
			//çıkan dialog kutusunda evet seçeneği seçilirse kayıt adımları gerçekleşecek, diğer durumlarda kayıt yapılmadan form kapatılacak.
			if (_unsavedChanges)
			{
				DialogResult result = MessageBox.Show("Değişiklikleri kaydetmek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
				if (result == DialogResult.Yes)
				{
					if (CheckFields())
					{
						await TahsilatPlaniKaydet();
						Close();
					}
				}
				else if (result == DialogResult.No)
				{
					Close();
				}
				else if (result == DialogResult.Cancel)
				{
					return;
				}
			}
			else
			{
				Close();
			}
		}
		private async void buttonGuncelle_Click(object sender, EventArgs e)
		{
			if (CheckFields())
			{
				this.Enabled = false;
				await TahsilatPlaniKaydet();
				this.Enabled = true;
			}
		}
		/// <summary>
		/// Form üzerinde "tahsilat aşama sayısı" değiştirildiğinde, değişen sayı kadar form üzerine ödeme planı satırı ekler ya da siler.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void numericTahsilatAsamaSayisi_ValueChanged(object sender, EventArgs e)
		{
			//Tahsilat aşama sayısı artırılırsa forma bir satır eklenir, azaltılırsa son satır verilerle beraber silinir.
			NumericUpDown kayitSiraNo = (NumericUpDown)sender;
			while (kayitSiraNo.Value != _kayitSayisi) //_kayitSayisi form üzerinde mevcutta bulunan ödeme planı satır sayısıdır. Kayıt sıra no elle 1 adımdan fazla şekilde giriş yapılırsa döngü ile kayıt sayısı kayıt sıra no'ya eşitlenene kadar işlem yapılır.
			{
				if (kayitSiraNo.Value < _kayitSayisi)
				{
					//Kayıt sayısı azaltılmış ise bu kısım çalışacak ve son satır silinecek.
					List<Control> ctrlList = new List<Control>();
					foreach (Control control in panelTahsilatAsama.Controls)
					{
						if (control.Name.Length - 1 > 0 && control.Name[control.Name.Length - 1].ToString() == ((_kayitSayisi - 1).ToString("X"))) // ToString("X") ifadesi sayıyı hexafloat yapıyor, bu sayede 16 haneye kadar tek dijit olarak saklayabiliyoruz.
						{
							ctrlList.Add(control);
						}

					}
					foreach (var item in ctrlList)
					{
						panelTahsilatAsama.Controls.Remove(item); // Form üzerindeki kontrolleri fiziken siler.
					}
					_dataControlList.RemoveAt(_kayitSayisi - 1); //Form üzerindeki kontrollerin değerlerini tutan listeden de kayıt silinir.
					_kayitSayisi = _kayitSayisi - 1;
					_locationY = _locationY - _controlHeight;
				}
				else
				{
					//Kayıt sayısı artırılmış ise bu kısım çalışacak ve yeni satır eklenecek.
					_locationY = _locationY + _controlHeight;
					PlanOdemeSatirEkle(_kayitSayisi);
					_kayitSayisi = _kayitSayisi + 1;
				}
			}

			_unsavedChanges = true; //Formu kapatırken kayıt edilsin mi uyarısı için değişiklik yapıldığı bilgisi true yapılır.
		}
		/// <summary>
		/// Açıklama alanında bir değişiklik olursa kaydedilmemiş değişiklikler olduğu bilgisi true olur.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void textBoxAciklamalar_TextChanged(object sender, EventArgs e)
		{
			_unsavedChanges = true;
		}
		/// <summary>
		/// Net+KDV olarak işaretlenirse formun görünümü net+kdv'ye göre güncellenir.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void customRadioButtonNetKdv_Click(object sender, EventArgs e)
		{
			if (customRadioButtonNetKdv.Checked == true)
			{
				_KDVDahilMi = 0;
				textBoxSatisTutari.TextCustom = _satisSiparis.satisTutari.tutar.ToString("#,##0.00") + " " + _dovizBirimSembol; ;
				numericTahsilatAsamaSayisi.Value = 0;
				BaslikEtiketleriniOlustur();
				AlanlariDoldur();
				_unsavedChanges = true;
			}
		}
		/// <summary>
		/// Toplam yani kdv dahil olarak işaretlenirse formun görünümü kdv dahil olacak şekilde düzenlenir.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void customRadioButtonToplam_Click(object sender, EventArgs e)
		{
			if (customRadioButtonToplam.Checked == true)
			{
				//seçim toplam olduğunda görünüm ayarları
				_KDVDahilMi = 1;
				textBoxSatisTutari.TextCustom = (_satisSiparis.satisTutari.tutar + _satisSiparis.satisTutari.tutar * _satisSiparis.kdv.kdvOrani / 100).ToString("#,##0.00") + " " + _dovizBirimSembol;
				numericTahsilatAsamaSayisi.Value = 0;
				BaslikEtiketleriniOlustur();
				AlanlariDoldur();
				_unsavedChanges = true;
			}
		}

		#endregion formElementsEvents

		/// <summary>
		/// Daha önce kayıt edilmiş bir tahsilat planı yoksa form SaveMode olarak açılır.
		/// </summary>
		/// <param name="satisSiparis"></param>
		public async void SaveMode(SatisSiparis satisSiparis)
		{
			_unsavedChanges = false;  //Form ilk açıldığında kaydedilmemiş değişklikler false olarak tanımlanır.
			this.Enabled = false;
			ClearFields();
			_satisSiparis = satisSiparis;
			await VerileriAl();
			BaslikEtiketleriniOlustur();

			//textBoxProjeKodu.TextCustom = ProjeKod.GetProjeKodString(satisSiparis.projeKod.projeNo, satisSiparis.projeKod.marka.markaId);
			//_dovizBirimSembol = GlobalData.GetSymbolFromDovizId(satisSiparis.satisTutari.dovizCinsi.id);
			textBoxSatisTutari.TextCustom = satisSiparis.satisTutari.tutar.ToString("#,##0.00") + " " + _dovizBirimSembol;
			textBoxSatisTutari.ReadOnly = true;
			customRadioButtonNetKdv.Checked = true;
			rButtonGuncelle.Visible = false;
			rButtonKaydet.Visible = true;
			//AlanlariDoldur();
			this.Enabled = true;
		}
		/// <summary>
		/// Daha önce kayıt edilmiş bir tahsilat planı varsa form UpdateMode olarak açılır.
		/// </summary>
		/// <param name="satisSiparis"></param>
		public async void UpdateMode(SatisSiparis satisSiparis)
		{
			_unsavedChanges = false;  //Form ilk açıldığında kaydedilmemiş değişklikler false olarak tanımlanır.
			this.Enabled = false; //Form açılma işlemi sürerken pasif durumda bekler.
			ClearFields();
			_satisSiparis = satisSiparis;
			await VerileriAl();
			BaslikEtiketleriniOlustur();

			textBoxProjeKodu.TextCustom = satisSiparis.satisProje.projeKod.kod;
			_dovizBirimSembol = satisSiparis.satisTutari.dovizCinsi.sembol.ToString();
			if (customRadioButtonToplam.Checked == true)   //Net+kdv mi toplam mı bilgisine göre satış tutarı hesaplanır.
			{
				textBoxSatisTutari.TextCustom = (satisSiparis.satisTutari.tutar + satisSiparis.satisTutari.tutar * satisSiparis.kdv.kdvOrani / 100).ToString("#,##0.00") + " " + _dovizBirimSembol;
			}
			else
			{
				textBoxSatisTutari.TextCustom = satisSiparis.satisTutari.tutar.ToString("#,##0.00") + " " + _dovizBirimSembol;
			}

			foreach (DataRow dr in tahsilatPlanData.Tables[2].Rows)
			{
				customRadioButtonToplam.Checked = ((bool)dr["KDVDahilMi"] == true) ? true : false;
				customRadioButtonNetKdv.Checked = ((bool)dr["KDVDahilMi"] == false) ? true : false;
				_KDVDahilMi = (customRadioButtonNetKdv.Checked == true) ? 0 : 1;
				textBoxAciklamalar.Text = dr["Aciklamalar"].ToString();
				_tahsilatPlaniId = int.Parse(dr["tahsilatPlaniId"].ToString());
			}
			rButtonGuncelle.Visible = true;
			rButtonKaydet.Visible = false;
			AlanlariDoldur();
			this.Enabled = true;
		}
		/// <summary>
		/// Uyarı alanlarındaki yazıları temizler
		/// </summary>
		private void ClearFields()
		{
			labelOranVeKdvUyari.Text = null;
			foreach (DataControl dataControl in _dataControlList)
			{
				dataControl.labelUyari.Text = null;
			}
		}

		/// <summary>
		/// Dinamik olarak oluşturulacak satırların başlık etiketlerini form üzerinde oluşturur. 
		/// </summary>
		private void BaslikEtiketleriniOlustur()
		{
			int labelLocationX = 50;
			foreach (Control control in panelTahsilatAsama.Controls.OfType<Label>().ToList())
			{
				panelTahsilatAsama.Controls.Remove(control);
				control.Dispose();
			}

			_controlWidth = 120;
			Label label = new Label();
			label.Location = new Point(labelLocationX, 15); ;
			label.Size = new Size(_controlWidth, _controlHeight);
			label.Text = "Aşama".ToString();
			panelTahsilatAsama.Controls.Add(label);
			labelLocationX = labelLocationX + label.Size.Width + _spaceX;

			_controlWidth = 50;
			label = new Label();
			label.Location = new Point(labelLocationX, 15); ;
			label.Size = new Size(_controlWidth, _controlHeight);
			label.Text = "Vade  (Gün)".ToString();
			panelTahsilatAsama.Controls.Add(label);
			labelLocationX = labelLocationX + label.Size.Width + _spaceX;

			_controlWidth = 60;
			label = new Label();
			label.Location = new Point(labelLocationX, 15); ;
			label.Size = new Size(_controlWidth, _controlHeight);
			label.Text = "%Ödeme Oranı".ToString();
			panelTahsilatAsama.Controls.Add(label);
			labelLocationX = labelLocationX + label.Size.Width + _spaceX;

			if (_KDVDahilMi == 0)
			{
				_controlWidth = 45;
				label = new Label();
				label.Location = new Point(labelLocationX, 15); ;
				label.Size = new Size(_controlWidth, _controlHeight);
				label.Text = "+KDV?".ToString();
				panelTahsilatAsama.Controls.Add(label);
				labelLocationX = labelLocationX + label.Size.Width + _spaceX;
			}

			_controlWidth = 100;
			label = new Label();
			label.Location = new Point(labelLocationX, 15);
			label.Size = new Size(_controlWidth, _controlHeight);
			label.Text = "Miktar".ToString();
			panelTahsilatAsama.Controls.Add(label);
			labelLocationX = labelLocationX + label.Size.Width + _spaceX;

			_controlWidth = 80;
			label = new Label();
			label.Location = new Point(labelLocationX, 15);
			label.Size = new Size(_controlWidth, _controlHeight);
			label.Text = "Ödeme Şekli".ToString();
			panelTahsilatAsama.Controls.Add(label);
			labelLocationX = labelLocationX + label.Size.Width + _spaceX;

			_controlWidth = 85;
			label = new Label();
			label.Location = new Point(labelLocationX, 0); ;
			label.Size = new Size(_controlWidth, _controlHeight * 3);
			label.Text = "Ödeme\nGerçekleşti Mi".ToString();

			panelTahsilatAsama.Controls.Add(label);
			labelLocationX = labelLocationX + label.Size.Width + _spaceX;

			_controlWidth = 85;
			label = new Label();
			label.Location = new Point(labelLocationX, 15); ;
			label.Size = new Size(_controlWidth, _controlHeight);
			label.Text = "Tahsilat Tarihi".ToString();
			panelTahsilatAsama.Controls.Add(label);
			labelLocationX = labelLocationX + label.Size.Width + _spaceX;

			_controlWidth = 100;
			label = new Label();
			label.Location = new Point(labelLocationX + 10, 15); ;
			label.Size = new Size(_controlWidth, _controlHeight);
			label.Text = "Gelen Ödeme".ToString();
			panelTahsilatAsama.Controls.Add(label);
			labelLocationX = labelLocationX + label.Size.Width + _spaceX;

			_controlWidth = 100;
			label = new Label();
			label.Location = new Point(labelLocationX + 10, 15); ;
			label.Size = new Size(_controlWidth, _controlHeight);
			label.Text = "Kalan Ödeme".ToString();
			panelTahsilatAsama.Controls.Add(label);
			labelLocationX = labelLocationX + label.Size.Width + _spaceX;
		}

		/// <summary>
		/// Tahsilat planı satırları için kontroller form üzerine yerleştirilir.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void PlanOdemeSatirEkle(int _asamaSiraNo)
		{
			int locationX = 50; //Her yeni satırda locationX sıfırlanır, dizilim soldan tekrar başlar.
			DataControl dataControl = new DataControl(); //Forma eklenecek kontrolleri DataControl nesnesinde tutabilmek için her satır için yeni bir referans oluşturuyoruz.

			var type = typeof(CustomComboListBox);
			dataControl.projeSafhaId = (CustomComboListBox)Activator.CreateInstance(type);
			dataControl.projeSafhaId.Location = new Point(locationX, _locationY + _asamaSiraNo * 35);
			dataControl.projeSafhaId.Width = 120;
			dataControl.projeSafhaId.Height = _controlHeight;
			MethodInfo method = dataControl.projeSafhaId.GetType().GetMethod("AddDataRow");
			var satisProjeSafhalari = from DataRow row in tahsilatPlanData.Tables[3].Rows where (bool)row["IsSatisSafha"] == true select row;
			foreach (DataRow drProjeSafha in satisProjeSafhalari)
			{
				object[] parameters = new object[] { int.Parse(drProjeSafha["ProjeSafhaId"].ToString()), drProjeSafha["ProjeSafhaAdi"].ToString() };
				method.Invoke(dataControl.projeSafhaId, parameters);
			}
			locationX = locationX + dataControl.projeSafhaId.Width + _spaceX;
			dataControl.projeSafhaId.Name = "projeSafhaId" + _asamaSiraNo.ToString("X");
			panelTahsilatAsama.Controls.Add(dataControl.projeSafhaId);

			type = typeof(CustomTextBox);
			dataControl.vade = (CustomTextBox)Activator.CreateInstance(type);
			dataControl.vade.Location = new Point(locationX, _locationY + _asamaSiraNo * 35);
			dataControl.vade.Width = 50;
			dataControl.vade.Height = _controlHeight;
			dataControl.vade.TextCustom = "0";
			KontrolOlayEkle(dataControl.vade, type, "KeyPress", "TextBox_KeyPress"); //vade textBox'ına ait KeyPress olayı eklenir.
			KontrolOlayEkle(dataControl.vade, type, "TextChanged", "TextBox_TextChanged");//vade textBox'ına ait TextChanged olayı eklenir.
			dataControl.vade.TextAlignment = HorizontalAlignment.Right;
			locationX = locationX + dataControl.vade.Width + _spaceX;
			dataControl.vade.Name = "vade" + _asamaSiraNo.ToString("X");
			panelTahsilatAsama.Controls.Add(dataControl.vade);

			type = typeof(CustomTextBox);
			dataControl.odemeOrani = (CustomTextBox)Activator.CreateInstance(type);
			dataControl.odemeOrani.Location = new Point(locationX, _locationY + _asamaSiraNo * 35);
			dataControl.odemeOrani.Width = 60;
			dataControl.odemeOrani.Height = _controlHeight;
			KontrolOlayEkle(dataControl.odemeOrani, type, "KeyPress", "TextBox_KeyPress"); //odemeOrani textBox'ına ait KeyPress olayı eklenir.
			KontrolOlayEkle(dataControl.odemeOrani, type, "TextChanged", "TextBox_TextChanged"); //odemeOrani textBox'ına ait TextChanged olayı eklenir.
			dataControl.odemeOrani.TextAlignment = HorizontalAlignment.Right;
			locationX = locationX + dataControl.odemeOrani.Width + _spaceX;
			dataControl.odemeOrani.Name = "odemeOrani" + _asamaSiraNo.ToString("X");
			panelTahsilatAsama.Controls.Add(dataControl.odemeOrani);

			if (_KDVDahilMi == 0)
			{
				type = typeof(RadioButton);
				dataControl.KDVMi = (RadioButton)Activator.CreateInstance(type);
				dataControl.KDVMi.Location = new Point(locationX + 10, _locationY + 10 + _asamaSiraNo * 35);
				dataControl.KDVMi.Width = 45;
				dataControl.KDVMi.Height = _controlHeight;
				KontrolOlayEkle(dataControl.KDVMi, type, "CheckedChanged", "RadioButtonKdv_Changed"); //kdvMi radioButton'ına ait CheckedChanged olayı eklenir.
				locationX = locationX + dataControl.KDVMi.Width + _spaceX;
				dataControl.KDVMi.Name = "KDVMi" + _asamaSiraNo.ToString("X");
				panelTahsilatAsama.Controls.Add(dataControl.KDVMi);
			}

			type = typeof(CustomTextBox);
			dataControl.tutar = (CustomTextBox)Activator.CreateInstance(type);
			dataControl.tutar.Location = new Point(locationX, _locationY + _asamaSiraNo * 35);
			dataControl.tutar.Width = 100;
			dataControl.tutar.Height = _controlHeight;
			dataControl.tutar.TextAlignment = HorizontalAlignment.Right;
			dataControl.tutar.ReadOnly = true;
			locationX = locationX + dataControl.tutar.Width + _spaceX;
			dataControl.tutar.Name = "tutar" + _asamaSiraNo.ToString("X");
			panelTahsilatAsama.Controls.Add(dataControl.tutar);

			type = typeof(CustomComboListBox);
			dataControl.odemeSekliId = (CustomComboListBox)Activator.CreateInstance(type);
			dataControl.odemeSekliId.Location = new Point(locationX, _locationY + _asamaSiraNo * 35);
			dataControl.odemeSekliId.Width = 80;
			dataControl.odemeSekliId.Height = _controlHeight;
			method = dataControl.odemeSekliId.GetType().GetMethod("AddDataRow");
			foreach (OdemeSekli odemeSekli in Enum.GetValues(typeof(OdemeSekli)))
			{
				object[] parameters = new object[] { (int)Convert.ChangeType(odemeSekli, typeof(int)), odemeSekli.ToString() };
				method.Invoke(dataControl.odemeSekliId, parameters);
			}
			locationX = locationX + dataControl.odemeSekliId.Width + _spaceX;
			dataControl.odemeSekliId.Name = "odemeSekliId" + _asamaSiraNo.ToString("X");
			panelTahsilatAsama.Controls.Add(dataControl.odemeSekliId);

			type = typeof(CheckBox);
			dataControl.tahsilatGerceklestiMi = (CheckBox)Activator.CreateInstance(type);
			dataControl.tahsilatGerceklestiMi.Location = new Point(locationX + 10, _locationY + 5 + _asamaSiraNo * 35);
			dataControl.tahsilatGerceklestiMi.Width = 85;
			dataControl.tahsilatGerceklestiMi.Height = _controlHeight;
			locationX = locationX + dataControl.tahsilatGerceklestiMi.Width + _spaceX;
			dataControl.tahsilatGerceklestiMi.Name = "tahsilatGerceklestiMi" + _asamaSiraNo.ToString("X");
			panelTahsilatAsama.Controls.Add(dataControl.tahsilatGerceklestiMi);

			type = typeof(CustomTextBox);
			dataControl.gerceklesmeTarihi = (CustomTextBox)Activator.CreateInstance(type);
			dataControl.gerceklesmeTarihi.Location = new Point(locationX, _locationY + _asamaSiraNo * 35);
			dataControl.gerceklesmeTarihi.Width = 85;
			dataControl.gerceklesmeTarihi.Height = _controlHeight;
			dataControl.gerceklesmeTarihi.TextAlignment = HorizontalAlignment.Right;
			KontrolOlayEkle(dataControl.gerceklesmeTarihi, type, "Click", "DateClick"); //gerceklesmeTarihi textBox'ına ait Click olayı eklenir.
			KontrolOlayEkle(dataControl.gerceklesmeTarihi, type, "KeyPress", "Date_KeyPress"); //gerceklesmeTarihi textBox'ına ait KeyPress olayı eklenir.
			locationX = locationX + dataControl.gerceklesmeTarihi.Width + _spaceX;
			dataControl.gerceklesmeTarihi.Name = "gerceklesmeTarihi" + _asamaSiraNo.ToString("X");
			panelTahsilatAsama.Controls.Add(dataControl.gerceklesmeTarihi);

			type = typeof(CustomTextBox);
			dataControl.planOdemeId = (CustomTextBox)Activator.CreateInstance(type);
			dataControl.planOdemeId.Location = new Point(locationX, _locationY + _asamaSiraNo * 35);
			dataControl.planOdemeId.Width = 0;
			dataControl.planOdemeId.Visible = false;
			dataControl.planOdemeId.Height = _controlHeight;
			locationX = locationX + dataControl.planOdemeId.Width + _spaceX;
			dataControl.planOdemeId.Name = "planOdemeId" + _asamaSiraNo.ToString("X");
			panelTahsilatAsama.Controls.Add(dataControl.planOdemeId);

			type = typeof(CustomTextBox);
			dataControl.odenenMiktar = (CustomTextBox)Activator.CreateInstance(type);
			dataControl.odenenMiktar.Location = new Point(locationX, _locationY + _asamaSiraNo * 35);
			dataControl.odenenMiktar.Width = 100;
			dataControl.odenenMiktar.Height = _controlHeight;
			KontrolOlayEkle(dataControl.odenenMiktar, type, "Leave", "TextBox_TextChanged"); //odenenMiktar textBox'ına ait TextChanged olayı eklenir.
			KontrolOlayEkle(dataControl.odenenMiktar, type, "KeyPress", "TextBox_KeyPress"); //odenemMiktar textBox'ına ait KeyPress olayı eklenir.
			dataControl.odenenMiktar.TextAlignment = HorizontalAlignment.Right;
			locationX = locationX + dataControl.odenenMiktar.Width + _spaceX;
			dataControl.odenenMiktar.Name = "odenenMiktar" + _asamaSiraNo.ToString("X");
			panelTahsilatAsama.Controls.Add(dataControl.odenenMiktar);

			type = typeof(CustomTextBox);
			dataControl.kalanMiktar = (CustomTextBox)Activator.CreateInstance(type);
			dataControl.kalanMiktar.Location = new Point(locationX, _locationY + _asamaSiraNo * 35);
			dataControl.kalanMiktar.Width = 100;
			dataControl.kalanMiktar.Height = _controlHeight;
			dataControl.kalanMiktar.TextAlignment = HorizontalAlignment.Right;
			dataControl.kalanMiktar.ReadOnly = true;
			locationX = locationX + dataControl.kalanMiktar.Width + _spaceX;
			dataControl.kalanMiktar.Name = "kalanMiktar" + _asamaSiraNo.ToString("X");
			KontrolOlayEkle(dataControl.kalanMiktar, type, "TextChanged", "TextBox_TextChanged"); //kalanMiktar textBox'ına ait TextChanged olayı eklenir.
			panelTahsilatAsama.Controls.Add(dataControl.kalanMiktar);

			type = typeof(Label);
			dataControl.labelUyari = (Label)Activator.CreateInstance(type);
			dataControl.labelUyari.Location = new Point(locationX, _locationY + _asamaSiraNo * 35);
			dataControl.labelUyari.Width = 150;
			dataControl.labelUyari.Height = _controlHeight;
			dataControl.labelUyari.Name = "labelUyari" + _asamaSiraNo.ToString("X");
			dataControl.labelUyari.ForeColor = Color.Red;
			dataControl.labelUyari.Font = new Font("Segoe UI Semibold", 9, FontStyle.Bold);
			dataControl.labelUyari.Text = "";
			panelTahsilatAsama.Controls.Add(dataControl.labelUyari);

			_dataControlList.Add(dataControl);

		}
		/// <summary>
		/// Form için gerekli veriler tek bir seferde çalıştırılır. Sonucunda 4 tablo döner. 
		/// [0] Plan ödeme tablosu
		/// [1] projeKodId  değeri
		/// [2] Tahsilat planı başlık bilgileri
		/// [3] Projeye ait aşama listesi
		/// </summary>
		/// <returns></returns>
		public async Task<string> VerileriAl()
		{
			//DateTime dateTime1 = DateTime.Now;
			//string webReturnValue = await WebMethods.GetTahsilatPlanDesign(_satisSiparis.siparisId);
			//byte[] bytes = JsonConvert.DeserializeObject<byte[]>(webReturnValue);
			//string returnValue = Encoding.UTF8.GetString(bytes);
			//tahsilatPlanData = JsonConvert.DeserializeObject<DataSet>(returnValue);
			return "";
		}
		/// <summary>
		/// Form üzerinde oluşturulan tahsilat planı aşamalarının kotrollerine ait değerler veritabanından okunan değerlerle doldurulur.
		/// </summary>
		private void AlanlariDoldur()
		{
			try
			{
				int j = 0; //PlanOdeme tablosundaki her kayıt için index değeri tanımlandı.
				foreach (DataRow dr in tahsilatPlanData.Tables[0].Rows) //PlanOdeme tablosundan gelen her bir satır için döngü oluşturuldu
				{
					if (j == _kayitSayisi) numericTahsilatAsamaSayisi.Value += 1; //Form üzerindeki mevcut satır sayısı kayıt sayısından az ise numeratör 1 artırılacak ve satır eklenecek.
					foreach (FieldInfo fieldInfo in typeof(DataControl).GetFields())
					{
						if (tahsilatPlanData.Tables[0].Columns.Contains(fieldInfo.Name))
						{
							Type fieldType = fieldInfo.FieldType; //Üzerine gelinen DataControl elemanının tipi alınıyor.
							if (fieldType.Name == "CustomComboListBox")
							{
								MethodInfo method;
								object[] parameters;
								if (fieldInfo.Name == "projeSafhaId")
								{
									method = fieldType.GetMethod("SelectDataRowId");
									parameters = new object[] { int.Parse(dr["ProjeSafhaId"].ToString()) };
									method.Invoke(fieldInfo.GetValue(_dataControlList[j]), parameters);
								}
								else
								{
									method = fieldType.GetMethod("SelectDataRowId");
									if (!string.IsNullOrEmpty(dr["OdemeSekliId"].ToString()))
									{
										parameters = new object[] { int.Parse(dr["OdemeSekliId"].ToString()) };
										method.Invoke(fieldInfo.GetValue(_dataControlList[j]), parameters);
									}
								}
							}
							if (fieldType.Name == "CustomTextBox")
							{
								if (dr.Table.Columns.Contains(fieldInfo.Name))
								{
									PropertyInfo property = fieldType.GetProperty("TextCustom");
									DateTime dateTime;
									DateTime.TryParse(dr[fieldInfo.Name].ToString(), out dateTime);
									string value;
									if (fieldInfo.Name.ToString().Contains("Tarih"))
									{
										value = (dateTime == DateTime.MinValue) ? null : dateTime.ToShortDateString();
									}
									else
									{
										value = dr[fieldInfo.Name].ToString();
									}
									property.SetValue(fieldInfo.GetValue(_dataControlList[j]), value);
								}
							}
							if (fieldType.Name == "RadioButton" && _KDVDahilMi == 0)
							{
								PropertyInfo property = fieldType.GetProperty("Checked");
								bool.TryParse(dr[fieldInfo.Name].ToString(), out bool value);
								property.SetValue(fieldInfo.GetValue(_dataControlList[j]), value);
							}
						}
					}
					j = j + 1;
				}
				_unsavedChanges = false;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		/// <summary>
		/// Dinamik olarak oluşturulan satır nesnelerine tanımlanmış olayların(keypress hariç) metodlarını bağlar.
		/// </summary>
		/// <param name="action"></param>
		/// <param name="i">index parametresidir</param>
		/// <returns></returns>
		public EventHandler GetEventHandler(string methodName)
		{
			Type type = this.GetType();
			MethodInfo methodInfo = type.GetMethod(methodName); // İstenen metodun MethodInfo nesnesini alır.

			if (methodInfo != null)
			{
				EventHandler handler = (EventHandler)Delegate.CreateDelegate(typeof(EventHandler), this, methodInfo);
				return handler;
			}
			else
			{
				return null;
			}
		}
		/// <summary>
		/// Dinamik olarak oluşturulan satır nesnelerine tanımlanmış keypress olaylarının metodlarını bağlar.
		/// </summary>
		/// <param name="methodName"></param>
		/// <returns></returns>
		public KeyPressEventHandler GetKeyPressEventHandler(string methodName)
		{
			Type type = this.GetType();
			MethodInfo methodInfo = type.GetMethod(methodName); // İstenen metodun MethodInfo nesnesini alır.

			if (methodInfo != null)
			{
				KeyPressEventHandler handler = (KeyPressEventHandler)Delegate.CreateDelegate(typeof(KeyPressEventHandler), this, methodInfo);
				return handler;
			}
			else
			{
				return null;
			}
		}
		/// <summary>
		/// Ödeme oranı ve ödenen miktar alanlarında değişiklik olursa, tutar ve kalan ödeme alanlarını günceller. 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void TextBox_TextChanged(dynamic sender, EventArgs e)
		{
			_unsavedChanges = true;
			string textCustom = sender.TextCustom;
			string strSender = sender.Name;
			int j = Convert.ToInt32(strSender[strSender.Length - 1].ToString(), 16); //Dinamik olarak eklenen kontrol isimlerinin son hanesi, ilgili satırın indexini temsil eder
			float satisTutari = CurrencyToFloat(textBoxSatisTutari.TextCustom.ToString());
			float odemeOrani = (!string.IsNullOrWhiteSpace(_dataControlList[j].odemeOrani.TextCustom)) ? float.Parse(_dataControlList[j].odemeOrani.TextCustom) : 0;
			float odenenMiktar = CurrencyToFloat(_dataControlList[j].odenenMiktar.TextCustom.ToString());
			float kdvTutar;
			if (customRadioButtonNetKdv.Checked)
			{
				kdvTutar = (_dataControlList[j].KDVMi.Checked) ? _satisSiparis.kdv.kdvOrani * satisTutari / 100 : 0;
			}
			else
			{
				kdvTutar = 0;
			}

			float tutar = satisTutari * odemeOrani / 100 + kdvTutar;
			_dataControlList[j].tutar.TextCustom = tutar.ToString("#,##0.00") + " " + _dovizBirimSembol;
			_dataControlList[j].odenenMiktar.TextCustom = odenenMiktar.ToString("#,##0.00") + " " + _dovizBirimSembol;
			_dataControlList[j].odenenMiktar.SelectionStart = _dataControlList[j].odenenMiktar.TextCustom.ToString().Length - ParaBirimUzunluk() - 1;
			_dataControlList[j].kalanMiktar.TextCustom = (tutar - odenenMiktar).ToString("#,##0.00") + " " + _dovizBirimSembol;
		}
		/// <summary>
		/// Forma eklenen kontrolllerin olaylarını kontrol nesnelerine ekler.
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="fieldType"></param>
		/// <param name="eventName"></param>
		/// <param name="methodName"></param>
		public void KontrolOlayEkle(Object obj, Type fieldType, string eventName, string methodName)
		{
			EventInfo eventInfo = fieldType.GetEvent(eventName);
			if (eventName == "TextChanged")
			{
				EventHandler handler = GetEventHandler(methodName);
				if (handler != null) eventInfo.AddEventHandler(obj, handler);
			}
			if (eventName == "Click")
			{
				EventHandler handler = GetEventHandler(methodName);
				if (handler != null) eventInfo.AddEventHandler(obj, handler);
			}
			if (eventName == "Leave")
			{
				EventHandler handler = GetEventHandler(methodName);
				if (handler != null) eventInfo.AddEventHandler(obj, handler);
			}
			if (eventName == "KeyPress")
			{
				KeyPressEventHandler handler = GetKeyPressEventHandler(methodName);
				if (handler != null) eventInfo.AddEventHandler(obj, handler);
			}
			if (eventName == "CheckedChanged")
			{
				EventHandler handler = GetEventHandler(methodName);
				if (handler != null) eventInfo.AddEventHandler(obj, handler);
			}
		}
		/// <summary>
		/// Sayısal alanlarda, her tuşa basışdığında girilen değerin sayısal olup olmadığı kontrol eder. Girilen değer rakam değilse hata uyarısı gösterir.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void TextBox_KeyPress(dynamic sender, KeyPressEventArgs e)
		{
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
			{
				CustomTextBox customTextBox = (CustomTextBox)sender;

				if (e.KeyChar.ToString() == ",")
				{
					if (customTextBox.TextCustom.Contains(","))
					{
						e.Handled = true; // Geçersiz karakterleri işlemle
						MessageBox.Show("Sadece rakamsal değerler girilmelidir!");
					}
				}
				else
				{
					e.Handled = true; // Geçersiz karakterleri işlemle
					MessageBox.Show("Sadece rakamsal değerler girilmelidir!");
				}
			}
		}
		/// <summary>
		/// Tarih alanında iken backspace tuşuna basıldığında alan üzerindeki değeri temizler.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void Date_KeyPress(dynamic sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == 8)
			{
				sender.TextCustom = null;
			}
		}
		/// <summary>
		/// Tutar sembolünün karakter uzunluğunu verir. Tutar sembolü "TL" ise 2 olarak değer döner.
		/// Bu değer textbox içinde para biriminin sembolünü göstermek için kullanılır.
		/// </summary>
		/// <returns></returns>
		private int ParaBirimUzunluk()
		{
			return _dovizBirimSembol.Length;
		}
		/// <summary>
		/// Tarih alanına tıklandığında monthcalendar nesnesini açar.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void DateClick(dynamic sender, EventArgs e)
		{
			monthCalendarTahsilatTarihi.Visible = true;
			monthCalendarTahsilatTarihi.SelectionStart = (sender.TextCustom != "") ? DateTime.Parse(sender.TextCustom) : DateTime.Now;
			monthCalendarTahsilatTarihi.SelectionEnd = (sender.TextCustom != "") ? DateTime.Parse(sender.TextCustom) : DateTime.Now;
			monthCalendarTahsilatTarihi.Location = new Point(sender.Location.X, sender.Location.Y + 25);
			_selectedTextBox = (CustomTextBox)sender;
		}
		/// <summary>
		/// Mouse monthcalendar nesnesinin üzerinden ayrılırsa monthcalendar nesnesi kapanır.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void monthCalendarTahsilatTarihi_MouseLeave(object sender, EventArgs e)
		{
			if (!monthCalendarTahsilatTarihi.Bounds.Contains(PointToClient(MousePosition)))
			{
				monthCalendarTahsilatTarihi.Visible = false;
			}
		}
		/// <summary>
		/// Monthcalendar nesnesinden tarih seçimi yapıldığında seçilen değer tarih alanına yazılır.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void monthCalendarTahsilatTarihi_DateSelected(object sender, DateRangeEventArgs e)
		{
			_selectedTextBox.TextCustom = e.Start.ToShortDateString();
			monthCalendarTahsilatTarihi.Visible = false;
			_selectedTextBox.Focus();
		}
		/// <summary>
		/// Textbox içinde para birimi sembolü ile saklanan değeri float cinsinden sayısal değere dönüştürür.
		/// </summary>
		/// <param name="currency"></param>
		/// <returns></returns>
		private float CurrencyToFloat(string currency)
		{
			float returnValue = 0;
			try
			{
				if (currency.Length > 0)
				{
					if (int.TryParse(currency[currency.Length - 1].ToString(), out int number))
					{
						returnValue = (!string.IsNullOrWhiteSpace(currency)) ? float.Parse(currency) : 0;
					}
					else
					{
						returnValue = (!string.IsNullOrWhiteSpace(currency.Substring(0, currency.Length - ParaBirimUzunluk()))) ? float.Parse(currency.Substring(0, currency.Length - ParaBirimUzunluk())) : 0;
					}
				}
				else { returnValue = 0; }
				return returnValue;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return returnValue;
			}
		}
		/// <summary>
		/// Bütün alanlardaki veriler doğru yazılmış mı kontrolünü yapar.
		/// Yanlış varsa alanın yanındaki label'larda uyarı mesajı olarak belirtilecek
		/// </summary>
		private bool CheckFields()
		{
			ClearFields();
			bool result = true;
			float toplam = 0;
			int j = 0;
			foreach (DataControl control in _dataControlList)
			{
				if (customRadioButtonNetKdv.Checked == true && _dataControlList[j].KDVMi.Checked == false)
				{
					result = false;
					labelOranVeKdvUyari.Text = "KDV alanı seçilmelidir!";
				}
				else
				{
					result = true;
					labelOranVeKdvUyari.Text = "";
					break;
				}
				j = j + 1;
			}
			j = 0;
			foreach (DataControl control in _dataControlList)
			{
				if (string.IsNullOrWhiteSpace(_dataControlList[j].odemeOrani.TextCustom))
				{
					_dataControlList[j].labelUyari.Text = "Ödeme oranı girilmelidir!";
					result = false;
				}
				if (_dataControlList[j].odemeSekliId.selectedDataRowValue == null)
				{
					_dataControlList[j].labelUyari.Text = "Ödeme şekli seçilmelidir!";
					result = false;
				}
				if (_dataControlList[j].projeSafhaId.selectedDataRowValue == null)
				{
					_dataControlList[j].labelUyari.Text = "Safha seçimi yapılmalıdır!";
					result = false;
				}
				toplam += int.TryParse(_dataControlList[j].odemeOrani.TextCustom.ToString(), out int odemeOrani) ? odemeOrani : 0;
				j += 1;
			}


			if (toplam != 100)
			{
				labelOranVeKdvUyari.Text = string.Format("Ödeme Oranları toplamı 100 olmalıdır. Toplam: {0}", toplam);
				result = false;
			}
			return result;
		}
		/// <summary>
		/// Tahsilat planını veritabanına kaydeder.
		/// </summary>
		/// <returns></returns>
		private async Task<string> TahsilatPlaniKaydet()
		{
			//try
			//{
			//	List<PlanOdeme> planOdemeList = new List<PlanOdeme>();
			//	planOdemeList = await GetCurrentPlanOdeme();
			//	await WebMethods.UpdatePlanOdeme(planOdemeList);
			//	await VerileriAl();
			//	AlanlariDoldur();

			//	MessageBox.Show("Kayıt başarılı");
			//}
			//catch (Exception ex)
			//{
			//	MessageBox.Show(ex.Message);
			//}
			return "";
		}
		private void CloseForm()
		{
			GlobalData.RemoveLastForm();
			_tahsilatPlanKayitFormu = null;
		}
		/// <summary>
		/// Satırlarda yer alan kdv radiobutton değerinde değişiklik olduğunda tutarları yeniden hesaplar.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void RadioButtonKdv_Changed(dynamic sender, EventArgs e)
		{
			_unsavedChanges = true;
			//string textCustom = sender.TextCustom;
			string strSender = sender.Name;
			int j = Convert.ToInt32(strSender[strSender.Length - 1].ToString(), 16); //Dinamik olarak eklenen kontrol isimlerinin son hanesi, ilgili satırı temsil eder
			float satisTutari = CurrencyToFloat(textBoxSatisTutari.TextCustom.ToString());
			float odemeOrani = (!string.IsNullOrWhiteSpace(_dataControlList[j].odemeOrani.TextCustom)) ? float.Parse(_dataControlList[j].odemeOrani.TextCustom) : 0;
			float odenenMiktar = CurrencyToFloat(_dataControlList[j].odenenMiktar.TextCustom.ToString());
			float kdvTutar = (_dataControlList[j].KDVMi.Checked) ? _satisSiparis.kdv.kdvOrani * satisTutari / 100 : 0;
			float tutar = satisTutari * odemeOrani / 100 + kdvTutar;
			_dataControlList[j].tutar.TextCustom = tutar.ToString("#,##0.00") + " " + _dovizBirimSembol;
			_dataControlList[j].odenenMiktar.TextCustom = odenenMiktar.ToString("#,##0.00") + " " + _dovizBirimSembol;
			_dataControlList[j].kalanMiktar.TextCustom = (tutar - odenenMiktar).ToString("#,##0.00") + " " + _dovizBirimSembol;
		}
		/// <summary>
		/// Proje safhalarının tanımlandığı grid formunu açar.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private async void roundedProjeSafhalari_Click(object sender, EventArgs e)
		{
			List<ProjeSafha> projeSafhalar = new List<ProjeSafha>();
			ProjeSafhaGridForm projeSafhaGridForm = ProjeSafhaGridForm.projeSafhaGridForm;
			projeSafhalar = await projeSafhaGridForm.GetSatisProjeSafhaList(_satisSiparis.satisProje.projeId);
			if(projeSafhaGridForm != null)
			{
                projeSafhaGridForm.UpdateMode(_satisSiparis.satisProje.projeId);
                projeSafhaGridForm.Show();
            }
		}
		/// <summary>
		/// Form üzerinde işlenmiş değerleri tahsilatPlani ve planOdeme nesnelerine atar.
		/// </summary>
		/// <returns></returns>
		//private async Task<List<PlanOdeme>> GetCurrentPlanOdeme()
		//{
		//	try
		//	{
		//		TahsilatPlani tahsilatPlani = new TahsilatPlani();
		//		tahsilatPlani.tahsilatPlaniId = _tahsilatPlaniId;
		//		tahsilatPlani.kdvDahilMi = (customRadioButtonToplam.Checked == true) ? true : false;
		//		tahsilatPlani.aciklamalar = textBoxAciklamalar.Text;
		//		tahsilatPlani.siparisId = _satisSiparis.siparisId;
		//		await WebMethods.SaveTahsilatPlani(tahsilatPlani);
		//		List<PlanOdeme> planOdemeList = new List<PlanOdeme>();
		//		foreach (DataControl control in _dataControlList)
		//		{
		//			PlanOdeme planOdeme = new PlanOdeme();
		//			planOdeme = new PlanOdeme();
		//			planOdeme.planOdemeId = (!string.IsNullOrWhiteSpace(control.planOdemeId.TextCustom)) ? int.Parse(control.planOdemeId.TextCustom) : 0;
		//			planOdeme.odemeOrani = (string.IsNullOrWhiteSpace(control.odemeOrani.TextCustom)) ? 0 : int.Parse(control.odemeOrani.TextCustom);
		//			planOdeme.odemeSekli = (OdemeSekli)control.odemeSekliId.selectedDataRowId;
		//			planOdeme.projeSafhaId = control.projeSafhaId.selectedDataRowId;
		//			planOdeme.vade = (string.IsNullOrWhiteSpace(control.vade.TextCustom)) ? 0 : int.Parse(control.vade.TextCustom);
		//			planOdeme.KDVMi = (_KDVDahilMi == 1) ? false : control.KDVMi.Checked;
		//			planOdeme.tahsilatGerceklestiMi = control.tahsilatGerceklestiMi.Checked;
		//			planOdeme.gerceklesmeTarihi = (!string.IsNullOrWhiteSpace(control.gerceklesmeTarihi.TextCustom)) ? DateTime.Parse(DateTime.Parse(control.gerceklesmeTarihi.TextCustom).ToShortDateString()) : DateTime.Parse(DateTime.MinValue.ToShortDateString());
		//			planOdeme.odenenMiktar = CurrencyToFloat(control.odenenMiktar.TextCustom);
		//			planOdeme.kalanMiktar = CurrencyToFloat(control.kalanMiktar.TextCustom);
		//			planOdeme.tahsilatPlaniId = _tahsilatPlaniId;
		//			planOdemeList.Add(planOdeme);
		//		}
		//		return planOdemeList;
		//	}
		//	catch (Exception ex)
		//	{
		//		MessageBox.Show(ex.Message);
		//		return null;
		//	}
		//}

		private async void rButtonKaydet_Click(object sender, EventArgs e)
		{
			if (CheckFields())
			{
				this.Enabled = false;
				await TahsilatPlaniKaydet();
				this.Enabled = true;
				UpdateMode(_satisSiparis);
			}
		}

		private void TahsilatPlanKayitFormu_FormClosing(object sender, FormClosingEventArgs e)
		{
			CloseForm();
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
	public class DataControl
    {
        public CustomTextBox planOdemeId;
        public CustomTextBox odemeOrani;
        public CustomComboListBox odemeSekliId;
        public CustomComboListBox projeSafhaId;
        public CustomTextBox vade;
        public RadioButton KDVMi;
        public CheckBox tahsilatGerceklestiMi;
        public CustomTextBox gerceklesmeTarihi;
        public CustomTextBox odenenMiktar;
        public CustomTextBox kalanMiktar;
        public CustomTextBox tutar;
        public Label labelUyari;
    }
}
