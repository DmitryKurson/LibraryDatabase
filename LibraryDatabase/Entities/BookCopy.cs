﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDatabase.Entities
{
    internal class BookCopy
    {
        public int inventory_code { get; set; }
        public int database_book_code { get; set; }

        public Book book_ { get; set; }
        public ICollection<BookIssue>? book_issue_ { get; set; }
    }
}