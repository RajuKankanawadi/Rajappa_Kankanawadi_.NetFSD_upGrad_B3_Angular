
using ContactMgmtProject.Interfaces;
using ContactMgmtProject.Models;
using ContactMgmtProject.Services;

public class Program
{
    public static void Main()
    {
        IContactService service = new ContactService();

        service.Add(new Contact
        {
            Id = 1,
            Name = "Raju",
            Email = "raju@test.com",
            Phone = "9999999999"
        });

        var contacts = service.GetAll();

        foreach (var contact in contacts)
        {
            Console.WriteLine($"{contact.Name} - {contact.Email}");
        }
    }
}