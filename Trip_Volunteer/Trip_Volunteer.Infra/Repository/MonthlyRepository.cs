using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Common;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.DTO;
using Trip_Volunteer.Core.Repository;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Trip_Volunteer.Infra.Repository
{
    public class MonthlyRepository : IMonthlyRepository
    {
        private readonly IDbContext _dbContext;

        public MonthlyRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<MonthlyReportDTO> MonthlyReport(string month, string year)
        {
            var p = new DynamicParameters();
            p.Add("p_month", month, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_year", year, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Query<MonthlyReportDTO>("GetMonthlyRevenue", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<YearsDTO> GetDistinctTripYears()
        {
            IEnumerable<YearsDTO> result = _dbContext.Connection.Query<YearsDTO>(
                "GetDistinctTripYears", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<MonthlyReportDTO> GetDailyRevenueForMonth(string month, string year)
        {
            var p = new DynamicParameters();
            p.Add("p_month", month, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_year", year, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Query<MonthlyReportDTO>("GetDailyRevenueForMonth", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public GetSYSMonthlyRevenueDTO GetSYSMonthlyRevenue()
        {

            var result = _dbContext.Connection.Query<GetSYSMonthlyRevenueDTO>("GetSYSMonthlyRevenue",  commandType: CommandType.StoredProcedure);

            return result.SingleOrDefault();
        }


    }
}
