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
		private readonly IDataTableConverter dataTableConverter;
		private readonly IJsonConvertHelper jsonConverter;

		public bool newRec = true;
		private RoundedButton _buttonSil;
		public RoundedButton buttonSil
		{
			get => _buttonSil;
			set
			{
				_buttonSil = value;
				_buttonSil.Tag = "  Sil";
				_buttonSil.Width = 35;
				_buttonSil.Height = 28;
				_buttonSil.TabIndex = 99;
				_buttonSil.BorderRadius = 5;
				_buttonSil.BackColor = Color.Transparent;
				_buttonSil.BackgroundImage = Resources.delete_icon;
				_buttonSil.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
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
			buttonSil = new RoundedButton();
			order=new Label();
		}

        public DataControl(IDataTableConverter dataTableConverter, IJsonConvertHelper jsonConverter)
        {
            this.dataTableConverter = dataTableConverter;
            this.jsonConverter = jsonConverter;
        }

        public List<T> ListEntity<T>(Func<T, string> method) where T : IEntity,new()
		{
			T filterData = new T();
			string result = method(filterData);
			DataSet dataSet = jsonConverter.JsonStringToDataSet(result);
			List<T> listEntity = new List<T>();
			foreach (DataRow dataRow in dataSet.Tables[0].Rows)
			{
				T entity = new T();
				entity = dataTableConverter.DataRowToModel<T>(dataRow);
				listEntity.Add(entity);
			}
			return listEntity;
		}
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
