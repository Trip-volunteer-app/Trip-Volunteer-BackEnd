using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.DTO;
using Trip_Volunteer.Core.Service;

namespace Trip_Volunteer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        private readonly IUserLoginService _userLoginService;
        public UserLoginController(IUserLoginService userLoginService)
        {
            _userLoginService = userLoginService;
        }

        [HttpGet]
        public List<UserLogin> GetAllUserLogin()
        {
            return _userLoginService.GetAllUserLogin();
        }
        [HttpGet]
        [Route("GetUserLoginById")]
        public UserLogin GetUserLoginById(int id)
        {
            return _userLoginService.GetUserLoginById(id);
        }
        [HttpPost]
        [Route("CreateUserLogin")]

        public void CreateUserLogin(UserLogin userLogin)
        {
            _userLoginService.CreateUserLogin(userLogin);
        }
        [HttpPut]
        [Route("UpdateUserLogin")]

        public void UpdateUserLogin(UserLogin userLogin)
        {
            _userLoginService.UpdateUserLogin(userLogin);
        }
        [HttpDelete]
        [Route("DeleteUserLogin")]

        public void DeleteUserLogin(int id)
        {
            _userLoginService.DeleteUserLogin(id);
        }
        [HttpPost]
        [Route("Auth")]

        public IActionResult Auth(UserLogin userLogin)
        {
            var token = _userLoginService.Auth(userLogin);
            if (token == null)
            {
                return Unauthorized();
            }
            else
            {
                return Ok(token);
            }
        }
        [HttpGet]
        [Route("GetAllUserInformation")]

        public List<UserInformationDto> GetAllUserInformation()
        {
            return _userLoginService.GetAllUserInformation();
        }
        [HttpGet]
        [Route("GetUserinfoByEmail")]

        public List<UserInformationDto> GetUserinfoByEmail(string email)
        {
            return _userLoginService.GetUserinfoByEmail(email);
        }
        [HttpGet]
        [Route("GetUserinfoByPhone")]

        public List<UserInformationDto> GetUserinfoByPhone(string Phone)
        {
            return _userLoginService.GetUserinfoByPhone(Phone);
        }
        [HttpGet]
        [Route("GetUserinfoByName")]

        public List<UserInformationDto> GetUserinfoByName(string F_Name, string L_Name)
        {
            return _userLoginService.GetUserinfoByName(F_Name, L_Name);
        }
    }
}
