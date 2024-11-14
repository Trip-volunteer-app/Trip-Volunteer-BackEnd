using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.Repository;
using Trip_Volunteer.Core.Service;
using Trip_Volunteer.Infra.Repository;

namespace Trip_Volunteer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutUsController : ControllerBase
    {
        private readonly IAboutUsService _aboutUsService;
        private readonly IConfiguration _configuration;

        public AboutUsController(IAboutUsService aboutUsService, IConfiguration configuration)
        {
            _aboutUsService = aboutUsService;
            _configuration = configuration;
        }

        [HttpGet]
        [Route("GetAllAboutUsElements")]
        //[CheckClaimsAttribute("Roleid", "1")]
        public List<Aboutu> GetAllAboutUsElements()
        {
            return _aboutUsService.GetAllAboutUsElements();
        }

        [HttpGet]
        [Route("GetAboutUsElementById/{id}")]
        //[CheckClaimsAttribute("Roleid", "1")]
        public Aboutu GetAboutUsElementById(int id)
        {
            return _aboutUsService.GetAboutUsElementById(id);
        }


        [HttpPost]
        [Route("CreateAboutUsElements")]
        [CheckClaimsAttribute("Roleid", "1")]
        public void CreateAboutUsElements(Aboutu aboutus)
        {
            _aboutUsService.CreateAboutUsElements(aboutus);
        }

        [HttpPut]
        [Route("UpdateAboutUsElements")]
        [CheckClaimsAttribute("Roleid", "1")]
        public void UpdateAboutUsElements(Aboutu aboutus)
        {
            _aboutUsService.UpdateAboutUsElements(aboutus);
        }

        [HttpDelete]
        [Route("DeleteAboutUsElements/{id}")]
        [CheckClaimsAttribute("Roleid", "1")]
        public void DeleteAboutUsElements(int id)
        {
            _aboutUsService.DeleteAboutUsElements(id);
        }


        [HttpPost]       
        [Route("uploadHeroImage")]
        [CheckClaimsAttribute("Roleid", "1")]
        public Aboutu uploadHeroImage()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine(_configuration["AppSettings:UploadImage"], fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            Aboutu item = new Aboutu();
            item.Hero_image = fileName;
            return item;
        }

        [HttpPost]
        [Route("uploadImage1")]
        [CheckClaimsAttribute("Roleid", "1")]
        public Aboutu UploadImage1()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine(_configuration["AppSettings:UploadImage"], fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            Aboutu item = new Aboutu();
            item.Image1 = fileName;
            return item;
        }

        
        [HttpPost]
        [Route("uploadImage2")]
        [CheckClaimsAttribute("Roleid", "1")]
        public Aboutu UploadImage2()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine(_configuration["AppSettings:UploadImage"], fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            Aboutu item = new Aboutu();
            item.Image2 = fileName;
            return item;
        }

        
        [HttpPost]
        [Route("uploadImage3")]
        [CheckClaimsAttribute("Roleid", "1")]
        public Aboutu UploadImage3()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine(_configuration["AppSettings:UploadImage"], fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            Aboutu item = new Aboutu();
            item.Image3 = fileName;
            return item;
        }

        
        [HttpPost]
        [Route("uploadImage4")]
        [CheckClaimsAttribute("Roleid", "1")]
        public Aboutu UploadImage4()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine(_configuration["AppSettings:UploadImage"], fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            Aboutu item = new Aboutu();
            item.Image4 = fileName;
            return item;
        }


        [HttpPost]
        [Route("uploadImage5")]
        [CheckClaimsAttribute("Roleid", "1")]
        public Aboutu UploadImage5()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine(_configuration["AppSettings:UploadImage"], fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            Aboutu item = new Aboutu();
            item.Image5 = fileName;
            return item;
        }

        [HttpPost]    
        [Route("uploadImage6")]
        [CheckClaimsAttribute("Roleid", "1")]
        public Aboutu UploadImage6()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine(_configuration["AppSettings:UploadImage"], fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            Aboutu item = new Aboutu();
            item.Image6 = fileName;
            return item;
        }

        [HttpPost]        
        [Route("uploadFeedbackBackground")]
        [CheckClaimsAttribute("Roleid", "1")]
        public Aboutu uploadFeedbackBackground()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine(_configuration["AppSettings:UploadImage"], fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            Aboutu item = new Aboutu();
            item.Feedback_background = fileName;
            return item;
        }



        [HttpGet]
        [Route("GetSelectedAboutus")]
        [CheckClaimsAttribute("Roleid", "1")]
        public Aboutu GetSelectedAboutus()
        {
            return _aboutUsService.GetSelectedAboutus();

        }

        
        [HttpPut]
        [Route("UpdateSelectedAboutus")]
        [CheckClaimsAttribute("Roleid", "1")]
        public void UpdateSelectedAboutus(int id)
        {
            _aboutUsService.UpdateSelectedAboutus(id);
        }
    }
}
