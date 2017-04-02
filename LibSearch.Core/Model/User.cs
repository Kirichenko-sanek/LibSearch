using System.Collections.Generic;

namespace LibSearch.Core.Model
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public bool IsActivated { get; set; }
        public long IdPhoto { get; set; }
        public long IdRole { get; set; }

        public virtual Roles Roles { get; set; }
        public virtual Photo Photo { get; set; }
        public virtual List<SavedBook> SavedBooks { get; set; }


        public User()
        {
            SavedBooks = new List<SavedBook>();
        }

    }
}
