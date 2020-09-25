using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Libr.Data;
using Microsoft.AspNetCore.Identity;
using Libr.Data.Models;
using Libr.Data.Repository;

namespace Libr.Areas.Identity.Pages.Account.Manage
{
    public class RolesAndUserModel : PageModel
    {
        ApplicationDbContext Db;
       public IEnumerable<IdentityUser> users;
        public IEnumerable<IdentityRole> role;
        public UserManager<IdentityUser> UM;
        public RoleManager<IdentityRole> RM;
        public UserAndRolesRepo Rol;

        [BindProperty]
        public IdentityUser user { get; set; }

        [BindProperty]
        public string Name { get; set; }

        public RolesAndUserModel(ApplicationDbContext context, UserManager<IdentityUser> UMContext, UserAndRolesRepo Repocontext, RoleManager<IdentityRole> RMcontext)
        {
            Db = context;
            UM = UMContext;
            Rol = Repocontext;
            RM = RMcontext;
        }

        public  void OnGet()
        {
        users= Db.Users.ToList();
            role = Db.Roles.ToList();
        }

        public IActionResult OnPostNewRole()
        {
            Rol.AddRole(Name);
            Rol.save();
   
            return Page();
        }

        public async Task<bool> Getrole(IdentityUser Us, string rolo)
        {
            return await UM.IsInRoleAsync(Us, rolo);
        }

        public async Task<IActionResult> OnPostAdmin(string id)
        {
        
            users = Db.Users.ToList();
            foreach (var U in users)
            {
                if (U.Id == id)
                { 
               
                user = U;
                }

            }

            await Rol.UpUserAsync(user, "Admin");
            OnGet();
            return Page();
        }

        public async Task<IActionResult> OnPostLibrarian(string id)
        {
          user=  await  UM.FindByIdAsync(id);
          await  Rol.UpUserAsync(user, "Librarian");
            OnGet();
            return Page();
        }
        public async Task<IActionResult> OnPostDownGrade(string id) 
        {
         
            users = Db.Users.ToList();
            foreach (var U in users)
            {
                if (U.Id == id)
                {
                    //   ID  = item.Id.ToString();
                    user = U;
                }

            }
        //    await Rol.downUser(user);
            OnGet();
            return Page();

        }
    }
}
