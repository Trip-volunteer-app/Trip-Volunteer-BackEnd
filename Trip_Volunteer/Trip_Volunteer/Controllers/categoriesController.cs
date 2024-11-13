using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.Service;

namespace Trip_Volunteer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class categoriesController : ControllerBase
    {

        private readonly IcategoriesService _categoriesService;
        private readonly IConfiguration _configuration;

        public categoriesController(IcategoriesService categoriesService, IConfiguration configuration)
        {
            _categoriesService = categoriesService;
            _configuration = configuration;
        }


        [HttpGet]
        [Route("GetAllcategories")]
        public List<Category> GetAllcategories()
        {
            return _categoriesService.GetAllcategories();
        }

        [HttpGet]
        [Route("GetcategoriesById/{id}")]
        public Category GetcategoriesById(int id)
        {
            return _categoriesService.GetcategoriesById(id);
        }



        [HttpPost]
        [Route("CREATEcategories")]
        [CheckClaimsAttribute("Roleid", "1")]
        public void CREATEcategories(Category category)
        {
            _categoriesService.CREATEcategories(category);
        }


        [HttpPut]
        [Route("UPDATEcategories")]
        [CheckClaimsAttribute("Roleid", "1")]

        public void UPDATEcategories(Category category)
        {
            _categoriesService.UPDATEcategories(category);
        }


        [HttpDelete]
        [Route("Deletecategories/{id}")]
        [CheckClaimsAttribute("Roleid", "1")]
        public void Deletecategories(int id)
        {
            _categoriesService.Deletecategories(id);
        }

        [HttpGet]
        [Route("GetCategoryWithImageAndTrips")]
        public List<Category> GetCategoryWithImageAndTrips()
        {
            return _categoriesService.GetCategoryWithImageAndTrips();
        }

        [HttpPost]
        [Route("uploadImage")]
        [CheckClaimsAttribute("Roleid", "1")]
        public User UploadImage()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine(_configuration["AppSettings:UploadImage"], fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            User item = new User();
            item.Image_Path = fileName;
            return item;
        }
    }
}
