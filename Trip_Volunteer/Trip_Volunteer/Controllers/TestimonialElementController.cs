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
        public TestimonialElement GetTestimonialElementById(int id)
        {
            return _testimonialElementService.GetTestimonialElementById(id);
        }
        [HttpPost]
        [Route("CreateTestimonialElement")]
        public void CreateTestimonialElement(TestimonialElement testimonialElement)
        {
            _testimonialElementService.CreateTestimonialElement(testimonialElement);
        }
        [HttpPut]
        [Route("UpdateTestimonialElement")]
        public void UpdateTestimonialElement(TestimonialElement testimonialElement)
        {
            _testimonialElementService.UpdateTestimonialElement(testimonialElement);
        }
        [HttpDelete]
        [Route("DeleteTestimonialElement")]
        public void DeleteTestimonialElement(int id)
        {
            _testimonialElementService.DeleteTestimonialElement(id);
        }
    }
}
