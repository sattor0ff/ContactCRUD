using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        private ContactService _contactService;
        public ContactController()
        {
            _contactService = new ContactService();
        }
        [HttpGet("Contact")]
        public List<ContactDto> Contact()
        {
            return _contactService.GetContacts();
        }
        [HttpGet("ContactByName")]
        public List<ContactDto> ContactByName(string name)
        {
            return _contactService.GetContactByName(name);
        }
        [HttpPost("Add")]
        public bool Add(ContactDto contact)
        {
            return _contactService.AddContact(contact);
        }
        [HttpPut("Update")]
        public bool Update(ContactDto contact)
        {
            return _contactService.UpdateContact(contact);
        }
        [HttpDelete("Delete")]
        public void Delete(int id)
        {
            _contactService.DeleteContact(id);
        }
    }