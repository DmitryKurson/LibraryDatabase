using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDatabase.Entities
{
    public class Author : Person
    {
        public int authorID { get; set; }
        public string nationality { get; set; }
        public string literature_direction { get; set; }       
        public ICollection <HasBeenWritten>? has_been_written_ { get; set; }
    }
}
