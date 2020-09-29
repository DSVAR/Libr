using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Libr.Data.Repository;
using Libr.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Libr.RepeatsCodes;
using Microsoft.AspNetCore.Authorization;

namespace Libr.Pages.Shared.books
{
    [Authorize(Roles = "Admin,Librarian")]
    public class DetailOfBookModel : PageModel
    {
        private readonly IWebHostEnvironment _webHostEnvironment;


        private readonly BookRepository bd;

        public DetailOfBookModel(BookRepository context, IWebHostEnvironment webHostEnvironment)
        {
            bd = context;
            _webHostEnvironment = webHostEnvironment;
        }
        [BindProperty]
        public book Book { get; set; }
        [BindProperty]
        public IFormFile photo { get; set; }

        public IActionResult OnGet(int id)
        {
            Book = bd.objectBook(id);
            if (Book == null) return RedirectToPage("NotFound");

            return Page();
        }


        public void OnPostDelete(int id)
        {

            bd.delete(id);
            bd.Save();
            OnGet(id);
        }

  
       
        public  ActionResult OnPostUpdate(int id)
        {
            Book.ID = id;
       
            if (photo != null)
            {
                if (Book.PhotoPath!= null)
                {
                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", Book.PhotoPath);
                    System.IO.File.Delete(filePath);

                }
                Book.PhotoPath = SaveFile.UpLoadFile(photo, _webHostEnvironment);
               
            }
            bd.update(Book);
           bd.Save();

         //   OnGet(id);
            return RedirectToPage("ViewBooks");
        }
     
    }
}
