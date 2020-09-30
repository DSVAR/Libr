using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Libr.Data.Models;
using Libr.Data.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Libr.Areas.Identity.Pages.Account.Manage
{
    [Authorize(Roles = "Admin,Librarian")]
    public class HistoryOrdersModel : PageModel
    {
        private readonly CartRepository CR;
        public IEnumerable<Cart> carts;
        public HistoryOrdersModel(CartRepository context)
        {
            CR = context;
        }

        public void OnGet()
        {
            carts = CR.Logitem().Where(S=>S.status==Status.Issued);
        }
    }
}
