using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.Repository;
using Trip_Volunteer.Core.Service;

namespace Trip_Volunteer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {

        private readonly ITripsRepository _tripsRepository;
        public TripsController(ITripsRepository tripsRepository)
        {
            _tripsRepository = tripsRepository;
        }


        [HttpGet]
        [Route("GetAlltrips")]

        public List<Trip> GetAlltrips()
        {
            return _tripsRepository.GetAlltrips();
        }

        [HttpGet]
        [Route("GettripsById/{id}")]
        public Trip GettripsById(int id)
        {
            return _tripsRepository.GettripsById(id);
        }



        [HttpPost]
        [Route("CREATEtrips")]
        public void CREATEtrips(Trip trip)
        {
            _tripsRepository.CREATEtrips(trip);
        }


        [HttpPut]
        [Route("UPDATEtrips")]

        public void UPDATEtrips(Trip trip)
        {
            _tripsRepository.UPDATEtrips(trip);
        }


        [HttpDelete]
        [Route("Deletetrips/{id}")]
        public void Deletetrips(int id)
        {
            _tripsRepository.Deletetrips(id);
        }



    }
}
