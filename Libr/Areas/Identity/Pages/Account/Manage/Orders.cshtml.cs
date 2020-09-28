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
    public class OrdersModel : PageModel
    {
        public CartRepository CR;
        public IEnumerable<Cart> Cast { get; set; }
        public OrdersModel(CartRepository context)
        {
            CR = context;
        }

        public void OnGet()
        {
            Cast = CR.Logitem().OrderBy(n=>n.login);
        }


        public IActionResult OnPostAccepting(int id)
        {
            Cart cat = CR.objectCart(id);
            cat.status = Status.Libraly;
            CR.update(cat);
            CR.save();
            OnGet();
            return Page();
        }
    }
}
