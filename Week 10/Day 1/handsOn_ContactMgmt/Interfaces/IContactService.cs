using ContactMgmtProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactMgmtProject.Interfaces
{
    public  interface IContactService
    {
        IEnumerable<Contact> GetAll();
        Contact? GetById(int id);
        void Add(Contact contact);
        void Update(Contact contact);
        void Delete(int id);
    }
}
