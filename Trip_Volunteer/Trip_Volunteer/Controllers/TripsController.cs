using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        private readonly ITripsService _tripsService;
        public TripsController(ITripsService tripsService)
        {
            _tripsService = tripsService;
        }


        [HttpGet]
        [Route("GetAllTrips")]

        public List<Trip> GetAllTrips()
        {
            return _tripsService.GetAllTrips();
        }

        [HttpGet]
        [Route("GetTripById/{id}")]
        public Trip GetTripById(int id)
        {
            return _tripsService.GetTripById(id);
        }



        [HttpPost]
        [Route("CreateTrip")]
        public void CreateTrip(Trip trip)
        {
            _tripsService.CreateTrip(trip);
        }


        [HttpPut]
        [Route("UpdateTrip")]

        public void UpdateTrip(Trip trip)
        {
            _tripsService.UpdateTrip(trip);
        }


        [HttpDelete]
        [Route("DeleteTrip/{id}")]
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
        public IActionResult GetNumberOfTrips()
        {
            int numberOfTrips = _tripsService.NumberOfTrips();
            return Ok(numberOfTrips); 
        }

        [HttpGet("trips/NumberOfFinishedTrips")]
        public IActionResult NumberOfFinishedTrips()
        {
            int numberOfTrips = _tripsService.NumberOfFinishedTrips();
            return Ok(numberOfTrips); 
        }


        [HttpGet]
        [Route("TripsWithMaxReservations")]

        public List<Trip> TripsWithMaxReservations()
        {
            return _tripsService.TripsWithMaxReservations();
        }
        [HttpGet]
        [Route("GetAllTripInformation")]
        public List<TripInformationDTO> GetAllTripInformation()
        {
            return _tripsService.GetAllTripInformation();
        }
        [HttpGet]
        [Route("GetAllTripInformationById")]
        public TripInformationDTO GetAllTripInformationById(int Id)
        {
            return _tripsService.GetAllTripInformationById(Id);
        }
        [HttpGet]
        [Route("GetTripVolById")]
        public TripWithVolDTO GetTripVolById(int Id)
        {
            return _tripsService.GetTripVolById(Id);
        }
        [HttpGet]
        [Route("GetTripUsersById")]
        public TripWithVolDTO GetTripUsersById(int Id)
        {
            return _tripsService.GetTripUsersById(Id);
        }
    }
}
