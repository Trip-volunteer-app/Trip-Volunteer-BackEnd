using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.Service;

namespace Trip_Volunteer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactusElementController : ControllerBase
    {
        private readonly IContactusElementService _contactusElementService;
        public ContactusElementController(IContactusElementService contactusElementService)
        {
            _contactusElementService = contactusElementService;
        }
        [HttpGet]
        public List<ContactusElement> GetAllContactusElements()
        {
            return _contactusElementService.GetAllContactusElements();
        }
        [HttpGet]
        [Route("GetContactusElementById")]
        public ContactusElement GetContactusElementById(int id)
        {
            return _contactusElementService.GetContactusElementById(id);
        }
        [HttpPost]
        [Route("CreateContactusElement")]
        public void CreateContactusElement(ContactusElement contactusElement)
        {
            _contactusElementService.CreateContactusElement(contactusElement);
        }
        [HttpPut]
        [Route("UpdateContactusElement")]
        public void UpdateContactusElement(ContactusElement contactusElement)
        {
            _contactusElementService.UpdateContactusElement(contactusElement);
        }
        [HttpDelete]
        [Route("DeleteContactusElement")]
        public void DeleteContactusElement(int id)
        {
            _contactusElementService.DeleteContactusElement(id);
        }
    }
}
