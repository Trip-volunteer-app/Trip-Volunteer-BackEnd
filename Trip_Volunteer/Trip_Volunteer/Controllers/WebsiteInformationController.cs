using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.Service;

namespace Trip_Volunteer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebsiteInformationController : ControllerBase
    {

        private readonly IWebsiteInformationService _websiteInformationService;
        public WebsiteInformationController(IWebsiteInformationService websiteInformationService)
        {
            _websiteInformationService = websiteInformationService;
        }


        [HttpGet]
        [Route("GetAllwebsite_information")]
        [CheckClaimsAttribute("Roleid", "1", "2")]
        public List<WebsiteInformation> GetAllwebsite_information()
        {
            return _websiteInformationService.GetAllwebsite_information();
        }

        [HttpGet]
        [Route("Getwebsite_informationById/{id}")]
        [CheckClaimsAttribute("Roleid", "1", "2")]
        public WebsiteInformation Getwebsite_informationById(int id)
        {
            return _websiteInformationService.Getwebsite_informationById(id);
        }



        [HttpPost]
        [Route("CREATEwebsite_information")]
        [CheckClaimsAttribute("Roleid", "1")]
        public void CREATEwebsite_information(WebsiteInformation websiteInformation)
        {
            _websiteInformationService.CREATEwebsite_information(websiteInformation);
        }


        [HttpPut]
        [Route("UPDATEwebsite_information")]
        [CheckClaimsAttribute("Roleid", "1")]
        public void UPDATEwebsite_information(WebsiteInformation websiteInformation)
        {
            _websiteInformationService.UPDATEwebsite_information(websiteInformation);
        }


        [HttpDelete]
        [Route("Deletewebsite_information/{id}")]
        [CheckClaimsAttribute("Roleid", "1")]
        public void Deletewebsite_information(int id)
        {
            _websiteInformationService.Deletewebsite_information(id);
        }

        [HttpPut]
        [Route("UpdateSelectedWebsiteInfo")]
        [CheckClaimsAttribute("Roleid", "1")]
        public void UpdateSelectedWebsiteInfo(int id)
        {
            _websiteInformationService.UpdateSelectedWebsiteInfo(id);
        }

        [HttpGet]
        [Route("GetSelectedWebsiteInfo")]
        [CheckClaimsAttribute("Roleid", "1")]
        public WebsiteInformation GetSelectedWebsiteInfo()
        {
            return _websiteInformationService.GetSelectedWebsiteInfo();
        }
    }
}
