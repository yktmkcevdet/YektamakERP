using System.Reflection;

namespace Models.Models
{
    public class GridColumnMetadata
    {
        public PropertyInfo Property { get; set; }
        public string Header { get; set; }
        public bool Visible { get; set; }
        public bool Sortable { get; set; }
        public string Format { get; set; }
        public int Order { get; set; }
        public string Permission { get; set; }
    }
}
