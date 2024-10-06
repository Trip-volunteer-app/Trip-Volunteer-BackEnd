using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.Repository;
using Trip_Volunteer.Core.Service;

namespace Trip_Volunteer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutUsController : ControllerBase
    {
        private readonly IAboutUsService _aboutUsService;
        public AboutUsController(IAboutUsService aboutUsService)
        {
            _aboutUsService = aboutUsService;
        }

        [HttpGet]
        [Route("GetAllAboutUsElements")]
        public List<Aboutu> GetAllAboutUsElements()
        {
            return _aboutUsService.GetAllAboutUsElements();
        }

        [HttpGet]
        [Route("GetAboutUsElementById/{id}")]
        public Aboutu GetAboutUsElementById(int id)
        {
            return _aboutUsService.GetAboutUsElementById(id);
        }

        [HttpPost]
        [Route("CreateAboutUsElements")]
        public void CreateAboutUsElements(Aboutu aboutus)
        {
            _aboutUsService.CreateAboutUsElements(aboutus);
        }

        [HttpPut]
        [Route("UpdateAboutUsElements")]
        public void UpdateAboutUsElements(Aboutu aboutus)
        {
            _aboutUsService.UpdateAboutUsElements(aboutus);
        }

        [HttpDelete]
        [Route("DeleteAboutUsElements/{id}")]
        public void DeleteAboutUsElements(int id)
        {
            _aboutUsService.DeleteAboutUsElements(id);
        }

        [Route("uploadImage1")]
        [HttpPost]
        public Aboutu UploadImage1()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("Images", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            Aboutu item = new Aboutu();
            item.Image1 = fileName;
            return item;
        }

        [Route("uploadImage2")]
        [HttpPost]
        public Aboutu UploadImage2()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("Images", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            Aboutu item = new Aboutu();
            item.Image2 = fileName;
            return item;
        }
    }
}
