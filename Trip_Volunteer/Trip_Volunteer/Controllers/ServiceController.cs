using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.DTO;
using Trip_Volunteer.Core.Service;

namespace Trip_Volunteer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServicesService _servicesService;

        public ServiceController(IServicesService servicesService)
        {
            _servicesService = servicesService;
        }

        [HttpGet]
        public List<Service> GetAllServices()
        {
            return _servicesService.GetAllServices();
        }

        [HttpGet]
        [Route("GetServiceById/{serviceId}")]
        public Service GetServiceById(int serviceId)
        {
            return _servicesService.GetServiceById(serviceId);
        }

        [HttpPost]
        [Route("CreateService")]
        [CheckClaimsAttribute("Roleid", "1")]
        public void CreateService(Core.Data.Service service)
        {
            _servicesService.CreateService(service);
        }

        [HttpPut]
        [Route("UpdateService")]
        [CheckClaimsAttribute("Roleid", "1")]
        public void UpdateService(Core.Data.Service service)
        {
            _servicesService.UpdateService(service);
        }

        [HttpDelete]
        [Route("DeleteService/{serviceId}")]
        [CheckClaimsAttribute("Roleid", "1")]
        public void DeleteService(int serviceId)
        {
            _servicesService.DeleteService(serviceId);
        }

        [HttpGet]
        [Route("GetServiceByTripId/{id}")]
        public List<Core.Data.Service> GetServiceByTripId(int id)
        {
            return _servicesService.GetServiceByTripId(id);
        }

        [HttpPost]
        [Route("CreateServiceForTrip")]
        [CheckClaimsAttribute("Roleid", "1")]
        public void CreateServiceForTrip(ServiceTripDTO serviceTrip)
        {
            _servicesService.CreateServiceForTrip(serviceTrip);
        }
    }
}