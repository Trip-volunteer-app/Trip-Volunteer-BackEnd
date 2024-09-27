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

        public Booking GetBookingById(int bookingId)
        {
            var p = new DynamicParameters();
            p.Add("p_booking_id", bookingId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Query<Booking>(
                "booking_Package.GetBookingById",
                p,
                commandType: CommandType.StoredProcedure);

            return result.SingleOrDefault();
        }

        public void CreateBooking(int tripId, int loginId, decimal totalAmount)
        {
            var p = new DynamicParameters();
            p.Add("p_trip_id", tripId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_login_id", loginId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_total_amount", totalAmount, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute(
                "booking_Package.CreateBooking",
                p,
                commandType: CommandType.StoredProcedure);
        }

        public void UpdateBooking(int bookingId, string paymentStatus, int tripId, int loginId, decimal totalAmount)
        {
            var p = new DynamicParameters();
            p.Add("p_booking_id", bookingId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_payment_status", paymentStatus, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_trip_id", tripId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_login_id", loginId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_total_amount", totalAmount, dbType: DbType.Decimal, direction: ParameterDirection.Input);

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


    }
}
