using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.Service;

namespace Trip_Volunteer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet]
        [Route("GetAlllocation")]
        public List<Location> GetAlllocation()
        {
            return _locationService.GetAlllocation();
        }


        [HttpGet]
        [Route("GetlocationById/{id}")]
        public Location GetlocationById(int id)
        {
            return _locationService.GetlocationById(id);
        }


        [HttpPost]
        [Route("CREATElocation")]
        public void CREATElocation(Location location)
        {
            _locationService.CREATElocation(location);
        }


        [HttpPut]
        [Route("UPDATElocation")]

        public void UPDATElocation(Location location)
        {
            _locationService.UPDATElocation(location);
        }


        [HttpDelete]
        [Route("Deletelocation/{id}")]
        public void Deletelocation(int id)
        {
            _locationService.Deletelocation(id);
        }

        

    }
}
