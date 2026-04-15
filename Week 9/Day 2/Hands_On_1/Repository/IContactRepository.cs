using WebApplication13.Models;

namespace WebApplication13.Repository
{
    public interface IContactRepository
    {
        List<Contact> GetAll();
        Contact GetById(int id);

    }
}
