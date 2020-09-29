using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Libr.Data.Models;
using Libr.Data.Repository;
using Libr.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Libr.Areas.Identity.Pages.Account.Manage
{
    [Authorize(Roles = "User")]
    public class OrdersModel : PageModel
    {
        public CartRepository CR;
        public BookRepository BR;
        public IEnumerable<Cart> Cast { get; set; }
        book Books { get; set; }
        public OrdersModel(CartRepository context, BookRepository bookCOntext)
        {
            CR = context;
            BR = bookCOntext;
        }

        public void OnGet()
        {
            Cast = CR.Logitem().OrderBy(n=>n.login);
        }


        public IActionResult OnPostAccepting(string id)
        {
            Cart cat = CR.objectCart(id);
            cat.status = Status.InLibraly;
            CR.update(cat);
            CR.save();
            OnGet();
            return Page();
        }

        public IActionResult OnPostIssued(string id)
        {
            
            Cart cat = CR.objectCart(id);
          

            cat.status = Status.Issued;
            cat.Librariant = HttpContext.User.Identity.Name;
            cat.Issued = DateTime.Now;

           
            CR.update(cat);
        
            CR.save();

            return RedirectToPage("Orders");
        }
        public int CountBook(int id)
        {
            Books = BR.objectBook(id);
            return Books.count;
        }
    }
}
