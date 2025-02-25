using Models.Attributes;

namespace Models
{
    public class MalzemeGrup:IEntity
    {
        [FilterAttribute]
        public int Id;
        public string ad;
        public string kod;
        public int parcaGrupId;
        public bool isUretim;
    }
}
