using System;
using System.Collections.Generic;
using System.Text;
using Libr.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Libr.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
       
       
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
         
            Database.EnsureCreated();

        }
        
       
    }

}
