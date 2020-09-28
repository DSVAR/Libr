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
      


        public ViewBooksModel(BookRepository context,CartRepository CartContext)
        {
            bd = context;
            CR = CartContext;
        }
        public void OnGet()
        {
          Books = bd.GetBooksList();

        }


        public ActionResult OnPostOffer(int id)
        {
           
            Book = bd.objectBook(id);

            carts.login = HttpContext.User.Identity.Name;
            carts.NameBook = Book.Name;
            carts.Author = Book.Author;
            carts.priceBook =Book.price;
            carts.Photo = Book.PhotoPath;
            carts.FullPrice = Book.price * carts.count;
            carts.status = 0;
           



            CR.Offer(carts);
            CR.save();

            OnGet();
            return Page();
        }
        
        public ActionResult OnPostDelete(int id)
        {
            bd.delete(id);
            bd.Save();
            OnGet();
            return RedirectToPage("ViewBooks");
        }

    }
}
