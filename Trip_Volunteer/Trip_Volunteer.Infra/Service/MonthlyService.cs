using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.DTO;
using Trip_Volunteer.Core.Repository;
using Trip_Volunteer.Core.Service;

namespace Trip_Volunteer.Infra.Service
{
    public class MonthlyService : IMonthlyService
    {
        private readonly IMonthlyRepository _monthlyRepository;

        public MonthlyService(IMonthlyRepository monthlyRepository) 
        {
            _monthlyRepository= monthlyRepository;
        }

        public List<MonthlyReportDTO> MonthlyReport(string month, string year)
        {
            return _monthlyRepository.MonthlyReport(month, year);
        }
        public List<YearsDTO> GetDistinctTripYears() { 
        return _monthlyRepository.GetDistinctTripYears();
        }

        public List<MonthlyReportDTO> GetDailyRevenueForMonth(string month, string year) {

            return _monthlyRepository.GetDailyRevenueForMonth(month, year);
        }

        public MonthlyReportDTO GetSYSMonthlyRevenue()
        {

            return _monthlyRepository.GetSYSMonthlyRevenue();
        }
    }
}
