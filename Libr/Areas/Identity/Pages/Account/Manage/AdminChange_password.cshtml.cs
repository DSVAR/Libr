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
        [BindProperty]
        public string NewPassword { get; set; }
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

        public async Task<IActionResult> OnPostChangePassword(string id,string email)
        {
            IdentityUser User = await UM.FindByIdAsync(id);
            
            NewPassword = Request.Form.FirstOrDefault(E => E.Key == User.Email.ToString()).Value;
            if (User != null)
            {
                var _passwordValidator =
                HttpContext.RequestServices.GetService(typeof(IPasswordValidator<IdentityUser>)) as IPasswordValidator<IdentityUser>;
                var _passwordHasher =
                    HttpContext.RequestServices.GetService(typeof(IPasswordHasher<IdentityUser>)) as IPasswordHasher<IdentityUser>;

                    User.PasswordHash = _passwordHasher.HashPassword(User, NewPassword);
                    await UM.UpdateAsync(User);
                    
                    return RedirectToAction("AdminChange_password");
                
            }
            return Page();
        }
        public async Task<IActionResult> OnPostDeleteUs(string id)
        {
            IdentityUser user;
            user = await UM.FindByIdAsync(id);
            if(user!=null)
            await UM.DeleteAsync(user);

            return RedirectToAction("AdminChange_password");
        }
    }
}
