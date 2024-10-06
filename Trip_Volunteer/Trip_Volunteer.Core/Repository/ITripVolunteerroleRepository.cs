using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Data;

namespace Trip_Volunteer.Core.Repository
{
    public interface ITripVolunteerroleRepository
    {

        public List<TripVolunteerrole> GetAlltrip_volunteerRoles();
        public TripVolunteerrole Gettrip_volunteerRolesById(int id);

        public void CREATEtrip_volunteerRoles(TripVolunteerrole tripVolunteerrole);

        public void UPDATEtrip_volunteerRoles(TripVolunteerrole tripVolunteerrole);

        public void Deletetrip_volunteerRoles(int id);

    }
}
