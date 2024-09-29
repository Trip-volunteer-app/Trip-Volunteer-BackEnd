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

        public List<MonthlyReportDTO> MonthlyReport()
        {
            return _monthlyRepository.MonthlyReport();
        }
    }
}
