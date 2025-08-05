namespace Models.DTO
{
    public class AnaMenuDTO:IEntity
    {
        public int Id { get; set; }
        public string ad { get; set; }
        public string formAdi { get; set; }
        public string icon { get; set; }
        public int rolId { get; set; }
    }
}
