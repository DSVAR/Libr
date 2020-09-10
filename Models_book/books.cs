using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Interfaces.Streaming;
using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Models_book
{
    public class books
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string description { get; set; }
        public Genre?  genres {get;set;}
    }
}