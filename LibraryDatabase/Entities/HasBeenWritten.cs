using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryDatabase.Entities
{
    public class HasBeenWritten
    {
        [Key]
        public int author_code { get; set; }
        public int book_code { get; set; }  
       
        
        //Navigation Property
        public virtual Author author { get; set;}
        public virtual OriginalBook original_book { get; set;}
    }
}
