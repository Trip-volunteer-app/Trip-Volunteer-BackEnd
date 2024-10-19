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
        [Route("GetAlltrips")]

        public List<Trip> GetAlltrips()
        {
            return _tripsService.GetAlltrips();
        }

        [HttpGet]
        [Route("GettripsById/{id}")]
        public Trip GettripsById(int id)
        {
            return _tripsService.GettripsById(id);
        }



        [HttpPost]
        [Route("CREATEtrips")]
        public void CREATEtrips(Trip trip)
        {
            _tripsService.CREATEtrips(trip);
        }


        [HttpPut]
        [Route("UPDATEtrips")]

        public void UPDATEtrips(Trip trip)
        {
            _tripsService.UPDATEtrips(trip);
        }


        [HttpDelete]
        [Route("Deletetrips/{id}")]
        public void Deletetrips(int id)
        {
            _tripsService.Deletetrips(id);
        }

        [HttpGet]
        [Route("searchBetweendate/{Start_Date}/{End_Date}")]
        public List<Trip> searchBetweendate(DateTime Start_Date,DateTime End_Date)
        {
            return _tripsService.searchBetweendate(Start_Date, End_Date);
        }


        [HttpGet("trips/GetNumberOfTrips")]
        public IActionResult GetNumberOfTrips()
        {
            int numberOfTrips = _tripsService.NumberOfTrips();
            return Ok(numberOfTrips); // Return the total number of trips
        }

        [HttpGet("trips/NumberOfFinishedTrips")]
        public IActionResult NumberOfFinishedTrips()
        {
            int numberOfTrips = _tripsService.NumberOfFinishedTrips();
            return Ok(numberOfTrips); // Return the total number of trips
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
