using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.DTO;
using Trip_Volunteer.Core.Service;

namespace Trip_Volunteer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VolunteersController : ControllerBase
    {
        private readonly IVolunteersService _volunteersService;
        public VolunteersController(IVolunteersService volunteersService)
        {
            _volunteersService = volunteersService;
        }

        [HttpGet]
        [Route("GetAllVolunteers")]
        public List<Volunteer> GetAllVolunteers()
        {
            return _volunteersService.GetAllVolunteers();
        }

        [HttpGet]
        [Route("GetVolunteerById/{id}")]
        public Volunteer GetVolunteerById(int id)
        {
            return _volunteersService.GetVolunteerById(id);
        }

        [HttpPost]
        [Route("CreateVolunteer")]
        public void CreateVolunteer(Volunteer volunteer)
        {
            _volunteersService.CreateVolunteer(volunteer);
        }

        [HttpPut]
        [Route("UpdateVolunteer")]
        public void UpdateVolunteer(Volunteer volunteer)
        {
            _volunteersService.UpdateVolunteer(volunteer);
        }

        [HttpDelete]
        [Route("DeleteVolunteer/{id}")]
        public void DeleteVolunteer(int id)
        {
            _volunteersService.DeleteVolunteer(id);
        }

        [HttpPut]
        [Route("UpdateVolunteerStatus/{id}/{status}")]
        public void UpdateVolunteerStatus(int id, string status)
        {
            _volunteersService.UpdateVolunteerStatus(id, status);

        [HttpPost]
        [Route("Search")]
        public List<VolunteerSearchDto> SearchVolunteers(VolunteerSearchDto searchCriteria)
        {
            return _volunteersService.SearchVolunteers(searchCriteria);
        }

        [HttpPost]
        [Route("GetTripsByVolunteerName")]
        public List<Trip> GetTripsForVolunteerByName(string firstName, string lastName)
        {
            return _volunteersService.GetTripsForVolunteerByName(firstName, lastName);
        }
    }
}
