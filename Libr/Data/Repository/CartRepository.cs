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

        public IEnumerable<Cart> Logitem()
        {
            return db.Carts;
        }

        public IEnumerable<Cart> CartItem(string login)
        {
           return db.Carts.Where(x => x.login ==login);
           
        }

         public Cart objectCart(string id)
         {
            return db.Carts.Find(id);
         }

        public void clear(string login)
        {
            Cart CartItem = db.Carts.Find(login);
            if (CartItem != null)
                db.Carts.RemoveRange(CartItem);
        }

      

        public void save()
        {
            db.SaveChanges();
        }

       public void Delete(string Id)
        {
            if (Id != null) { 
            Cart cart = db.Carts.Find(Id);
           
            if (cart != null) { 
            db.Carts.Remove(cart);
            }
            }
        }
        public void update(Cart name)
        {
            db.Carts.Update(name);
        }

        public void Offer(Cart book)
        {
            db.Add(book);
        }
    }
}
