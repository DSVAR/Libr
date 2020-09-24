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
        private IdentityUser user { get; set; }

        public UserAndRolesRepo(ApplicationDbContext context, UserManager<IdentityUser> UMcontext)
        {
            db = context;
            UM = UMcontext;
        }


        public IEnumerable<IdentityUser> GetUsers()
        {
           return db.Users.ToList();
        }
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

        public async Task downUser(string id)
        {
            string[] role = { "Admin", "Librarian" };
            await UM.RemoveFromRolesAsync(user, role);
        }

        public IEnumerable<IdentityUser> allGetUser(IdentityUser user)
        {
            return db.Users.ToList();
        }

        public async Task<bool> GetRole(string id,string role)
        {
            
            user = await UM.FindByIdAsync(id);
            return await UM.IsInRoleAsync(user, role);
        }

    }
}
