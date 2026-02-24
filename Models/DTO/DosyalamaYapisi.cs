using Models.Attributes;

namespace Models.DTO
{
    public record DosyalamaYapisi:IEntity
    {
        [GridDisplay(Header ="Id")] public int? Id { get; set; }
        [GridDisplay(Header = "Stok Grubu",Tip ="Liste",ListName ="stokGrups",ListVisibleColumnName ="ad")] public int? stokGrupId { get; set; }
        [GridDisplay(Header = "Malzeme Grubu", Tip = "Liste", ListName = "malzemeGrups", ListVisibleColumnName = "ad")] public int? malzemeGrupId { get; set; }
        [GridDisplay(Header = "Malzeme Alt Grubu", Tip = "Liste", ListName = "malzemeAltGrups", ListVisibleColumnName = "ad")] public int? malzemeAltGrupId { get; set; }
        [GridDisplay(Header = "Boyut", Tip = "Liste", ListName = "boyutList", ListVisibleColumnName = "ad")] public int? boyutId { get; set; }
        [GridDisplay(Header = "Dosya Yolu")] public string path { get; set; }
        [GridDisplay(Header = "Klasör")] public string klasorAd { get; set; }
        [GridDisplay(Header = "pdf")] public bool pdf { get; set; }
        [GridDisplay(Header = "dxf")] public bool dxf { get; set; }
        [GridDisplay(Header = "step")] public bool step { get; set; }
        [GridDisplay(Header = "büküm")] public bool isBukum { get; set; }
        [GridDisplay(Header = "talaşlı")] public bool isTalasli { get; set; }

    }
}
