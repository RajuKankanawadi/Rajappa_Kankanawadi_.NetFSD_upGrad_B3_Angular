using ContactMgmtProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactMgmtProject.Interfaces
{
    public  interface IContactService
    {
        void AddContact(Contact contact);
        void UpdateContact(Contact contact);
        void DeleteContact(int id);
        List<Contact> GetAllContacts();
    }
}
