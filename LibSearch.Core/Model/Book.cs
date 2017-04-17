namespace LibSearch.Core.Model
{
    public class Book : BaseEntity
    {
        public string Name { get; set; }
        public long IdPhoto { get; set; }
        public string Category { get; set; }
        public string Author { get; set; }
        public string Summary { get; set; }
        public string PageUrl { get; set; }

        public virtual Photo Photo { get; set; }

    }
}
