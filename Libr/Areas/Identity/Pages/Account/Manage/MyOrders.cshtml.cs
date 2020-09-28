using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Libr.Data.Models;
using Libr.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Libr.Areas.Identity.Pages.Account.Manage
{
    public class MyOrdersModel : PageModel
    {
        private readonly CartRepository CR;

        public IEnumerable<Cart> cat { get; set; }
        [BindProperty]
        public Cart cart { get; set; }
        public MyOrdersModel(CartRepository context)
        {
            CR = context;
        }


        public void OnGet()
        {
            string login = HttpContext.User.Identity.Name;
           cat= CR.CartItem(login);
        }
    }
}
