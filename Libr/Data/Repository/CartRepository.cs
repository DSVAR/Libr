using Libr.Data.Interfaces;
using Libr.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Libr.Data.Repository
{
    public class CartRepository : ICartView<Cart>
    {
        readonly CartContext db;

        public CartRepository(CartContext context)
        {
            db = context;
        }

        public void Buy(Cart cart)
        {
            
          db.Carts.Add(cart);
            
        }

        public Cart CartItem(string loginOrIP)
        {
            Cart CartItem = db.Carts.Find(loginOrIP);
            if (CartItem != null)
                return CartItem;
            else return null;//НЕЛЬЗЯ ВОЗРАЩАТЬ ПУСТОТУ!!!
        }

        public void clear(string loginOrIP)
        {
            Cart CartItem = db.Carts.Find(loginOrIP);
            if (CartItem != null)
                db.Carts.RemoveRange(CartItem);
        }

     
        public void save()
        {
            db.SaveChanges();
        }
    }
}
