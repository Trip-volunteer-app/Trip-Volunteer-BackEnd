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

        public List<Trip> GetAllTrips()
        {
            return _tripsRepository.GetAllTrips();
        }


        public Trip GetTripById(int ID)
        {
            return _tripsRepository.GetTripById(ID);

        }


        public void CreateTrip(TripsDto trip)
        {
            _tripsRepository.CreateTrip(trip);

        }

        public void UpdateTrip(Trip trip)
        {
            _tripsRepository.UpdateTrip(trip);
        }

        public void DeleteTrip(int Id)
        {
            _tripsRepository.DeleteTrip(Id);
        }

        public List<Trip> SearchBetweenDate(DateTime Start_Date, DateTime End_Date)
        {
            return _tripsRepository.SearchBetweenDate(Start_Date, End_Date);
        }
        public int NumberOfTrips()
        {
            var result = _tripsRepository.NumberOfTrips();
            return result;
        }

        //public int NumberOfFinishedTrips()
        //{
        //    var result = _tripsRepository.NumberOfFinishedTrips();
        //    return result;
        //}
        

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
