namespace Models
{
    [Serializable]
    public class Sektor:IEntity
    {
        public int Id { get; set; }
        public string ad { get; set; }
        public string kod { get; set; }
    }
}