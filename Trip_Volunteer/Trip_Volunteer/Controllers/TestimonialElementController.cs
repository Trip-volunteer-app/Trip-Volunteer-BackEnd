using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.Service;

namespace Trip_Volunteer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialElementController : ControllerBase
    {
        private readonly ITestimonialElementService _testimonialElementService;
        public TestimonialElementController(ITestimonialElementService testimonialElementService)
        {
            _testimonialElementService = testimonialElementService;
        }


        [HttpGet]
        public List<TestimonialElement> GetAllTestimonialElements()
        {
            return _testimonialElementService.GetAllTestimonialElements();
        }


        [HttpGet]
        [Route("GetTestimonialElementById")]
        [CheckClaimsAttribute("Roleid", "1", "2")]
        public TestimonialElement GetTestimonialElementById(int id)
        {
            return _testimonialElementService.GetTestimonialElementById(id);
        }


        [HttpPost]
        [Route("CreateTestimonialElement")]
        [CheckClaimsAttribute("Roleid", "1")]
        public void CreateTestimonialElement(TestimonialElement testimonialElement)
        {
            _testimonialElementService.CreateTestimonialElement(testimonialElement);
        }


        [HttpPut]
        [Route("UpdateTestimonialElement")]
        [CheckClaimsAttribute("Roleid", "1")]
        public void UpdateTestimonialElement(TestimonialElement testimonialElement)
        {
            _testimonialElementService.UpdateTestimonialElement(testimonialElement);
        }


        [HttpDelete]
        [Route("DeleteTestimonialElement")]
        [CheckClaimsAttribute("Roleid", "1")]
        public void DeleteTestimonialElement(int id)
        {
            _testimonialElementService.DeleteTestimonialElement(id);
        }


        [HttpPost]
        [Route("uploadImage")]
        [CheckClaimsAttribute("Roleid", "1")]
        public TestimonialElement UploadImage()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("Images", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            TestimonialElement item = new TestimonialElement();
            item.Image1 = fileName;
            return item;
        }


    }
}
