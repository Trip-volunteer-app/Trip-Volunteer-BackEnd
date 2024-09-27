using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.Repository;
using Trip_Volunteer.Core.Service;

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
    }
}
