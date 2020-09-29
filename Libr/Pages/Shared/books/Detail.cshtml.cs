using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Libr.Data.Repository;
using Libr.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Libr.Pages.Shared.books
{
    public class DetailModel : PageModel
    {
        private readonly BookRepository bd;



        public DetailModel(BookRepository context)
        {
            bd = context;
        }
        public book Book;
        public void OnGet(int id)
        {
            Book = bd.objectBook(id);
        }
    }
}
