using Libr.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Libr.Data
{
    public class OrdersContext : DbContext
    {
       public  DbSet<Orders> Orders { get; set; }

        public OrdersContext(DbContextOptions<OrdersContext> options) : base(options)
        {
            Database.Migrate();     
        }
    }
}
