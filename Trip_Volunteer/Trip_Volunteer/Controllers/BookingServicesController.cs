using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.Service;
using Trip_Volunteer.Core.DTO;

namespace Trip_Volunteer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingServicesController : ControllerBase
    {
        private readonly IBookingServicesServices _bookingServiceService;
        public BookingServicesController(IBookingServicesServices bookingServiceService)
        {
            _bookingServiceService = bookingServiceService;
        }


        [HttpGet]
        [Route("GetAllBookingServices")]

        public List<BookingServices> GetAllBookingServices()
        {
            return _bookingServiceService.GetAllBookingServices();
        }

        [HttpGet]
        [Route("GetBookingServiceById/{id}")]
        [CheckClaimsAttribute("Roleid", "1","2")]
        public BookingServices GetBookingServiceById(int id)
        {
            return _bookingServiceService.GetBookingServiceById(id);
        }

        [HttpGet]
        [Route("GetBookingServiceByBookingId/{id}")]
        [CheckClaimsAttribute("Roleid", "1", "2")]
        public List<BookingServicesDTO> GetBookingServiceByBookingId(int id)
        {
            return _bookingServiceService.GetBookingServiceByBookingId(id);
        }

        [HttpPost]
        [Route("CreateBookingService")]
        [CheckClaimsAttribute("Roleid", "1", "2")]
        public void CreateBookingService(BookingServices bookingServices)
        {
            _bookingServiceService.CreateBookingService(bookingServices);
        }

        [HttpPut]
        [Route("UpdateBookingService")]
        [CheckClaimsAttribute("Roleid", "1", "2")]
        public void UpdateBookingService(BookingServices bookingServices)
        {
            _bookingServiceService.UpdateBookingService(bookingServices);
        }

        [HttpDelete]
        [Route("DeleteBookingService")]
        [CheckClaimsAttribute("Roleid", "1", "2")]
        public void DeleteBookingService(int id)
        {
            _bookingServiceService.DeleteBookingService(id);
        }
    }
}
