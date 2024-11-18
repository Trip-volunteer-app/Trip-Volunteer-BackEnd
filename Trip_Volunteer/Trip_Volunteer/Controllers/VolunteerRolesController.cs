using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.DTO;
using Trip_Volunteer.Core.Service;

namespace Trip_Volunteer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VolunteerRolesController : ControllerBase
    {
        private readonly IVolunteerRolesService _volunteerRolesService;
        public VolunteerRolesController(IVolunteerRolesService volunteerRolesService)
        {

            _volunteerRolesService = volunteerRolesService;
        }


        [HttpGet]
        [Route("GetAllVolunteerRoles")]
        public List<VolunteerRole> GetAllVolunteerRoles()
        {
            return _volunteerRolesService.GetAllVolunteerRoles();
        }

        [HttpGet]
        [Route("GetVolunteerRoleById/{id}")]
        public VolunteerRole GetVolunteerRoleById(int id)
        {
            return _volunteerRolesService.GetVolunteerRoleById(id);
        }

        [HttpPost]
        [Route("CreateVolunteerRole")]
        [CheckClaimsAttribute("Roleid", "1")]
        public void CreateVolunteerRole(VolunteerRole volunteerRole)
        {
            _volunteerRolesService.CreateVolunteerRole(volunteerRole);
        }

        [HttpPut]
        [Route("UpdateVolunteerRole")]
        [CheckClaimsAttribute("Roleid", "1")]
        public void UpdateVolunteerRole(VolunteerRole volunteerRole)
        {
            _volunteerRolesService.UpdateVolunteerRole(volunteerRole);
        }

        [HttpDelete]
        [Route("DeleteVolunteerRole/{id}")]
        [CheckClaimsAttribute("Roleid", "1")]
        public void DeleteVolunteerRole(int id)
        {
            _volunteerRolesService.DeleteVolunteerRole(id);
        }


        [HttpGet]
        [Route("GetRoleByTripID/{tripId}")]
        public List<VolunteerRoleDTO> GetRoleByTripID(int tripId)
        {
            return _volunteerRolesService.GetRoleByTripID(tripId);
        }
        
        [HttpPost]
        [Route("CreateVolunteerRoleForTrip")]
        public void CreateVolunteerRoleForTrip(VolunteerRoleDTO volunteerRoleDTO)

        {
            _volunteerRolesService.CreateVolunteerRoleForTrip(volunteerRoleDTO);
        }
    }
}
