using Microsoft.Extensions.Caching.Memory;
using WebApplication13.Models;
using WebApplication13.Repository;

namespace WebApplication13.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _repository;
        private readonly IMemoryCache _cache;

        public ContactService(IContactRepository repository, IMemoryCache cache)
        {
            _repository = repository;
            _cache = cache;
        }

        public List<Contact> GetAllContacts()
        {
            string cacheKey = "contact_list";

            if (!_cache.TryGetValue(cacheKey, out List<Contact> contacts))
            {
                contacts = _repository.GetAll();

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(60));

                _cache.Set(cacheKey, contacts, cacheOptions);

                Console.WriteLine("Stored in Cache: Contact List");
            }
            else
            {
                Console.WriteLine("Fetched from Cache: Contact List");
            }

            return contacts;
        }

        public Contact GetContactById(int id)
        {
            string cacheKey = $"contact_{id}";

            if (!_cache.TryGetValue(cacheKey, out Contact contact))
            {
                contact = _repository.GetById(id);

                if (contact != null)
                {
                    var cacheOptions = new MemoryCacheEntryOptions()
                        .SetAbsoluteExpiration(TimeSpan.FromSeconds(60));

                    _cache.Set(cacheKey, contact, cacheOptions);

                    Console.WriteLine($"Stored in Cache: Contact {id}");
                }
            }
            else
            {
                Console.WriteLine($"Fetched from Cache: Contact {id}");
            }

            return contact;
        }
    }
}
