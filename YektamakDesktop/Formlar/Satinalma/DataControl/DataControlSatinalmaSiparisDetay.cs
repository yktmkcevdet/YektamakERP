using YektamakDesktop.CustomControls;
using Models;
using ApiService;
using System.Data;
using Utilities.Implementations;
using Utilities.Interfaces;

namespace YektamakDesktop.Formlar.Satinalma.DataControl
{
    public class DataControlSatinalmaSiparisDetay: Abstracts.DataControl, IEntity
    {
        public CustomTextBox satinalmaSiparisDetayId { get; set; }
        public CustomTextBox satinalmaSiparisId {  get; set; }
        private CustomComboListBox _stokKartId;
        public CustomComboListBox stokKartId 
        {
            get {  return _stokKartId; }
            set 
            {
                _stokKartId = value;
                
                IJsonConvertHelper jsonConverter = new JsonConvertHelper();
                DataSet dataSet = jsonConverter.JsonStringToDataSet(WebMethods.GetStokKart());
                FillComboBoxListFromDataSet(_stokKartId, dataSet);
            }
        }
        public CustomTextBoxSayisal miktar {  get; set; }
        public CustomTextBoxSayisal birimFiyat { get; set; }
        private CustomComboListBox _dovizCinsiId;
        public CustomComboListBox dovizCinsiId 
        { get { return _dovizCinsiId; } 
            set 
            {
                _dovizCinsiId = value;
            } 
        }
        public DataControlSatinalmaSiparisDetay()
        {
            satinalmaSiparisDetayId = new CustomTextBox() { TabIndex = 1, Width = 0, Visible = true, Tag = "DetayID ", Location = new System.Drawing.Point(6, 0) };
            satinalmaSiparisId = new CustomTextBox() { TabIndex = 2, Width = 0, Visible = true, Tag = "SiparisID ", Location = new System.Drawing.Point(6, 0) };
            stokKartId=new CustomComboListBox() { TabIndex = 3, Width = 250, Visible = true, Tag = "Stok Kartı ", Location = new System.Drawing.Point(106, 0) };
            miktar=new CustomTextBoxSayisal() { TabIndex = 4, Width = 100, Visible = true, Tag = "Miktar", OndalikBasamak=0,Location = new System.Drawing.Point(206, 0) };
            birimFiyat=new CustomTextBoxSayisal() { TabIndex = 5, Width = 100, Visible = true, Tag = "Br. Fiyat", Location = new System.Drawing.Point(306, 0) };
            dovizCinsiId=new CustomComboListBox() { TabIndex = 6, Width = 100, Visible = true, Tag = "Dvz Cinsi", Location = new System.Drawing.Point(406, 0) };
            //GlobalData.ComboDovizCinsi(_dovizCinsiId);
        }
    }
}
