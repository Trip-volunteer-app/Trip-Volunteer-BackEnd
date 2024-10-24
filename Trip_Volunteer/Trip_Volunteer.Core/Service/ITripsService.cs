using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.DTO;

namespace Trip_Volunteer.Core.Service
{
    public interface ITripsService
    {
        List<Trip> GetAllTrips();
        Trip GetTripById(int ID);

        void CreateTrip(Trip trip);

        void UpdateTrip(Trip trip);

        void DeleteTrip(int Id);

        List<Trip> SearchBetweenDate(DateTime Start_Date, DateTime End_Date);
      
        int NumberOfTrips();

        //int NumberOfFinishedTrips();

        List<Trip> TripsWithMaxReservations();
        List<TripInformationDTO> GetAllTripInformation();
        TripInformationDTO GetAllTripInformationById(int Id);
        TripWithVolDTO GetTripVolById(int Id);
        TripWithVolDTO GetTripUsersById(int Id);
    }
}
