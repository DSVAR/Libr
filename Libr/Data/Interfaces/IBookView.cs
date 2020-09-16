using Libr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Libr.Data.Interfaces
{
    //машина от APPLE
    interface IBookView<T>  where T : class
    {
        IEnumerable<T> GetBooksList();
        book objectBook(int bookid);

        void Add(T item);
        void delete(int id);
        void update(T item);
        void Save();
    }
}
