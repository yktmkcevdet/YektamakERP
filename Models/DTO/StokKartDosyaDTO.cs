using Models.Attributes;

namespace Models.DTO
{
    public class StokKartDosyaDTO:IEntity
    {
        [GridDisplay(Header = "Id")]public int Id { get; set; }
        [GridDisplay(Header = "Stok Kartı Id")]public int stokKartId { get; set; }
        [GridDisplay(Header = "Dosya Tipi", Tip = "Liste", ListVisibleColumnName = "ad", ListName = "dosyaTipList")]public int? dosyaTipId { get; set; }
        [GridDisplay(Header = "Dosya Adı")]public string dosyaAd { get; set; }
        [GridDisplay(Header = "Dosya Uzantısı")]public string dosyaUzanti { get; set; }
        [GridDisplay(Header = "Dosya")]public byte[] dosya { get; set; }
        [GridDisplay(Header = "Dosya Yolu", Visible = true)] public string dosyaFullPath { get; set; }
        public bool isActive { get; set; }
        [GridDisplay(Header = "Kontrol Eden", Visible = true, Tip = "Liste", ListVisibleColumnName = "ad", ListName = "kullaniciList")]
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
