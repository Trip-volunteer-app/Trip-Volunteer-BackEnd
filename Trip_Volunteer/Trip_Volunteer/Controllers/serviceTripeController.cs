using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.Service;

namespace Trip_Volunteer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class serviceTripeController : ControllerBase
    {
        private readonly ITripServicesService _tripServicesService;
        public serviceTripeController(ITripServicesService tripServicesService)
        {
            _tripServicesService = tripServicesService;
        }

        [HttpGet]
        //[Route("GetAllTripServices")]
        List<TripService> GetAllTripServices()
        {
            return _tripServicesService.GetAllTripServices();
        }

        [HttpGet]
        [Route("GetTripServiceById/{tripServiceId}")]
        TripService GetTripServiceById(int tripServiceId)
        {
            return _tripServicesService.GetTripServiceById(tripServiceId);
        }
        [HttpPost]
        [Route("CreateTripService")]
        void CreateTripService(int serviceId, int tripId)
        {
            _tripServicesService.CreateTripService(serviceId, tripId);
        }
        [HttpPut]
        [Route("UpdateTripService")]
        void UpdateTripService(int tripServiceId, int serviceId, int tripId)
        {
            _tripServicesService.UpdateTripService(tripServiceId, serviceId, tripId);
        }

        [HttpDelete]
        [Route("DeleteTripService/{tripServiceId}")]
        void DeleteTripService(int tripServiceId)
        {
            _tripServicesService.DeleteTripService(tripServiceId);
        }
    }
}
