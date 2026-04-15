using WebApplication13.Models;

namespace WebApplication13.Services
{
    public interface IContactService
    {
        List<Contact> GetAllContacts();
        Contact GetContactById(int id);
    }
}
