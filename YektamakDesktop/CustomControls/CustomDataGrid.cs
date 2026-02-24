using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using YektamakDesktop.Abstracts;
using YektamakDesktop.Common;

namespace YektamakDesktop.CustomControls
{
    /// <summary>
    /// User controlleri içerebilen datagrid şeklinde bir görünüm oluşturur.
    /// Form üzerinde oluşturulan bir panel üzerine yerleştirilir.
    /// </summary>
    public partial class CustomDataGrid<T>  where T : DataControl,new()
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
                _detailPanel.AutoScroll = true;
                _detailPanel.Scroll += DetailPanel_Scroll;
            }
        }
        int controlPointY;
        int _columnSpace;
        int _rowSpace;
        public Point _headerLocation;
        public Size _detailSize;
        private Panel _headerPanel;
        public Panel headerPanel
        {
            get
            {
                if (_headerPanel == null)
                {
                    _headerPanel = new Panel();
                    _headerPanel.Location = _headerLocation;
                    _headerPanel.AutoSize = true;
                    _headerPanel.Height = 30;
                }
                return _headerPanel;
            }
            set
            {
                _headerPanel = value;
            }
        }
        private Panel _detailPanel;
		public Panel detailPanel
		{
			get
			{
				if (_detailPanel == null)
				{
					_detailPanel = new Panel();
					_detailPanel.Location = new Point(_headerLocation.X, _headerLocation.Y + 30);
                    _detailPanel.Size = _detailSize;
                    AddDataRow(DIContainer.GetService<T>());
				}
				return _detailPanel;
			}
			set
			{
				_detailPanel = value;
			}
		}
		
        public CustomDataGrid(int columnSpace, int rowSpace, Point headerLocation, Size detailSize, T entity = null)
        {
            _columnSpace = columnSpace;
            _rowSpace = rowSpace;
            _headerLocation = headerLocation;
            _detailSize = detailSize;
        }
        public CustomDataGrid()
        {
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
            var propertyValue = senderType.GetProperty("TextCustom")?.GetValue(control);

            if (propertyValue == null)
            {
                propertyValue = senderType.GetProperty("SelectedIndex")?.GetValue(control);
            }
            if (propertyValue == null) return;

            T dataControl = dataSource.SingleOrDefault(dataControl => dataControl.GetType().GetProperties().Any(control => control.GetValue(dataControl) == sender));

            if (dataControl == null)
                return;

            var newRecProperty = dataControl.GetType().GetField("newRec");
            if (newRecProperty == null || !(bool)newRecProperty.GetValue(dataControl))
                return;

            if(AddDataRow(DIContainer.GetService<T>()))
            {
                newRecProperty.SetValue(dataControl, false);
            }
            control.Focus();
        }
        public void FillDataRows()
        {
            detailPanel.Controls.Clear();
            controlPointY = 2;
            CreateLabels();
            orderNr = 1;
            foreach (T dataRow in dataSource)
            {
                ControlList(dataRow);
                PlaceControls();
                SetControlEvents();
                dataRow.newRec = false;
            }
            AddDataRow(DIContainer.GetService<T>());
        }
        //public void UstFormBagla(IUstForm ustForm)
        //{
        //    foreach (var dataControl in dataSource)
        //    {
        //        if (dataControl is IAltForm altForm)
        //        {
        //            altForm.UstFormuBagla(ustForm);
        //        }
        //    }
        //}
        private void RePlaceControls(T dataControl)
        {
            orderNr = int.Parse(dataControl.order.Text);
            foreach (var dataCtl in dataSource.Where(dc=>int.Parse(dc.order.Text)> int.Parse(dataControl.order.Text)))
            {
                foreach(PropertyInfo propertyInfo in dataCtl.GetType().GetProperties().Where(p=> typeof(Control).IsAssignableFrom(p.PropertyType)))
                {
                    Control control = (Control)propertyInfo.GetValue(dataCtl);
                    if (control != null)
                    {
                        if ((string)control.Tag == "#")
                        {
                            control.TextChanged -= ControlValueChange;
                            control.Text = orderNr++.ToString();
                        }
                        control.Location = new Point(control.Location.X, control.Location.Y - _rowSpace);
                    }
                }
            }
            controlPointY -= _rowSpace;
        }
        public void DeleteRow(object sender, EventArgs e)
        {
            T dataControl = dataSource.SingleOrDefault(x => x.GetType().GetProperties().Any(z => z.GetValue(x) == sender));
            RePlaceControls(dataControl);
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
            foreach (Control control in listControl.Where(p=>p!=null && p.Visible).OrderBy(p => p.TabIndex))
            {
				if (control.Tag != null && control.Tag!="Sil") 
				{
					Label label = new Label();
					label.Location = new Point(controlPointX, 0);
					var isim = control.Tag;
					label.Text = isim.ToString();
					int labelWidth = Convert.ToInt32(control.Width);
					bool labelVisible = labelWidth==0?false:control.Visible;
					label.Visible = labelVisible;
					label.Width = labelWidth;
                    //label.Height = headerPanel.Height;
                    label.AutoSize = true;
					label.Font = new Font("Segoe UI", 9, FontStyle.Bold, GraphicsUnit.Point);
					controlPointX = controlPointX + Convert.ToInt32(labelWidth) + _columnSpace;
					headerPanel.Controls.Add(label);
				}
			}
        }
        private IUstForm _ustForm;

        public void SetUstForm(IUstForm ustForm)
        {
            _ustForm = ustForm;
            AltFormlaraBagla(); // daha önce eklenmiş data row’lar varsa onlara da bağla
        }

        private void AltFormlaraBagla()
        {
            foreach (var dataControl in dataSource)
            {
                if (dataControl is IAltForm altForm)
                {
                    altForm.UstFormuBagla(_ustForm);
                }
            }
        }
        public bool AddDataRow(T dataRow)
        {
            if (CheckFields())
            {
                ControlList(dataRow);
                CreateLabels();
                PlaceControls();
                SetControlEvents();
                dataSource.Add(dataRow);
                if (dataRow is IAltForm altForm && _ustForm != null)
                {
                    altForm.UstFormuBagla(_ustForm);
                }
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
            if(dataSource[orderNr -2].newRec == true) return true;
            ControlList(dataSource[orderNr -2]);
            foreach (Control control in listControl.Where(p => p != null))
            {
                FieldInfo fieldInfo = control.GetType().GetField("isMandatory");

                if (fieldInfo!=null && (bool)control.GetType().GetField("isMandatory").GetValue(control) == true)
                {
                    PropertyInfo propertyInfo = control.GetType().GetProperty("TextCustom");
                    if (propertyInfo!=null && string.IsNullOrEmpty(propertyInfo.GetValue(control)?.ToString()))
                    {
                        PropertyInfo property = control.GetType().GetProperty("BackColor");
                        property.SetValue(control, Color.Gainsboro);
                        return false;
                    }
                    else
                    {
                        propertyInfo = control.GetType().GetProperty("selectedDataRowId");
                        var s = propertyInfo.GetValue(control)?.ToString();
                        if (propertyInfo != null && string.IsNullOrEmpty(propertyInfo.GetValue(control)?.ToString()))
                        {
                            PropertyInfo property = control.GetType().GetProperty("BackColor");
                            property.SetValue(control, Color.Gainsboro);
                            return false;
                        }
                        else
                        {
                            control.BackColor = Color.White;
                            return true;
                        }
                            
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
            foreach (Control control in  listControl.Where(c=>c!=null && c.Visible).OrderBy(c=>c.TabIndex))
            {
                if((string)control.Tag == "#")
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
            foreach(Control control in listControl.Where(p=>p!=null))
            {
                var s = control.Name;
				Type type = control.GetType();
				SetControlEventHandler(control, type, nameof(control.TextChanged), nameof(ControlValueChange));
                SetControlEventHandler(control, type, nameof(FilterableComboBox.SelectedIndexChanged), nameof(ControlValueChange));
                if (type.GetProperty(nameof(control.Tag)).GetValue(control).ToString().Contains("Sil")) SetControlEventHandler(control, type, nameof(control.Click), nameof(DeleteRow));
            }
        }
        public void SetControlEventHandler(object obj, Type fieldType, string eventName, string methodName)
        {
            EventInfo eventInfo = fieldType.GetEvent(eventName);
            if (eventInfo == null) return;
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
            if (eventName == "SelectedIndexChanged")
            {
                EventHandler handler = GetEventHandler(methodName);
                if (handler != null) eventInfo.AddEventHandler(obj, handler);
            }
        }
        public EventHandler GetEventHandler(string methodName)
        {
            Type type = GetType();
            MethodInfo methodInfo = type.GetMethod(methodName);

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
            MethodInfo methodInfo = type.GetMethod(methodName);
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

