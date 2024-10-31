using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.DTO;
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

        public void CreateBooking(BookingDTO bookingDto)
        {
            _bookingRepository.CreateBooking( bookingDto);
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

        public void UpdateBooking(Booking booking)
        {
            _bookingRepository.UpdateBooking(booking);
        }
    }
}
