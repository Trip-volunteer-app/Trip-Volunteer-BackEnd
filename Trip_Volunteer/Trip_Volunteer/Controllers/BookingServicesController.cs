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
        [Route("GetBookingServiceById")]
        public BookingServices GetBookingServiceById(int id)
        {
            return _bookingServiceService.GetBookingServiceById(id);
        }

        [HttpGet]
        [Route("GetBookingServiceByBookingId")]
        public BookingServicesDTO GetBookingServiceByBookingId(int id)
        {
            return _bookingServiceService.GetBookingServiceByBookingId(id);
        }

        [HttpPost]
        [Route("CreateBookingService")]
        public void CreateBookingService(BookingServices bookingServices)
        {
            _bookingServiceService.CreateBookingService(bookingServices);
        }

        [HttpPut]
        [Route("UpdateBookingService")]
        public void UpdateBookingService(BookingServices bookingServices)
        {
            _bookingServiceService.UpdateBookingService(bookingServices);
        }

        [HttpDelete]
        [Route("DeleteBookingService")]
        public void DeleteBookingService(int id)
        {
            _bookingServiceService.DeleteBookingService(id);
        }
    }
}
