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


        private readonly ITripImageService _tripImageService;
        public TripImageController(ITripImageService tripImageService)
        {
            _tripImageService = tripImageService;
        }


        [HttpGet]
        [Route("GetAlltrip_image")]

        public List<TripImage> GetAlltrip_image()
        {
            return _tripImageService.GetAlltrip_image();
        }

        [HttpGet]
        [Route("Gettrip_imageById/{id}")]
        public TripImage Gettrip_imageById(int id)
        {
            return _tripImageService.Gettrip_imageById(id);
        }



        [HttpPost]
        [Route("CREATEtrip_image")]
        public void CREATEtrip_image(TripImage tripImage)
        {
            _tripImageService.CREATEtrip_image(tripImage);
        }


        [HttpPut]
        [Route("UPDATEtrip_image")]

        public void UPDATEtrip_image(TripImage tripImage)
        {
            _tripImageService.UPDATEtrip_image(tripImage);
        }


        [HttpDelete]
        [Route("Deletetrip_image/{id}")]
        public void Deletetrip_image(int id)
        {
            _tripImageService.Deletetrip_image(id);
        }

        [Route("uploadImage")]
        [HttpPost]
        public TripImage UploadImage()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("Images", fileName);
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
