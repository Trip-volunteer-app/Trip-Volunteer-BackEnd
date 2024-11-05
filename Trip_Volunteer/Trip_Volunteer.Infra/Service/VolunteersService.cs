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
    public class VolunteersService : IVolunteersService
    {
        private readonly IVolunteersRepository _volunteersRepository;
        public VolunteersService(IVolunteersRepository volunteersRepository)
        {
            _volunteersRepository = volunteersRepository;
        }
        public List<Volunteer> GetAllVolunteers()
        {
            return _volunteersRepository.GetAllVolunteers();
        }
        public Volunteer GetVolunteerById(int id)
        {
            return _volunteersRepository.GetVolunteerById(id);
        }
        public void CreateVolunteer(Volunteer volunteer)
        {
            _volunteersRepository.CreateVolunteer(volunteer);
        }
        public void UpdateVolunteer(Volunteer volunteer)
        {
            _volunteersRepository.UpdateVolunteer(volunteer);
        }
        public void DeleteVolunteer(int id)
        {
            _volunteersRepository.DeleteVolunteer(id);
        }
        public void UpdateVolunteerStatus(int id, string status)
        {
            _volunteersRepository.UpdateVolunteerStatus(id, status);
        }
        public List<VolunteerSearchDto> SearchVolunteers(VolunteerSearchDto searchCriteria)
        {
            return _volunteersRepository.SearchVolunteers(searchCriteria);
        }

        public List<VolunteerSearchDto> AllVolunteersWithTrips()
        {
            return _volunteersRepository.AllVolunteersWithTrips();
        }
        public List<Trip> GetTripsForVolunteerByName(string firstName, string lastName)
        {
            return _volunteersRepository.GetTripsForVolunteerByName(firstName, lastName);
        }

        public int TotalNumberOfVolunteer()
        {
            var result = _volunteersRepository.TotalNumberOfVolunteer();
            return result;
        }
        public List<Volunteer> GetVolunteerByTripId(int TripId, int LoginId)
        {
            return _volunteersRepository.GetVolunteerByTripId(TripId,LoginId);
        }


    }
}

