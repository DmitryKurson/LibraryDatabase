using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDatabase.Entities
{
    public class Book
    {
        [Key] public int book_ID_in_database { get; set; }
        public int name { get; set; }
        public int year_of_writing { get; set; }
        public int publishing_house { get; set; }
        public int count_of_copyes { get; set; }
        public int count_of_pages { get; set; }
        public int literary_direction { get; set; }
        public int code { get; set; }

        public virtual OriginalBook? original_book_ { get; set; }
        public virtual PublishingHouse? publishing_house_ { get; set; }
        public virtual ICollection<BookCopy>? book_copyes_ { get; set; }      
    }
}
