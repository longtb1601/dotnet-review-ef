using System;
using System.Collections.Generic;
using System.Linq;
using Library_System.Models;

namespace Library_System.Services
{
    public class ClientService : IClientService
    {
        private LibraryContext _context;
        public ClientService(LibraryContext context)
        {
            _context = context;
        }
        public Client Create(ClientDTO client)
        {
            using var transaction = _context.Database.BeginTransaction(); //using transaction

            try
            {
                var newClient = new Client {
                    ClientName = client.ClientName
                };

                _context.Clients.Add(newClient);
                _context.SaveChanges();

                transaction.Commit(); 

                return newClient;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Delete(Client client)
        {
            if(client == null)
            {
                return false;
            }

            using var transaction = _context.Database.BeginTransaction(); //using transaction

            try 
            {
                _context.Clients.Remove(client);

                _context.SaveChanges();

                transaction.Commit(); 

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Client> GetAll()
        {
            return _context.Clients.ToList();
        }

        public Client GetOne(int id)
        {
            return _context.Clients.FirstOrDefault(c => c.Id == id);
        }

        public Client Update(ClientDTO client)
        {
            var clientEdit = this.GetOne(client.Id);

            if(clientEdit == null)
            {
                return null;
            }

            using var transaction = _context.Database.BeginTransaction(); //using transaction

            try
            {
                clientEdit.ClientName = client.ClientName;

                _context.SaveChanges();

                transaction.Commit(); 

                return clientEdit;

            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}