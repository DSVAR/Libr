using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Libr.Areas.Identity.Pages.Account.Manage
{
    public static class ManageNavPages
    {
        public static string Index => "Index";
        public static string MyOrders => "MyOrders";
        public static string Orders => "Orders";
        public static string Email => "Email";
        public static string AddBooks => "AddBooks";
        public static string RolesAndUser => "RolesAndUser";
        public static string ChangePassword => "ChangePassword";
        public static string ChangePasswordUser => "ChangePasswordUser";
        public static string HistoryOrder => "HistoryOrder";


       
        public static string MyOrdersNavClass(ViewContext viewContext) => PageNavClass(viewContext, MyOrders);
        public static string OrdersNavClass(ViewContext viewContext) => PageNavClass(viewContext, Orders);
        public static string IndexNavClass(ViewContext viewContext) => PageNavClass(viewContext, Index);
        public static string AddBooksClass(ViewContext viewContext) => PageNavClass(viewContext, AddBooks);
        public static string RolesAndUserClass(ViewContext viewContext) => PageNavClass(viewContext, RolesAndUser);
        public static string EmailNavClass(ViewContext viewContext) => PageNavClass(viewContext, Email);

        public static string ChangePasswordNavClass(ViewContext viewContext) => PageNavClass(viewContext, ChangePassword);
        public static string ChangePasswordUserNavClass(ViewContext viewContext) => PageNavClass(viewContext, ChangePasswordUser);
        public static string HistoryOrderNavClass(ViewContext viewContext) => PageNavClass(viewContext, HistoryOrder);
        private static string PageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string
                ?? System.IO.Path.GetFileNameWithoutExtension(viewContext.ActionDescriptor.DisplayName);
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }
    }
}
