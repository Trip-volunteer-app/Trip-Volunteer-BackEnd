using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Common;
using Trip_Volunteer.Core.DTO;
using Trip_Volunteer.Core.Repository;

namespace Trip_Volunteer.Infra.Repository
{
    public class AnnualRepository : IAnnualRepository
    {
        private readonly IDbContext _dbContext;

        public AnnualRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<AnnualReportDTO> AnnualReport()
        {
            var result = _dbContext.Connection.Query<AnnualReportDTO>("generate_annual_revenue_report", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

    }
}
