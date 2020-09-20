using Libr.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Libr.Data.Interfaces
{
    public interface ICartView<T> where T:class
    {
        //IEnumerable<T> GetCartList();
        IEnumerable<T> CartItem(string login, string ip);
        Cart objectCart(int id);
        void clear(string loginOrIP);
        void Buy(T Item);

        void save();
    }
}
