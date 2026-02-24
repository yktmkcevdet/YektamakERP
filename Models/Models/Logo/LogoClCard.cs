using Models.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class LogoClCard:IEntity
    {
           [GridDisplay(Header ="LOGICALREF")] public int LOGICALREF { get; set; }
           [GridDisplay(Header ="ACTIVE")] public int ACTIVE { get; set; }
           [GridDisplay(Header ="CARDTYPE")] public int CARDTYPE { get; set; }
           [GridDisplay(Header ="CODE")] public string CODE { get; set; }
           [GridDisplay(Header ="DEFINITION_")] public string DEFINITION_ { get; set; }
           [GridDisplay(Header ="SPECODE")] public string SPECODE { get; set; }
           [GridDisplay(Header ="CYPHCODE")] public string CYPHCODE { get; set; }
           [GridDisplay(Header ="ADDR1")] public string ADDR1 { get; set; }
           [GridDisplay(Header ="ADDR2")] public string ADDR2 { get; set; }
           [GridDisplay(Header ="CITY")] public string CITY { get; set; }
           [GridDisplay(Header ="COUNTRY")] public string COUNTRY { get; set; }
           [GridDisplay(Header ="POSTCODE")] public string POSTCODE { get; set; }
           [GridDisplay(Header ="TELNRS1")] public string TELNRS1 { get; set; }
           [GridDisplay(Header ="TELNRS2")] public string TELNRS2 { get; set; }
           [GridDisplay(Header ="FAXNR")] public string FAXNR { get; set; }
           [GridDisplay(Header ="TAXNR")] public string TAXNR { get; set; }
           [GridDisplay(Header ="TAXOFFICE")] public string TAXOFFICE { get; set; }
           [GridDisplay(Header ="INCHARGE")] public string INCHARGE { get; set; }
           [GridDisplay(Header ="DISCRATE")] public decimal DISCRATE { get; set; }
           [GridDisplay(Header ="EXTENREF")] public int EXTENREF { get; set; }
           [GridDisplay(Header ="PAYMENTREF")] public int PAYMENTREF { get; set; }
           [GridDisplay(Header ="EMAILADDR")] public string EMAILADDR { get; set; }
           [GridDisplay(Header ="WEBADDR")] public string WEBADDR { get; set; }
           [GridDisplay(Header ="WARNMETHOD")] public int WARNMETHOD { get; set; }
           [GridDisplay(Header ="WARNEMAILADDR")] public string WARNEMAILADDR { get; set; }
           [GridDisplay(Header ="WARNFAXNR")] public string WARNFAXNR { get; set; }
           [GridDisplay(Header ="CLANGUAGE")] public int CLANGUAGE { get; set; }
           [GridDisplay(Header ="VATNR")] public string VATNR { get; set; }
           [GridDisplay(Header ="BLOCKED")] public int BLOCKED { get; set; }

            // ... diğer banka, adres, ödeme alanları aynı şekilde

           [GridDisplay(Header ="RECSTATUS")] public int RECSTATUS { get; set; }
           [GridDisplay(Header ="ORGLOGICREF")] public int ORGLOGICREF { get; set; }
           [GridDisplay(Header ="EDINO")] public string EDINO { get; set; }
           [GridDisplay(Header ="TRADINGGRP")] public string TRADINGGRP { get; set; }

           [GridDisplay(Header ="CAPIBLOCK_CREATEDBY")] public int CAPIBLOCK_CREATEDBY { get; set; }
           [GridDisplay(Header ="CAPIBLOCK_CREADEDDATE")] public DateTime CAPIBLOCK_CREADEDDATE { get; set; }
           [GridDisplay(Header ="CAPIBLOCK_CREATEDHOUR")] public int CAPIBLOCK_CREATEDHOUR { get; set; }
           [GridDisplay(Header ="CAPIBLOCK_CREATEDMIN")] public int CAPIBLOCK_CREATEDMIN { get; set; }
           [GridDisplay(Header ="CAPIBLOCK_CREATEDSEC")] public int CAPIBLOCK_CREATEDSEC { get; set; }
           [GridDisplay(Header ="CAPIBLOCK_MODIFIEDBY")] public int CAPIBLOCK_MODIFIEDBY { get; set; }
           [GridDisplay(Header ="CAPIBLOCK_MODIFIEDDATE")] public DateTime? CAPIBLOCK_MODIFIEDDATE { get; set; }
           [GridDisplay(Header ="CAPIBLOCK_MODIFIEDHOUR")] public int CAPIBLOCK_MODIFIEDHOUR { get; set; }
           [GridDisplay(Header ="CAPIBLOCK_MODIFIEDMIN")] public int CAPIBLOCK_MODIFIEDMIN { get; set; }
           [GridDisplay(Header ="CAPIBLOCK_MODIFIEDSEC")] public int CAPIBLOCK_MODIFIEDSEC { get; set; }

            // ... kalan tüm alanlar

           [GridDisplay(Header ="DEFINITION2")] public string DEFINITION2 { get; set; }
           [GridDisplay(Header ="GUID")] public Guid GUID { get; set; }

            [GridDisplay(Header ="NAME")] public string NAME { get; set; }
            [GridDisplay(Header ="SURNAME")] public string SURNAME { get; set; }

            // KVKK alanları
           [GridDisplay(Header ="KVKKPERMSTATUS")] public int KVKKPERMSTATUS { get; set; }
            [GridDisplay(Header ="KVKKBEGDATE")] public DateTime? KVKKBEGDATE { get; set; }
            [GridDisplay(Header ="KVKKENDDATE")] public DateTime? KVKKENDDATE { get; set; }
            [GridDisplay(Header ="KVKKCANCELDATE")] public DateTime? KVKKCANCELDATE { get; set; }
            [GridDisplay(Header ="KVKKANONYSTATUS")] public int KVKKANONYSTATUS { get; set; }
            [GridDisplay(Header ="KVKKANONYDATE")] public DateTime? KVKKANONYDATE { get; set; }

            // Sosyal medya
           [GridDisplay(Header ="FACEBOOKURL")] public string FACEBOOKURL { get; set; }
           [GridDisplay(Header ="TWITTERURL")] public string TWITTERURL { get; set; }
           [GridDisplay(Header ="INSTAGRAMURL")] public string INSTAGRAMURL { get; set; }
           [GridDisplay(Header ="LINKEDINURL")] public string LINKEDINURL { get; set; }
           [GridDisplay(Header ="WHATSAPPID")] public string WHATSAPPID { get; set; }
        }
    public class LogoCariKart
    {
        public int? INTERNAL_REFERENCE { get; set; }
        public bool? RECORD_STATUS { get; set; }
        public int? ACCOUNT_TYPE { get; set; }
        public string? CODE { get; set; }
        public string? TITLE { get; set; }

    }

}
