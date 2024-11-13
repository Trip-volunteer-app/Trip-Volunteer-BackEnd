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
        [Route("MonthlyReport/{year}/{month}")]
        //[CheckClaimsAttribute("Roleid", "1")]
        public List<MonthlyReportDTO> MonthlyReport(string month, string year)
        {
            return _monthlyService.MonthlyReport(month, year);
        }
        [HttpGet]
        [Route("GetDistinctTripYears")]
        public List<YearsDTO> GetDistinctTripYears()
        {
            return _monthlyService.GetDistinctTripYears();
        }

        [HttpGet]
        [Route("GetDailyRevenueForMonth/{year}/{month}")]
        public List<MonthlyReportDTO> GetDailyRevenueForMonth(string month, string year)
        {

            return _monthlyService.GetDailyRevenueForMonth(month, year);
        }

        [HttpGet]
        [Route("GetSYSMonthlyRevenue")]
        public GetSYSMonthlyRevenueDTO GetSYSMonthlyRevenue()
        {

            return _monthlyService.GetSYSMonthlyRevenue();
        }
    }
}
