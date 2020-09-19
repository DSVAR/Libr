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
        Cart CartItem(string loginOrIP);
        void clear(string loginOrIP);
        void Buy(T Item);

        void save();
    }
}
