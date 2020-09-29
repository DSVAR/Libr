using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Libr.Data.Models
{
    public class Cart
    {
        [Key]
        public string ID { get; set; }
        public int IdBook { get; set; }
        public string login { get; set; }
        public string NameBook { get; set; }
        public string Author { get; set; }
        public float priceBook { get; set; }
        public float FullPrice { get; set; }
        public int count { get; set; }
        public string Photo { get; set; }

        public Status? status { get; set; }
        public string Librariant { get; set; }
        public DateTime Issued { get; set; }


    }
}
