using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.DTO;
using Trip_Volunteer.Core.Service;
using Trip_Volunteer.Infra.Service;

namespace Trip_Volunteer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripVolunteerroleController : ControllerBase
    {

        private readonly ITripVolunteerroleService _tripVolunteerroleService;

        public TripVolunteerroleController(ITripVolunteerroleService tripVolunteerroleService)
        {
            _tripVolunteerroleService = tripVolunteerroleService;
        }


        [HttpGet]
        [Route("GetAlltrip_volunteerRoles")]
        /*        [CheckClaimsAttribute("Roleid", "1")]
        */
        public List<TripVolunteerrole> GetAlltrip_volunteerRoles()
        {
            return _tripVolunteerroleService.GetAlltrip_volunteerRoles();
        }

        [HttpGet]
        [Route("Gettrip_volunteerRolesById/{id}")]
        /*        [CheckClaimsAttribute("Roleid", "1")]
        */
        public TripVolunteerrole Gettrip_volunteerRolesById(int id)
        {
            return _tripVolunteerroleService.Gettrip_volunteerRolesById(id);
        }

        [HttpPost]
        [Route("CREATEtrip_volunteerRoles")]
        /*        [CheckClaimsAttribute("Roleid", "1")]
        */
        public void CREATEtrip_volunteerRoles(TripVolunteerrole tripVolunteerrole)
        {
            _tripVolunteerroleService.CREATEtrip_volunteerRoles(tripVolunteerrole);
        }

        [HttpPut]
        [Route("UPDATEtrip_volunteerRoles")]
        /*        [CheckClaimsAttribute("Roleid", "1")]
        */
        public void UPDATEtrip_volunteerRoles(TripVolunteerrole tripVolunteerrole)
        {
            _tripVolunteerroleService.UPDATEtrip_volunteerRoles(tripVolunteerrole);
        }

        [HttpDelete]
        [Route("Deletetrip_volunteerRoles/{Id}")]
        /*        [CheckClaimsAttribute("Roleid", "1")]
        */
        public void Deletetrip_volunteerRoles(int Id)
        {
            _tripVolunteerroleService.Deletetrip_volunteerRoles(Id);
        }

        [HttpGet]
        [Route("GetVolunteerRoleByTripId")]

        public List<VolunteerRoleDTO> GetVolunteerRoleByTripId(int id)
        {
            return _tripVolunteerroleService.GetVolunteerRoleByTripId(id);
        }

        [HttpPost]
        [Route("CreateTripVRoleForVRolesList")]
        public void CreateTripVRoleForVRolesList(TripWithVolunteerRolesDTO tripWithVolunteerRoles)
        {
            _tripVolunteerroleService.CreateTripVRoleForVRolesList(tripWithVolunteerRoles);
        }

        [HttpDelete("Deletetrip_volunteerRoles")]
        public void DeleteTripVolunteerRole([FromQuery] int id, [FromQuery] int tripid)
        {

            _tripVolunteerroleService.DeleteTripVolunteerRoleForATrip(tripid, id);

        }


        [HttpPut]
        [Route("updateNumberOfVolunteer")]
        /*        [CheckClaimsAttribute("Roleid", "1","2")]
*/
        public void updateNumberOfVolunteer(TripVolunteerrole tripVolunteerrole)
        {
            _tripVolunteerroleService.updateNumberOfVolunteer(tripVolunteerrole);

        [HttpPut]
        [Route("UpdateTrip_vrole_NumberOfVolunteers")]
        public void UpdateTrip_vrole_NumberOfVolunteers(TripVolunteerrole tripVolunteerrole)
        {
            _tripVolunteerroleService.UpdateTrip_vrole_NumberOfVolunteers(tripVolunteerrole);


        }
    }
}
