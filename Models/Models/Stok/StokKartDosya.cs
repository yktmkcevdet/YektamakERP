using Models.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class StokKartDosya : IEntity
    {
        [GridDisplay(Header="Id",Visible = true)]
        public int? Id { get; set; }
        [GridDisplay(Header = "Stok Kartı Id", Visible = true)]
        public int? stokKartId { get; set; }
        private DosyaTip _dosyaTip { get; set; }
        [GridDisplay(Header = "Dosya Tipi", Visible = true,Tip ="Liste",ListVisibleColumnName ="ad",ListName ="dosyaTipList")]
        public DosyaTip dosyaTip { get { if (_dosyaTip == null) { _dosyaTip = new DosyaTip(); } return _dosyaTip; } set { _dosyaTip = value; } }
        [GridDisplay(Header = "Dosya Adı", Visible = true)]
        public string dosyaAd { get; set; }
        [GridDisplay(Header = "Dosya Uzantısı", Visible = true)]
        public string dosyaUzanti { get; set; }
        [GridDisplay(Header = "Dosya", Visible = true)]
        public byte[] dosya { get; set; }
        [GridDisplay(Header = "Dosya Yolu", Visible = true)]
        public string dosyaFullPath { get; set; }
    }
}
