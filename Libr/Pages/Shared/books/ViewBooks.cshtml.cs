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
using Microsoft.AspNetCore.Authorization;

namespace Libr.Pages.Shared
{
    [Authorize(Roles = "User")]
    public class ViewBooksModel : PageModel
    {
        
    
        public IEnumerable<book> Books { get; set; }
        private readonly BookRepository bd;
        private readonly CartRepository CR;
        [BindProperty]
        public Cart carts { get; set; }
        [BindProperty]
        public book Book { get; set; }
        [BindProperty]
        public int count { get; set; }
        [BindProperty]
        public string Search { get; set; }
        [BindProperty]
        public string text { get; set; }

        
        public ViewBooksModel(BookRepository context,CartRepository CartContext)
        {
            bd = context;
            CR = CartContext;
          
        }

        /// <summary>
        /// ///////////////////
        /// </summary>
        public void OnGet()
        {
          Books = bd.GetBooksList();

        }
        /// <summary>
        /// ///////////////////
        /// </summary>

        public ActionResult OnPostOffer(int id)
        {
           
            Book = bd.objectBook(id);
            carts.IdBook = id;
            carts.login = HttpContext.User.Identity.Name;
            carts.NameBook = Book.Name;
            carts.Author = Book.Author;
            carts.count = count;
            carts.priceBook =Book.price;
            carts.Photo = Book.PhotoPath;
            carts.FullPrice = Book.price *count;
            carts.status = 0;
            carts.ID = Guid.NewGuid().ToString();
            Book.count -= count;

            bd.update(Book);
            CR.Offer(carts);
            bd.Save();
            CR.save();

            OnGet();
            return Page();
        }
        /// <summary>
        /// ///////////////////
        /// </summary>
        public ActionResult OnPostDelete(int id)
        {
            bd.delete(id);
            bd.Save();
            OnGet();
            return RedirectToPage("ViewBooks");
        }
        /// <summary>
        /// ///////////////////
        /// </summary>
        public int counBook(int id)
        {
            Book = bd.objectBook(id);
            return Book.count;
        }

        /// <summary>
        /// ///////////////////
        /// </summary>
        public ActionResult OnPostSearching() 
        {
            if (text != null)
            {
                if (Search == "Автору")
                {
                    Books = bd.GetBooksList().Where(A => A.Author == text);
                }
                if (Search == "Названию")
                {
                    Books = bd.GetBooksList().Where(N => N.Name == text);
                }
                return Page();
            }
            else return RedirectToPage("ViewBooks");
        }

    }
}
