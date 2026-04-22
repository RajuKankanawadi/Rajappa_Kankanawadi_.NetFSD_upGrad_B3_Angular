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

        public IEnumerable<Contact> GetAll()
        {
            return _contacts;
        }

        public Contact? GetById(int id)
        {
            return _contacts.FirstOrDefault(c => c.Id == id);
        }

        public void Add(Contact contact)
        {
            ValidateContact(contact);

            if (_contacts.Any(c => c.Id == contact.Id))
            {
                throw new InvalidOperationException("Contact with same Id already exists.");
            }

            _contacts.Add(contact);
        }

        public void Update(Contact contact)
        {
            ValidateContact(contact);

            var existing = GetById(contact.Id);
            if (existing == null)
            {
                throw new KeyNotFoundException("Contact not found.");
            }

            existing.Name = contact.Name;
            existing.Email = contact.Email;
            existing.Phone = contact.Phone;
        }

        public void Delete(int id)
        {
            var contact = GetById(id);

            if (contact == null)
            {
                throw new KeyNotFoundException("Contact not found.");
            }

            _contacts.Remove(contact);
        }

        // 🔹 Extracted method (reduces complexity)
        private static void ValidateContact(Contact contact)
        {
            if (contact == null)
                throw new ArgumentNullException(nameof(contact));

            if (string.IsNullOrWhiteSpace(contact.Name))
                throw new ArgumentException("Name is required.");

            if (string.IsNullOrWhiteSpace(contact.Email))
                throw new ArgumentException("Email is required.");

            if (string.IsNullOrWhiteSpace(contact.Phone))
                throw new ArgumentException("Phone is required.");
        }
    }
}
