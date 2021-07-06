using System;
using System.Collections.Generic;
using System.Linq;
using Library_System.Models;

namespace Library_System.Services
{
    public class BookService : IBookService
    {
        private LibraryContext _context;
        public BookService(LibraryContext context)
        {
            _context = context;
        }
        public Book Create(BookDTO book)
        {
            using var transaction = _context.Database.BeginTransaction(); //using transaction

            try
            {
                var newBook = new Book {
                    BookName = book.BookName,
                };

                _context.Books.Add(newBook);
                _context.SaveChanges();

                transaction.Commit(); 

                return newBook;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Delete(Book book)
        {
            if(book == null)
            {
                return false;
            }

            using var transaction = _context.Database.BeginTransaction(); //using transaction

            try 
            {
                _context.Books.Remove(book);

                _context.SaveChanges();

                transaction.Commit(); 

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Book> GetAll()
        {
            return _context.Books.ToList();
        }

        public Book GetOne(int id)
        {
            return _context.Books.FirstOrDefault(b => b.Id == id);
        }

        public Book Update(BookDTO book)
        {
            var bookEdit = this.GetOne(book.Id);

            if(bookEdit == null)
            {
                return null;
            }

            using var transaction = _context.Database.BeginTransaction(); //using transaction

            try
            {
                bookEdit.BookName = book.BookName;

                _context.SaveChanges();

                transaction.Commit(); 

                return bookEdit;

            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}