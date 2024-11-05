﻿using Microsoft.AspNetCore.Http;
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
        [Route("GetAllTripServices")]
        //[CheckClaimsAttribute("Roleid", "1","2")]
        public List<TripService> GetAllTripServices()
        {
            return _tripServicesService.GetAllTripServices();
        }

        [HttpGet]
        [Route("GetTripServiceById")]
        [CheckClaimsAttribute("Roleid", "1","2")]
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
    }
}
