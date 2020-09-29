using Libr.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Collections;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Libr.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.CodeAnalysis.Options;
using System;
using System.IO;
using Libr.Data.Repository;
using Libr.Data.Interfaces;
using Libr.RepeatsCodes;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Libr.Areas.Identity.Pages.Account.permission
{
    [Authorize(Roles = "Admin")]
    public class AddBooksModel : PageModel
    {
       

        readonly IWebHostEnvironment _IwebHostEnvironment;
        BookRepository bd;

        public AddBooksModel(IWebHostEnvironment webHostEnvironment, BookRepository context)
        {
            
            _IwebHostEnvironment = webHostEnvironment;
            bd = context;

        }
        
        public string Dest { get; set; }


        [BindProperty]
        public IFormFile photo { get; set; }
        [BindProperty]
        public book books { get; set; }
        
    

        public IActionResult OnPost()
        {
           
            books.PhotoPath = SaveFile.UpLoadFile(photo,_IwebHostEnvironment);
            
            
            if (books.Author != null && books.Name != null && books.count != 0 && books.PhotoPath != null && books.genres!=null )
            {
                 bd.Add(books);
                  bd.Save();
                return RedirectToPage("AddBooks");
            }
            else return RedirectToPage("index");
        }





    }
}
