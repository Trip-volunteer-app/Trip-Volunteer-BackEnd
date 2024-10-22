using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.DTO;

namespace Trip_Volunteer.Core.Repository
{
    public interface IVolunteersRepository
    {
        List<Volunteer> GetAllVolunteers();
        Volunteer GetVolunteerById(int id);
        void CreateVolunteer(Volunteer volunteer);
        void UpdateVolunteer(Volunteer volunteer);
        void DeleteVolunteer(int id);
        void UpdateVolunteerStatus(int id, string status);
        List<VolunteerSearchDto> SearchVolunteers(VolunteerSearchDto searchCriteria);
        List<Trip> GetTripsForVolunteerByName(string firstName, string lastName);
        int TotalNumberOfVolunteer();
    }
}
