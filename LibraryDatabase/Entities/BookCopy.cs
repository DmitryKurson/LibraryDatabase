using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LibraryDatabase.Entities
{
    public class BookCopy
    {
        [Key] public int inventory_code { get; set; }
        public int database_book_code { get; set; }

        public virtual Book book_ { get; set; }
        public virtual ICollection<BookIssue>? book_issue_ { get; set; }
    }
}
