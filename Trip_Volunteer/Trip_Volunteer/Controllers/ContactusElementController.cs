﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.DTO;
using Trip_Volunteer.Core.Service;

namespace Trip_Volunteer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactusElementController : ControllerBase
    {
        private readonly IContactusElementService _contactusElementService;
        private readonly IConfiguration _configuration;

        public ContactusElementController(IContactusElementService contactusElementService, IConfiguration configuration)
        {
            _contactusElementService = contactusElementService;
            _configuration = configuration;
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
        [CheckClaimsAttribute("Roleid", "1")]
        public void CreateContactusElement(ContactusElement contactusElement)
        {
            _contactusElementService.CreateContactusElement(contactusElement);
        }


        [HttpPut]
        [Route("UpdateContactusElement")]
        [CheckClaimsAttribute("Roleid", "1")]
        public void UpdateContactusElement(ContactusElement contactusElement)
        {
            _contactusElementService.UpdateContactusElement(contactusElement);
        }


        [HttpDelete]
        [Route("DeleteContactusElement")]
        [CheckClaimsAttribute("Roleid", "1")]
        public void DeleteContactusElement(int id)
        {
            _contactusElementService.DeleteContactusElement(id);
        }

        [HttpPost]
        [Route("uploadImage")]
        [CheckClaimsAttribute("Roleid", "1")]
        public ContactusElement UploadImage()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine(_configuration["AppSettings:UploadImage"], fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            ContactusElement item = new ContactusElement();
            item.Image1 = fileName;
            return item;
        }

        
        [HttpPost]
        [Route("uploadImage2")]
        [CheckClaimsAttribute("Roleid", "1")]
        public ContactusElement UploadImage2()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine(_configuration["AppSettings:UploadImage"], fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            ContactusElement item = new ContactusElement();
            item.Hero_Img = fileName;
            return item;
        }

        
        [HttpPut]
        [Route("UpdateSelectedElement")]
        [CheckClaimsAttribute("Roleid", "1")]
        public void UpdateContactusElementSelectStatus(int id)
        {
            _contactusElementService.UpdateContactusElementSelectStatus(id);
        }

        
        [HttpGet]
        [Route("GetSelectedElement")]
        public ContactusElement GetSelectedContactusElement()
        {
            return _contactusElementService.GetSelectedContactusElement();
        }


        [HttpGet]
        [Route("GetAllTeam")]
        public List<TeamDTO> GetAllTeam()
        {
            return _contactusElementService.GetAllTeam();
        }

    }
}
