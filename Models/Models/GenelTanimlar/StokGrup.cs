using Models.Attributes;

namespace Models
{
    public class StokGrup : IEntity
    {
        [GridDisplay(Header ="Id")]
        public int? Id { get; set; }
        [GridDisplay(Header = "kod")]
        [MaxLength(2)]
        public string kod { get; set; }
        [GridDisplay(Header = "ad")]
        public string ad { get; set; }
    }
}
