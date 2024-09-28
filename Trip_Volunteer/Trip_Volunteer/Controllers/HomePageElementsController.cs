using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.Repository;
using Trip_Volunteer.Core.Service;

namespace Trip_Volunteer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomePageElementsController : ControllerBase
    {
        private readonly IHomePageElementsService _homePageElementsService;
        public HomePageElementsController(IHomePageElementsService homePageElementsService)
        {
            _homePageElementsService = homePageElementsService;
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
        public void CreateHomePageElement(HomePageElement homePageElement)
        {
            _homePageElementsService.CreateHomePageElement(homePageElement);
        }

        [HttpPut]
        [Route("UpdatHomePageElement")]
        public void UpdatHomePageElement(HomePageElement homePageElement)
        {
            _homePageElementsService.UpdatHomePageElement(homePageElement);
        }

        [HttpDelete]
        [Route("DeleteHomePageElement/{id}")]
        public void DeleteHomePageElement(int id)
        {
            _homePageElementsService.DeleteHomePageElement(id);
        }
    }
}
