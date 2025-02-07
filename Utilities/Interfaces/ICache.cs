using Models;
using Models.DTO;

namespace Utilities.Interfaces
{
    public interface ICache
    {
        public Kullanici kullanici { get; set; }
        public List<AnaMenu> ananaMenuList { get; }
        public List<Yetki> yetkiList { get; }
        public List<ParcaGrup> parcaGrups { get; }
        public List<StokTip> stokTip { get; }
        public List<ProfilTip> profilTip { get; }
        public List<OlcuBirim> olcuBirim { get; }
        public List<MalzemeGrup> malzemeGrup { get; }
        public List<MalzemeStandart> malzemeStandart { get; }
        public List<Proje> proje { get; }
        public List<Sektor> sektorList { get; }
    }
}
