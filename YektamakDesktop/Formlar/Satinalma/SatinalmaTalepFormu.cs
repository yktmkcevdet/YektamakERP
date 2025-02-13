using Domain.Models.Models;
using FastReport;
using YektamakDesktop.CustomControls;
using YektamakDesktop.Formlar.Ortak;
using YektamakDesktop.Formlar.Satinalma.DataControl;
using Models;
using ApiService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities.Interfaces;
using Utilities.Implementations;

namespace YektamakDesktop.Formlar.Satinalma
{
    public partial class SatinalmaTalepFormu : Form, IForm
	{
		private readonly ICache _cache;
        private string filePath;
		private WebMethods _webMethods;
		public CustomDataGrid<DataControlTalepDetay> customDataGrid;

		private static SatinalmaTalepFormu _satinalmaTalepFormu;

        public static SatinalmaTalepFormu satinalmaTalepFormu 
		{ 
			get 
			{ 
				if (_satinalmaTalepFormu == null) 
				{
					_satinalmaTalepFormu = new SatinalmaTalepFormu(new Cache(new JsonConvertHelper(), new DataTableHelper())); 
					GlobalData.Yetki(ref _satinalmaTalepFormu); 
				}
				return _satinalmaTalepFormu; 
			} 
			set 
			{ 
				_satinalmaTalepFormu = value; 
			} 
		}

		private List<Control> _controlsToDisable;
		public List<Control> controlsToDisable { get { if (_controlsToDisable == null) { _controlsToDisable = new List<Control>(); } return _controlsToDisable; } set { _controlsToDisable = value; } }
		private int satinalmaTalepBaslikId;
		public bool activeForm { get; set; }
		private ToolTip toolTip;
		private void SetToolTips()
		{
			toolTip = new ToolTip();
			toolTip.ToolTipTitle = "Excelden Veri Al";
			toolTip.SetToolTip(btnExceldenAktar, "Satınalma taleplerini excelden aktarma formunu açar.");
			toolTip.ToolTipIcon = ToolTipIcon.Info;
			toolTip.AutoPopDelay = 20000;
		}
		public SatinalmaTalepFormu(ICache cache)
		{
            _cache = cache;
            InitializeComponent();
            FillComboLists();
            customDataGrid = new CustomDataGrid<DataControlTalepDetay>(2, 34, new Point(12, 374), new Size(1154, 300));
			this.Controls.Add(customDataGrid.headerPanel);
			this.Controls.Add(customDataGrid.detailPanel);
		}

