using Models.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class SatinalmaTeklifBaslikDTO:IEntity
    {
        [GridDisplay(Header =HeaderSatinalmaTeklifDTO.Id,Visible =true)]
        public int? Id { get; set; }
        [GridDisplay(Header = HeaderSatinalmaTeklifDTO.teklifNo, Visible = true)]
        public string teklifNo { get; set; }
        [GridDisplay(Header = HeaderSatinalmaTeklifDTO.projeId, Visible = true)]
        public int? projeId { get; set; }
        [GridDisplay(Header = HeaderSatinalmaTeklifDTO.parcaGrupId, Visible = true)]
        public int? parcaGrupId { get; set; }
        [GridDisplay(Header = HeaderSatinalmaTeklifDTO.teklifTalepTarihi, Visible = true)]
        public DateTime? teklifTalepTarihi { get; set; }
        [GridDisplay(Header = HeaderSatinalmaTeklifDTO.terminSuresi, Visible = true)]
        public int? terminSuresi { get; set; }
        [GridDisplay(Header = HeaderSatinalmaTeklifDTO.teklifTarihi, Visible = true)]
        public DateTime? teklifTarihi { get; set; }
        [GridDisplay(Header = HeaderSatinalmaTeklifDTO.firmaId, Visible = true)]
        public int? teklifFirmaId { get; set; }
        [GridDisplay(Header = HeaderSatinalmaTeklifDTO.firmaad, Visible = true)]
        public string? teklifFirmaad { get; set; }
        [GridDisplay(Header = HeaderSatinalmaTeklifDTO.firmamail, Visible = true)]
        public string? teklifFirmamail { get; set; }
        [GridDisplay(Header = HeaderSatinalmaTeklifDTO.odemeVadeId, Visible = true)]
        public int? vadeId { get; set; }
        [GridDisplay(Header = HeaderSatinalmaTeklifDTO.odemeVadead, Visible = true)]
        public string? vadead { get; set; }
        [GridDisplay(Header = HeaderSatinalmaTeklifDTO.aciklama, Visible = true)]
        public string? aciklama { get; set; }
        [GridDisplay(Header = HeaderSatinalmaTeklifDTO.tutar, Visible = true)]
        public double? teklifTutartutar { get; set; }
        [GridDisplay(Header = HeaderSatinalmaTeklifDTO.dovizCinsiId, Visible = true)]
        public int? teklifTutardovizCinsiId { get; set; }
        [GridDisplay(Header = HeaderSatinalmaTeklifDTO.teklifGecerlilikSuresi, Visible = true)]
        public int? teklifGecerlilikSuresi { get; set; }
        [GridDisplay(Header = HeaderSatinalmaTeklifDTO.teklifDurumuId, Visible = true)]
        public int? teklifDurumuId { get; set; }
        [GridDisplay(Header = HeaderSatinalmaTeklifDTO.satinalmaTeklifDetayList, Visible = true)]
        public List<SatinalmaTeklifDetay> satinalmaTeklifDetayList { get; set; }
    }
    public class  HeaderSatinalmaTeklifDTO
    {
        public const string Id = "Id";
        public const string projeId = "Proje Id";
        public const string parcaGrupId = "Parça Grup Id";
        public const string teklifTalepTarihi = "Teklif Talep Tarihi";
        public const string terminSuresi = "Termin Süresi";
        public const string teklifTarihi = "Teklif Tarihi";
        public const string firmaId = "Firma Id";
        public const string odemeVadeId = "Ödeme Vade Id";
        public const string aciklama = "Açıklama";
        public const string tutar = "Tutar";
        public const string dovizCinsiId = "Döviz Cinsi Id";
        public const string teklifGecerlilikSuresi = "Teklif Geçerlilik Süresi";
        public const string teklifDurumuId = "Teklif Durumu Id";
        public const string firmaad = "Firma Adı";
        public const string firmamail = "Firma Maili";
        public const string satinalmaTeklifDetayList = "satinalmaTeklifDetayList";
        public const string teklifNo = "Teklif No";
        public const string odemeVadead = "Vade";
    }
}
