using Models;
using Models.DTO;

namespace Utilities.Interfaces
{
    public interface ICache
    {
        public Kullanici kullanici { get; set; }
        public List<Kullanici> kullaniciList { get;  }
        public Task<List<Kullanici>> kullaniciListAsync();
        public List<Rol> rolList { get; }
        public List<AnaMenuDTO> anaMenuList { get; }
        public List<Menu> menuList { get; }
        public List<Yetki> yetkiList { get; }
        public List<StokKart> stokKartList { get; }
        public List<StokGrup> stokGrups { get; }
        public List<MalzemeGrup> malzemeGrups { get; }
        public List<MalzemeAltGrup2> malzemeAltGrup2List { get; }
        public List<MalzemeAltGrup> malzemeAltGrups { get; }
        public List<StokTip> stokTips { get; }
        public List<ProfilTip> profilTips { get; }
        public List<OlcuBirim> olcuBirims { get; }
        public List<MalzemeStandart> malzemeStandarts { get; }
        public List<Proje> projes { get; }
        public List<ProjeTip> projeTipList { get; }
        public List<Proje> unAssignedProjeList { get; }
        public List<Sektor> sektorList { get; }
        public List<Firma> firmaList { get; }
        public List<Personel> personelList { get; }
        public List<Pozisyon> pozisyonList { get; }
        public List<Marka> markaList { get; }
        public List<MarkaAltGrup> markaAltGrupList { get; }
        public List<MarkaAltGrupKategori> markaAltGrupKategori { get; }
        public List<ReferansKaynak> referansKaynakList { get; }
        public List<DovizCinsi> dovizCinsiList { get; }
        public List<Vade> vadeList { get; }
        public List<MaliyetUnsur> maliyetUnsurList { get; set; }
        public List<MaliyetTespitKanal> maliyetTespitKanalList { get; set; }
        public List<DosyaTip> dosyaTipList { get; set; }
        public List<TalepNeden> talepNedenList { get; set; }
        void Reset();
    }
}
