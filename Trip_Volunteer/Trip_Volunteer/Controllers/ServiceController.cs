using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Trip_Volunteer.Core.Data;
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
          return  _servicesService.GetAllServices();


        }

        [HttpGet]
        [Route("GetServiceById/{serviceId}")]
        public Service GetServiceById(int serviceId)
        {
          return _servicesService.GetServiceById(serviceId);
        }

        [HttpPost]
        [Route("CreateService")]
        public void CreateService(decimal serviceCost, string serviceName)
        {
            _servicesService.CreateService(serviceCost, serviceName);
        }

        [HttpPut]
        [Route("UpdateService")]
        public void UpdateService(int serviceId, decimal serviceCost, string serviceName)
        {
            _servicesService.UpdateService(serviceId, serviceCost, serviceName);
        }

        [HttpDelete]
        [Route("DeleteService/{serviceId}")]
        public void DeleteService(int serviceId)
        {
            _servicesService.DeleteService(serviceId);

        }
    }
}