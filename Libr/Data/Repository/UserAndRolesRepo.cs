using Libr.Data.Interfaces;
using Libr.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Libr.Data.Repository
{
    public class UserAndRolesRepo : IRolesAndUsers<IdentityUser>
    {
        private readonly ApplicationDbContext db;
        private readonly UserManager<IdentityUser> UM;

        public UserAndRolesRepo(ApplicationDbContext context, UserManager<IdentityUser> UMcontext)
        {
            db = context;
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
            var RoleNow = db.UserRoles.Find(users);
            await UM.RemoveFromRoleAsync(users, RoleNow.ToString()) ;
            await UM.AddToRoleAsync(users, role);
        }

        public async Task downUser(IdentityUser users)
        {
            await UM.AddToRoleAsync(users, "User");
        }


    }
}
