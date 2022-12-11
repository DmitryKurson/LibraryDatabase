using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDatabase.Entities
{
    internal class OnlineIssue
    {
        public int issue_code { get; set; }
        public int readers_ticket_code { get; set; }
        public ICollection<BookIssue>? book_issue_ { get; set; }
        public Reader reader_ { get; set; }
    }
}
