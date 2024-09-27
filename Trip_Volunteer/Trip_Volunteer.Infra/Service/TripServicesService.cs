using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.Repository;
using Trip_Volunteer.Core.Service;
using Trip_Volunteer.Infra.Repository;

namespace Trip_Volunteer.Infra.Service
{
    public class TripServicesService : ITripServicesService
    {
        private readonly ITripServiceRepository _tripServiceRepository;
        public TripServicesService(ITripServiceRepository tripServiceRepository)
        {
            _tripServiceRepository = tripServiceRepository;
        }

        public void CreateTripService(int serviceId, int tripId)
        {
            _tripServiceRepository.CreateTripService(serviceId, tripId);
        }

        public void DeleteTripService(int tripServiceId)
        {
            _tripServiceRepository.DeleteTripService(tripServiceId);
        }

        public List<TripService> GetAllTripServices()
        {
           return _tripServiceRepository.GetAllTripServices();
        }

        public TripService GetTripServiceById(int tripServiceId)
        {
            return _tripServiceRepository.GetTripServiceById(tripServiceId);
        }

        public void UpdateTripService(int tripServiceId, int serviceId, int tripId)
        {
            _tripServiceRepository.UpdateTripService(tripServiceId, serviceId, tripId);
        }
    }
}
