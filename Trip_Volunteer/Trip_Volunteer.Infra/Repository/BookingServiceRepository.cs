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
    public class BookingServiceRepository: IBookingServiceRepository
    {

        private readonly IDbContext _dbContext;
        public BookingServiceRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<BookingServices> GetAllBookingServices()
        {
            IEnumerable<BookingServices> result = _dbContext.Connection.Query<BookingServices>(
                "booking_service_Package.GetAllBookingServices",
                commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public BookingServices GetBookingServiceById(int id)
        {
            var p = new DynamicParameters();
            p.Add("Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Query<BookingServices>(
                "booking_service_Package.GetBookingServiceById",
                p,
                commandType: CommandType.StoredProcedure);

            return result.SingleOrDefault();
        }

        /*  public BookingService GetBookingServiceByBookingId(int id)
          {
              var p = new DynamicParameters();
              p.Add("Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

              var result = _dbContext.Connection.Query<BookingService>(
                  "booking_service_Package.GetBookingServiceByBookingId",
                  p,
                  commandType: CommandType.StoredProcedure);

              return result.SingleOrDefault();
          }*/
        public List<BookingServicesDTO> GetBookingServiceByBookingId(int id)
        {
          
            var p = new DynamicParameters();
            p.Add("Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<BookingServicesDTO> result = _dbContext.Connection.Query<BookingServicesDTO>("booking_service_Package.GetBookingServiceByBookingId", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public void CreateBookingService(BookingServices bookingServices)
        {
            var p = new DynamicParameters();
            p.Add("p_booking_id", bookingServices.Booking_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_service_id", bookingServices.Service_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute(
                "booking_service_Package.CreateBookingService",
                p,
                commandType: CommandType.StoredProcedure);
        }

        public void UpdateBookingService(BookingServices bookingServices)
        {
            var p = new DynamicParameters();
            p.Add("p_booking_S_id", bookingServices.Booking_Service_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_booking_id", bookingServices.Booking_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_service_id", bookingServices.Service_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute(
                "booking_service_Package.UpdateBookingService",
                p,
                commandType: CommandType.StoredProcedure);
        }

        public void DeleteBookingService(int id)
        {
            var p = new DynamicParameters();
            p.Add("Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute(
                "booking_service_Package.DeleteBookingService",
                p,
                commandType: CommandType.StoredProcedure);
        }
    }
}
