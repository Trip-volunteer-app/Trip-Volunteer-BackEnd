using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.Repository;
using Trip_Volunteer.Core.Service;

namespace Trip_Volunteer.Infra.Service
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public void CreateBooking(int tripId, int loginId, decimal totalAmount)
        {
            _bookingRepository.CreateBooking(tripId, loginId, totalAmount);
        }

        public void DeleteBooking(int bookingId)
        {
            _bookingRepository.DeleteBooking(bookingId);
        }

        public List<Booking> GetAllBookings()
        {
           return _bookingRepository.GetAllBookings();
        }

        public Booking GetBookingById(int bookingId)
        {
            return _bookingRepository.GetBookingById(bookingId);
        }

        public void UpdateBooking(int bookingId, string paymentStatus, int tripId, int loginId, decimal totalAmount)
        {
            _bookingRepository.UpdateBooking(bookingId, paymentStatus, tripId, loginId, totalAmount);
        }
    }
}
