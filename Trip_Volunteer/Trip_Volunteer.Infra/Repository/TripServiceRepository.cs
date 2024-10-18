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
    public class TripServiceRepository: ITripServiceRepository
    {
        private readonly IDbContext _dbContext;
        public TripServiceRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<TripService> GetAllTripServices()
        {
            IEnumerable<TripService> result = _dbContext.Connection.Query<TripService>("trip_service_Package.GetAllTripServices", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public TripService GetTripServiceById(int tripServiceId)
        {
            var p = new DynamicParameters();
            p.Add("p_trip_service_id", tripServiceId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Query<TripService>("trip_service_Package.GetTripServiceById",p, commandType: CommandType.StoredProcedure);

            return result.SingleOrDefault();
        }

        public void CreateTripService(TripService tripService)
        {
            var p = new DynamicParameters();
            p.Add("p_service_id", tripService.Service_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_trip_id", tripService.Trip_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("trip_service_Package.CreateTripService",p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateTripService(TripService tripService)
        {
            var p = new DynamicParameters();
            p.Add("p_trip_service_id", tripService.Trip_Service_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_service_id", tripService.Service_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_trip_id", tripService.Trip_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("trip_service_Package.UpdateTripService",p, commandType: CommandType.StoredProcedure);
          
        }

        public void DeleteTripService(int tripServiceId)
        {
            var p = new DynamicParameters();
            p.Add("p_trip_service_id", tripServiceId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("trip_service_Package.DeleteTripService",p, commandType: CommandType.StoredProcedure);
            
        }





    }
}
