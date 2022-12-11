using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDatabase.Entities
{
    internal class Worker : Person
    {
        public int passport_code_and_series { get; set; }
        public int data_of_birth { get; set; }
        public ICollection<BookIssue>? book_issue_ { get; set; }
        public WorkInHall work_in_hall_ { get; set; }
    }
}
