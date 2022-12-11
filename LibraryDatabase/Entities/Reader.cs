﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDatabase.Entities
{
    internal class Reader : Person
    {
        public int reader_ticket_code { get; set; }
        public int data_of_birth { get; set; }
        public int place_of_living { get; set; }
        public int phone { get; set; }
        public OnlineIssue online_issue_ { get; set; }
    }
}
