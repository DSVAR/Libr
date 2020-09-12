using System;
using System.Collections.Generic;
using System.Text;
using Libr.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Libr.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
       
       
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
         
            Database.EnsureCreated();

        }
        
       
    }

}
