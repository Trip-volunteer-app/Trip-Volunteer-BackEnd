using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net.Mail;
using System.Net;
using Trip_Volunteer.Core.Common;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.DTO;
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
        [Route("GetBookingById")]
        public BookingDTO GetBookingById(int bookingId)
        {
           return _bookingService.GetBookingById(bookingId);
        }

        [HttpPost]
        [Route("CreateBooking")]
        [CheckClaimsAttribute("Roleid", "1", "2")]
        public IActionResult CreateBooking([FromBody] BookingDTO bookingDto)
        {
            int bookingId = _bookingService.CreateBooking(bookingDto);
            return Ok(new { BookingId = bookingId });

        }

        [HttpPut]
        [Route("UpdateBooking")]
        [CheckClaimsAttribute("Roleid", "1", "2")]
        public void UpdateBooking(Booking booking)
        {
            _bookingService.UpdateBooking(booking);
        }

        [HttpDelete]
        [Route("DeleteBooking/{bookingId}")]
        [CheckClaimsAttribute("Roleid", "1", "2")]
        public void DeleteBooking(int bookingId)
        {
            _bookingService.DeleteBooking(bookingId);
        }

        [HttpPut]
        [Route("UpdatePaymentStatus")]
        public void UpdatePaymentStatus(Booking booking)
        {
            _bookingService.UpdatePaymentStatus( booking);
        }

        [HttpGet]
        [Route("GetBookingByTripId")]
        public Booking GetBookingByTripId(int TripId, int LoginId)
        {
            return _bookingService.GetBookingByTripId( TripId, LoginId);
        }

        [HttpGet]
        [Route("TotalNumberOfBooking")]
        [CheckClaimsAttribute("Roleid", "1")]
        public int TotalNumberOfBooking()
        {
            return _bookingService.TotalNumberOfBooking();
        }

    }
}
