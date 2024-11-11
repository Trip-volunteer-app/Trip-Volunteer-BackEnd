using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Common;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.DTO;
using Trip_Volunteer.Core.Repository;

namespace Trip_Volunteer.Infra.Repository
{
    public class VolunteersRepository : IVolunteersRepository
    {
        private readonly IDbContext _dbContext;

        public VolunteersRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Volunteer> GetAllVolunteers()
        {
            IEnumerable<Volunteer> result = _dbContext.Connection.Query<Volunteer>("volunteers_package.GatAllVolunteers", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public Volunteer GetVolunteerById(int id)
        {
            var p = new DynamicParameters();
            p.Add("V_Id", id, DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Query<Volunteer>("volunteers_package.GetVolunteerById", p, commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }

        public void CreateVolunteer(Volunteer volunteer)
        {
            var p = new DynamicParameters();
            p.Add("LoginId", volunteer.Login_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("TripId", volunteer.Trip_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("VolunteerRoleId", volunteer.Volunteer_Role_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("V_Experience", volunteer.Experience, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("V_PhoneNumber", volunteer.Phone_Number, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("V_Email", volunteer.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("V_Notes", volunteer.Notes, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("V_EmergencyContacts", volunteer.Emergency_Contact, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("volunteers_package.CreateVolunteer", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateVolunteer(Volunteer volunteer)
        {
            var p = new DynamicParameters();
            p.Add("V_Id", volunteer.Volunteer_Id, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("LoginId", volunteer.Login_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("TripId", volunteer.Trip_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("VolunteerRoleId", volunteer.Volunteer_Role_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("V_Experience", volunteer.Experience, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("V_PhoneNumber", volunteer.Phone_Number, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("V_Email", volunteer.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("V_Status", volunteer.Status, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Application_date", volunteer.Date_Applied, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("V_Notes", volunteer.Notes, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("V_EmergencyContacts", volunteer.Emergency_Contact, dbType: DbType.String, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("volunteers_package.UpdateVolunteer", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteVolunteer(int id)
        {
            var p = new DynamicParameters();
            p.Add("V_Id", id, DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("volunteers_package.DeleteVolunteer", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateVolunteerStatus(Volunteer volunteer)
        {
            var p = new DynamicParameters();
            p.Add("p_Volunteer_ID", volunteer.Volunteer_Id, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_New_Status", volunteer.Status, DbType.String, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("volunteers_package.UpdateVolunteerStatus", p, commandType: CommandType.StoredProcedure);
        }

        public List<VolunteerSearchDto> SearchVolunteers(VolunteerSearchDto searchCriteria)
        {
            var parameters = new DynamicParameters();
            parameters.Add("pFirstName", searchCriteria.First_Name, DbType.String, ParameterDirection.Input);
            parameters.Add("pLastName", searchCriteria.Last_Name, DbType.String, ParameterDirection.Input);
            parameters.Add("pTripName", searchCriteria.Trip_Name, DbType.String, ParameterDirection.Input);
            parameters.Add("pVolunteerRole", searchCriteria.Role_Name, DbType.String, ParameterDirection.Input);

            var result = _dbContext.Connection.Query<VolunteerSearchDto>("SearchVolunteers", parameters, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<VolunteerSearchDto> AllVolunteersWithTrips()
        {
            var result = _dbContext.Connection.Query<VolunteerSearchDto>("AllVolunteers", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<Trip> GetTripsForVolunteerByName(string firstName, string lastName)
        {
            var parameters = new DynamicParameters();
            parameters.Add("pFirstName", firstName, DbType.String, ParameterDirection.Input);
            parameters.Add("pLastName", lastName, DbType.String, ParameterDirection.Input);

            var result = _dbContext.Connection.Query<Trip>(
                "GetTripsForVolunteerByName",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return result.ToList();
        }


        public int TotalNumberOfVolunteer()
        {

            var result = _dbContext.Connection.QuerySingleOrDefault<int>("volunteers_package.TotalNumberOfVolunteer", commandType: CommandType.StoredProcedure);

            return result;
        }


        public Volunteer GetVolunteerByTripId(int TripId, int LoginId)
        {
            var p = new DynamicParameters();
            p.Add("T_Id", TripId, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("L_Id", LoginId, DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Query<Volunteer>("volunteers_package.GetVolunteerByTripId", p, commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault(); // Now returns List<Volunteer>
        }


        //IEnumerable<UserInformationDto> result = _dbContext.Connection.Query<UserInformationDto>("User_Login_Package.GetUserinfoByName", p, commandType: CommandType.StoredProcedure);

        public List<GetTripVolunteersDTO> GetTripVolunteers(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_trip_id", id, DbType.Int32,  ParameterDirection.Input);
            IEnumerable<GetTripVolunteersDTO> result = _dbContext.Connection.Query<GetTripVolunteersDTO>("get_volunteer_info", p, commandType: CommandType.StoredProcedure);

            return result.ToList();

        }
    }
}