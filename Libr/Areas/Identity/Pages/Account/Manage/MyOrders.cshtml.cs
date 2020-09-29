using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Libr.Data.Models;
using Libr.Data.Repository;
using Libr.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Libr.Areas.Identity.Pages.Account.Manage
{
    public class MyOrdersModel : PageModel
    {
        private readonly CartRepository CR;
        private readonly BookRepository BR;
        public IEnumerable<Cart> cat { get; set; }
        [BindProperty]
        public Cart cart { get; set; }
        public book Book { get; set; }
        public MyOrdersModel(CartRepository context,BookRepository Bcontext)
        {
            CR = context;
            BR = Bcontext;
        }
        

        public void OnGet()
        {
            string login = HttpContext.User.Identity.Name;
           cat= CR.CartItem(login);
        }


        public string stats(Enum val)
        {
            FieldInfo FI = val.GetType().GetField(val.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])FI.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes[0].Description.ToString();
        }

        public IActionResult OnPostDelete(string id)
        {
            cart = CR.objectCart(id);
            Book = BR.objectBook(cart.IdBook);
            Book.count += cart.count;
            BR.update(Book);
            CR.Delete(id);
            BR.Save();
            CR.save();
            OnGet();
            return Page();
        }
    }
}
