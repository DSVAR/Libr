using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Libr.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Libr.Areas.Identity.Pages.Account.Manage
{
    [Authorize(Roles ="Admin")]
    public class AdminChange_passwordModel : PageModel
    {
        private readonly ApplicationDbContext db;
        public IEnumerable<IdentityUser> users;
        private UserManager<IdentityUser> UM;
        
        public AdminChange_passwordModel(UserManager<IdentityUser> UMContext, ApplicationDbContext context)
        {
            UM = UMContext;
            db = context;
        }

        public void OnGet()
        {
            users = db.Users.ToList();
            
        }


        public async Task<IActionResult> OnPostRout(string id)
        {
            IdentityUser us = await UM.FindByIdAsync(id);

            var password = await UM.GeneratePasswordResetTokenAsync(us);

            return Page();
        }
    }
}
