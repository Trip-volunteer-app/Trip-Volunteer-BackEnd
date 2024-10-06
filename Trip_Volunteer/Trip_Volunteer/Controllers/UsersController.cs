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
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public List<User> GetAllUsers()
        {
            return _userService.GetAllUsers();
        }
        [HttpGet]
        [Route("GetUsersById")]
        public User GetUsersById(int id)
        {
            return _userService.GetUsersById(id);
        }
        [HttpPost]
        [Route("CreateUsers")]

        public void CreateUsers(User user)
        {
            _userService.CreateUsers(user);
        }
        [HttpPut]
        [Route("UpdateUsers")]

        public void UpdateUsers(User user)
        {
            _userService.UpdateUsers(user);
        }
        [HttpDelete]
        [Route("DeleteUsers")]

        public void DeleteUsers(int id)
        {
            _userService.DeleteUsers(id);
        }


        [HttpGet("trips/NumberOfRegisteredUsers")]
        public IActionResult NumberOfRegisteredUsers()
        {
            int numberOfTrips = _userService.NumberOfRegisteredUsers();
            return Ok(numberOfTrips); 
        }

        [Route("uploadImage")]
        [HttpPost]
        public User UploadImage()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("Images", fileName);
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
