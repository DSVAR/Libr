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
using System;
using System.IO;

namespace Libr.Areas.Identity.Pages.Account.permission
{
    public class AddBooksModel : PageModel
    {
        readonly IWebHostEnvironment _IwebHostEnvironment;

        public AddBooksModel(IWebHostEnvironment webHostEnvironment)
        {
            _IwebHostEnvironment = webHostEnvironment;
        }
        
        public string Dest { get; set; }


        [BindProperty]
        public IFormFile photo { get; set; }
        [BindProperty]
        public book books { get; set; }
        
    

        public IActionResult OnPost()
        {
            books.PhotoPath = UpLoadFile();
            
            if (books.Author != null && books.Name != null && books.count != 0 && books.PhotoPath != null && books.genres!=null )
            {

                books.Author = UpLoadFile();
                using (AddBooksContext db = new AddBooksContext())
                {
                    db.Books.Add(books);
                    db.SaveChanges();
                }
                return RedirectToPage("AddBooks");
            }
            else return RedirectToPage("index");
        }


        private string UpLoadFile()
        {
            string folder = Path.Combine(_IwebHostEnvironment.WebRootPath, "images");
            string UniqName = null;
            if (photo != null)
            {
                UniqName = Guid.NewGuid().ToString() + "__" + photo.FileName;
                string FilePath = Path.Combine(folder, UniqName);
                using (var fs = new FileStream(FilePath, FileMode.Create))
                {
                    photo.CopyTo(fs);
                }
            }
            return UniqName;
        }


    }
}
