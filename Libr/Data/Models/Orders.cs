using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Libr.Data.Models
{
    public class Orders
    {
        [Key]
        public int ID { get; set; }
        public string Book { get; set; }
        public string Author { get; set; }
        public string LoginUser { get; set; }
        public int count { get; set; }
        public ushort Price { get; set; }
        public bool Accept { get; set; }

    }
}
