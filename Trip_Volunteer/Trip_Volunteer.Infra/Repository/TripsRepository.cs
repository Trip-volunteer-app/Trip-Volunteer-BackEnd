﻿using Dapper;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Trip_Volunteer.Core.Common;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.DTO;
using Trip_Volunteer.Core.Repository;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


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

        public Trip GetTripById(int ID)
        {
            var p = new DynamicParameters();
            p.Add("id", ID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Trip> result = _dbContext.Connection.Query<Trip>("trips_Package.GettripsById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void CreateTrip(Trip trip)
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

        public List<Trip> SearchBetweenDate(DateTime Start_Date, DateTime End_Date)
        {
            var p = new DynamicParameters();
            p.Add("p_start_date", Start_Date, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("p_end_date", End_Date, dbType: DbType.Date, direction: ParameterDirection.Input);
            IEnumerable<Trip> result = _dbContext.Connection.Query<Trip>("trips_Package.searchBetweendate", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public int NumberOfTrips()
        {
            var result = _dbContext.Connection.QuerySingleOrDefault<int>("trips_Package.NumberOfTrips", commandType: CommandType.StoredProcedure);

            return result;  
        }

        public int NumberOfFinishedTrips()
        {
            var result = _dbContext.Connection.QuerySingleOrDefault<int>("trips_Package.NumberOfFinishedTrips", commandType: CommandType.StoredProcedure);

            return result;
        }

        public List<Trip> TripsWithMaxReservations()
        {
            IEnumerable<Trip> result = _dbContext.Connection.Query<Trip>("trips_Package.TripsWithMaxReservations", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<TripInformationDTO> GetAllTripInformation()
        {
             IEnumerable<TripInformationDTO> result = _dbContext.Connection.Query<TripInformationDTO>("trips_Package.GetAllTripInformation", commandType: CommandType.StoredProcedure);
             return result.ToList();

        }
        public TripInformationDTO GetAllTripInformationById(int Id)
        {
            var p = new DynamicParameters();
            p.Add("id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<TripInformationDTO> result = _dbContext.Connection.Query<TripInformationDTO>("trips_Package.GetAllTripInformationById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
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
    }
}
