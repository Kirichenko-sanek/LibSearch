using System.Collections.Generic;
using System.Data.Entity;
using LibSearch.Core.Model;
using LibSearch.Data.Mapping;

namespace LibSearch.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<SavedBook> SavedBooks { get; set; }
        public DbSet<User> Users { get; set; }

        public DataContext() : base("LibSearchDB")
        {
            Configuration.LazyLoadingEnabled = true;
            Database.SetInitializer(new LibSearchInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BookMap());
            modelBuilder.Configurations.Add(new GenreMap());
            modelBuilder.Configurations.Add(new PhotoMap());
            modelBuilder.Configurations.Add(new RolesMap());
            modelBuilder.Configurations.Add(new SavedBookMap());
            modelBuilder.Configurations.Add(new UserMap());
        }



        private class LibSearchInitializer : DropCreateDatabaseAlways<DataContext>
        {
            protected override void Seed(DataContext context)
            {
                var roles = new List<Roles>
                {
                    new Roles()
                    {
                        Role = "Admin"
                    },
                    new Roles()
                    {
                        Role = "User"
                    }
                };
                foreach (var role in roles) context.Roles.Add(role);
                context.SaveChanges();



                base.Seed(context);
            }
        }
    }
}
