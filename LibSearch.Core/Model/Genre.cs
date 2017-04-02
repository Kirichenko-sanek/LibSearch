using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSearch.Core.Model
{
    public class Genre : BaseEntity
    {
        public string Name { get; set; }

        public virtual List<Book> Books { get; set; }

        public Genre()
        {
            Books = new List<Book>();
        }
    }
}
