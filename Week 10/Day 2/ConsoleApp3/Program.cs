using ContactMgmtProject.Interfaces;
using ContactMgmtProject.Models;
using ContactMgmtProject.Services;

public class Program
{
    public static void Main(string[] args)
    {
        IContactService contactService = new ContactService();

        //ADD Contact
        contactService.AddContact(new Contact
        {
            Name = "Raju",
            Email = "raju@email.com",
            Phone = "9876543210"
        });

      
        contactService.AddContact(new Contact
        {
            Name = "John",
            Email = "john@email.com",
            Phone = "1234567890"
        });

        contactService.AddContact(new Contact
        {
            Name = "John",
            Email = "john@email.com",
            Phone = "1234567890"
        });

        //Update
        contactService.UpdateContact(new Contact
        {
            Id = 1,
            Name = "Raju Updated",
            Email = "raju.updated@email.com",
            Phone = "9999999999"
        });
        contactService.UpdateContact(new Contact
        {
            Id = 2,
            Name = "Raju Updated",
            Email = "raju.updated@email.com",
            Phone = "9999999999"
        });

        //DELETE
        contactService.DeleteContact(2);

        //GET ALL
        var contacts = contactService.GetAllContacts();

        Console.WriteLine("Contact List:");
        foreach (var contact in contacts)
        {
            Console.WriteLine($"{contact.Id} - {contact.Name} - {contact.Email} - {contact.Phone}");
        }

        Console.ReadLine();
    }
}