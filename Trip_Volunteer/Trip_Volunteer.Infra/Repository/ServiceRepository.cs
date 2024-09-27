using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Common;
using Trip_Volunteer.Core.Repository;
using Trip_Volunteer.Core.Data;

namespace Trip_Volunteer.Infra.Repository
{
    public class ServiceRepository: IServiceRepository
    {
        private readonly IDbContext _dbContext;
        public ServiceRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Core.Data.Service> GetAllServices()
        {
            IEnumerable<Core.Data.Service> result = _dbContext.Connection.Query<Core.Data.Service>(
                "service_Package.GetAllServices",
                commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public Core.Data.Service GetServiceById(int serviceId)
        {
            var p = new DynamicParameters();
            p.Add("p_service_id", serviceId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Query<Core.Data.Service>(
                "service_Package.GetServiceById",
                p,
                commandType: CommandType.StoredProcedure);

            return result.SingleOrDefault();
        }

        public void CreateService(decimal serviceCost, string serviceName)
        {
            var p = new DynamicParameters();
            p.Add("p_service_cost", serviceCost, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("p_service_name", serviceName, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute(
                "service_Package.CreateService",
                p,
                commandType: CommandType.StoredProcedure);
        }

        public void UpdateService(int serviceId, decimal serviceCost, string serviceName)
        {
            var p = new DynamicParameters();
            p.Add("p_service_id", serviceId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_service_cost", serviceCost, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("p_service_name", serviceName, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute(
                "service_Package.UpdateService",
                p,
                commandType: CommandType.StoredProcedure);
        }

        public void DeleteService(int serviceId)
        {
            var p = new DynamicParameters();
            p.Add("p_service_id", serviceId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute(
                "service_Package.DeleteService",
                p,
                commandType: CommandType.StoredProcedure);
        }


    }
}
