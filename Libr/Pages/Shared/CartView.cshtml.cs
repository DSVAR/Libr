using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Libr.Data.Models;
using Libr.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Libr.Pages.Shared
{
    public class CartViewModel : PageModel
    {
        public IEnumerable<Cart> Carts { get; set; }
        private readonly CartRepository db;
        private readonly OrdersRepository OR;


        [BindProperty]
        public Orders orders { get; set; }
        [BindProperty]
        public Cart cart { get; set; }


        private string login { get; set; }
        private string ip { get; set; }
        public ushort FullPrice;
        public int FullCount { get; set; }



        public CartViewModel(CartRepository context, OrdersRepository Ocontext)
        {
            db = context;
            OR = Ocontext;
        }

        public void OnGet()
        {
            login = HttpContext.User.Identity.Name;
            ip = HttpContext.Connection.RemoteIpAddress.ToString();

                Carts = db.CartItem(login,ip);
          

            sum();

        }


        void sum()
        {
            FullCount = 0;
            FullPrice = 0;
            foreach ( var item in Carts)
            {
                FullPrice += item.priceBook;
                FullCount += item.count;
            }
        }

        public void OnPostCleaning(int id)
        {
           
            OnGet();
        }

        public void OnPostOrder()
        {
       
            login = HttpContext.User.Identity.Name;
            ip = HttpContext.Connection.RemoteIpAddress.ToString();
            Carts = db.CartItem(login, ip);
            foreach(var item in Carts) 
            { 
                cart = db.objectCart(item.ID);
                orders.Book = cart.NameBook;
                orders.Author = cart.Author;
                orders.count = cart.count;
                orders.Price = cart.priceBook;
                orders.LoginUser = login;
                        orders.Accept = false;
                        OR.Add(orders);
            }
            OR.save();

              
            OnGet();
        }
    }
}
