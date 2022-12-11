using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDatabase.Entities
{
    internal class Readerhall
    {
        public int hall_code { get; set; }
        public int count_of_tables { get; set; }
        public int count_of_shelves { get; set; }
        public WorkInHall work_in_hall_ { get; set; }
        public ICollection<BookIssueInHall>? book_issue_in_hall_ { get; set; }
    }
}
