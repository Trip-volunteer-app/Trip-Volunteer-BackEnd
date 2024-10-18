using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.Repository;
using Trip_Volunteer.Core.Service;
using Trip_Volunteer.Infra.Repository;

namespace Trip_Volunteer.Infra.Service
{
    public class WebsiteInformationService : IWebsiteInformationService
    {

        private readonly IWebsiteInformationRepository _websiteInformationRepository;
        public WebsiteInformationService(IWebsiteInformationRepository websiteInformationRepository)
        {
            _websiteInformationRepository = websiteInformationRepository;
        }

        public List<WebsiteInformation> GetAllwebsite_information()
        {
            return _websiteInformationRepository.GetAllwebsite_information();
        }


        public WebsiteInformation Getwebsite_informationById(int ID)
        {
            return _websiteInformationRepository.Getwebsite_informationById(ID);

        }


        public void CREATEwebsite_information(WebsiteInformation websiteInformation)
        {
            _websiteInformationRepository.CREATEwebsite_information(websiteInformation);

        }

        public void UPDATEwebsite_information(WebsiteInformation websiteInformation)
        {
            _websiteInformationRepository.UPDATEwebsite_information(websiteInformation);
        }

        public void Deletewebsite_information(int Id)
        {
            _websiteInformationRepository.Deletewebsite_information(Id);
        }

        public void UpdateSelectedWebsiteInfo(int id)
        {
            _websiteInformationRepository.UpdateSelectedWebsiteInfo(id);
        }
        public WebsiteInformation GetSelectedWebsiteInfo()
        {
            return _websiteInformationRepository.GetSelectedWebsiteInfo();
        }
    }
}
