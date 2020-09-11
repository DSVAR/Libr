using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Libr.Areas.Identity.Pages.Account.Manage;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Models_book;

namespace Libr.Areas.Identity.Pages.Account.permission
{
    public class AddBooksModel : PageModel
    {
        readonly IWebHostEnvironment _IwebHostEnvironment;
        
       public string Dest { get; set; }
        public void OnGet()
        {
            
        }
        [BindProperty]
        public books books { get; set; }
       
        [BindProperty]
        public IFormFile photo { get; set; }
        public IActionResult OnPost()
        {
            Dest = "suka"+books.genres+books.Author+books.Name+books.count;
            return Page();
        }

     
        public string Hello()
        {
            return "Hello ASP.NET";
        }

    }
}
