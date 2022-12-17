using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace LibraryDatabase.Entities
{
    public class PublishingHouse
    {
        [Key] public string name { get; set; }
        public int count_of_printing_per_year { get; set; }
        public int literature_direction { get; set; }

        public ICollection<Book>? book_ { get; set; }
    }
}
