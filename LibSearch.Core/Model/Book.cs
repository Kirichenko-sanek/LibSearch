using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSearch.Core.Model
{
    public class Book
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public long IdPhoto { get; set; }
        public long IdGenre { get; set; }
        public string Summary { get; set; }
        public string Price { get; set; }


        public virtual Photo Photo { get; set; }
        public virtual Genre Genre { get; set; }

    }
}