        public SatinalmaTalepFormu(WebMethods webMethods)
        {
            _webMethods = webMethods;
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

		private void CloseForm()
		{
			Close();
			GlobalData.RemoveLastForm();
			_satinalmaTalepFormu = null;
		}
		private void buttonClose_Click(object sender, EventArgs e)
		{
			CloseForm();
		}
		private void button1_Click(object sender, EventArgs e)
		{
			ExceldenVeriAlmaFormu exceldenVeriAlmaFormu = ExceldenVeriAlmaFormu.exceldenVeriAlmaFormu;
			if(exceldenVeriAlmaFormu != null)
			{
                exceldenVeriAlmaFormu.Show();
            }
        }
		private void FillComboLists()
		{
			//foreach (Kullanici kullanici in GlobalData.kullaniciList)
			//{
			//	comboListBoxTalepEden.AddDataRow(kullanici.Id, kullanici.ad);
			//}
			comboListBoxTalepEden.SelectDataRowId(_cache.kullanici.Id);

            
            IJsonConvertHelper jsonConverter = new JsonConvertHelper();
            DataSet dataSet = jsonConverter.JsonStringToDataSet(_webMethods.GetAllAssignedProjeKod());
            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
			{
                comboListBoxProjeKodu.AddDataRow(int.Parse(dataRow["ProjeKodId"].ToString()), dataRow["kod"].ToString());
			}
			dataSet = jsonConverter.JsonStringToDataSet(_webMethods.GetTalepTipleri());
			foreach (DataRow dataRow in dataSet.Tables[0].Rows)
			{
				comboListBoxTalepTipi.AddDataRow(int.Parse(dataRow["TalepTipId"].ToString()), dataRow["TalepTipi"].ToString());
			}
		}
		public async Task GenerateReport()
		{
			Report report = new Report();
			string path = "Reports/CariEkstre.frx";
			report.Load(path);
			List<CariHareketler> cariHareketler = new List<CariHareketler>();
            
            IJsonConvertHelper jsonConverter = new JsonConvertHelper();
            DataSet dataSet = jsonConverter.JsonStringToDataSet(await _webMethods.GetCariHesapEkstresi());
			foreach (DataRow dataRow in dataSet.Tables[0].Rows)
			{
				CariHareketler cariHareketler1 = new CariHareketler();
				cariHareketler1.FaturaTarihi = Convert.ToDateTime(dataRow["FaturaTarihi"].ToString());
				cariHareketler1.VadeTarihi = Convert.ToDateTime(dataRow["VadeTarihi"].ToString());
				cariHareketler1.FisDurumu = dataRow["FisDurumu"].ToString();
				cariHareketler1.Aciklama = dataRow["Aciklama"].ToString();
				cariHareketler1.BorcTutari = float.TryParse(dataRow["BorcTutari"].ToString(), out float bocTutari) ? bocTutari : 0;
				cariHareketler1.AlacakTutari = float.TryParse(dataRow["AlacakTutari"].ToString(), out float alacakTutari) ? alacakTutari : 0;
				cariHareketler.Add(cariHareketler1);
			}
			report.SetParameterValue("parameter", "deneme 3");
			report.SetParameterValue("parameter1", "deneme 4");
			report.RegisterData(cariHareketler, "CariEkstre");

			if (report.Report.Prepare())
			{
				FastReport.Export.PdfSimple.PDFSimpleExport export = new FastReport.Export.PdfSimple.PDFSimpleExport();
				export.ShowProgress = false;
				export.Subject = "Sub";
				export.Title = "ttl";
				MemoryStream ms = new MemoryStream();
				filePath = "Reports/report.pdf";
				report.Report.Export(export, filePath);
				report.Dispose();
				ms.Position = 0;
			}

		}

		private void button2_Click(object sender, EventArgs e)
		{
			GenerateReport();
			PdfGoruntuleme pdfGoruntuleme = PdfGoruntuleme.pdfGoruntuleme;
			if(pdfGoruntuleme != null)
			{
                pdfGoruntuleme.pdfFilePath = filePath;
                pdfGoruntuleme.Show();
            }
		}
        
        private bool CheckFields()
		{
			bool result = true;
            GlobalData.ClearWarningLabels(this);
            result = GlobalData.CheckField("Talep Tarihi girilmelidir!",this,textBoxTalepTarihi)?result:false;
            result = GlobalData.CheckField("Proje Kodu seçilmelidir!", this, comboListBoxProjeKodu)?result:false;
			if (result)
			{
				if(customDataGrid.dataSource.Count > 1)
				{
					result = true;
				}
				else
				{
					MessageBox.Show("Detaya kayıt girilmediği için satınalma talebi kaydedilemez!");
					result = false;
				} 
			}
            return result;
		}

		private async void btnKaydet_Click(object sender, EventArgs e)
		{
			if (!CheckFields()) return;
			SatinalmaTalepBaslik satinalmaTalepBaslik = new SatinalmaTalepBaslik();
			satinalmaTalepBaslik.Id = satinalmaTalepBaslikId;
			satinalmaTalepBaslik.talepTarihi = DateTime.TryParse(textBoxTalepTarihi.TextCustom, out DateTime talepTarihi) ? talepTarihi : DateTime.MinValue;
			satinalmaTalepBaslik.proje.Id = comboListBoxProjeKodu.selectedDataRowId;
			satinalmaTalepBaslik.talepEdenKullaniciId = comboListBoxTalepEden.selectedDataRowId;
			satinalmaTalepBaslik.talepTip.talepTipId = comboListBoxTalepTipi.selectedDataRowId;

			foreach (DataControlTalepDetay dataControlTalep in customDataGrid.dataSource)
			{
				if (!dataControlTalep.newRec)
				{
					SatinalmaTalepDetay satinalmaTalepDetay = new SatinalmaTalepDetay();
					satinalmaTalepDetay.id = int.TryParse(dataControlTalep.satinalmaTalepDetayId.TextCustom, out int satinalmaTalepDetayId) ? satinalmaTalepDetayId : 0;
					satinalmaTalepDetay.stokKart.Id = dataControlTalep.stokKartId.selectedDataRowId;
					satinalmaTalepDetay.aciklama = dataControlTalep.aciklama.TextCustom;
					//satinalmaTalepBaslik.satinalmaTalepDetay.Add(satinalmaTalepDetay);
				}
			}
            
            IJsonConvertHelper jsonConverter = new JsonConvertHelper();
            satinalmaTalepBaslikId = Convert.ToInt32(jsonConverter.JsonStringToDataSet((WebMethods.SaveSatinalmaTalep(satinalmaTalepBaslik))).Tables[0].Rows[0]["SatinalmaTalepBaslikId"]);
			satinalmaTalepBaslik.Id = satinalmaTalepBaslikId;
			DataSet dataSet = jsonConverter.JsonStringToDataSet((await WebMethods.GetSatinalmaTalep(satinalmaTalepBaslik)));
			List<DataControlTalepDetay> satinalmaTalepDetayList = new List<DataControlTalepDetay>();
			for (int i = 0; i < dataSet.Tables[1].Rows.Count; i++)
			{
				DataRow dataRow = dataSet.Tables[1].Rows[i];
				customDataGrid.dataSource[i].satinalmaTalepDetayId.TextCustom = dataRow["SatinalmaTalepDetayId"].ToString();
			}
		}

		private void SatinalmaTalepFormu_Paint(object sender, PaintEventArgs e)
		{

		}

		private void button1_Paint(object sender, PaintEventArgs e)
		{
			SetToolTips();
		}
		public async Task UpdateMode(SatinalmaTalepBaslik satinalmaTalepBaslik)
		{
            IJsonConvertHelper jsonConverter = new JsonConvertHelper();
            satinalmaTalepBaslikId = satinalmaTalepBaslik.Id;
			textBoxTalepTarihi.TextCustom = satinalmaTalepBaslik.talepTarihi.ToString("dd.MM.yyyy");
			comboListBoxProjeKodu.SelectDataRowId(satinalmaTalepBaslik.proje.Id);
			comboListBoxTalepTipi.SelectDataRowId(satinalmaTalepBaslik.talepTip.talepTipId);
			DataSet dataSet = jsonConverter.JsonStringToDataSet(await WebMethods.GetSatinalmaTalep(satinalmaTalepBaslik));
            List<DataControlTalepDetay> satinalmaTalepDetayList = new List<DataControlTalepDetay>();
			
            for (int i=0;i<dataSet.Tables[1].Rows.Count;i++)
            {
				DataRow dataRow = dataSet.Tables[1].Rows[i];
                satinalmaTalepDetayList.Add(Common.ConvertHelper.DataRowToModel<DataControlTalepDetay>(dataRow));
				satinalmaTalepDetayList[i].newRec = false;
            }
			customDataGrid.dataSource = satinalmaTalepDetayList;
        }

    }



}
