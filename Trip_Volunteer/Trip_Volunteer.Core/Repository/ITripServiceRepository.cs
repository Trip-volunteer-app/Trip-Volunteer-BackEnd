using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.DTO;
using Trip_Volunteer.Core.Service;

namespace Trip_Volunteer.Core.Repository
{
    public interface ITripServiceRepository
    {
        List<TripService> GetAllTripServices();
        TripService GetTripServiceById(int tripServiceId);
        void CreateTripService(TripService tripService);
        void UpdateTripService(TripService tripService);
        void DeleteTripService(int tripServiceId);
        List<ServiceDTO> GetServiceByTripID(int tripId);
        void CreateTripServiceForServicesList(TripWithServicesListDTO tripServiceList);

    }
}
