using Models;
using System;
using System.Collections.Generic;
using System.Reflection;
using YektamakDesktop.CustomControls;

namespace YektamakDesktop.Common
{
    public class ComboBoxListFill
    {
        public static void GetLookupAd<T>(List<T> list, ref CustomComboListBox customComboListBox) where T : IEntity,new()
        {   
            T entity=new T();
            FieldInfo idField = entity.GetType().GetField("Id");
            PropertyInfo idProperty= entity.GetType().GetProperty("Id");
            FieldInfo kodField = entity.GetType().GetField("kod");
            PropertyInfo kodProperty = typeof(T).GetType().GetProperty("kod");
            FieldInfo adField = entity.GetType().GetField("ad");
            PropertyInfo adProperty = entity.GetType().GetProperty("ad");
            customComboListBox.ClearListBox();
            if(list.Count>0)customComboListBox.AddDataRow(-1, "<SEÇİM YAP>");
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
            customComboListBox.SelectDataRowId(-1);
        }
        public static void GetLookupKod<T>(List<T> list, ref CustomComboListBox customComboListBox) where T : IEntity, new()
        {
            T entity = new T();
            FieldInfo idField = entity.GetType().GetField("Id");
            PropertyInfo idProperty = entity.GetType().GetProperty("Id");
            FieldInfo kodField = entity.GetType().GetField("kod");
            PropertyInfo kodProperty = entity.GetType().GetProperty("kod");
            FieldInfo adField = entity.GetType().GetField("ad");
            PropertyInfo adProperty = entity.GetType().GetProperty("ad");
            if (list.Count > 0) customComboListBox.AddDataRow(-1, "<SEÇİM YAP>");
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
            customComboListBox.SelectDataRowId(-1);
        }
    }
}
