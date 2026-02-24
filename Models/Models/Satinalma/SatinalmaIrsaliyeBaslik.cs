using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class SatinalmaIrsaliyeBaslik:IEntity
    {
        public int? Id { get; set; }
        public string irsaliyeNo { get; set; }
        public DateTime? tarih { get; set; }
        private Proje _proje;
        public Proje proje { get { if (_proje == null) { _proje = new(); } return _proje;  } set { _proje = value; }  }
        private Firma _firma;
        public Firma firma { get { if(_firma == null) { _firma = new(); } return _firma; } set { _firma = value; } }
        private StokGrup _stokgrup;
        public StokGrup stokGrup { get { if(_stokgrup == null) { _stokgrup = new(); } return _stokgrup; } set { _stokgrup = value; }  }
        private MalzemeGrup _malzemeGrup;
        public MalzemeGrup malzemeGrup { get { if(_malzemeGrup == null) { _malzemeGrup = new(); } return _malzemeGrup; } set { _malzemeGrup = value; }  }
        public string aciklama { get; set; }
        public List<SatinalmaIrsaliyeDetay> satinalmaIrsaliyeDetayList { get; set; }
    }
    public class SatinalmaIrsaliyeDetay:IEntity
    {
        public int? Id { get; set; }
        private SatinalmaIrsaliyeBaslik _satinalmaIrsaliyeBaslik;
        public SatinalmaIrsaliyeBaslik satinalmaIrsaliyeBaslik { get { if (_satinalmaIrsaliyeBaslik == null) { _satinalmaIrsaliyeBaslik = new(); } return _satinalmaIrsaliyeBaslik; } set { _satinalmaIrsaliyeBaslik = value; } }
        private SatinalmaSiparisDetay _satinalmaSiparisDetay;
        public SatinalmaSiparisDetay satinalmaSiparisDetay{ get { if (_satinalmaSiparisDetay == null) { _satinalmaSiparisDetay = new(); } return _satinalmaSiparisDetay; } set{ _satinalmaSiparisDetay = value; } }
        private ProjeStokKart _projeStokKart;
        public ProjeStokKart projeStokKart { get { if(_projeStokKart == null) { _projeStokKart = new(); } return _projeStokKart; } set { _projeStokKart = value; }  }
        public double? miktar { get; set; }
        public string birim { get; set; }
        public double? birimFiyat { get; set; }
        public double? kdvOran { get; set; }
        public double? toplamTutar { get; set; }
    }
}
