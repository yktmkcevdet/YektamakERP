using Models;
using System;
using System.Collections.Generic;
using YektamakDesktop.CustomControls;

namespace YektamakDesktop.Common
{
    public class ComboBoxListFill
    {
        public static void GetLookupAd<T>(List<T> list, ref CustomComboListBox customComboListBox) where T : IEntity,new()
        {
            foreach (T model in list)
            {
                customComboListBox.AddDataRow(Convert.ToInt32(model.GetType().GetField("Id").GetValue(model)), model.GetType().GetField("ad").GetValue(model).ToString());
            }
        }
        public static void GetLookupKod<T>(List<T> list, ref CustomComboListBox customComboListBox) where T : IEntity, new()
        {
            foreach (T model in list)
            {
                customComboListBox.AddDataRow(Convert.ToInt32(model.GetType().GetField("Id").GetValue(model)), model.GetType().GetField("kod").GetValue(model).ToString());
            }
        }
    }
}
