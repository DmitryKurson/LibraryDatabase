using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDatabase.Entities
{
    internal class HasBeenWritten
    {
        public int author_code { get; set; }
        public int book_code { get; set; }  
       
        
        //Navigation Property
        public Author author { get; set;}
        public OriginalBook original_book { get; set;}
    }
}
