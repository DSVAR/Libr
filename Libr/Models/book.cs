using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Libr.Models
{
    public class book
    {
        [Key]
        public string Name { get; set; }
        public string Author { get; set; }
        public string description { get; set; }
        public int count { get; set; }
        public string PhotoPath { get; set; }
        public Genre? genres { get; set; }
    }
}
