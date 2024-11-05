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
/*        [CheckClaimsAttribute("Roleid", "1")]
*/        public List<Booking> GetAllBookings()
        {
          return  _bookingService.GetAllBookings();
        }

        [HttpGet]
        [Route("GetBookingById")]
/*        [CheckClaimsAttribute("Roleid", "1")]
*/        public Booking GetBookingById(int bookingId)
        {
           return _bookingService.GetBookingById(bookingId);
        }

        [HttpPost]
        [Route("CreateBooking")]
/*        [CheckClaimsAttribute("Roleid", "1","2")]
*/        public IActionResult CreateBooking([FromBody] BookingDTO bookingDto)
        {
            int bookingId = _bookingService.CreateBooking(bookingDto);
            return Ok(new { BookingId = bookingId });

        }

        [HttpPut]
        [Route("UpdateBooking")]
/*        [CheckClaimsAttribute("Roleid", "1")]
*/        public void UpdateBooking(Booking booking)
        {
            _bookingService.UpdateBooking(booking);
        }

        [HttpDelete]
        [Route("DeleteBooking/{bookingId}")]
/*        [CheckClaimsAttribute("Roleid", "1", "2")]
*/         public void DeleteBooking(int bookingId)
        {

            _bookingService.DeleteBooking(bookingId);
        }

        [HttpPut]
        [Route("UpdatePaymentStatus")]
        /*        [CheckClaimsAttribute("Roleid", "2")]
*/
        public void UpdatePaymentStatus(Booking booking)
        {
            _bookingService.UpdatePaymentStatus( booking);
        }
        [HttpGet]
        [Route("GetBookingByTripId")]
        /*        [CheckClaimsAttribute("Roleid", "1", "2")]
*/
        public Booking GetBookingByTripId(int TripId, int LoginId)
        {
            return _bookingService.GetBookingByTripId( TripId, LoginId);
        }
        [HttpPost("send-email")]
        public async Task<IActionResult> SendEmail([FromBody] SendEmailBookingDTO sendEmailBookingDTO)
        {
            try
            {
                using (var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("sajedaalquraan1@gmail.com", "bobf xqnl rsiq gmbe"),
                    EnableSsl = true,
                })
                {
                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress("sajedaalquraan1@gmail.com"),
                        Subject = $"Payment Status Update for Trip: {sendEmailBookingDTO.Trip_Name}",
                        Body = sendEmailBookingDTO.Status?.ToLower() == "paid"
                             ? $"Hello! Your payment for the trip '{sendEmailBookingDTO.Trip_Name}' has been successfully received. Thank you for completing the transaction. We look forward to having you on this exciting journey with us! \n\n Trip_Name: '{sendEmailBookingDTO.Trip_Name}'\n\n Start_Date:'{sendEmailBookingDTO.Start_Date}'\n\n End_Date:'{sendEmailBookingDTO.End_Date}'\n\n Departure Location:'{sendEmailBookingDTO.Departure_Location}'\n\n Destination Location:'{sendEmailBookingDTO.Destination_Location}'\n\n Services:'{string.Join(", ", sendEmailBookingDTO.Services.Select(s => s.Service_Name))}'"
                             : "We wanted to inform you that there was an issue processing your payment. Please review your booking details or contact support for assistance.",
                        IsBodyHtml = false,
                    };

                    mailMessage.To.Add(sendEmailBookingDTO.Email);

                    await smtpClient.SendMailAsync(mailMessage);
                }

                return Ok("Email sent successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }



    }
}
