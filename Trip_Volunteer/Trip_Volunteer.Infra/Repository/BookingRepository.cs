using Dapper;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
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
    public class BookingRepository: IBookingRepository
    {
        private readonly IDbContext _dbContext;
        public BookingRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Booking> GetAllBookings()
        {
            IEnumerable<Booking> result = _dbContext.Connection.Query<Booking>(
                "booking_Package.GetAllBookings",
                commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public BookingDTO GetBookingById(int bookingId)
        {
            var p = new DynamicParameters();
            p.Add("p_booking_id", bookingId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Query<BookingDTO>(
                "booking_Package.GetBookingById",
                p,
                commandType: CommandType.StoredProcedure);

            return result.SingleOrDefault();
        }

        public int CreateBooking(BookingDTO bookingDto)
        {

            var p = new DynamicParameters();

            p.Add("p_trip_id", bookingDto.Trip_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_login_id", bookingDto.Login_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_total_amount", bookingDto.Total_Amount, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("p_NumberOfUser", bookingDto.NumberOfUser, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_Note", bookingDto.Note, dbType: DbType.String, direction: ParameterDirection.Input);

            p.Add("p_booking_id", dbType: DbType.Decimal, direction: ParameterDirection.Output);

            _dbContext.Connection.Execute(
                "booking_Package.CreateBooking",
                p,
                commandType: CommandType.StoredProcedure);

            var generatedBookingId = p.Get<decimal>("p_booking_id");
            Console.WriteLine($"Generated Booking ID: {generatedBookingId}");

            if (bookingDto.ArrayParam != null)
            {
                foreach (var serviceId in bookingDto.ArrayParam)
                {
                    var serviceParams = new DynamicParameters();
                    serviceParams.Add("p_booking_id", generatedBookingId, dbType: DbType.Decimal, direction: ParameterDirection.Input);
                    serviceParams.Add("p_service_id", serviceId, dbType: DbType.Decimal, direction: ParameterDirection.Input);

                    _dbContext.Connection.Execute(
                        "booking_service_Package.CreateBookingService",
                        serviceParams,
                        commandType: CommandType.StoredProcedure);
                }
            }
            return (int)generatedBookingId;
        }

        public void UpdateBooking(Booking booking)
        {
            var p = new DynamicParameters();
            p.Add("p_booking_id", booking.Booking_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_trip_id", booking.Trip_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_login_id", booking.Login_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_total_amount", booking.Total_Amount, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("P_NumberOfUser", booking.NumberOfUser, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_Note", booking.Note, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute(
                "booking_Package.UpdateBooking",
                p,
                commandType: CommandType.StoredProcedure);
        }

        public void DeleteBooking(int bookingId)
        {
            var p = new DynamicParameters();
            p.Add("p_booking_id", bookingId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute(
                "booking_Package.DeleteBooking",
                p,
                commandType: CommandType.StoredProcedure);
        }

        public void UpdatePaymentStatus(Booking booking)
        {
            var p = new DynamicParameters();
            p.Add("p_booking_id", booking.Booking_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
          
            _dbContext.Connection.Execute(
                "booking_Package.UpdatePaymentStatus",
                p,
                commandType: CommandType.StoredProcedure);
        }

        public Booking GetBookingByTripId(int TripId, int LoginId)
        {
            var p = new DynamicParameters();
            p.Add("T_Id", TripId, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("L_Id", LoginId, DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Query<Booking>("booking_Package.GetBookingByTripId", p, commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }

        public int TotalNumberOfBooking()
        {
            var result = _dbContext.Connection.QuerySingleOrDefault<int>("booking_Package.TotalNumberOfBooking", commandType: CommandType.StoredProcedure);

            return result;
        }
    }
}
