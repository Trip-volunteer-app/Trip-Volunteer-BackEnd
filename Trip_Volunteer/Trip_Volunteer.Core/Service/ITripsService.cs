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
        List<Trip> GetAlltrips();
        Trip GettripsById(int ID);

        void CREATEtrips(Trip trip);

        void UPDATEtrips(Trip trip);

        void Deletetrips(int Id);

        List<Trip> searchBetweendate(DateTime Start_Date, DateTime End_Date);
      
        int NumberOfTrips();

        List<Trip> TripsWithMaxReservations();
        List<TripInformationDTO> GetAllTripInformation();
        TripInformationDTO GetAllTripInformationById(int Id);
        TripWithVolDTO GetTripVolById(int Id);
        TripWithVolDTO GetTripUsersById(int Id);
    }
}
