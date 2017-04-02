using System.Collections.Generic;

namespace LibSearch.Core.Model
{
    public class Photo : BaseEntity
    {
        public string Url { get; set; }

        public virtual List<User> User { get; set; }
        public virtual List<Book> Book { get; set; }
        public virtual List<Genre> Genre { get; set; }

        public Photo()
        {
            User = new List<User>();
            Book = new List<Book>();
            Genre = new List<Genre>();
        }
    }
}
