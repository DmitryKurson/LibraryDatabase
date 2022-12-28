using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDatabase.Entities
{
    public class OnlineIssue
    {
        [Key]
        public int issue_code { get; set; }
        public int readers_ticket_code { get; set; }
        public virtual ICollection<BookIssue>? book_issue_ { get; set; }
        public virtual Reader reader_ { get; set; }
    }
}
