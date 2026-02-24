using Models.Attributes;

namespace Models.DTO
{
    public record ProjeDTO:IEntity
    {
        [GridDisplay(Header = "Id")] public int? Id { get; set; }
        [GridDisplay(Header = "Proje No")] public int? projeNo { get; set; }
        [GridDisplay(Header = "Ver.")] public string? versiyon { get; set; }
        [GridDisplay(Header = "Kod")] public string kod { get; set; }
        [GridDisplay(Header = "Marka", Tip = "Liste", ListName = "markaList", ListVisibleColumnName = "ad", readOnly = false)] public int? markaId { get; set; }
        [GridDisplay(Header = "Marka Prefix")] public string markaprefix { get; set; }
        [GridDisplay(Header = "Marka Alt Grup", Tip = "Liste", ListName = "markaAltGrupList", ListVisibleColumnName = "ad", readOnly = false)] public int? markaAltGrupId { get; set; }
        [GridDisplay(Header = "Marka Alt Grup Kategori", Tip = "Liste", ListName = "markaAltGrupKategori", ListVisibleColumnName = "ad", readOnly = false)] public int? markaAltGrupKategoriId { get; set; }
        [GridDisplay(Header = "Ad")] public string ad { get; set; }
        [GridDisplay(Header = "Açıklama")] public string aciklama { get; set; }
        [GridDisplay(Header = "Proje Tipi", Tip = "Liste", ListName = "projeTipList", ListVisibleColumnName = "ad", readOnly = false)] public int? projeTipId { get; set; }
        [GridDisplay(Header = "Proje Tip Kod")] public string projeTipkod { get; set; }
        [GridDisplay(Header ="Sipariş No")]public int? satisSiparisId { get; set; }
        [GridDisplay(Header ="Miras Alına Proje", Tip ="Liste", ListName = "projes", ListVisibleColumnName ="kod")]public int? mirasProjeId { get; set; }
        private List<ProjeDosya> _projeDosyaList;
        public List<ProjeDosya> projeDosyaList { get => _projeDosyaList ??= new List<ProjeDosya>(); set => _projeDosyaList = value;
        }
    }
}
