using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Libr.Data.Repository;
using Libr.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Libr.Pages.Shared.books
{
    public class DetailOfBookModel : PageModel
    {
        public IFormFile photo;
        public IEnumerable<book> Books { get; set; }
        private readonly BookRepository bd;

        public DetailOfBookModel(BookRepository context)
        {
            bd = context;
        }
        public book Book { get; set; }
        public IActionResult OnGet(int id)
        {
            Book = bd.objectBook(id);
            if (Book == null) return RedirectToPage("NotFound");

            return Page();
        }
    }
}
