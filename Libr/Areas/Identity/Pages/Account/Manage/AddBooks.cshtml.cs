using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Libr.Areas.Identity.Pages.Account.Manage;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Libr.Areas.Identity.Pages.Account.permission
{
    public class AddBooksModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<PersonalDataModel> _logger;
        public void OnGet()
        {
            
        }

        public string Dest { get; set; }

        public IActionResult OnPost()
        { 
            Dest = "suka";
            return Page();
        }

     
        public string Hello()
        {
            return "Hello ASP.NET";
        }

    }
}
