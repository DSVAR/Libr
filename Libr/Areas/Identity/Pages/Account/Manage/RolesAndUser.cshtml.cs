using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Libr.Data;
using Microsoft.AspNetCore.Identity;
using Libr.Data.Models;

namespace Libr.Areas.Identity.Pages.Account.Manage
{
    public class RolesAndUserModel : PageModel
    {
        ApplicationDbContext Db;
       public IEnumerable<IdentityUser> users;
        public IEnumerable<IdentityRole> role;
        public UserManager<IdentityUser> UM;
     
      [BindProperty]
        public string Name { get; set; }
        
        public RolesAndUserModel(ApplicationDbContext context, UserManager<IdentityUser> UMContext)
        {
            Db = context;
            UM = UMContext;
         
        }

        public void OnGet()
        {
        users= Db.Users.ToList();
            role = Db.Roles.ToList();
           
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

        public async Task<IActionResult> OnPostAdmin()
        {
           // await UM.AddToRoleAsync()
            return Page();
        }
    }
}
