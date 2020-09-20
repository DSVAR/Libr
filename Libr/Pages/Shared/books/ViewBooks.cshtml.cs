using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Libr.Data.Models;
using Libr.Data.Repository;
using Libr.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Web;
using System.Net.Http;

namespace Libr.Pages.Shared
{
    public class ViewBooksModel : PageModel
    {
        public IEnumerable<book> Books { get; set; }
        private readonly BookRepository bd;
        private readonly CartRepository CR;
        [BindProperty]
        public Cart carts { get; set; }
        [BindProperty]
        public book Book { get; set; }
        public string ip { get; set; }
        public string login { get; set; }


        public ViewBooksModel(BookRepository context,CartRepository CartContext)
        {
            bd = context;
            CR = CartContext;
        }
        public void OnGet()
        {
          Books = bd.GetBooksList();
         
           

        }


        public void OnPostOffer(int id)
        {
            carts.login = HttpContext.User.Identity.Name;
            carts.ip = HttpContext.Connection.LocalIpAddress.ToString();
            Book = bd.objectBook(id);
            carts.IDBook = Book.ID;
            carts.NameBook = Book.Name;
            carts.Author = Book.Author;
            carts.priceBook = Book.price;

            CR.Buy(carts);
            CR.save();
            OnGet();
        }
    }
}
