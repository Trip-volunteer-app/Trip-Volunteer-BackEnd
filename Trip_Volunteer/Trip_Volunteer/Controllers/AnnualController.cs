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
        [Route("GetMonthlyRevenueForYear/{year}")]
        [CheckClaimsAttribute("Roleid", "1")]
        public List<AnnualReportDTO> GetMonthlyRevenueForYear(string year)
        {
            return _annualService.GetMonthlyRevenueForYear(year);

        }

        [HttpGet]
        [Route("GetYearlyRevenue/{year}")]
        [CheckClaimsAttribute("Roleid", "1")]
        public List<AnnualReportDTO> GetYearlyRevenue(string year)
        {
            return _annualService.GetYearlyRevenue(year);

        }
    }
}
