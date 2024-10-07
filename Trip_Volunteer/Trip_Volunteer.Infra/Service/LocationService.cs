using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.Repository;
using Trip_Volunteer.Core.Service;

namespace Trip_Volunteer.Infra.Service
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;

        public LocationService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public List<Location> GetAlllocation()
        {
            return _locationRepository.GetAlllocation();
        }

        public Location GetlocationById(int id)
        {
            return _locationRepository.GetlocationById(id);
        }

        public void CREATElocation(Location location)
        {
            _locationRepository.CREATElocation(location);
        }

        public void UPDATElocation(Location location)
        {
            _locationRepository.UPDATElocation(location);
        }

        public void Deletelocation(int id)
        {
            _locationRepository.Deletelocation(id);
        }


    }
}
