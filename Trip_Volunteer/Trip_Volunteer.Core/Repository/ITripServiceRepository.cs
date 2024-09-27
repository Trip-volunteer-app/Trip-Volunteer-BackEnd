using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Data;

namespace Trip_Volunteer.Core.Repository
{
    public interface ITripServiceRepository
    {
        List<TripService> GetAllTripServices();
        TripService GetTripServiceById(int tripServiceId);
        void CreateTripService(int serviceId, int tripId);
        void UpdateTripService(int tripServiceId, int serviceId, int tripId);
        void DeleteTripService(int tripServiceId);
    }
}
