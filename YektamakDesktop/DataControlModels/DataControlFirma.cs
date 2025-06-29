using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Interfaces;
using YektamakDesktop.Common;
using YektamakDesktop.CustomControls;

namespace YektamakDesktop
{
    //private class DataControlFirma : Abstracts.DataControl, IEntity
    //{
    //    private static ICache _cache;
    //    private CustomComboListBox _Id;
    //    public CustomComboListBox Id { get { if (_Id == null) { _Id = new(); } return _Id; } set { _Id = value; } }
    //    private string _mail;
    //    public string mail { get { return _mail; } set { _mail = value; } }
    //    private DataControlFirma()
    //    {
    //        Id = new() { TabIndex = 1, Width = 300, Visible = true, Tag = "Id" };
    //        Id.textBox.PlaceholderText = "Firma Seçiniz";
    //        ComboBoxListFill.GetLookupAd(_cache.firmaList, ref _Id);
    //        Id.SelectedIndexChanged += Id_SelectedIndexChanged;
    //    }
    //    private DataControlFirma(ICache cache)
    //    { 
    //        _cache = cache;
    //    }
    //    private void Id_SelectedIndexChanged(object sender, EventArgs e)
    //    {
    //        mail = _cache.firmaList.First(f => f.Id == Id.selectedDataRowId).mail;
    //    }
    //}
}
