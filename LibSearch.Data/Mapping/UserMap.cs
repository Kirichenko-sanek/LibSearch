using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using LibSearch.Core.Model;

namespace LibSearch.Data.Mapping
{
    class UserMap: EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);


            ToTable("User");

            HasRequired(m=>m.Roles).WithMany(m=>m.Users).HasForeignKey(m=>m.IdRole).WillCascadeOnDelete(false);
            HasRequired(m=>m.Photo).WithMany(m=>m.User).HasForeignKey(m=>m.IdPhoto).WillCascadeOnDelete(false);
        }
    }
}
