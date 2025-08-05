using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using YektamakDesktop.CustomControls;

namespace YektamakDesktop.Common
{
    public class ComboBoxListFill
    {
        public static void GetLookupAd<T>(List<T> list, ref CustomComboListBox customComboListBox) where T : IEntity,new()
        {
            customComboListBox.selectedDataRowId = null;
            customComboListBox.ClearListBox();
            T entity=new T();
            FieldInfo idField = entity.GetType().GetField("Id");
            PropertyInfo idProperty= entity.GetType().GetProperty("Id");
            FieldInfo kodField = entity.GetType().GetField("kod");
            PropertyInfo kodProperty = typeof(T).GetType().GetProperty("kod");
            FieldInfo adField = entity.GetType().GetField("ad");
            PropertyInfo adProperty = entity.GetType().GetProperty("ad");
            customComboListBox.ClearListBox();
            if(list.Count>0)customComboListBox.AddDataRow(null, "<SEÇİM YAP>");
            foreach (T model in list)
            {
                if (idField != null)
                {
                    customComboListBox.AddDataRow(Convert.ToInt32(idField.GetValue(model)), adField.GetValue(model).ToString());
                }
                else
                {
                    customComboListBox.AddDataRow(Convert.ToInt32(idProperty.GetValue(model)), adProperty.GetValue(model).ToString());
                }
            }
            customComboListBox.SelectDataRowId(null);
        }
        public static void GetLookupKod<T>(List<T> list, ref CustomComboListBox customComboListBox) where T : IEntity, new()
        {
            customComboListBox.selectedDataRowId = null;
            customComboListBox.ClearListBox();
            T entity = new T();
            FieldInfo idField = entity.GetType().GetField("Id");
            PropertyInfo idProperty = entity.GetType().GetProperty("Id");
            FieldInfo kodField = entity.GetType().GetField("kod");
            PropertyInfo kodProperty = entity.GetType().GetProperty("kod");
            FieldInfo adField = entity.GetType().GetField("ad");
            PropertyInfo adProperty = entity.GetType().GetProperty("ad");
            if (list.Count > 0) customComboListBox.AddDataRow(null, "<SEÇİM YAP>");
            foreach (T model in list)
            {
                if (idField != null)
                {
                    customComboListBox.AddDataRow(Convert.ToInt32(idField.GetValue(model)), kodField.GetValue(model).ToString());
                }
                else
                {
                    customComboListBox.AddDataRow(Convert.ToInt32(idProperty.GetValue(model)), kodProperty.GetValue(model).ToString());
                }
            }
            customComboListBox.SelectDataRowId(null);
        }
        public static void GetLookupKodAd<T>(List<T> list, ref CustomComboListBox customComboListBox) where T : IEntity, new()
        {
            customComboListBox.selectedDataRowId = null;
            customComboListBox.ClearListBox();
            T entity = new T();
            FieldInfo idField = entity.GetType().GetField("Id");
            PropertyInfo idProperty = entity.GetType().GetProperty("Id");
            FieldInfo kodField = entity.GetType().GetField("kod");
            PropertyInfo kodProperty = entity.GetType().GetProperty("kod");
            FieldInfo adField = entity.GetType().GetField("ad");
            PropertyInfo adProperty = entity.GetType().GetProperty("ad");
            if (list.Count > 0) customComboListBox.AddDataRow(null, "<SEÇİM YAP>");
            foreach (T model in list)
            {
                if (idField != null)
                {
                    customComboListBox.AddDataRow(Convert.ToInt32(idField.GetValue(model)), $"{kodField.GetValue(model).ToString()} - {adField.GetValue(model).ToString()}" );
                }
                else
                {
                    customComboListBox.AddDataRow(Convert.ToInt32(idProperty.GetValue(model)), $"{kodProperty.GetValue(model).ToString()} - {adProperty.GetValue(model).ToString()}");
                }
            }
            customComboListBox.SelectDataRowId(null);
        }
        //public static void GetLookupAd<T>(List<T> list, ref FilterableComboBox customComboListBox) where T : IEntity, new()
        //{
        //    T entity = new T();
        //    FieldInfo idField = entity.GetType().GetField("Id");
        //    PropertyInfo idProperty = entity.GetType().GetProperty("Id");
        //    FieldInfo kodField = entity.GetType().GetField("kod");
        //    PropertyInfo kodProperty = typeof(T).GetType().GetProperty("kod");
        //    FieldInfo adField = entity.GetType().GetField("ad");
        //    PropertyInfo adProperty = entity.GetType().GetProperty("ad");
        //    customComboListBox.DataSource = null;
        //    customComboListBox.SetDataSource(list);
        //}
        public static void GetLookupKod<T>(List<T> list, ref FilterableComboBox customComboListBox) where T : IEntity, new()
        {
            //customComboListBox.SelectedItem = null;
            T entity = new T();
            customComboListBox.SetDataSource(list);
            
        }
        public static void GetLookupAd<T>(List<T> list, ref FilterableComboBox customComboListBox) where T : IEntity, new()
        {
            //customComboListBox.SelectedItem = null;
            T entity = new T();
            customComboListBox.SetDataSource(list);
        }
    }
}
