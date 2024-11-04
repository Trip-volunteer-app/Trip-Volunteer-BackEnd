using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.DTO;

namespace Trip_Volunteer.Core.Repository
{
    public interface IBookingRepository
    {
        List<Booking> GetAllBookings();
        Booking GetBookingById(int bookingId);
        int CreateBooking(BookingDTO bookingDto);
        void UpdateBooking(Booking booking);
        void DeleteBooking(int bookingId);
        void UpdatePaymentStatus(Booking booking);
        Booking GetBookingByTripId(int TripId, int LoginId);
    }
}
