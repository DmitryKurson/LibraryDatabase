using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LibraryDatabase.Entities
{
    public class WorkInHall
    {
        [Key]
        public int passport_code_and_series { get; set; }
        public int hall_code { get; set; }
        public int date_of_work { get; set; }
        public ICollection<Worker>? worker_ { get; set; }
        public ICollection<Readerhall>? reader_hall_ { get; set; }
    }   
}
