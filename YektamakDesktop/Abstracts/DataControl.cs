using ApiService.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Utilities.Interfaces;
using YektamakDesktop.CustomControls;
using YektamakDesktop.Properties;

namespace YektamakDesktop.Abstracts
{
    public class DataControl:IDisposable
	{
        public bool newRec = true;
		private RoundedIconButton _buttonSil;
		public RoundedIconButton buttonSil
		{
			get => _buttonSil;
			set
			{
				_buttonSil = value;
				_buttonSil.Tag = "Sil";
				_buttonSil.Width = 35;
				_buttonSil.Height = 28;
				_buttonSil.TabIndex = 99;
				_buttonSil.CornerRadius = 5;
				_buttonSil.BackColor = Color.Transparent;
				_buttonSil.BackgroundImage = Resources.sil;
				_buttonSil.BackgroundImageLayout = ImageLayout.Zoom;
				_buttonSil.Cursor = Cursors.Hand;
            }
		}
		private Label _order;
		public Label order 
		{
			get => _order;
			set
			{
				_order = value;
				_order.Enabled = false;
				_order.Width = 40;
				_order.Height = 28;
				_order.TabIndex = 0;
				_order.Tag = "No";
			}
		}
		public DataControl()
		{
			buttonSil = new RoundedIconButton();
			order=new Label();
		}


  //      public List<T> ListEntity<T>(Func<T, string> method) where T : IEntity,new()
		//{
		//	T filterData = new T();
		//	string result = method(filterData);
  //          List<T> listEntity = _jsonConverter.DeserializeToModelList<T>(result);
		//	return listEntity;
		//}
		public virtual void FillComboBoxListFromDataSet(CustomComboListBox customComboListBox, DataSet dataSet)
		{
			if (dataSet != null)
			{
				foreach (DataRow row in dataSet.Tables[0].Rows)
				{
					customComboListBox.AddDataRow(Convert.ToInt32(row[0].ToString()), row[1].ToString());
				}
			}
		}
        public void Dispose()
        {
            
        }
    }
}
