﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.DTO;
using Trip_Volunteer.Core.Service;
using System.Security.Cryptography;
using System.Text;



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
        public IActionResult Registers(string First_Name, string Last_Name, string Email, string Password, string RePassword, string PHONE_NUMBER, string ADDRESS)
        {
            // Ensure the fields are being received properly
            if (string.IsNullOrEmpty(First_Name) || string.IsNullOrEmpty(Last_Name) ||
                string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password) ||
                string.IsNullOrEmpty(RePassword) || string.IsNullOrEmpty(PHONE_NUMBER) ||
                string.IsNullOrEmpty(ADDRESS))
            {
                return BadRequest("One or more fields are empty or invalid.");
            }

            // Check if email already exists
            var existingUser = _userLoginService.GetAllUserLogin().SingleOrDefault(x => x.Email == Email);
                //GetUserinfoByEmail(Email).SingleOrDefault();
            if (existingUser != null)
            {
                return BadRequest("Email already exists");
            }

            // Proceed with registration if no issues
            _userLoginService.Registers(First_Name, Last_Name, Email, Password, RePassword, PHONE_NUMBER, ADDRESS);
            return Ok(new { success = true, message = "User registered successfully" });
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


        [HttpPut("updatePassword")]
        public IActionResult UpdatePassword([FromBody] PasswordUpdateRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.NewPassword))
            {
                return BadRequest("New password is required.");
            }

            try
            {
                // Fetch the user by email
                var user = _userLoginService.GetAllUserLogin().SingleOrDefault(x => x.Email == request.Email);
                if (user == null)
                {
                    return NotFound("User not found.");
                }

                // Hash the new password before updating
                string hashedPassword = HashPassword(request.NewPassword);

                // Update only the password (store the hashed password)
                user.Repassword = hashedPassword;
                user.Password = hashedPassword;
                _userLoginService.UpdateUserLogin(user);  // Save changes




                return Ok(new { message = "Password updated successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Failed to update password", error = ex.Message });
            }
        }

        // Hashing function for password
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }





    }
}
