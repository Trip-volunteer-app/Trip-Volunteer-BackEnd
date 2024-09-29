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
        [Route("Registers")]
        public void Registers(string FirstName, string LastName, string Email, string Password, string RePassword)
        {
            _userLoginService.Registers(FirstName, LastName, Email, Password, RePassword);
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
        [HttpPut]
        [Route("UpdateAllUserInformation")]
        public void UpdateAllUserInformation(string L_id, string L_Email, string L_Pass, string L_RePass, string r_id, string u_id, string F_Name, string L_Name, string IMG, string u_Address, string phone, DateTime B_Day)
        {
            _userLoginService.UpdateAllUserInformation(L_id, L_Email, L_Pass, L_RePass, r_id, u_id, F_Name, L_Name, IMG, u_Address, phone, B_Day);
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
