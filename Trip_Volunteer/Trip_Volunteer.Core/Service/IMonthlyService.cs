using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.DTO;

namespace Trip_Volunteer.Core.Service
{
    public interface IMonthlyService
    {
        List<MonthlyReportDTO> MonthlyReport(string month, string year);
        List<YearsDTO> GetDistinctTripYears();
        List<MonthlyReportDTO> GetDailyRevenueForMonth(string month, string year);

    }
}
