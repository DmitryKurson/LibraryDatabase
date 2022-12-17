using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LibraryDatabase.Entities
{
    public class BookIssueInHall
    {
        [Key]
        public int hall_code { get; set; }
        public int issue_code { get; set; }
        public BookIssue book_issue_ { get; set; }
        public Readerhall reader_hall_ { get; set; }
    }
}
