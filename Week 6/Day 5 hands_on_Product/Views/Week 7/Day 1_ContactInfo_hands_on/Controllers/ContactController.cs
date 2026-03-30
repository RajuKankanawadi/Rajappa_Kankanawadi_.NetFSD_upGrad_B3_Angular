using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ContactController : Controller
        {
            private static List<ContactInfo> contacts = new List<ContactInfo>()
            {
            new ContactInfo
            {
                ContactId = 1,
                FirstName = "Ravi",
                LastName = "Kumar",
                CompanyName = "ABC Pvt Ltd",
                EmailId = "ravi@gmail.com",
                MobileNo = 9876543210,
                Designation = "Manager"
            },
            new ContactInfo
            {
                ContactId = 2,
                FirstName = "Raghu",
                LastName = "Patil",
                CompanyName = "XYZ Technologies",
                EmailId = "sneha@gmail.com",
                MobileNo = 9876501234,
                Designation = "Developer"
            }
        };

            // Display all contacts
            public ActionResult ShowContacts()
            {
                return View(contacts);
            }

            // Search contact by Id
            public ActionResult GetContactById(int id)
            {
                ContactInfo contact = contacts.FirstOrDefault(c => c.ContactId == id);

                return View(contact);
            }

            // GET: Add Contact
            public ActionResult AddContact()
            {
                return View();
            }

            // POST: Add Contact
            [HttpPost]
            public ActionResult AddContact(ContactInfo contactInfo)
            {
                contacts.Add(contactInfo);

                return RedirectToAction("ShowContacts");
            }
        }
    }
