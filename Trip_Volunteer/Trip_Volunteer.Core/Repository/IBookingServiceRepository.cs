using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.DTO;

namespace Trip_Volunteer.Core.Repository
{
    public interface IBookingServiceRepository
    {
        List<BookingServices> GetAllBookingServices();
        BookingServices GetBookingServiceById(int id);
        List<BookingServicesDTO> GetBookingServiceByBookingId(int id);
        void CreateBookingService(BookingServices bookingServices);
        void UpdateBookingService(BookingServices bookingServices);
        void DeleteBookingService(int id);

    }
}
