using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Common;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.Repository;

namespace Trip_Volunteer.Infra.Repository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly IDbContext _dbContext;
        public ServiceRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Core.Data.Service> GetAllcategories()
        {
            IEnumerable<Core.Data.Service> result = _dbContext.Connection.Query<Core.Data.Service>("categories_Package.GetAllcategories", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }

}
