using Models.Attributes;

namespace Models.DTO
{
    public record StokKartDTO:StokKart
    {
        [GridDisplay(Header = "Ölçü Birimi")]public int? olcuBirimId { get; set; }
        [GridDisplay(Header = "Malzeme Standart")]public int? malzemeStandartId { get; set; }
        [GridDisplay(Header = "Stok Tipi", Visible = false)]public int? stokTipId { get; set; }
        [GridDisplay(Header = "Stok Grubu")]public int? stokGrupId { get; set; }
        [GridDisplay(Header = "Hammadde Kodu", Visible = false)]public int? hammaddeId { get; set; }
        [GridDisplay(Header = "Hammadde Ölçü Birimi", Visible = false)] public int? hammaddeolcuBirimId { get; set; }
        [GridDisplay(Header = "Malzeme Grubu", Visible = false)]public int? malzemeGrupId { get; set; }
        [GridDisplay(Header = "Malzeme Alt Grubu", Visible = false)]public int? malzemeAltGrupId { get; set; }
        [GridDisplay(Header = "Malzeme Alt Grubu 2", Visible = false)]public int? malzemeAltGrup2Id { get; set; }
    }
}
