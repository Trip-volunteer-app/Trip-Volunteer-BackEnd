using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.DTO;
using Trip_Volunteer.Core.Repository;
using Trip_Volunteer.Core.Service;

namespace Trip_Volunteer.Infra.Service
{
    public class TripsService : ITripsService
    {

        private readonly ITripsRepository _tripsRepository;
        public TripsService(ITripsRepository tripsRepository)
        {
            _tripsRepository = tripsRepository;
        }

        public List<Trip> GetAlltrips()
        {
            return _tripsRepository.GetAlltrips();
        }


        public Trip GettripsById(int ID)
        {
            return _tripsRepository.GettripsById(ID);

        }


        public void CREATEtrips(Trip trip)
        {
            _tripsRepository.CREATEtrips(trip);

        }

        public void UPDATEtrips(Trip trip)
        {
            _tripsRepository.UPDATEtrips(trip);
        }

        public void Deletetrips(int Id)
        {
            _tripsRepository.Deletetrips(Id);
        }

        public List<Trip> searchBetweendate(DateTime Start_Date, DateTime End_Date)
        {
            return _tripsRepository.searchBetweendate(Start_Date, End_Date);
        }
        public int NumberOfTrips()
        {
            var result = _tripsRepository.NumberOfTrips();
            return result;
        }

        public int NumberOfFinishedTrips()
        {
            var result = _tripsRepository.NumberOfFinishedTrips();
            return result;
        }
        

        public List<Trip> TripsWithMaxReservations()
        {
            return _tripsRepository.TripsWithMaxReservations();
        }
        public List<TripInformationDTO> GetAllTripInformation()
        {
            return _tripsRepository.GetAllTripInformation();
        }
        public TripInformationDTO GetAllTripInformationById(int Id)
        {
            return _tripsRepository.GetAllTripInformationById(Id);
        }
        public TripWithVolDTO GetTripVolById(int Id)
        {
            return _tripsRepository.GetTripVolById(Id);
        }
        public TripWithVolDTO GetTripUsersById(int Id)
        {
            return _tripsRepository.GetTripUsersById(Id);
        }
    }
}
