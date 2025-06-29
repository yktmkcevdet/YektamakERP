using Models.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class MondayTeklif:IEntity
    {
        [GridDisplay(Header ="sutun1",Visible =true)]
        public string alt___eler_mkmwa9xh { get; set; }
        [GridDisplay(Header = "Firma", Visible = true)]
        public string text_mknxmwbx { get; set; }
        [GridDisplay(Header = "Durum", Visible = true)]
        public string project_status { get; set; }
        [GridDisplay(Header = "Teklif Talep Tarihi", Visible = true)]
        public DateTime date { get; set; }
        [GridDisplay(Header = "Teklif Tarihi", Visible = true)]
        public DateTime tarih_1_mkmxw5a6 { get; set; }
        //public string priority_1 { get; set; }
        [GridDisplay(Header = "Konu", Visible = true)]
        public string a__lan_liste_mkmw31b9 { get; set; }
        //public string konum_mkmwcepz { get; set; }
        [GridDisplay(Header = "Mail", Visible = true)]
        public string belge_mkmxe7pg { get; set; }
        [GridDisplay(Header = "Belge", Visible = true)]
        public string file_mknxjfx8 { get; set; }
        [GridDisplay(Header = "Teklif tutarı", Visible = true)]
        public string numeric_mknxw6gr { get; set; }
        [GridDisplay(Header = "Adres", Visible = true)]
        public string konum_mkmwcepz { get; set; }
        [GridDisplay(Header = "İletişim Kişisi", Visible = true)]
        public string metin_mkmxg1ss { get; set; }
        [GridDisplay(Header = "İletişim Mail", Visible = true)]
        public string e_posta_mkmxjnh9 { get; set; }
        [GridDisplay(Header = "Telefon", Visible = true)]
        public string telefon_mkmxxx0f { get; set; }
        public List<byte[]> belgeler;
    }
}
