using YektamakDesktop.CustomControls;
using Models;
using ApiService;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using Utilities.Implementations;
using Utilities.Interfaces;

namespace YektamakDesktop.Formlar.Satinalma.DataControl
{
    public class DataControlTalepDetay : Abstracts.DataControl,IEntity
	{
        public CustomTextBox _filePath;
        public CustomTextBox filePath { get => _filePath; set { _filePath = value; } }
        private CustomTextBox _parcaAdi;
		public CustomTextBox parcaAdi
		{
			get => _parcaAdi;
			set
			{
				_parcaAdi = value;
			}
		}
		private CustomTextBoxSayisal _setMiktar;
		public CustomTextBoxSayisal setMiktar
		{
			get => _setMiktar;
			set
			{
				_setMiktar = value;
			}
		}

		private CustomTextBoxSayisal _xSetMiktar;
		public CustomTextBoxSayisal xSetMiktar
		{
			get => _xSetMiktar;
			set
			{
				_xSetMiktar = value;
			}
		}

		private CustomTextBox _boyut;
		public CustomTextBox boyut
		{
			get => _boyut;
			set
			{
				_boyut = value;
			}
		}

		private CustomTextBox _aciklama;
		public CustomTextBox aciklama
		{
			get => _aciklama;
			set
			{
				_aciklama = value;
			
			}
		}

		private CustomTextBoxSayisal _agirlik;
		public CustomTextBoxSayisal agirlik
		{
			get => _agirlik;
			set
			{
				_agirlik = value;
			}
		}
		private CustomTextBox _satinalmaTalepDetayId;
		public CustomTextBox satinalmaTalepDetayId
		{
			get => _satinalmaTalepDetayId;
			set
			{
				_satinalmaTalepDetayId = value;
			}
		}
        private CustomTextBox _satinalmaTalepBaslikId;
        public CustomTextBox satinalmaTalepBaslikId
        {
            get => _satinalmaTalepBaslikId;
            set
            {
                _satinalmaTalepBaslikId = value;
            }
        }

		private CustomComboListBox _malzemeId;
		public CustomComboListBox malzemeId
		{
			get => _malzemeId;
			set
			{
				_malzemeId = value;
				string jsonString = WebMethods.GetMalzeme(new Malzeme());
                
                IJsonConvertHelper jsonConverter = new JsonConvertHelper();
                DataSet dataSet = jsonConverter.JsonStringToDataSet(jsonString);
                FillComboBoxListFromDataSet(_malzemeId, dataSet);
			}
		}
		private CustomComboListBox _stokKartId;
		public CustomComboListBox stokKartId
		{
			get => _stokKartId;
			set
			{
				_stokKartId = value;
				_stokKartId.SelectedIndexChanged += CustomComboListBoxStokKartId_SelectedIndexChange;
				//FillComboBoxList(_stokKartId, stokKartList);
			}
		}
		private void FillComboBoxList(CustomComboListBox customComboListBox, List<StokKart> stokKartList)
		{
			if (stokKartList != null)
			{
				foreach (StokKart stokKart in stokKartList)
				{
					customComboListBox.AddDataRow(stokKart.Id, stokKart.kod);
				}
			}
		}

