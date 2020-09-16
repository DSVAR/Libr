using Libr.Data.Interfaces;
using Libr.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Libr.Data.Repository
{
    public class BookRepository : IBookView<book>
    {
        private readonly BooksContext db;

        public BookRepository(BooksContext context)
        {
            db =context;
        }

        public IEnumerable<book> GetBooksList()
        {
            return db.Books;
        }

        public book objectBook(int bookid) 
        {
            return db.Books.Find(bookid);
        }

        public void Add(book books)
        {
            db.Books.Add(books);
         
        }
        public void update(book books)
        {
            db.Entry(books).State = EntityState.Modified;

      
        }
      

        public void delete(int id)
        {
            book books = db.Books.Find(id);
            if (books != null)
                db.Books.Remove(books);

        }

        public void Save()
        {
            db.SaveChanges();
        }

        
    }

    
}
