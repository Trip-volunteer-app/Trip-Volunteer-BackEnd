using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.DTO;

namespace Trip_Volunteer.Core.Repository
{https://github.com/Trip-volunteer-app/Trip-Volunteer-BackEnd/pull/21/conflict?name=Trip_Volunteer%252FTrip_Volunteer.Core%252FRepository%252FIVolunteersRepository.cs&ancestor_oid=b2e710e0971b901df6f72c455422f82d76b6fbef&base_oid=de31a391fcc2bf2c73f7c32e8f500a81daaf1bdd&head_oid=d5eae7022dae4ccf8cdf1b22cfdce897091e70e1
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
    }
}
