using System.Collections.Generic;
using System.Data.Entity;
using LibSearch.BL;
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

                var photos = new List<Photo>
                {
                    new Photo()
                    {
                        Url = "/assets/images/users/1.jpg"
                    }
                };
                foreach (var photo in photos) context.Photos.Add(photo);
                context.SaveChanges();



                var salt = PasswordHashing.GenerateSaltValue();
                var pass = PasswordHashing.HashPassword("123456", salt);
                var users = new List<User>
                {
                    new User()
                    {
                        FirstName = "Alexander",
                        LastName = "Kirichenko",
                        Password = pass,
                        PasswordSalt = salt,
                        Email = "kirichenko-sanek@mail.ru",
                        IsActivated = true,
                        IdRole = 1,
                        IdPhoto = 1
                    }
                };
                foreach (var user in users) context.Users.Add(user);
                context.SaveChanges();



                base.Seed(context);
            }
        }
    }
}
