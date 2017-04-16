using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using LibSearch.Core.Model;

namespace LibSearch.Data.Mapping
{
    class SavedBookMap : EntityTypeConfiguration<SavedBook>
    {
        public SavedBookMap()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(m => m.IdUser).IsRequired();
            ToTable("SavedBook");
            
            HasRequired(m=>m.User).WithMany(m=>m.SavedBooks).HasForeignKey(m=>m.IdUser).WillCascadeOnDelete(false);
        }
    }
}
