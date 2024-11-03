using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.DTO;
using Trip_Volunteer.Core.Repository;
using Trip_Volunteer.Core.Service;

namespace Trip_Volunteer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        private readonly ITripsService _tripsService;
        public TripsController(ITripsService tripsService, IConfiguration configuration)
        {
            _tripsService = tripsService;
            _configuration = configuration;

        }


        [HttpGet]
        [Route("GetAllTrips")]

        public List<Trip> GetAllTrips()
        {
            return _tripsService.GetAllTrips();
        }

        [HttpGet]
        [Route("GetTripById/{id}")]
/*        [CheckClaimsAttribute("Roleid", "1")]
*/        public Trip GetTripById(int id)
        {
            return _tripsService.GetTripById(id);
        }



        [HttpPost]
        [Route("CreateTrip")]
        [CheckClaimsAttribute("Roleid", "1")]
        public void CreateTrip(TripsDto trip)
        {
            _tripsService.CreateTrip(trip);
        }


        [HttpPut]
        [Route("UpdateTrip")]
        [CheckClaimsAttribute("Roleid", "1")]
        public void UpdateTrip(Trip trip)
        {
            _tripsService.UpdateTrip(trip);
        }


        [HttpDelete]
        [Route("DeleteTrip/{id}")]
        [CheckClaimsAttribute("Roleid", "1")]
        public void DeleteTrip(int id)
        {
            _tripsService.DeleteTrip(id);
        }

        [HttpGet]
        [Route("SearchBetweenDate")]

        public List<Trip> SearchBetweenDate(DateTime Start_Date,DateTime End_Date)
        {
            return _tripsService.SearchBetweenDate(Start_Date, End_Date);
        }


        [HttpGet("trips/GetNumberOfTrips")]
        [CheckClaimsAttribute("Roleid", "1")]
        public IActionResult GetNumberOfTrips()
        {
            int numberOfTrips = _tripsService.NumberOfTrips();
            return Ok(numberOfTrips); 
        }


        [HttpGet]
        [Route("TripsWithMaxReservations")]
        [CheckClaimsAttribute("Roleid", "1")]
        public List<Trip> TripsWithMaxReservations()
        {
            return _tripsService.TripsWithMaxReservations();
        }


        [HttpGet]
        [Route("GetAllTripInformation")]
        public Task<List<TripInfoByIdDTO>> GetAllTripInformation()
        {
            return _tripsService.GetAllTripInformation();
        }


        [HttpGet]
        [Route("GetAllTripInformationById")]
/*        [CheckClaimsAttribute("Roleid", "1")]
*/        public TripInfoByIdDTO GetAllTripInformationById(int Id)
        {
            return _tripsService.GetAllTripInformationById(Id);
        }


        [HttpGet]
        [CheckClaimsAttribute("Roleid", "1")]
        [Route("GetTripVolById/{id}")]
        public TripWithVolDTO GetTripVolById(int Id)
        {
            return _tripsService.GetTripVolById(Id);
        }


        [HttpGet]
        [Route("GetTripUsersById")]
        [CheckClaimsAttribute("Roleid", "1")]
        public TripWithVolDTO GetTripUsersById(int Id)
        {
            return _tripsService.GetTripUsersById(Id);
        }

        [HttpGet]
        [Route("GetVolunteerUserInfoByTripId/{ID}")]

        public List<GetVolunteerUserInfoByTripIdDTO> GetVolunteerUserInfoByTripId(int ID)
        {
            return _tripsService.GetVolunteerUserInfoByTripId(ID);
        }



        [HttpGet]
        [Route("GetUserPaymentsForTrip/{ID}")]

        public List<GetUserPaymentsForTripDTO> GetUserPaymentsForTrip(int ID)
        {
            return _tripsService.GetUserPaymentsForTrip(ID);
        }

    }
}
