using System.Collections.Generic;
using Library_System.Models;

namespace Library_System.Services
{
    public interface IAuthorService
    {
        List<Author> GetAll();
        Author GetOne(int id);
        Author Create(AuthorDTO author);
        Author Update(AuthorDTO author);
        bool Delete(Author author);
    }

    public interface IClientService
    {
        List<Client> GetAll();
        Client GetOne(int id);
        Client Create(ClientDTO client);
        Client Update(ClientDTO client);
        bool Delete(Client client);
    }

    public interface IBookService
    {
        List<Book> GetAll();
        Book GetOne(int id);
        Book Create(BookDTO book);
        Book Update(BookDTO book);
        bool Delete(Book book);
    }
}