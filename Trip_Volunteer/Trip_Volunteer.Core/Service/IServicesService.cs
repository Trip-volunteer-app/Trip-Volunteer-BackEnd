using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trip_Volunteer.Core.Service
{
    public interface IServicesService
    {
        List<Core.Data.Service> GetAllServices();
        Core.Data.Service GetServiceById(int serviceId);
        void CreateService(decimal serviceCost, string serviceName);
        void UpdateService(int serviceId, decimal serviceCost, string serviceName);
        void DeleteService(int serviceId);
    }
}
