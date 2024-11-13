using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.DTO;
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
        [Route("GetAllTripServices")]
        public List<TripService> GetAllTripServices()
        {
            return _tripServicesService.GetAllTripServices();
        }

        [HttpGet]
        [Route("GetTripServiceById")]
        public TripService GetTripServiceById(int tripServiceId)
        {
            return _tripServicesService.GetTripServiceById(tripServiceId);
        }

        [HttpPost]
        [Route("CreateTripService")]
        [CheckClaimsAttribute("Roleid", "1")]
        public void CreateTripService(TripService tripService)
        {
            _tripServicesService.CreateTripService(tripService);
        }
        [HttpPut]
        [Route("UpdateTripService")]
        [CheckClaimsAttribute("Roleid", "1")]
        public void UpdateTripService(TripService tripService)
        {
            _tripServicesService.UpdateTripService(tripService);
        }

        [HttpDelete]
        [Route("DeleteTripService")]
        [CheckClaimsAttribute("Roleid", "1")]
        public void DeleteTripService(int tripServiceId)
        {
            _tripServicesService.DeleteTripService(tripServiceId);
        }

        [HttpGet]
        [Route("GetServiceByTripID/{tripId}")]
        public List<ServiceDTO> GetServiceByTripID(int tripId)
        {
            return _tripServicesService.GetServiceByTripID(tripId);
        }
        [HttpPost]
        [Route("CreateTripServiceForServicesList")]
        [CheckClaimsAttribute("Roleid", "1")]
        public void CreateTripServiceForServicesList(TripWithServicesListDTO tripServiceList)
        {
            _tripServicesService.CreateTripServiceForServicesList(tripServiceList);
        }
    }
}
