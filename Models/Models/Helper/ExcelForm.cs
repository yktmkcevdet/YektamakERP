namespace Models
{
    public class ExcelForm : IEntity
    {
        public int Id { get; set; }
        public int? satirSayisi { get; set; }
        public string formAd { get; set; }
        public string excel { get; set; } 

    } 
}
