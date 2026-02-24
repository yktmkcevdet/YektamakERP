namespace Models
{
    [Serializable]
    public class KDV:IEntity
    {
        public int? Id { get; set; }
        public string kod { get; set; }
        public string ad { get; set; }
        public double? oran { get; set; }
    }
}
