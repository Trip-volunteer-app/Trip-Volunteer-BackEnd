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
using Trip_Volunteer.Infra.Service;

namespace Trip_Volunteer.Infra.Repository
{
    public class TripsRepository : ITripsRepository
    {

        private readonly IDbContext _dbContext;
        public TripsRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Trip> GetAlltrips()
        {
            IEnumerable<Trip> result = _dbContext.Connection.Query<Trip>("trips_Package.GetAlltrips", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Trip GettripsById(int ID)
        {
            var p = new DynamicParameters();
            p.Add("id", ID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Trip> result = _dbContext.Connection.Query<Trip>("trips_Package.GettripsById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void CREATEtrips(Trip trip)
        {
            var p = new DynamicParameters();
            p.Add("trip_id", trip.Trip_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("trip_name", trip.Trip_Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("trip_location_id", trip.Trip_Location_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("trip_price", trip.Trip_Price, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("max_number_of_users", trip.Max_Number_Of_Users, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("start_date", trip.Start_Date, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("end_date", trip.End_Date, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("description", trip.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("max_number_of_volunteers", trip.Max_Number_Of_Volunteers, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("category_id", trip.Category_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("trips_Package.CREATEtrips", p, commandType: CommandType.StoredProcedure);


        }

        public void UPDATEtrips(Trip trip)
        {
            var p = new DynamicParameters();
            p.Add("tripid", trip.Trip_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("tripname", trip.Trip_Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("triplocationid", trip.Trip_Location_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("tripprice", trip.Trip_Price, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("maxnumberofusers", trip.Max_Number_Of_Users, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("startdate", trip.Start_Date, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("enddate", trip.End_Date, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("descriptions", trip.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("maxnumberofvolunteers", trip.Max_Number_Of_Volunteers, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("categoryid", trip.Category_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("trips_Package.UPDATEtrips", p, commandType: CommandType.StoredProcedure);

        }

        public void Deletetrips(int Id)
        {
            var p = new DynamicParameters();
            p.Add("Id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("trips_Package.Deletetrips", p, commandType: CommandType.StoredProcedure);

        }


    }
}
