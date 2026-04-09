using WebApplication12.Models;

namespace WebApplication12.DataAccess
{
    public class ContactRepository : IContactRepository
    {
        public static List<ContactInfo> contacts = new List<ContactInfo>
        {
            new ContactInfo
            {
                 ContactId = 1,
                FirstName = "Raju",
                LastName = "K",
                EmailId = "raju@gmail.com",
                MobileNo = 9876543210,
                Designation = "Software Developer",
                CompanyId = 101,
                DepartmentId = 1
            },
            new ContactInfo
            {
                ContactId = 2,
                FirstName = "Asha",
                LastName = "M",
                EmailId = "asha@gmail.com",
                MobileNo = 9876501234,
                Designation = "HR Executive",
                CompanyId = 102,
                DepartmentId = 2
            }
        };
        public async Task<List<ContactInfo>> GetAllContactsAsync()
        {
            return await Task.FromResult(contacts);
        }

        public async Task<ContactInfo?> GetContactByIdAsync(int id)
        {
            var contact = contacts.FirstOrDefault(c => c.ContactId == id);
            return await Task.FromResult(contact);
        }
        public async Task<ContactInfo> AddContactAsync(ContactInfo contact)
        {
            int newId = contacts.Any() ? contacts.Max(c => c.ContactId) + 1 : 1;
            contact.ContactId = newId;

            contacts.Add(contact);

            return await Task.FromResult(contact);
        }
        public async Task<bool> UpdateContactAsync(int id, ContactInfo updatedContact)
        {
            var existingContact = contacts.FirstOrDefault(c => c.ContactId == id);

            if (existingContact == null)
            {
                return await Task.FromResult(false);
            }

            existingContact.FirstName = updatedContact.FirstName;
            existingContact.LastName = updatedContact.LastName;
            existingContact.EmailId = updatedContact.EmailId;
            existingContact.MobileNo = updatedContact.MobileNo;
            existingContact.Designation = updatedContact.Designation;
            existingContact.CompanyId = updatedContact.CompanyId;
            existingContact.DepartmentId = updatedContact.DepartmentId;

            return await Task.FromResult(true);
        }
        public async Task<bool> DeleteContactAsync(int id)
        {
            var contact = contacts.FirstOrDefault(c => c.ContactId == id);

            if (contact == null)
            {
                return await Task.FromResult(false);
            }

            contacts.Remove(contact);
            return await Task.FromResult(true);
        }
    }
}
