using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trip_Volunteer.Core.DTO;
using Trip_Volunteer.Core.Service;

namespace Trip_Volunteer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnualController : ControllerBase
    {
        private readonly IAnnualService _annualService;

        public AnnualController(IAnnualService annualService)
        {
            _annualService = annualService;
        }

        [HttpGet]
        [Route("AnnualReport")]

        public List<AnnualReportDTO> AnnualReport()
        {
            return _annualService.AnnualReport();
        }
    }
}
