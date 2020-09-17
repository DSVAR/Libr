using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Libr.Data.Repository;
using Libr.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Libr.Pages.Shared
{
    public class ViewBooksModel : PageModel
    {
        public IEnumerable<book> Books { get; set; }
        private readonly BookRepository bd;

       public ViewBooksModel(BookRepository context)
        {
            bd = context;
        }
        public void OnGet()
        {
          Books = bd.GetBooksList();
        }
    }
}
