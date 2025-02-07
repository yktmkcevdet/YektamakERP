using YektamakDesktop.CustomControls;
using FontAwesome.Sharp;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using static YektamakDesktop.GlobalData;

namespace YektamakDesktop.Formlar.Satinalma.DataControl
{
    public class DataControlTalep : Abstracts.DataControl, IEntity
    {
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

        private CustomTextBox _aciklama;
        public CustomTextBox aciklama
        {
            get => _aciklama;
            set
            {
                _aciklama = value;

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
        private RoundedIconButton _roundedButton;
        public RoundedIconButton roundedButton
        {
            get=>_roundedButton;
            set
            {
                _roundedButton = value;
                _roundedButton.Click += RoundedIconButton_Click;
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

        public DataControlTalep()
        {
            stokKartId = new CustomComboListBox { TabIndex = 1, Width = 200, Tag = "Stok Kodu", Location = new System.Drawing.Point(6, 0) };
            parcaAdi = new CustomTextBox { TabIndex = 2, Width = 150, Tag = "Stok Adı", Location = new System.Drawing.Point(213, 0) };
            setMiktar = new CustomTextBoxSayisal { TabIndex = 4, OndalikBasamak = 2, Width = 70, Tag = "Miktar", Location = new System.Drawing.Point(477, 0) };
            aciklama = new CustomTextBox { TabIndex = 7, Width = 100, Tag = "Açıklama", Location = new System.Drawing.Point(738, 0) };
            satinalmaTalepDetayId = new CustomTextBox { TabIndex = 8, Width = 0, Visible = false, Tag = "Detay Id", Location = new System.Drawing.Point(952, 0) };
            satinalmaTalepBaslikId = new CustomTextBox { TabIndex = 9, Width = 0, Visible = false, Tag = "Başlık Id", Location = new System.Drawing.Point(952, 0) };
            roundedButton = new RoundedIconButton { TabIndex = 10, Width = 50, Height=30,Tag = "Excel",IconChar=IconChar.FileExcel,IconFont=IconFont.Solid,IconSize=25,BackColor=System.Drawing.Color.Transparent,ForeColor=System.Drawing.Color.WhiteSmoke,FlatStyle=System.Windows.Forms.FlatStyle.Flat };
        }
        private void CustomComboListBoxStokKartId_SelectedIndexChange(object sender, EventArgs e)
        {
            CustomComboListBox customComboListBox = (CustomComboListBox)sender;
            StokKart stokKart = new StokKart();
            //stokKart = stokKartList.SingleOrDefault(x => x.Id == _stokKartId.selectedDataRowId);
            _parcaAdi.TextCustom = stokKart.ad;
        }
        private void RoundedIconButton_Click(object sender, EventArgs e)
        {
            SatinalmaTalepFormuDetay satinalmaTalepFormuDetay=SatinalmaTalepFormuDetay.satinalmaTalepFormuDetay;
            if(satinalmaTalepFormuDetay!=null)
            satinalmaTalepFormuDetay.Show();
        }
    }
}
