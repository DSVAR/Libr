using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Libr.Data.Models;
using Libr.Data.Repository;
using Libr.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Libr.Pages.Shared.books
{
    public class DetailModel : PageModel
    {
        private readonly BookRepository bd;
        private readonly CartRepository CR;

        public DetailModel(BookRepository context,CartRepository CRcontext)
        {
            bd = context;
            CR = CRcontext;
        }
        public book Book;
        [BindProperty]
        public Cart carts { get; set; }
        [BindProperty]
        public int count { get; set; }
        public void OnGet(int id)
        {
            Book = bd.objectBook(id);
        }
        public int counBook(int id)
        {
            Book = bd.objectBook(id);
            return Book.count;
        }




        public ActionResult OnPostOffer(int id)
        {

            Book = bd.objectBook(id);
            carts.IdBook = id;
            carts.login = HttpContext.User.Identity.Name;
            carts.NameBook = Book.Name;
            carts.Author = Book.Author;
            carts.count = count;
            carts.priceBook = Book.price;
            carts.Photo = Book.PhotoPath;
            carts.FullPrice = Book.price * count;
            carts.status = 0;
            carts.ID = Guid.NewGuid().ToString();
            Book.count -= count;

            bd.update(Book);
            CR.Offer(carts);
            bd.Save();
            CR.save();


            return RedirectToPage("ViewBooks");
        }
    }
}
