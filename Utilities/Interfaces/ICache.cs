using Models;
using Models.DTO;

namespace Utilities.Interfaces
{
    public interface ICache
    {
        public Kullanici kullanici { get; set; }
        public List<AnaMenu> ananaMenuList { get; }
        public List<Menu> menuList { get; }
        public List<Yetki> yetkiList { get; }
        public List<ParcaGrup> parcaGrups { get; }
        public List<StokTip> stokTips { get; }
        public List<ProfilTip> profilTips { get; }
        public List<OlcuBirim> olcuBirims { get; }
        public List<MalzemeGrup> malzemeGrups { get; }
        public List<MalzemeStandart> malzemeStandarts { get; }
        public List<Proje> projes { get; }
        public List<Proje> unAssignedProjeList { get; }
        public List<Sektor> sektorList { get; }
        public List<Firma> firmaList { get; }
    }
}
