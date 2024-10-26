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

        private readonly ITripVolunteerroleService _tripVolunteerroleService;

        public ITripVolunteerroleController(ITripVolunteerroleService tripVolunteerroleService)
        {
            _tripVolunteerroleService = tripVolunteerroleService;
        }
        

        [HttpGet]
        [Route("GetAlltrip_volunteerRoles")]
        [CheckClaimsAttribute("Roleid", "1")]
        public List<TripVolunteerrole> GetAlltrip_volunteerRoles()
        {
            return _tripVolunteerroleService.GetAlltrip_volunteerRoles();
        }

        [HttpGet]
        [Route("Gettrip_volunteerRolesById/{id}")]
        [CheckClaimsAttribute("Roleid", "1")]
        public TripVolunteerrole Gettrip_volunteerRolesById(int id)
        {
            return _tripVolunteerroleService.Gettrip_volunteerRolesById(id);
        }

        [HttpPost]
        [Route("CREATEtrip_volunteerRoles")]
        [CheckClaimsAttribute("Roleid", "1")]
        public void CREATEtrip_volunteerRoles(TripVolunteerrole tripVolunteerrole)
        {
            _tripVolunteerroleService.CREATEtrip_volunteerRoles(tripVolunteerrole);
        }

        [HttpPut]
        [Route("UPDATEtrip_volunteerRoles")]
        [CheckClaimsAttribute("Roleid", "1")]
        public void UPDATEtrip_volunteerRoles(TripVolunteerrole tripVolunteerrole)
        {
            _tripVolunteerroleService.UPDATEtrip_volunteerRoles(tripVolunteerrole);
        }

        [HttpDelete]
        [Route("Deletetrip_volunteerRoles/{Id}")]
        [CheckClaimsAttribute("Roleid", "1")]
        public void Deletetrip_volunteerRoles(int Id)
        {
            _tripVolunteerroleService.Deletetrip_volunteerRoles(Id);
        }




    }
}
