using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.DTO;
using Trip_Volunteer.Core.Service;
using System.Security.Cryptography;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using Trip_Volunteer.Infra.Service;



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
        [CheckClaimsAttribute("Roleid", "1")]
        public List<UserLogin> GetAllUserLogin()
        {
            return _userLoginService.GetAllUserLogin();
        }


        [HttpGet]
        [Route("GetUserLoginById")]
        [CheckClaimsAttribute("Roleid", "1", "2")]
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
        [CheckClaimsAttribute("Roleid", "1","2")]
        public void UpdateUserLogin(UserLogin userLogin)
        {
            _userLoginService.UpdateUserLogin(userLogin);
        }


        [HttpDelete]
        [Route("DeleteUserLogin")]
        [CheckClaimsAttribute("Roleid", "1")]
        public void DeleteUserLogin(int id)
        {
            _userLoginService.DeleteUserLogin(id);
        }


        [HttpPost]
        [Route("Registers")]
        //[CheckClaimsAttribute("Roleid", "2")]
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
        //[CheckClaimsAttribute("Roleid", "1", "2")]
        public void UpdateAllUserInformation(int L_id, string L_Email, int u_id, string F_Name, string L_Name, string IMG, string u_Address, string phone, DateTime B_Day)
        {
            _userLoginService.UpdateAllUserInformation(L_id, L_Email, u_id, F_Name, L_Name, IMG, u_Address, phone, B_Day);
        }


        [HttpGet]
        [Route("GetAllUserInformation")]
        //[CheckClaimsAttribute("Roleid", "1", "2")]
        public List<UserInformationDto> GetAllUserInformation()
        {
            return _userLoginService.GetAllUserInformation();
        }


        [HttpGet]
        [Route("GetUserinfoByEmail")]
        //[CheckClaimsAttribute("Roleid", "1")]
        public List<UserInformationDto> GetUserinfoByEmail(string email)
        {
            return _userLoginService.GetUserinfoByEmail(email);
        }


        [HttpGet]
        [Route("GetUserinfoByPhone")]
        [CheckClaimsAttribute("Roleid", "1")]
        public List<UserInformationDto> GetUserinfoByPhone(string Phone)
        {
            return _userLoginService.GetUserinfoByPhone(Phone);
        }


        [HttpGet]
        [Route("GetUserinfoByName")]
        //[CheckClaimsAttribute("Roleid", "1")]
        public List<UserInformationDto> GetUserinfoByName(string F_Name, string L_Name)
        {
            return _userLoginService.GetUserinfoByName(F_Name, L_Name);
        }


        [HttpPut("updatePassword")]
        //[CheckClaimsAttribute("Roleid", "1", "2")]
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

        
      

        [HttpPut]
        [Route("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto changePassword)
        {
            // Check if the required fields are filled
            if (string.IsNullOrWhiteSpace(changePassword.OldPassword) ||
                string.IsNullOrWhiteSpace(changePassword.NewPassword) ||
                string.IsNullOrWhiteSpace(changePassword.ConfirmPassword))
            {
                return BadRequest("Old password, new password, and confirm password are required.");
            }

            // Hash the new password and confirm password
            changePassword.NewPassword = HashPassword(changePassword.NewPassword);
            changePassword.ConfirmPassword = HashPassword(changePassword.ConfirmPassword);

            try
            {

                // Retrieve the user's stored hashed password from the database
                var user =  _userLoginService.GetUserLoginById(changePassword.LOGIN_ID); // Assuming UserId is part of your DTO
                if (user == null)
                {
                    return NotFound("User not found.");
                }

                // Verify the old password
                changePassword.OldPassword = HashPassword(changePassword.OldPassword);


                // Ensure the new password and confirm password match
                //if (changePassword.NewPassword != changePassword.ConfirmPassword)
                //{
                //    return BadRequest("New password and confirm password do not match.");
                //}
                int result = await _userLoginService.ChangePasswordAsync(changePassword);

                // Check the result and respond accordingly
                if (result == -2)
                {
                    return BadRequest("New password and confirm password do not match.");
                }
                else if (result == 1)
                {
                    return Ok(new { message = "Password changed successfully." });
                }
                else
                {
                    return StatusCode(500, new { message = "Failed to change password. Please try again later." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while changing the password.", error = ex.Message });
            }
        }

        [HttpGet("GetUserinfoByLoginId/{id}")]
        //[CheckClaimsAttribute("Roleid", "1", "2")]

        public ProfileDTO GetUserinfoByLoginId(int id)
        {
            return _userLoginService.GetUserinfoByLoginId(id);
        }

        [HttpGet("GetUserinfoByLoginIdForReview/{id}")]
        //[CheckClaimsAttribute("Roleid", "1", "2")]

        public ProfileDTO GetUserinfoByLoginIdForReview(int id)
        {
            return _userLoginService.GetUserinfoByLoginIdForReview(id);
        }
    }
}


