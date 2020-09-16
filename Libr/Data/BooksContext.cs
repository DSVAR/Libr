using Libr.Data.Repository;
using Libr.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Libr.Data
{
    public class BooksContext : DbContext
    {
       
        public DbSet<book> Books { get; set; }


        //public BooksContext()
        //{
        //    Database.EnsureCreated();
        //}

        public BooksContext(DbContextOptions<BooksContext> options)
            : base(options)
        {

            Database.EnsureCreated();

        }



    }
}
