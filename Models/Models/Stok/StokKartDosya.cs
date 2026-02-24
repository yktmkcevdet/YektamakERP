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
        [GridDisplay(Header = "Dosya Tipi", Visible = true,Tip ="Liste",ListName = "dosyaTipList")]
        public DosyaTip dosyaTip { get { if (_dosyaTip == null) { _dosyaTip = new DosyaTip(); } return _dosyaTip; } set { _dosyaTip = value; } }
        [GridDisplay(Header = "Dosya Adı", Visible = true)]
        public string dosyaAd { get; set; }
        [GridDisplay(Header = "Dosya Uzantısı", Visible = true)]
        public string dosyaUzanti { get; set; }
        [GridDisplay(Header = "Dosya", Visible = true)]
        public byte[] dosya { get; set; }
        [GridDisplay(Header = "Dosya Yolu", Visible = true)]
        public string dosyaFullPath { get; set; }
        public bool isActive { get; set; }
        [GridDisplay(Header = "Kontrol Eden", Visible = true,Tip ="Liste",ListVisibleColumnName ="ad",ListName ="kullaniciList")]
        public int? kontrolEdenKullaniciId { get; set; }
        [GridDisplay(Header = "Kontrol Tarihi", Visible = true)]
        public DateTime? kontrolTarihi { get; set; }
        [GridDisplay(Header = "Kontrol Durumu", Visible = true)]
        public bool? kontrolSonucu { get; set; }
        [GridDisplay(Header = "Onaylayan", Visible = true, Tip = "Liste", ListVisibleColumnName = "ad", ListName = "kullaniciList")]
        public int? onaylayanKullaniciId { get; set; }
        [GridDisplay(Header = "Onay Tarihi", Visible = true)]
        public DateTime? onayTarihi { get; set; }
        [GridDisplay(Header = "Onay Durumu", Visible = true)]
        public bool? onaySonucu { get; set; }
        public string kontrolRedSebepAciklama { get; set; }
    }
}
