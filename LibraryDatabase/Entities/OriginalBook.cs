using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDatabase.Entities
{
    internal class OriginalBook
    {
        public int name { get; set; }
        public int code { get; set; }
        public int year_of_writing { get; set; }
        public int count_of_pages { get; set; }
        public int literature_direction { get; set; }

        public ICollection<HasBeenWritten>? HasBeenWritten { get; set; }
        public ICollection<Book>? books { get; set; }
    }
}
