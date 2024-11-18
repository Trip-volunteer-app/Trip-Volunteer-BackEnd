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
        TripInformationDTO GetTripById(int ID);
        void CreateTrip(TripsDto trip);
        void UpdateTrip(Trip trip);
        void DeleteTrip(int Id);
        int NumberOfTrips();
        List<Trip> TripsWithMaxReservations();
        Task<List<TripInfoByIdDTO>> GetAllTripInformation();
        TripInfoByIdDTO GetAllTripInformationById(int Id);
        TripWithVolDTO GetTripVolById(int Id);
        TripWithVolDTO GetTripUsersById(int Id);
        List<GetVolunteerUserInfoByTripIdDTO> GetVolunteerUserInfoByTripId(int ID);
        List<GetUserPaymentsForTripDTO> GetUserPaymentsForTrip(int ID);
        void updateMaxUser(int id, int res_num);
        List<TripsByRatingDTO> GetTopRatedTrips();
        List<TripInformationDTO> GetAlltripsByCategory(int id);
        TripInfoByIdDTO GetAllTripInformationByIdWithOptionalServices(int Id);
        Task<List<TripInfoByIdDTO>> GETALLTRIPINFORMATIONWITHOUTOPTIONALSERVICES();

    }
}
