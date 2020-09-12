using Libr.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Libr.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.CodeAnalysis.Options;

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
        public book books { get; set; }
        
       
        [BindProperty]
        public IFormFile photo { get; set; }
        public IActionResult OnPost()
        {
            books.PhotoPath = "корейцы";
            if (books.Author != null && books.Name != null && books.count != 0)
            {

                using(AddBooksContext db=new AddBooksContext())
                {
                    db.Books.Add(books);
                    db.SaveChanges();
                }
                return RedirectToPage("AddBooks");
            }
            else return RedirectToPage("index");
        }


    }
}
