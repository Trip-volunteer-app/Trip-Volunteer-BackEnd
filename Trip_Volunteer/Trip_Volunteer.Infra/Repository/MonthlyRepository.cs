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

        public List<MonthlyReportDTO> MonthlyReport()
        {
            var result = _dbContext.Connection.Query<MonthlyReportDTO>("GetMonthlyRevenue", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }


    }
}
