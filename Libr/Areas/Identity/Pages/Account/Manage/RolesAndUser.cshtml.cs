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
using Microsoft.AspNetCore.Authorization;

namespace Libr.Areas.Identity.Pages.Account.Manage
{
    [Authorize(Roles ="Admin")]
    public class RolesAndUserModel : PageModel
    {
       
       public IEnumerable<IdentityUser> users;
        public IEnumerable<IdentityRole> role;
        public UserManager<IdentityUser> UM;
        public UserAndRolesRepo Rol;

        [BindProperty]
        public IdentityUser user { get; set; }

        [BindProperty]
        public string Name { get; set; }

        public RolesAndUserModel(UserManager<IdentityUser> UMContext, UserAndRolesRepo Repocontext)
        {
            UM = UMContext;
            Rol = Repocontext;
          
        }

        public  void OnGet()
        {
            users = Rol.allGetUser();
           
        }

        public IActionResult OnPostNewRole()
        {
            if (Name != null) { 
            Db.Roles.Add(new IdentityRole {Name=Name,NormalizedName=Name.ToUpper() });
            Db.SaveChanges();
            }
            OnGet();
            return Page();
        }

        public async Task<bool> Getrole(string id, string rolo)
        {
            // return await UM.IsInRoleAsync(Us, rolo);
            return await Rol.GetRole(id, rolo);
        }

        public async Task<IActionResult> OnPostAdmin(string id)
        {
            await Rol.UpUserAsync(id, "Admin");
            OnGet();
            return Page();
        }

        public async Task<IActionResult> OnPostLibrarian(string id)
        {
          await  Rol.UpUserAsync(id, "Librarian");
            OnGet();
            return Page();
        }
        public async Task<IActionResult> OnPostDownGrade(string id) 
        {
            await Rol.downUser(id);
        
            OnGet();
            return Page();

        }
    }
}
