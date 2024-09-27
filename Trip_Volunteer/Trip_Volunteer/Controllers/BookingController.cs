using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Trip_Volunteer.Core.Common;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.Service;

namespace Trip_Volunteer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        [HttpGet]
        public List<Booking> GetAllBookings()
        {
          return  _bookingService.GetAllBookings();
        }

        [HttpGet]
        [Route("GetBookingById/{bookingId}")]
        public Booking GetBookingById(int bookingId)
        {
           return _bookingService.GetBookingById(bookingId);
        }

        [HttpPost]
        [Route("CreateBooking")]
        public void CreateBooking(int tripId, int loginId, decimal totalAmount)
        {
            _bookingService.CreateBooking(tripId, loginId, totalAmount);
        }

        [HttpPut]
        [Route("UpdateBooking")]
        public void UpdateBooking(int bookingId, string paymentStatus, int tripId, int loginId, decimal totalAmount)
        {
            _bookingService.UpdateBooking(bookingId, paymentStatus, tripId, loginId, totalAmount);
        }

        [HttpDelete]
        [Route("DeleteBooking/{bookingId}")]
        public void DeleteBooking(int bookingId)
        {

            _bookingService.DeleteBooking(bookingId);
        }


    }
}
