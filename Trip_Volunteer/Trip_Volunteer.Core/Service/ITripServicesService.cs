using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.DTO;

namespace Trip_Volunteer.Core.Service
{
    public interface ITripServicesService
    {
        List<TripService> GetAllTripServices();
        TripService GetTripServiceById(int tripServiceId);
        void CreateTripService(TripService tripService);
        void UpdateTripService(TripService tripService);
        void DeleteTripService(int tripServiceId);
        List<ServiceDTO> GetServiceByTripID(int tripId);
    }
}
