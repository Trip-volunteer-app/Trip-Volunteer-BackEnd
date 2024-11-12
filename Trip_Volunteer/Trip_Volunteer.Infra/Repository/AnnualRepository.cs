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
        public List<AnnualReportDTO> GetMonthlyRevenueForYear(string year)
        {
            var p = new DynamicParameters();
            p.Add("p_year", year, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Query<AnnualReportDTO>("GetMonthlyRevenueForYear", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public List<AnnualReportDTO> GetYearlyRevenue(string year)
        {
            var p = new DynamicParameters();
            p.Add("p_year", year, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Query<AnnualReportDTO>("GetYearlyRevenue", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

    }
}
