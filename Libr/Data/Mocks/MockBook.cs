using Libr.Data.Interfaces;
using Libr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Libr.Data.Mocks
{
    public class MockBook  //IBookView
    {
        private readonly BooksContext booksContext;
        public IEnumerable<book> AllBooks {get; }

        public book objectBook(int bookid) => booksContext.Books.FirstOrDefault(i => i.ID == bookid);
    }
}
