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
        public int ID { get; set; }
        public string login { get; set; }
        public string ip { get; set; }
        public int IDBook { get; set; }
        public string NameBook { get; set; }
        public int idBook { get; set; }
        public ushort priceBook { get; set; }
        public ushort count { get; set; }


    }
}
