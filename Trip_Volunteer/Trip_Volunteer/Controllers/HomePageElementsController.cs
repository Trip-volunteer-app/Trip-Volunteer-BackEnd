﻿using Microsoft.AspNetCore.Http;
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


        [Route("uploadImage1")]
        [HttpPost]
        public HomePageElement UploadImage1()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("Images", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            HomePageElement item = new HomePageElement();
            item.Image1 = fileName;
            return item;
        }

        [Route("uploadImage2")]
        [HttpPost]
        public HomePageElement UploadImage2()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("Images", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            HomePageElement item = new HomePageElement();
            item.Image2 = fileName;
            return item;
        }

        [Route("uploadImage3")]
        [HttpPost]
        public HomePageElement UploadImage3()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("Images", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            HomePageElement item = new HomePageElement();
            item.Image3 = fileName;
            return item;
        }

        [Route("uploadImage4")]
        [HttpPost]
        public HomePageElement UploadImage4()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("Images", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            HomePageElement item = new HomePageElement();
            item.Image4 = fileName;
            return item;
        }

        [Route("uploadImage5")]
        [HttpPost]
        public HomePageElement UploadImage5()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("Images", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            HomePageElement item = new HomePageElement();
            item.Image5 = fileName;
            return item;
        }
    }
}
