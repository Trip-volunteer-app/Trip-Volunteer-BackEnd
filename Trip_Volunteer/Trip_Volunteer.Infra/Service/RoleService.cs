using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.Repository;
using Trip_Volunteer.Core.Service;

namespace Trip_Volunteer.Infra.Service
{
    public class RoleService: IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public List<UserRole> GetAllRoles()
        {
            return _roleRepository.GetAllRoles();
        }
        public UserRole GetRoleById(int id)
        {
            return _roleRepository.GetRoleById(id);
        }
        public void CreateRole(UserRole userRole)
        {
            _roleRepository.CreateRole(userRole);
        }
        public void UpdateRole(UserRole userRole)
        {
            _roleRepository.UpdateRole(userRole);
        }
        public void DeleteRole(int id)
        {
            _roleRepository.DeleteRole(id);
        }
    }
}
