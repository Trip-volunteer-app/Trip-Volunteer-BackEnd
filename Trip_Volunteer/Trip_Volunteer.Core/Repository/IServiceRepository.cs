using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Data;

namespace Trip_Volunteer.Core.Repository
{
    public interface IServiceRepository
    {
        List<Core.Data.Service> GetAllServices();
        Core.Data.Service GetServiceById(int serviceId);
        void CreateService(decimal serviceCost, string serviceName);
        void UpdateService(int serviceId, decimal serviceCost, string serviceName);
        void DeleteService(int serviceId);
    }
}
