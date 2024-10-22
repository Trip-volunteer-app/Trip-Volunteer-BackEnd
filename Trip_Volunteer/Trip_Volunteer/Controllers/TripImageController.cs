using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.Service;

namespace Trip_Volunteer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripImageController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly ITripImageService _tripImageService;
        public TripImageController(ITripImageService tripImageService, IConfiguration configuration)
        {
            _tripImageService = tripImageService;
            _configuration = configuration;
        }


        [HttpGet]
        public List<TripImage> GetAllTripImage()
        {
            return _tripImageService.GetAllTripImage();
        }

        [HttpGet]
        [Route("GetTripImageById")]
        public TripImage GetTripImageById(int id)
        {
            return _tripImageService.GetTripImageById(id);
        }

        [HttpGet]
        [Route("GetTripImageByTripId/{id}")]
        public List<TripImage> GetTripImageByTripId(int id)
        {
            return _tripImageService.GetTripImageByTripId(id);
        }
        [HttpPost]
        [Route("CreateTripImage")]
        public void CreateTripImage(TripImage tripImage)
        {
            _tripImageService.CreateTripImage(tripImage);
        }


        [HttpPut]
        [Route("UpdateTripImage")]

        public void UpdateTripImage(TripImage tripImage)
        {
            _tripImageService.UpdateTripImage(tripImage);
        }


        [HttpDelete]
        [Route("DeleteTripImage/{id}")]
        public void DeleteTripImage(int id)
        {
            _tripImageService.DeleteTripImage(id);
        }

        [Route("uploadImage")]
        [HttpPost]
        public TripImage UploadImage()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine(_configuration["AppSettings:UploadImage"], fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            TripImage item = new TripImage();
            item.Image_Name = fileName;
            return item;
        }
    }
}
