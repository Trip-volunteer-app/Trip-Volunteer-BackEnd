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

namespace Trip_Volunteer.Infra.Repository
{
    public class LocationRepository : ILocationRepository
    {
        //inject dbcontext to open session with db 
        private readonly IDbContext _dbContext;
        public LocationRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Location> GetAlllocation()
        {

            IEnumerable<Location> result = _dbContext.Connection.Query<Location>("location_Package.GetAlllocation", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Location GetlocationById(int ID)
        {
            
            var p = new DynamicParameters();
            p.Add("id", ID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Location> result = _dbContext.Connection.Query<Location>("location_Package.GetlocationById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }


        public void CREATElocation(Location location)
        {
            var p = new DynamicParameters();
            p.Add("location_id", location.Location_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("departure_location", location.Departure_Location, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("destination_location", location.Destination_Location, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("departure_latitude", location.Departure_Latitude, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("departure_longitude", location.Departure_Longitude, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("destination_latitude", location.Destination_Latitude, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("destination_longitude", location.Departure_Longitude, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("location_Package.CREATElocation", p, commandType: CommandType.StoredProcedure);


        }

        public void UPDATElocation(Location location)
        {
            var p = new DynamicParameters();
            p.Add("ID", location.Location_Id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("departurelocation", location.Departure_Location, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("destinationlocation", location.Destination_Location, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("departurelatitude", location.Departure_Latitude, dbType: DbType.Double, direction: ParameterDirection.Input);
            p.Add("departurelongitude", location.Departure_Longitude, dbType: DbType.Double, direction: ParameterDirection.Input);
            p.Add("destinationlatitude", location.Destination_Latitude, dbType: DbType.Double, direction: ParameterDirection.Input);
            p.Add("destinationlongitude", location.Departure_Longitude, dbType: DbType.Double, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("location_Package.UPDATElocation", p, commandType: CommandType.StoredProcedure);

        }

        public void Deletelocation(int Id)
        {
            var p = new DynamicParameters();
            p.Add("Id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("location_Package.Deletelocation", p, commandType: CommandType.StoredProcedure);

        }
        public Location GetLocationByTripId(int ID)
        {

            var p = new DynamicParameters();
            p.Add("T_Id", ID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Location> result = _dbContext.Connection.Query<Location>("location_Package.GetLocationByTripId", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
        public List<LocationDTO> GetAllLocationsWithTripId()
        {

            IEnumerable<LocationDTO> result = _dbContext.Connection.Query<LocationDTO>("location_Package.GetAllLocationsWithTripId", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

    }
}
