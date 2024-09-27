﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Repository;
using Trip_Volunteer.Core.Service;

namespace Trip_Volunteer.Infra.Service
{
    public class ServicesService : IServicesService
    {
        private readonly IServiceRepository _serviceRepository;

        public ServicesService(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public void CreateService(decimal serviceCost, string serviceName)
        {
             _serviceRepository.CreateService(serviceCost, serviceName);
        }
         
        public void DeleteService(int serviceId)
        {
            _serviceRepository.DeleteService(serviceId);
        }

        public List<Core.Data.Service> GetAllServices()
        {
           return _serviceRepository.GetAllServices();
        }

        public Core.Data.Service GetServiceById(int serviceId)
        {
           return _serviceRepository.GetServiceById(serviceId);
        }

        public void UpdateService(int serviceId, decimal serviceCost, string serviceName)
        {
            _serviceRepository.UpdateService(serviceId, serviceCost, serviceName);
        }
    }
}