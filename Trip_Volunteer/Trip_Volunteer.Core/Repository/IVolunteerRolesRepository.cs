using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.DTO;

namespace Trip_Volunteer.Core.Repository
{
    public interface IVolunteerRolesRepository
    {
        List<VolunteerRole> GetAllVolunteerRoles();
        VolunteerRole GetVolunteerRoleById(int id);
        void CreateVolunteerRole(VolunteerRole volunteerRole);
        void UpdateVolunteerRole(VolunteerRole volunteerRole);
        void DeleteVolunteerRole(int id);
        List<VolunteerRoleDTO> GetRoleByTripID(int tripId);
        void CreateVolunteerRoleForTrip(VolunteerRoleDTO volunteerRoleDTO);

    }
}
