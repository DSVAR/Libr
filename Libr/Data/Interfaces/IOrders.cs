using Libr.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Libr.Data.Interfaces
{
    public interface IOrders<T> where T:class
    {
        IEnumerable<T> CartItem();

         void Accept(T name);
        void Add(T name);
         void save();

    }
}
