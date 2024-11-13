using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.Repository;
using Trip_Volunteer.Core.Service;
using Trip_Volunteer.Infra.Repository;

namespace Trip_Volunteer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomePageElementsController : ControllerBase
    {
        private readonly IHomePageElementsService _homePageElementsService;
        private readonly IConfiguration _configuration;

        public HomePageElementsController(IHomePageElementsService homePageElementsService, IConfiguration configuration)
        {
            _homePageElementsService = homePageElementsService;
            _configuration = configuration;
        }

        [HttpGet]
        [Route("GetAllHomePageElements")]
        public List<HomePageElement> GetAllHomePageElements()
        {
            return _homePageElementsService.GetAllHomePageElements();
        }

        [HttpGet]
        [Route("GetHomePageElementById/{id}")]
        public HomePageElement GetHomePageElementById(int id)
        {
            return _homePageElementsService.GetHomePageElementById(id);
        }

        [HttpPost]
        [Route("CreateHomePageElement")]
        [CheckClaimsAttribute("Roleid", "1")]
        public void CreateHomePageElement(HomePageElement homePageElement)
        {
            _homePageElementsService.CreateHomePageElement(homePageElement);
        }

        [HttpPut]
        [Route("UpdatHomePageElement")]
        [CheckClaimsAttribute("Roleid", "1")]
        public void UpdatHomePageElement(HomePageElement homePageElement)
        {
            _homePageElementsService.UpdatHomePageElement(homePageElement);
        }

        [HttpDelete]
        [Route("DeleteHomePageElement/{id}")]
        [CheckClaimsAttribute("Roleid", "1")]
        public void DeleteHomePageElement(int id)
        {
            _homePageElementsService.DeleteHomePageElement(id);
        }

        [HttpPost]   
        [Route("uploadHeroImg")]
        [CheckClaimsAttribute("Roleid", "1")]

        public HomePageElement UploadHero_img()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine(_configuration["AppSettings:UploadImage"], fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            HomePageElement item = new HomePageElement();
            item.Hero_Image = fileName;
            return item;
        }


        [HttpPost]
        [Route("uploadImage1")]
        [CheckClaimsAttribute("Roleid", "1")]
        public HomePageElement UploadImage1()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine(_configuration["AppSettings:UploadImage"], fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            HomePageElement item = new HomePageElement();
            item.Logo_Image = fileName;
            return item;
        }


        [HttpPut]
        [Route("UpdateHomeSelectStatus")]
        [CheckClaimsAttribute("Roleid", "1")]

        public void UpdateHomeSelectStatus(int id)
        {
            _homePageElementsService.UpdateHomeSelectStatus(id);
        }


        [HttpGet]
        [Route("GetSelectedHomeElement")]
        [CheckClaimsAttribute("Roleid", "1")]

        public HomePageElement GetSelectedHomeElement()
        {
            return _homePageElementsService.GetSelectedHomeElement();
        }
    }
}
