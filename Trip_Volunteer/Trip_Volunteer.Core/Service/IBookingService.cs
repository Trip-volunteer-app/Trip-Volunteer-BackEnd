using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Data;

namespace Trip_Volunteer.Core.Service
{
    public interface IBookingService
    {
        List<Booking> GetAllBookings();
        Booking GetBookingById(int bookingId);
        void CreateBooking(int tripId, int loginId, decimal totalAmount);
        void UpdateBooking(int bookingId, string paymentStatus, int tripId, int loginId, decimal totalAmount);
        void DeleteBooking(int bookingId);
    }
}
