using ContactMgmtProject.Interfaces;
using ContactMgmtProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactMgmtProject.Services
{
    public class ContactService : IContactService
    {
        private readonly List<Contact> _contacts = new();

        public void AddContact(Contact contact)
        {
            ValidateContact(contact);

            contact.Id = _contacts.Count + 1;
            _contacts.Add(contact);
        }

        public void UpdateContact(Contact contact)
        {
            ValidateContact(contact);

            var existing = _contacts.FirstOrDefault(c => c.Id == contact.Id);

            if (existing == null)
                throw new ArgumentException("Contact not found");

            existing.Name = contact.Name;
            existing.Email = contact.Email;
            existing.Phone = contact.Phone;
        }

        public void DeleteContact(int id)
        {
            var contact = _contacts.FirstOrDefault(c => c.Id == id);

            if (contact == null)
                throw new ArgumentException("Contact not found");

            _contacts.Remove(contact);
        }

        public List<Contact> GetAllContacts()
        {
            return _contacts;
        }

        private static void ValidateContact(Contact contact)
        {
            if (contact == null)
                throw new ArgumentNullException(nameof(contact));

            if (string.IsNullOrWhiteSpace(contact.Name))
                throw new ArgumentException("Name is required");

            if (string.IsNullOrWhiteSpace(contact.Email))
                throw new ArgumentException("Email is required");
        }
    }
}
