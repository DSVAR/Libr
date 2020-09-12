using Libr.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Libr.Data
{
    public class AddBooksContext : DbContext
    {

        public DbSet<book> Books { get; set; }


        //public AddBooksContext (DbContextOptions options):base(options){
        //    Database.EnsureCreated();
        //}

        //protected override void OnModelCreating(ModelBuilder model)
        //{
        //    base.OnModelCreating(model);

        //    model.Entity<book>().HasData(new book
        //    {
        //        Author = "",
        //        Name="",
        //        count=1,
        //        description="описание",
        //        PhotoPath="rout"

        //    }); 
        //}

        public AddBooksContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Libr;Username=postgres;Password=password");
        }
    }
}
