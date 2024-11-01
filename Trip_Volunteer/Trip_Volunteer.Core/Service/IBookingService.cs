using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.DTO;

namespace Trip_Volunteer.Core.Service
{
    public interface IBookingService
    {
        List<Booking> GetAllBookings();
        Booking GetBookingById(int bookingId);
        void CreateBooking(BookingDTO bookingDto);
        void UpdateBooking(Booking booking);
        void DeleteBooking(int bookingId);
    }
}
