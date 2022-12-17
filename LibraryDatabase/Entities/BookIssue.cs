using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDatabase.Entities
{
    public class BookIssue
    {
        [Key] public int issue_code { get; set; }
        public int inventory_code { get; set; }
        public int days_to_issue_expire { get; set; }
        public int worker { get; set; }
        public int date_of_issue { get; set; }
        public int date_of_returning_book { get; set; }
        public int count_of_pledge { get; set; }
        public BookCopy book_copy_ { get; set; }
        public OnlineIssue online_book_issue { get; set; }
        public ICollection <BookIssueInHall> book_issue_in_hall_ { get; set; }
        public Worker worker_ { get; set; }
    }
}
