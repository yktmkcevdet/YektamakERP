namespace Models.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class GridDisplayAttribute : Attribute
    {
        public string Header { get; set; }
        public bool Visible { get; set; } = true;
        public bool IsRequired { get; set; } = false;
        public int Order { get; set; } = 0;
        public string Tip { get; set; }
        public string ListVisibleColumnName { get; set; }
        public string ListName { get; set; }
        public bool readOnly { get; set; }=true;
        public bool Sortable { get; set; } = true;
        public string Format { get; set; }
        public string Permission { get; set; }
    }
}