		public DataControlTalepDetay()
		{
            filePath = new CustomTextBox { TabIndex = 10, Width = 0, Visible = true, Tag = "Dosya Yolu", Location = new System.Drawing.Point(952, 0) };
            stokKartId = new CustomComboListBox { TabIndex = 1, Width = 200, Tag = "Kod",Location=new System.Drawing.Point(6,0) };
			parcaAdi = new CustomTextBox { TabIndex=2,Width=150,Tag="Parça Adı", Location = new System.Drawing.Point(213, 0) };
			malzemeId = new CustomComboListBox { TabIndex = 3, Width = 100, Tag = "Malzeme Id", Location = new System.Drawing.Point(370, 0) };
			setMiktar = new CustomTextBoxSayisal { TabIndex=4,OndalikBasamak = 2, Width = 70,Tag="1 SET Adet", Location = new System.Drawing.Point(477, 0) };
			xSetMiktar = new CustomTextBoxSayisal { TabIndex = 5, OndalikBasamak = 2,Width= 70,Tag= "X SET Adet", Location = new System.Drawing.Point(554, 0) };
			boyut = new CustomTextBox { TabIndex = 6,Width=100,Tag= "Boyut (mm)", Location = new System.Drawing.Point(631, 0) };
			aciklama = new CustomTextBox { TabIndex = 7,Width=100,Tag="Açıklama", Location = new System.Drawing.Point(738, 0) };
			agirlik = new CustomTextBoxSayisal { TabIndex = 8,Width=100, OndalikBasamak = 2,Tag= "Ağırlık (kg)", Location = new System.Drawing.Point(845, 0) };
			satinalmaTalepDetayId = new CustomTextBox{ TabIndex = 8,Width=0,Visible=false,Tag="Detay Id", Location = new System.Drawing.Point(952, 0) };
            satinalmaTalepBaslikId = new CustomTextBox { TabIndex = 9, Width = 0, Visible = false, Tag = "Başlık Id", Location = new System.Drawing.Point(952, 0) };
        }

		public async void CustomComboListBoxStokKartId_SelectedIndexChange(object sender, EventArgs e)
		{
			CustomComboListBox customComboListBox = (CustomComboListBox)sender;
			bool isExistStokKart = customComboListBox.listBoxDataRows.Any(x => x.value == customComboListBox.textBox.TextCustom);
			if (!isExistStokKart)
			{
				StokKart stokKart = new StokKart();
				//stokKart.proje.malzemeId = _malzemeId.selectedDataRowId;
				//stokKart.proje.malzemeKodu = _malzemeId.textBox.TextCustom;
				stokKart.kod = customComboListBox.textBox.TextCustom;
				stokKart.ad = _parcaAdi.TextCustom;
				stokKart.boyut = _boyut.TextCustom;
				if (File.Exists(filePath.TextCustom + "\\" + stokKart.kod + ".pdf"))
				{
					stokKart.pdf = File.ReadAllBytes(filePath.TextCustom + "\\" + stokKart.kod + ".pdf");
				}
                if (File.Exists(filePath.TextCustom + "\\" + stokKart.kod + ".dxf"))
                {
                    stokKart.pdf = File.ReadAllBytes(filePath.TextCustom + "\\" + stokKart.kod + ".dxf");
                }
                if (File.Exists(filePath.TextCustom + "\\" + stokKart.kod + ".step"))
                {
                    stokKart.pdf = File.ReadAllBytes(filePath.TextCustom + "\\" + stokKart.kod + ".step");
                }
                if (stokKart.kod != "")
				{
                    IDataTableConverter dataTableConverter = new DataTableConverter();
                    IJsonConvertHelper jsonConverter = new JsonConvertHelper();
                    DataSet stokKartDataSet = jsonConverter.JsonStringToDataSet(await WebMethods.SaveStokKart(stokKart));
					if (stokKartDataSet != null)
					{
						stokKart = dataTableConverter.DataRowToModel<StokKart>(stokKartDataSet.Tables[0].Rows[0]);
						//stokKartList.Add(stokKart);
						FillComboBoxListFromDataSet(_stokKartId, stokKartDataSet);
						_stokKartId.SelectDataRowId(stokKart.Id);
						/*if (!malzemeList.Any(x => x.malzemeId == stokKart.proje.malzemeId))
						{
							malzemeList.Add(stokKart.proje);
						}
						_malzemeId.SelectDataRowId(stokKart.proje.malzemeId);*/
					}
				}
			}
			else
			{
				StokKart stokKart = new StokKart();
				//stokKart = stokKartList.SingleOrDefault(x => x.Id == _stokKartId.selectedDataRowId);
				//_malzemeId.SelectDataRowId(stokKart.proje.malzemeId);
				_boyut.TextCustom = stokKart.boyut;
				_parcaAdi.TextCustom = stokKart.ad;
			}
		}

	}
}
