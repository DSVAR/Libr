using Libr.Data.Interfaces;
using Libr.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Libr.Data.Repository
{
    public class UserAndRolesRepo:IRolesAndUsers<IdentityUser>
    {
        private readonly ApplicationDbContext db;
        private static UserManager<IdentityUser> UM;
        User user;

       public UserAndRolesRepo(ApplicationDbContext context, UserManager<IdentityUser> UMcontext)
        {
            db = context;
          //  UM = UMcontext;
        }
        public static void seed( UserManager<IdentityUser> UMcontext)
        {
            UM = UMcontext;
        }

        public IEnumerable<IdentityUser> GetUsers()
        {
           return db.Users.ToList();
        }

        //public IEnumerable<User> GetRoles()
        //{
        //    throw new NotImplementedException();
        //}

        public void save()
        {
            db.SaveChanges();
        }

        public void AddRole(string name)
        {
           db.Roles.Add(new IdentityRole { Name = name, NormalizedName = name.ToUpper() });
        }

        public async Task UpUserAsync(IdentityUser users, string role)
        {
            
            await UM.AddToRoleAsync(users, role);
        }

        public void downUser(int id)
        {
            throw new NotImplementedException();
        }


    }
}
