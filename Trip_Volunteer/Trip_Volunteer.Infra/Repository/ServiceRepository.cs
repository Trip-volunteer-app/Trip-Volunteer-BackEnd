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
using Trip_Volunteer.Core.DTO;

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

        public void CreateService(Core.Data.Service service)
        {
            var p = new DynamicParameters();
            p.Add("p_service_cost", service.Service_Cost, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("p_service_name", service. Service_Name, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute(
                "service_Package.CreateService",
                p,
                commandType: CommandType.StoredProcedure);
        }

        public void UpdateService(Core.Data.Service service)
        {
            var p = new DynamicParameters();
            p.Add("p_service_id", service.Service_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_service_cost", service.Service_Cost, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("p_service_name", service.Service_Name, dbType: DbType.String, direction: ParameterDirection.Input);

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

        public List<Core.Data.Service> GetServiceByTripId(int id)
        {
            var p = new DynamicParameters();
            p.Add("id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Core.Data.Service> result = _dbContext.Connection.Query<Core.Data.Service>("service_Package.GetServiceByTripId", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public void CreateServiceForTrip(ServiceTripDTO serviceTrip)
        {
            var p = new DynamicParameters();
            p.Add("T_id", serviceTrip.Trip_Id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("s_id", serviceTrip.Trip_Id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("s_cost", serviceTrip.Service_Cost, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("s_name", serviceTrip.Service_Name, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute(
                "service_Package.CreateServiceForTrip",
                p,
                commandType: CommandType.StoredProcedure);
        }
    }
}
