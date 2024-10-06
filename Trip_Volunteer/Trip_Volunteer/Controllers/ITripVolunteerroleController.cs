using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.Service;

namespace Trip_Volunteer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ITripVolunteerroleController : ControllerBase
    {

        private readonly ITripVolunteerroleController _tripVolunteerroleController;

        public ITripVolunteerroleController(ITripVolunteerroleController tripVolunteerroleController)
        {
            _tripVolunteerroleController = tripVolunteerroleController;
        }
        
        [HttpGet]
        [Route("GetAlltrip_volunteerRoles")]
        public List<TripVolunteerrole> GetAlltrip_volunteerRoles()
        {
            return _tripVolunteerroleController.GetAlltrip_volunteerRoles();
        }

        [HttpGet]
        [Route("Gettrip_volunteerRolesById/{id}")]
        public TripVolunteerrole Gettrip_volunteerRolesById(int id)
        {
            return _tripVolunteerroleController.Gettrip_volunteerRolesById(id);
        }

        [HttpPost]
        [Route("CREATEtrip_volunteerRoles")]
        public void CREATEtrip_volunteerRoles(TripVolunteerrole tripVolunteerrole)
        {
            _tripVolunteerroleController.CREATEtrip_volunteerRoles(tripVolunteerrole);
        }

        [HttpPut]
        [Route("UPDATEtrip_volunteerRoles")]
        public void UPDATEtrip_volunteerRoles(TripVolunteerrole tripVolunteerrole)
        {
            _tripVolunteerroleController.UPDATEtrip_volunteerRoles(tripVolunteerrole);
        }

        [HttpDelete]
        [Route("Deletetrip_volunteerRoles/{Id}")]
        public void Deletetrip_volunteerRoles(int Id)
        {
            _tripVolunteerroleController.Deletetrip_volunteerRoles(Id);
        }




    }
}
