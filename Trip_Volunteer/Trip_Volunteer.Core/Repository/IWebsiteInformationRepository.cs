using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Data;

namespace Trip_Volunteer.Core.Repository
{
    public interface IWebsiteInformationRepository
    {

        List<WebsiteInformation> GetAllwebsite_information();
        WebsiteInformation Getwebsite_informationById(int ID);

        void CREATEwebsite_information(WebsiteInformation websiteInformation);

        void UPDATEwebsite_information(WebsiteInformation websiteInformation);

        void Deletewebsite_information(int Id);
        WebsiteInformation GetSelectedWebsiteInfo();
        void UpdateSelectedWebsiteInfo(int id);
    }
}
