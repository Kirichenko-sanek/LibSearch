using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using LibSearch.Core.Model;

namespace LibSearch.Data.Mapping
{
    class BookMap : EntityTypeConfiguration<Book>
    {
        public BookMap()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            ToTable("Book");

            HasRequired(m=>m.Photo).WithMany(m=>m.Book).HasForeignKey(m=>m.IdPhoto).WillCascadeOnDelete(false);
        }
    }
}
