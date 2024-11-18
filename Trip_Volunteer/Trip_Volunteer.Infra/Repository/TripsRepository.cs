using Dapper;
using System.Data;
using Trip_Volunteer.Core.Common;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.DTO;
using Trip_Volunteer.Core.Repository;


namespace Trip_Volunteer.Infra.Repository
{
    public class TripsRepository : ITripsRepository
    {

        private readonly IDbContext _dbContext;
        public TripsRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Trip> GetAllTrips()
        {
            IEnumerable<Trip> result = _dbContext.Connection.Query<Trip>("trips_Package.GetAlltrips", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public TripInformationDTO GetTripById(int ID)
        {
            var p = new DynamicParameters();
            p.Add("id", ID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<TripInformationDTO> result = _dbContext.Connection.Query<TripInformationDTO>("trips_Package.GettripsById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void CreateTrip(TripsDto trip)
        {
            var p = new DynamicParameters();
            p.Add("t_name", trip.Trip_Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("t_price", trip.Trip_Price, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("number_users", trip.Max_Number_Of_Users, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("s_date", trip.Start_Date, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("e_date", trip.End_Date, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("descr", trip.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("number_Volunteers", trip.Max_Number_Of_Volunteers, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("cate_id", trip.Category_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("img_name", trip.Image_Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("T_DEPARTURE_LOCATION", trip.Departure_Location, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("T_DESTINATION_LOCATION", trip.Destination_Location, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("T_DEPARTURE_LATITUDE", trip.Departure_Latitude, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("T_DEPARTURE_LONGITUDE", trip.Departure_Longitude, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("T_DESTINATION_LATITUDE", trip.Destination_Latitude, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("T_DESTINATION_LONGITUDE", trip.Destination_Longitude, dbType: DbType.String, direction: ParameterDirection.Input);

            var servicesJson = Newtonsoft.Json.JsonConvert.SerializeObject(trip.SelectedServices);
            p.Add("service_data", servicesJson, dbType: DbType.String, direction: ParameterDirection.Input);

            var volunteerRolesJson = Newtonsoft.Json.JsonConvert.SerializeObject(trip.SelectedVolunteerRoles);
            p.Add("volunteerRoleData", volunteerRolesJson, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("trips_Package.CreateTrip", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateTrip(Trip trip)
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

        public void DeleteTrip(int Id)
        {
            var p = new DynamicParameters();
            p.Add("Id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("trips_Package.Deletetrips", p, commandType: CommandType.StoredProcedure);
        }

        public int NumberOfTrips()
        {
            var result = _dbContext.Connection.QuerySingleOrDefault<int>("trips_Package.NumberOfTrips", commandType: CommandType.StoredProcedure);
            return result;
        }

        public List<Trip> TripsWithMaxReservations()
        {
            IEnumerable<Trip> result = _dbContext.Connection.Query<Trip>("trips_Package.TripsWithMaxReservations", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<List<TripInfoByIdDTO>> GetAllTripInformation()
        {
            List<TripInfoByIdDTO> trips = new List<TripInfoByIdDTO>();
            List<TripImage> images = new List<TripImage>();
            List<TripServiceDTO> tripServices = new List<TripServiceDTO>();
            try
            {
                using (var multi = await _dbContext.Connection.QueryMultipleAsync("trips_Package.GetAllTripInformation", commandType: CommandType.StoredProcedure))
                {
                    if (!multi.IsConsumed) trips = (await multi.ReadAsync<TripInfoByIdDTO>()).ToList();

                    if (!multi.IsConsumed) images = (await multi.ReadAsync<TripImage>()).ToList();

                    if (!multi.IsConsumed) tripServices = (await multi.ReadAsync<TripServiceDTO>()).ToList();
                }

                foreach (var trip in trips)
                {
                    trip.Images = images.Where(i => i.Trip_Id == trip.Trip_Id).ToList();
                    trip.TripServiceDTO = tripServices.Where(ts => ts.Trip_Id == trip.Trip_Id).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }

            return trips;
        }


        public async Task<List<TripInfoByIdDTO>> GETALLTRIPINFORMATIONWITHOUTOPTIONALSERVICES()
        {
            List<TripInfoByIdDTO> trips = new List<TripInfoByIdDTO>();
            List<TripImage> images = new List<TripImage>();
            List<TripServiceDTO> tripServices = new List<TripServiceDTO>();
            try
            {
                using (var multi = await _dbContext.Connection.QueryMultipleAsync("trips_Package.GETALLTRIPINFORMATIONWITHOUTOPTIONALSERVICES", commandType: CommandType.StoredProcedure))
                {
                    if (!multi.IsConsumed) trips = (await multi.ReadAsync<TripInfoByIdDTO>()).ToList();

                    if (!multi.IsConsumed) images = (await multi.ReadAsync<TripImage>()).ToList();

                    if (!multi.IsConsumed) tripServices = (await multi.ReadAsync<TripServiceDTO>()).ToList();
                }

                foreach (var trip in trips)
                {
                    trip.Images = images.Where(i => i.Trip_Id == trip.Trip_Id).ToList();
                    trip.TripServiceDTO = tripServices.Where(ts => ts.Trip_Id == trip.Trip_Id).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }

            return trips;
        }



        public TripInfoByIdDTO GetAllTripInformationById(int Id)
        {
            var p = new DynamicParameters();
            p.Add("id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (var multi = _dbContext.Connection.QueryMultiple("trips_Package.GetAllTripInformationById", p, commandType: CommandType.StoredProcedure))
            {
                var tripInfo = multi.Read<TripInfoByIdDTO>().FirstOrDefault();
                var images = multi.Read<TripImage>().ToList();
                var services = multi.Read<Core.Data.Service>().ToList();

                if (tripInfo != null)
                {
                    tripInfo.Images = images;
                    tripInfo.Services = services;
                }

                return tripInfo;
            }
        }

        public TripInfoByIdDTO GetAllTripInformationByIdWithOptionalServices(int Id)
        {
            var p = new DynamicParameters();
            p.Add("id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (var multi = _dbContext.Connection.QueryMultiple("trips_Package.GetAllTripInformationByIdWithOptionalServices", p, commandType: CommandType.StoredProcedure))
            {
                var tripInfo = multi.Read<TripInfoByIdDTO>().FirstOrDefault();
                var images = multi.Read<TripImage>().ToList();
                var services = multi.Read<Core.Data.Service>().ToList();

                if (tripInfo != null)
                {
                    tripInfo.Images = images;
                    tripInfo.Services = services;
                }

                return tripInfo;
            }
        }

        public TripWithVolDTO GetTripVolById(int Id)
        {
            var p = new DynamicParameters();
            p.Add("id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<TripWithVolDTO> result = _dbContext.Connection.Query<TripWithVolDTO>("trips_Package.GetTripVolById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
        public TripWithVolDTO GetTripUsersById(int Id)
        {
            var p = new DynamicParameters();
            p.Add("id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<TripWithVolDTO> result = _dbContext.Connection.Query<TripWithVolDTO>("trips_Package.GetTripUsersById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public List<GetVolunteerUserInfoByTripIdDTO> GetVolunteerUserInfoByTripId(int ID)
        {
            var p = new DynamicParameters();
            p.Add("p_trip_id", ID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<GetVolunteerUserInfoByTripIdDTO> result = _dbContext.Connection.Query<GetVolunteerUserInfoByTripIdDTO>("trips_Package.GetVolunteerUserInfoByTripId", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<GetUserPaymentsForTripDTO> GetUserPaymentsForTrip(int ID)
        {
            var p = new DynamicParameters();
            p.Add("p_trip_id", ID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<GetUserPaymentsForTripDTO> result = _dbContext.Connection.Query<GetUserPaymentsForTripDTO>("trips_Package.GetUserPaymentsForTrip", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public void updateMaxUser(int id, int res_num)
        {
            var p = new DynamicParameters();
            p.Add("id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("res_num", res_num, dbType: DbType.Int32, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("trips_Package.updateMaxUser", p, commandType: CommandType.StoredProcedure);

        }

        public List<TripsByRatingDTO> GetTopRatedTrips()
        {
            IEnumerable<TripsByRatingDTO> result = _dbContext.Connection.Query<TripsByRatingDTO>("trips_Package.GetTopRatedTrips", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<TripInformationDTO> GetAlltripsByCategory(int id)
        {
            var p = new DynamicParameters();
            p.Add("id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<TripInformationDTO> result = _dbContext.Connection.Query<TripInformationDTO>("trips_Package.GetAlltripsByCategory", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
