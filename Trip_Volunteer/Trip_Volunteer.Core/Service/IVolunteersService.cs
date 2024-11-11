using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.DTO;

namespace Trip_Volunteer.Core.Service
{
    public interface IVolunteersService
    {
        List<AllVolunteersInfoDTO> GetAllVolunteers();
        Volunteer GetVolunteerById(int id);
        void CreateVolunteer(Volunteer volunteer);
        void UpdateVolunteer(Volunteer volunteer);
        void DeleteVolunteer(int id);
        void UpdateVolunteerStatus(Volunteer volunteer);
        List<VolunteerSearchDto> SearchVolunteers(VolunteerSearchDto searchCriteria);
        List<VolunteerSearchDto> AllVolunteersWithTrips();
        List<Trip> GetTripsForVolunteerByName(string firstName, string lastName);
        int TotalNumberOfVolunteer();
        Volunteer GetVolunteerByTripId(int TripId, int LoginId);

        List<GetTripVolunteersDTO> GetTripVolunteers(int id);
    }
}
