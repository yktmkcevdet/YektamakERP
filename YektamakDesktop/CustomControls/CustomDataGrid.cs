using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace YektamakDesktop.CustomControls
{
    /// <summary>
    /// User controlleri içerebilen datagrid şeklinde bir görünüm oluşturur.
    /// Form üzerinde oluşturulan bir panel üzerine yerleştirilir.
    /// </summary>
    public class CustomDataGrid<T> : IDisposable where T : Abstracts.DataControl,new()
    {
        int orderNr = 1;
        List<Control> listControl = new List<Control>();
        private List<T> _dataSource;
        public List<T> dataSource
        {
            get
            {
                if (_dataSource == null) { _dataSource = new List<T>(); }
                return _dataSource;
            }
            set
            {
                _dataSource = value;
                
                FillDataRows();
            }
        }
        int controlPointY;
        int _columnSpace;
        int _rowSpace;
        public Point _headerLocation;
        public Size _detailSize;
		private Panel _detailPanel;
		public Panel detailPanel
		{
			get
			{
				if (_detailPanel == null)
				{
					_detailPanel = new Panel();
					_detailPanel.Location = new Point(_headerLocation.X, _headerLocation.Y + headerPanel.Height);
					_detailPanel.Size = _detailSize;
					_detailPanel.AutoScroll = true;
					_detailPanel.Scroll += DetailPanel_Scroll;
					AddDataRow(new T());
				}
				return _detailPanel;
			}
			set
			{
				_detailPanel = value;
			}
		}
		private Panel _headerPanel;
        public Panel headerPanel
        {
            get
            {
                if (_headerPanel == null)
                {
                    _headerPanel = new Panel();
                    _headerPanel.Location = _headerLocation;
                    _headerPanel.Size = new Size(_detailSize.Width, 30);
                    //CreateLabels();
                }
                return _headerPanel;
            }
            set
            {
                _headerPanel = value;
            }
        }
        
        public CustomDataGrid(int columnSpace, int rowSpace, Point headerLocation, Size detailSize)
        {
            _columnSpace = columnSpace;
            _rowSpace = rowSpace;
            _headerLocation = headerLocation;
            _detailSize = detailSize;
        }
        private void DetailPanel_Scroll(object sender, ScrollEventArgs e)
        {
            headerPanel.Location = new Point(_headerLocation.X - detailPanel.HorizontalScroll.Value, _headerLocation.Y);
        }
        public void ControlValueChange(object sender, EventArgs e)
        {
            if (dataSource == null || dataSource.Count == 0)
                return;

            Control control = (Control)sender;

            Type senderType = control.GetType();
            var propertyValue = senderType.GetProperty("Text")?.GetValue(control);

            if (propertyValue == null)
                return;

            T dataControl = dataSource.SingleOrDefault(dataControl => dataControl.GetType().GetProperties().Any(control => control.GetValue(dataControl) == sender));

            if (dataControl == null)
                return;

            var newRecProperty = dataControl.GetType().GetField("newRec");
            if (newRecProperty == null || !(bool)newRecProperty.GetValue(dataControl))
                return;

            if(AddDataRow(new T()))
            {
                newRecProperty.SetValue(dataControl, false);
            }
            control.Focus();
        }
        public void FillDataRows()
        {
            detailPanel.Controls.Clear();
            controlPointY = 0;
            CreateLabels();
            orderNr = 1;
            foreach (T dataRow in dataSource)
            {
                ControlList(dataRow);
                SetControlEvents();
                PlaceControls();
                dataRow.newRec = false;
            }
            AddDataRow(new T());
            //controlPointY = 0;
        }
        public void DeleteRow(object sender, EventArgs e)
        {
            T dataControl = dataSource.SingleOrDefault(x => x.GetType().GetProperties().Any(z => z.GetValue(x) == sender));
            if (dataControl != null && !(bool)dataControl.GetType().GetField("newRec").GetValue(dataControl))
            {
                dataSource.Remove(dataControl);

                foreach (PropertyInfo propertyInfo in dataControl.GetType().GetProperties())
                {
                    if (typeof(Control).IsAssignableFrom(propertyInfo.PropertyType))
                    {
                        Control control = (Control)propertyInfo.GetValue(dataControl);
                        if (control != null)
                        {
                            detailPanel.Controls.Remove(control);
                            dataSource.Remove(dataControl);
                            control.Dispose();
                        }
                    }
                }
            }
            controlPointY = 0;
            orderNr = 1;
            for (int i=0;i< dataSource.Count;i++)
            {
                T dataRow = dataSource[i];
                ControlList(dataRow);
                PlaceControls();
            }
        }
        private void ControlList(T dataRow)
        {
            listControl.Clear();
			foreach (PropertyInfo propertyInfo in typeof(T).GetProperties())
			{
				var control = propertyInfo.GetValue(dataRow) as Control;
				listControl.Add(control);
			}
		}
        private void CreateLabels()
        {
            int controlPointX = 7;
            if(headerPanel.Controls.Count>0) return;
            foreach (Control control in listControl.OrderBy(p => p.TabIndex))
            {
				if (control.Tag != null)
				{
					Label label = new Label();
					label.Location = new Point(controlPointX, 0);
					var isim = control.Tag;
					label.Text = isim.ToString();
					int labelWidth = Convert.ToInt32(control.Width);
					bool labelVisible = control.Visible;
					label.Visible = labelVisible;
					label.Width = labelWidth;
                    label.Height = headerPanel.Height;
					label.Font = new Font("Segoe UI", 9, FontStyle.Bold, GraphicsUnit.Point);
					controlPointX = controlPointX + Convert.ToInt32(labelWidth) + _columnSpace;
					headerPanel.Controls.Add(label);
				}
			}
        }
        public bool AddDataRow(T dataRow)
        {
            if (CheckFields())
            {
                ControlList(dataRow);
                CreateLabels();
                SetControlEvents();
                PlaceControls();
                dataSource.Add(dataRow);
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool CheckFields()
        {
            if(orderNr < 2) return true;
            ControlList(dataSource[orderNr -2]);
            foreach (Control control in listControl)
            {
                FieldInfo fieldInfo = control.GetType().GetField("isMandatory");

                if (fieldInfo!=null && (bool)control.GetType().GetField("isMandatory").GetValue(control) == true)
                {
                    FieldInfo propertyInfo = control.GetType().GetField("textBox");
                    if (string.IsNullOrEmpty(control.GetType().GetProperty("TextCustom").GetValue(control).ToString()))
                    {
                        PropertyInfo property = propertyInfo.GetType().GetProperty("BackColor");
                        property.SetValue(propertyInfo, Color.Gainsboro);
                        return false;
                    }
                    else
                    {
                        control.BackColor = Color.White;
                        return true;
                    }
                }
            }
            return true;
        }
        private void PlaceControls()
        {
            Point panelLocation = detailPanel.PointToScreen(Point.Empty);
            int leftPadding = 7;
            controlPointY =controlPointY - detailPanel.VerticalScroll.Value;
            leftPadding=leftPadding - detailPanel.HorizontalScroll.Value;
            foreach (Control control in  listControl.OrderBy(p=>p.TabIndex))
            {
                if((string)control.Tag == "No")
                {
                    control.TextChanged -= ControlValueChange;
                    control.Text = orderNr++.ToString();
                } 
                control.Location = new Point(leftPadding , controlPointY);
                var width = control.Width;
				leftPadding = leftPadding + Convert.ToInt32(width) + _columnSpace;
                detailPanel.Controls.Add(control);
            }
            
            controlPointY = controlPointY + _rowSpace;
        }
        private void SetControlEvents()
        {
            //foreach (PropertyInfo propertyInfo in dataRow.GetType().GetProperties())
            foreach(Control control in listControl)
            {
				//Type type = propertyInfo.PropertyType;
				Type type = control.GetType();
				//var control = propertyInfo.GetValue(dataRow) as Control;

				SetControlEventHandler(control, type, "TextChanged", "ControlValueChange");
                SetControlEventHandler(control, type, "SelectedIndexChanged", "ControlValueChange");
                if (type.GetProperty("Tag").GetValue(control).ToString().Contains("Sil")) SetControlEventHandler(control, type, "Click", "DeleteRow");
            }
        }
        public void SetControlEventHandler(object obj, Type fieldType, string eventName, string methodName)
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
        public EventHandler GetEventHandler(string methodName)
        {
            Type type = GetType();
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
        public KeyPressEventHandler GetKeyPressEventHandler(string methodName)
        {
            Type type = GetType();
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
        public void Dispose()
        {
            dataSource.Clear();
            headerPanel = null;
            detailPanel = null;
        }
    }
}

