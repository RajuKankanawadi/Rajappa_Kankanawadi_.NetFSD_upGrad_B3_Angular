using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Cryptography.Pkcs;
using WebApplication10.Models;
using WebApplication10.Repository;

namespace WebApplication10.Controllers
{
    [Route("[controller]")]
    public class ContactController : Controller
    {
        private readonly IContactRepository _repository;

        public ContactController(IContactRepository repository)
        {
            _repository = repository;
        }

        [Route("ShowContacts")]
        public IActionResult ShowContacts()
        {
            var contacts = _repository.GetAllContacts();
            return View(contacts);
        }

        [Route("GetContactById/{id}")]
        public IActionResult GetContactById(int id)
        {
            var contact = _repository.GetContactById(id);
            return View(contact);
        }

        [HttpGet]
        [Route("AddContact")]
        public IActionResult AddContact()
        {
            ViewBag.Companies = new SelectList(_repository.GetCompanies(), "CompanyId", "CompanyName");
            ViewBag.Departments = new SelectList(_repository.GetDepartments(), "DepartmentId", "DepartmentName");

            return View();
        }

        [HttpPost]
        [Route("AddContact")]
        public IActionResult AddContact(ContactInfo contact)
        {
            _repository.AddContact(contact);
            return RedirectToAction("ShowContacts");
        }

        [HttpGet]
        [Route("EditContact/{id}")]
        public IActionResult EditContact(int id)
        {
            var contact = _repository.GetContactById(id);

            ViewBag.Companies = new SelectList(_repository.GetCompanies(), "CompanyId", "CompanyName", contact.CompanyId);
            ViewBag.Departments = new SelectList(_repository.GetDepartments(), "DepartmentId", "DepartmentName", contact.DepartmentId);

            return View(contact);
        }
        [HttpPost]
        [Route("EditContact")]
        public IActionResult EditContact(ContactInfo contact)
        {
            _repository.UpdateContact(contact);
            return RedirectToAction("ShowContacts");
        }

        [Route("DeleteContact/{id}")]
        public IActionResult DeleteContact(int id)
        {
            _repository.DeleteContact(id);
            return RedirectToAction("ShowContacts");
        }





























    }
}
