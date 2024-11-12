using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.DTO;
using Trip_Volunteer.Core.Repository;
using Trip_Volunteer.Core.Service;

namespace Trip_Volunteer.Infra.Service
{
    public class AnnualService : IAnnualService
    {
        private readonly IAnnualRepository _annualRepository;

        public AnnualService(IAnnualRepository annualRepository)
        {
            _annualRepository = annualRepository;
        }

        public List<AnnualReportDTO> GetMonthlyRevenueForYear(string year)
        {
            return _annualRepository.GetMonthlyRevenueForYear(year);

        }
        public List<AnnualReportDTO> GetYearlyRevenue(string year)
        {
            return _annualRepository.GetYearlyRevenue(year);

        }

    }
}
