using Libr.Data.Interfaces;
using Libr.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Libr.Data.Repository
{
    public class OrdersRepository  : IOrders<Orders>
    {
        readonly OrdersContext db;

        public OrdersRepository(OrdersContext context)
        {
            db = context;
        }



        public void Accept(Orders name)
        {
           db.Entry(name).State= EntityState.Modified;
        }

        public void Add(Orders name)
        {
            db.Add(name);
        }

       

        public IEnumerable<Orders> CartItem()
        {
            return db.Orders;
        }

        public void save()
        {
            db.SaveChanges();
        }
    }
}
