
using WebApplication13.Models;

namespace WebApplication13.Repository
{
        public interface IContactRepository
        {
            Task<(List<Contact>, int)> GetContactsAsync(int pageNumber, int pageSize);
        }
    }
