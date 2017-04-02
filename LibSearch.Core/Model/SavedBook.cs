namespace LibSearch.Core.Model
{
    public class SavedBook : BaseEntity
    {
        public long IdUser { get; set; }

        public virtual User User { get; set; }
    }
}
