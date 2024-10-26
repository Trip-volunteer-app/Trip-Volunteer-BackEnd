using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trip_Volunteer.Core.DTO;
using Trip_Volunteer.Core.Service;

namespace Trip_Volunteer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonthlyReportController : ControllerBase
    {
        private readonly IMonthlyService _monthlyService;

        public MonthlyReportController(IMonthlyService monthlyService)
        {
            _monthlyService = monthlyService;
        }

        [HttpGet]
        [Route("MonthlyReport")]
        [CheckClaimsAttribute("Roleid", "1")]
        public List<MonthlyReportDTO> MonthlyReport()
        {
            return _monthlyService.MonthlyReport();
        }


    }
}
