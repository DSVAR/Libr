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

namespace Libr.Pages.Shared.books
{
    public class DetailOfBookModel : PageModel
    {
        private readonly IWebHostEnvironment _webHostEnvironment;


        private readonly BookRepository bd;

        public DetailOfBookModel(BookRepository context, IWebHostEnvironment webHostEnvironment)
        {
            bd = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public book Book { get; set; }
        [BindProperty]
        public IFormFile photo { get; set; }
        [BindProperty]
        public string text { get; set; }
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

        
        public async Task<ActionResult> OnPostUpdate(book Pbook,int id)
        {
            
            if (photo != null)
            {
                

                if (Pbook.PhotoPath!= null)
                {
                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", Book.PhotoPath);
                    System.IO.File.Delete(filePath);

                    //Book = new book
                    //{
                    //    ID = Pbook.ID,
                    //    Author = Pbook.Author,
                    //    count = Pbook.count,
                    //    description = Pbook.description,
                    //    genres = Pbook.genres,
                    //    Name = Pbook.Name,
                    //    PhotoPath = Pbook.PhotoPath,
                    //    price = Pbook.price
                    //};

                }
                Pbook.PhotoPath = SaveFile.UpLoadFile(photo, _webHostEnvironment);
                
                //   Books.PhotoPath = Pbook.PhotoPath;
            }
            bd.update(Pbook);
           bd.Save();
            OnGet(id);
            return Page() ;
        }
     
    }
}
