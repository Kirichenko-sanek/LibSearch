using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using LibSearch.Core.Model;

namespace LibSearch.Data.Mapping
{
    class GenreMap : EntityTypeConfiguration<Genre>
    {
        public GenreMap()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(m => m.Name).IsRequired();
            ToTable("Genre");
        }
    }
}
