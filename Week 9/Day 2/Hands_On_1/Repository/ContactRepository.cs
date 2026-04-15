
using WebApplication13.Models;

namespace WebApplication13.Repository
{
 
        public class ContactRepository : IContactRepository
        {
            private readonly List<Contact> _contacts;

            public ContactRepository()
            {
                // Simulated DB
                _contacts = new List<Contact>
            {
                new Contact { Id = 1, Name = "Raju", Email = "raju@gmail.com" },
                new Contact { Id = 2, Name = "Amit", Email = "amit@gmail.com" },
                new Contact { Id = 3, Name = "Sneha", Email = "sneha@gmail.com" }
            };
            }

            public List<Contact> GetAll()
            {
                Console.WriteLine("Fetching from DB: GetAll()");
                return _contacts;
            }

            public Contact GetById(int id)
            {
                Console.WriteLine($"Fetching from DB: GetById({id})");
                return _contacts.FirstOrDefault(c => c.Id == id);
            }
        }
    }

