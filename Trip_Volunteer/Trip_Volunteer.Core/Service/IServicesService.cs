using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.DTO;

namespace Trip_Volunteer.Core.Service
{
    public interface IServicesService
    {
        List<Core.Data.Service> GetAllServices();
        Core.Data.Service GetServiceById(int serviceId);
        void CreateService(Core.Data.Service service );
        void UpdateService(Core.Data.Service service);
        void DeleteService(int serviceId);
        List<Core.Data.Service> GetServiceByTripId(int id);
        void CreateServiceForTrip(ServiceTripDTO serviceTrip);
    }
}
