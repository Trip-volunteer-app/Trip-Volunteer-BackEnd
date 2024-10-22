using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.Service;
using System.Linq;


namespace Trip_Volunteer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        [HttpGet]
        [Route("GetAllTestimonies")]
        public List<Testimonial> GetAllTestimonies()
        {
            return _testimonialService.GetAllTestimonies();
        }

        [HttpGet]
        [Route("GetTestimonyById/{id}")]
        public Testimonial GetTestimonyById(int id)
        {
            return _testimonialService.GetTestimonyById(id);
        }

        [HttpPost]
        [Route("CreateTestimony")]
        public void CreateTestimony(Testimonial testimonial)
        {
            _testimonialService.CreateTestimony(testimonial);
        }

        [HttpPut]
        [Route("UpdateTestimony")]
        public void UpdateTestimony(Testimonial testimonial)
        {
            _testimonialService.UpdateTestimony(testimonial);
        }

        [HttpDelete]
        [Route("DeleteTestimony/{id}")]
        public void DeleteTestimony(int id)
        {
            _testimonialService.DeleteTestimony(id);
        }


        [HttpGet("StatusDistribution")]
        public async Task<IActionResult> GetStatusDistribution()
        {
            var distribution = await _testimonialService.GetStatusDistributionAsync();
            return Ok(distribution);
        }


    }
}




