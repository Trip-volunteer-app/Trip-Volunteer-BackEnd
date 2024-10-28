using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using Trip_Volunteer.Core.Common;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.Service;
using System.Net.Http;


namespace Trip_Volunteer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {        

        private readonly ILocationService _locationService;
        private readonly HttpClient _httpClient;

        public LocationController(ILocationService locationService, HttpClient httpClient)
        {
            _locationService = locationService;
            _httpClient = httpClient;
        }

        [HttpGet]
        [Route("GetAlllocation")]       
        public List<Location> GetAlllocation()
        {
            return _locationService.GetAlllocation();
        }


        [HttpGet]
        [Route("GetlocationById/{id}")]
        [CheckClaimsAttribute("Roleid", "1")]
        public Location GetlocationById(int id)
        {
            return _locationService.GetlocationById(id);
        }


        [HttpPost]
        [Route("CREATElocation")]
        [CheckClaimsAttribute("Roleid", "1")]
        public void CREATElocation(Location location)
        {
            _locationService.CREATElocation(location);
        }


        [HttpPut]
        [Route("UPDATElocation")]
        [CheckClaimsAttribute("Roleid", "1")]
        public void UPDATElocation(Location location)
        {
            _locationService.UPDATElocation(location);
        }


        [HttpDelete]
        [Route("Deletelocation/{id}")]
        [CheckClaimsAttribute("Roleid", "1")]
        public void Deletelocation(int id)
        {
            _locationService.Deletelocation(id);
        }


        
    }
}





