using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.Service;

namespace Trip_Volunteer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        [CheckClaimsAttribute("Roleid", "1")]
        public List<UserRole> GetAllRoles()
        {
            return _roleService.GetAllRoles();
        }


        [HttpGet]
        [Route("GetRoleById")]
        [CheckClaimsAttribute("Roleid", "1")]
        public UserRole GetRoleById(int id)
        {
            return _roleService.GetRoleById(id);
        }


        [HttpPost]
        [Route("CreateRole")]
        [CheckClaimsAttribute("Roleid", "1")]
        public void CreateRole(UserRole userRole)
        {
            _roleService.CreateRole(userRole);
        }


        [HttpPut]
        [Route("UpdateRole")]
        [CheckClaimsAttribute("Roleid", "1")]
        public void UpdateRole(UserRole userRole)
        {
            _roleService.UpdateRole(userRole);
        }


        [HttpDelete]
        [Route("DeleteRole")]
        [CheckClaimsAttribute("Roleid", "1")]
        public void DeleteRole(int id)
        {
            _roleService.DeleteRole(id);
        }
    }
}
