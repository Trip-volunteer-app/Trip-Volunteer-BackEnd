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
        private readonly IConfiguration _configuration;
        public UsersController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }


        [HttpGet]
        [CheckClaimsAttribute("Roleid", "1")]
        public List<User> GetAllUsers()
        {
            return _userService.GetAllUsers();
        }


        [HttpGet]
        [Route("GetUsersById")]
        [CheckClaimsAttribute("Roleid", "1")]
        public User GetUsersById(int id)
        {
            return _userService.GetUsersById(id);
        }


        [HttpPost]
        [Route("CreateUsers")]
        [CheckClaimsAttribute("Roleid", "1", "2")]
        public void CreateUsers(User user)
        {
            _userService.CreateUsers(user);
        }


        [HttpPut]
        [Route("UpdateUsers")]
        [CheckClaimsAttribute("Roleid", "1", "2")]
        public void UpdateUsers(User user)
        {
            _userService.UpdateUsers(user);
        }


        [HttpDelete]
        [Route("DeleteUsers")]
        [CheckClaimsAttribute("Roleid", "1")]
        public void DeleteUsers(int id)
        {
            _userService.DeleteUsers(id);
        }


        [HttpGet("trips/NumberOfRegisteredUsers")]
        [CheckClaimsAttribute("Roleid", "1")]
        public IActionResult NumberOfRegisteredUsers()
        {
            int numberOfTrips = _userService.NumberOfRegisteredUsers();
            return Ok(numberOfTrips); 
        }

        
        [HttpPut]
        [Route("uploadImage")]
        //[CheckClaimsAttribute("Roleid", "1", "2")]
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
