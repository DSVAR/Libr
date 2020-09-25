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


        public void save()
        {
            db.SaveChanges();
        }

        public void AddRole(string name)
        {
            if (name != null) 
            { 
                db.Roles.Add(new IdentityRole { Name = name, NormalizedName = name.ToUpper() });
                db.SaveChanges();
            }
        }

        public async Task UpUserAsync(string id, string role)
        {
            user = db.Users.Find(id);
            await UM.AddToRoleAsync(user, role);
        }

        public async Task downUser(string id)
        {
            user = db.Users.Find(id);
            string[] role = { "Admin", "Librarian" };
            await UM.RemoveFromRolesAsync(user, role);
        }

        public IEnumerable<IdentityUser> allGetUser()
        {
            return db.Users.ToList();
        }

        public async Task<bool> GetRole(string id,string role)
        {
            
            user = await UM.FindByIdAsync(id);
            return await UM.IsInRoleAsync(user, role);
        }

        public IEnumerable<IdentityUser> GetUsers()
        {
            throw new NotImplementedException();
        }
    }
}
