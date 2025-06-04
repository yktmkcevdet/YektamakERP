using Models.Interface;

namespace Models
{
    public class MaliyetTespitKanal:IEntity,IBaseEntity
    {
        public int? Id { get; set; }
        public string ad { get; set; }
        public string kod { get; set; }
    }
}
