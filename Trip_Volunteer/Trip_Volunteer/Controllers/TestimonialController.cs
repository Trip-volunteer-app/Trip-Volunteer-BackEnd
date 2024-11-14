using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.Service;
using System.Linq;
using Trip_Volunteer.Core.DTO;


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
        [Route("GetAcceptedTestimonies")]
        public List<TestimonialDTO> GetAcceptedTestimonies()
        {
            return _testimonialService.GetAcceptedTestimonies();
        }


        [HttpGet]
        [Route("GetTestimonyById/{id}")]
        public Testimonial GetTestimonyById(int id)
        {
            return _testimonialService.GetTestimonyById(id);
        }

        [HttpPost]
        [Route("CreateTestimony")]
        [CheckClaimsAttribute("Roleid", "2")]
        public void CreateTestimony(Testimonial testimonial)
        {
            _testimonialService.CreateTestimony(testimonial);
        }

        [HttpPut]
        [Route("UpdateTestimony")]
        [CheckClaimsAttribute("Roleid", "1")]
        public void UpdateTestimony(Testimonial testimonial)
        {
            _testimonialService.UpdateTestimony(testimonial);
        }

        [HttpDelete]
        [Route("DeleteTestimony/{id}")]
        [CheckClaimsAttribute("Roleid", "1")]
        public void DeleteTestimony(int id)
        {
            _testimonialService.DeleteTestimony(id);
        }

        [HttpGet("StatusDistribution")]
        [CheckClaimsAttribute("Roleid", "1")]
        public async Task<IActionResult> GetStatusDistribution()
        {
            var distribution = await _testimonialService.GetStatusDistributionAsync();
            return Ok(distribution);
        }

        [HttpGet("GetTestimonyStatusCounts")]
        [CheckClaimsAttribute("Roleid", "1")]
        public List<TestimonyCountDTO> GetTestimonyStatusCounts()
        {
            return _testimonialService.GetTestimonyStatusCounts();
        }
    }
}
