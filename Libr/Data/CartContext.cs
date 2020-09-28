using Libr.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Libr.Data
{
    public class CartContext:DbContext
    {
        public DbSet<Cart> Carts { get; set; }

        public CartContext(DbContextOptions<CartContext> options)
            : base(options)
        {

            Database.Migrate();

        }
    }
}
