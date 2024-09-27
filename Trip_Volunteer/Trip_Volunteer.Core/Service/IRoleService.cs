using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Data;

namespace Trip_Volunteer.Core.Service
{
    public interface IRoleService
    {
        List<UserRole> GetAllRoles();
        UserRole GetRoleById(int id);
        void CreateRole(UserRole userRole);
        void UpdateRole(UserRole userRole);
        void DeleteRole(int id);
    }
}
