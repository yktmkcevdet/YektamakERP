using YektamakDesktop.CustomControls;
using Models;
using ApiService;
using System;
using System.Data;
using Utilities.Implementations;
using Utilities.Interfaces;

namespace YektamakDesktop.Formlar.Satinalma.DataControl
{
    public class DataControlSatinalmaFaturaDetay: Abstracts.DataControl, IEntity
    {
        public static int firmaId;
        public static int dovizid;
        public CustomTextBox satinalmaFaturaDetayId { get; set; }
        public CustomTextBox satinalmaFaturaId { get; set; }
        private CustomComboListBox _satinalmaSiparisId;
        public CustomComboListBox satinalmaSiparisId
        {
            get { return _satinalmaSiparisId; ; }
            set
            {
                _satinalmaSiparisId = value;
            }
        }
        public CustomTextBox firma { get; set; } 
        public CustomTextBoxSayisal miktar { get; set; }
        public CustomTextBoxSayisal birimFiyat { get; set; }
        private CustomComboListBox _dovizCinsiId;
        public CustomComboListBox dovizCinsiId
        {
            get { return _dovizCinsiId; }
            set
            {
                _dovizCinsiId = value;
            }
        }
        public DataControlSatinalmaFaturaDetay()
        {
            satinalmaFaturaDetayId = new CustomTextBox() { TabIndex = 1, Width = 0, Visible = true, Tag = "DetayID ", Location = new System.Drawing.Point(6, 0) };
            satinalmaFaturaId = new CustomTextBox() { TabIndex = 2, Width = 0, Visible = true, Tag = "FaturaID ", Location = new System.Drawing.Point(6, 0) };
            firma = new CustomTextBox() { TabIndex = 2, Width = 100, Visible = true, Tag = "Firma ", Location = new System.Drawing.Point(6, 0), isMandatory = true };
            satinalmaSiparisId = new CustomComboListBox() { TabIndex = 3, Width = 250, Visible = true, Tag = "Sipariş ", Location = new System.Drawing.Point(106, 0) };
            miktar = new CustomTextBoxSayisal() { TabIndex = 4, Width = 100, Visible = true, Tag = "Miktar", OndalikBasamak = 0, Location = new System.Drawing.Point(206, 0) };
            birimFiyat = new CustomTextBoxSayisal() { TabIndex = 5, Width = 100, Visible = true, Tag = "Br. Fiyat", Location = new System.Drawing.Point(306, 0) };
            dovizCinsiId = new CustomComboListBox() { TabIndex = 6, Width = 100, Visible = true, Tag = "Dvz Cinsi", Location = new System.Drawing.Point(406, 0) };
            //GlobalData.ComboDovizCinsi(_dovizCinsiId);
            dovizCinsiId.SelectDataRowId(dovizid);
            SatinalmaSiparis satinalmaSiparis = new();
            satinalmaSiparis.firma.id = firmaId;
            satinalmaSiparis.tutar.dovizCinsi.id=dovizid;
            string result = WebMethods.GetFilteredSatinalmaSiparis(satinalmaSiparis);
            
            IJsonConvertHelper jsonConverter = new JsonConvertHelper();
            DataSet dataSet = jsonConverter.JsonStringToDataSet(result);
            satinalmaSiparis = GlobalData.GetModelFromDatabase(WebMethods.GetFilteredSatinalmaSiparis, satinalmaSiparis);
            
            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                satinalmaSiparisId.AddDataRow(Convert.ToInt32(dataRow["satinalmaSiparisId"].ToString()),dataRow["projeKod_projeKodString"].ToString()+" - " + dataRow["talepTip_talepTipi"].ToString());
            }
        }
    }
}
