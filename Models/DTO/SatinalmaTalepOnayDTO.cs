using Models.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class SatinalmaTalepOnayDTO:IEntity
    {
        [GridDisplay(Header = SatinalmaTalepOnayDTOHeader.IdHeader, Visible = true)]
        public int? Id { get; set; }
        [GridDisplay(Header = SatinalmaTalepOnayDTOHeader.TalepNoHeader, Visible = true)]
        public string? satinalmaTalepNo { get; set; }
        public bool? onayDurum { get; set; }
        [GridDisplay(Header = SatinalmaTalepOnayDTOHeader.TalepTarihiHeader, Visible = true)]
        public DateTime? talepTarihi { get; set; }
        [GridDisplay(Header = SatinalmaTalepOnayDTOHeader.TeslimTarihiHeader, Visible = true)]
        public DateTime? teslimTarihi { get; set; }
        public int malzemeGrupId { get; set; }
        [GridDisplay(Header = SatinalmaTalepOnayDTOHeader.MalzemeGrupAdiHeader, Visible = true)]
        public string? malzemeGrupad { get; set; }
        public string? malzemeGrupkod { get; set; }
        public int projeId { get; set; }
        public string? projead { get; set; }
        [GridDisplay(Header = SatinalmaTalepOnayDTOHeader.ProjeKoduHeader, Visible = true)]
        public string? projekod { get; set; }
        [GridDisplay(Header = SatinalmaTalepOnayDTOHeader.TalepEdenIdHeader, Visible = true)]
        public int talepEdenKullaniciId { get; set; }
        [GridDisplay(Header = SatinalmaTalepOnayDTOHeader.TalepEdenHeader, Visible = true)]
        public string? talepEdenKullanicipersonelad { get; set; }
        public string? talepEdenKullanicikod { get; set; }
        [GridDisplay(Header = SatinalmaTalepOnayDTOHeader.OnaylayanIdHeader, Visible = true)]
        public int? onayKullaniciId { get; set; }
        public string? onayKullaniciad { get; set; }
        public string? onayKullanicikod { get; set; }
        public int onayKullanicipersonelId { get; set; }
        [GridDisplay(Header = SatinalmaTalepOnayDTOHeader.OnaylayanHeader, Visible = true)]
        public string? onayKullanicipersonelad { get; set; }
        public string? onayKullanicipersonelsoyad { get; set; }

        public int talepTipId { get; set; }
        public string? talepTipad { get; set; }
        public string? talepTipkod { get; set; }
        [GridDisplay(Header = SatinalmaTalepOnayDTOHeader.AciklamaHeader, Visible = true)]
        public string? aciklama { get; set; }
        public string satinalmaTalepDetays { get; set; }
        public string satinalmaTalepDetaysstokKartsatinalmaTalepSatirDetays { get; set; }
        
    }
    public class SatinalmaTalepOnayDTOHeader
    {
        public const string StokKartKoduHeader = "Stok Kart Kodu";
        public const string StokKartAdiHeader = "Stok Kart Adı";
        public const string StokGrupAdiHeader = "Stok Grubu Adı";
        public const string MalzemeGrupAdiHeader = "Malzeme Grubu Adı";
        public const string TalepMiktariHeader = "Talep Miktarı";
        public const string TalepTarihiHeader = "Talep Tarihi";
        public const string TeslimTarihiHeader = "Teslim Tarihi";
        public const string OnaylayanHeader = "Onaylayan";
        public const string TalepEdenHeader = "Talep Eden";
        public const string AciklamaHeader = "Açıklama";
        public const string AgirlikHeader = "Ağırlık";
        public const string ProjeKoduHeader = "Proje Kod";
        public const string StokKartIdHeader = "Stok Kart Id";
        public const string MalzemeGrupIdHeader = "Malzeme Grup Id";
        public const string MalzemeAltGrupIdHeader = "Malzeme Alt Grup Id";
        public const string StokGrupIdHeader = "Grup Id";
        public const string ProjeIdHeader = "Proje Id ";
        public const string TalepNoHeader = "Talep No";
        public const string IdHeader = "Id";
        public const string OnaylayanIdHeader = "Onaylayan Kullanıcı Id";
        public const string TalepEdenIdHeader = "Talep Eden Kullanıcı Id";
    }
}
