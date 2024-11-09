using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.DTO;
using Trip_Volunteer.Core.Repository;
using Trip_Volunteer.Core.Service;
using Trip_Volunteer.Infra.Repository;

namespace Trip_Volunteer.Infra.Service
{
    public class VolunteerRolesService : IVolunteerRolesService
    {
        private readonly IVolunteerRolesRepository _volunteerRolesRepository;
        public VolunteerRolesService(IVolunteerRolesRepository volunteerRolesRepository)
        {
            _volunteerRolesRepository = volunteerRolesRepository;
        }
        public List<VolunteerRole> GetAllVolunteerRoles()
        {
            return _volunteerRolesRepository.GetAllVolunteerRoles();
        }
        public VolunteerRole GetVolunteerRoleById(int id)
        {
            return _volunteerRolesRepository.GetVolunteerRoleById(id);
        }
        public void CreateVolunteerRole(VolunteerRole volunteerRole) 
        {
            _volunteerRolesRepository.CreateVolunteerRole(volunteerRole);
        }
        public void UpdateVolunteerRole(VolunteerRole volunteerRole)
        {
            _volunteerRolesRepository.UpdateVolunteerRole(volunteerRole);
        }
        public void DeleteVolunteerRole(int id)
        {
            _volunteerRolesRepository.DeleteVolunteerRole(id);
        }
        public List<VolunteerRoleDTO> GetRoleByTripID(int tripId)
        {
            return _volunteerRolesRepository.GetRoleByTripID(tripId);
        }
        public void CreateVolunteerRoleForTrip(VolunteerRoleDTO volunteerRoleDTO)

        {
            _volunteerRolesRepository.CreateVolunteerRoleForTrip(volunteerRoleDTO);
        }
    }
}
