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
    public class TripVolunteerroleService : ITripVolunteerroleService
    {
        private readonly ITripVolunteerroleRepository _tripVolunteerroleRepository;
        public TripVolunteerroleService(ITripVolunteerroleRepository tripVolunteerroleRepository)
        {
            _tripVolunteerroleRepository = tripVolunteerroleRepository;
        }

        public List<TripVolunteerrole> GetAlltrip_volunteerRoles()
        {
            return _tripVolunteerroleRepository.GetAlltrip_volunteerRoles();
        }
        public TripVolunteerrole Gettrip_volunteerRolesById(int id)
        {
            return _tripVolunteerroleRepository.Gettrip_volunteerRolesById(id);
        }
        public void CREATEtrip_volunteerRoles(TripVolunteerrole tripVolunteerrole)
        {
            _tripVolunteerroleRepository.CREATEtrip_volunteerRoles(tripVolunteerrole);
        }
        public void UPDATEtrip_volunteerRoles(TripVolunteerrole tripVolunteerrole)
        {
            _tripVolunteerroleRepository.UPDATEtrip_volunteerRoles(tripVolunteerrole);
        }
        public void Deletetrip_volunteerRoles(int id)
        {
            _tripVolunteerroleRepository.Deletetrip_volunteerRoles(id);
        }

   
    }
}
