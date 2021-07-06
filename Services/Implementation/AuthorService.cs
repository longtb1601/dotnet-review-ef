using System;
using System.Collections.Generic;
using System.Linq;
using Library_System.Models;

namespace Library_System.Services
{
    public class AuthorService : IAuthorService
    {
        private LibraryContext _context;
        public AuthorService(LibraryContext context)
        {
            _context = context;
        }
        public Author Create(AuthorDTO author)
        {
            using var transaction = _context.Database.BeginTransaction(); //using transaction

            try
            {
                var newAuthor = new Author {
                    AuthorName = author.AuthorName
                };

                _context.Authors.Add(newAuthor);
                _context.SaveChanges();

                transaction.Commit(); 

                return newAuthor;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Delete(Author author)
        {
            if(author == null)
            {
                return false;
            }

            using var transaction = _context.Database.BeginTransaction(); //using transaction

            try 
            {
                _context.Authors.Remove(author);

                _context.SaveChanges();

                transaction.Commit(); 

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Author> GetAll()
        {
            return _context.Authors.ToList();
        }

        public Author GetOne(int id)
        {
            return _context.Authors.FirstOrDefault(a => a.Id == id);
        }

        public Author Update(AuthorDTO author)
        {
            var authorEdit = this.GetOne(author.Id);

            if(authorEdit == null)
            {
                return null;
            }

            using var transaction = _context.Database.BeginTransaction(); //using transaction

            try
            {
                authorEdit.AuthorName = author.AuthorName;

                _context.SaveChanges();

                transaction.Commit(); 

                return authorEdit;

            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}