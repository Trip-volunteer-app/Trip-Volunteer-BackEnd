using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.Service;

namespace Trip_Volunteer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactUController : ControllerBase
    {
        private readonly IContactUsService _contactUsService;

        public ContactUController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }
        [HttpGet]
        public List<ContactU> GetAllContacts()
        {
          return _contactUsService.GetAllContacts();
           
        }

        [HttpGet]
        [Route("GetContactById/{contactId}")]
        public ContactU GetContactById(int contactId)
        {
           return _contactUsService.GetContactById(contactId);
        }

        [HttpPost]
        [Route("CreateContact")]
        public void CreateContact(ContactU contact)
        {
            _contactUsService.CreateContact(contact);
        }

        [HttpPut]
        [Route("UpdateContact")]
        public void UpdateContact(ContactU contact)
        {
            _contactUsService.UpdateContact(contact);
        }

        [HttpDelete]
        [Route("DeleteContact/{contactId}")]
        public void DeleteContact(int contactId)
        {
            _contactUsService.DeleteContact(contactId);
        }


    }
}
