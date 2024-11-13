using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.DTO;
using Trip_Volunteer.Core.Repository;
using Trip_Volunteer.Core.Service;
using Trip_Volunteer.Infra.Repository;

namespace Trip_Volunteer.Infra.Service
{
    public class UserLoginService : IUserLoginService
    {
        private readonly IUserLoginRepository _userLoginRepository;
        private readonly IConfiguration _configuration;


        public UserLoginService(IUserLoginRepository userLoginRepository, IConfiguration configuration)
        {
            _userLoginRepository = userLoginRepository;
            _configuration = configuration;

        }

        public List<UserLogin> GetAllUserLogin()
        {
            return _userLoginRepository.GetAllUserLogin();
        }

        public UserLogin GetUserLoginById(int id)
        {
            return _userLoginRepository.GetUserLoginById(id);
        }

        public void CreateUserLogin(UserLogin userLogin)
        {
            _userLoginRepository.CreateUserLogin(userLogin);
        }

        public void UpdateUserLogin(UserLogin userLogin)
        {
            _userLoginRepository.UpdateUserLogin(userLogin);
        }

        public void DeleteUserLogin(int id)
        {
            _userLoginRepository.DeleteUserLogin(id);
        }

        public void Registers(string FirstName, string LastName, string Email, string Password, string RePassword, string PHONE_NUMBER, string ADDRESS)
        {
            _userLoginRepository.Registers(FirstName, LastName, Email, Password, RePassword, PHONE_NUMBER, ADDRESS);
        }

        public string Auth(AuthDTO userLogin)
        {
            var result = _userLoginRepository.Auth(userLogin);
            if (result == null)
            {
                return null;
            }
            else
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SuperSecretKey@ApiCourse123456"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256Signature);
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, result.Email),
                    new Claim("loginid", result.Login_Id.ToString()),
                    new Claim("Roleid", result.Role_Id.ToString())
                };
                var tokenOptions = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddHours(24),
                    signingCredentials: signinCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return tokenString;
            }
        }

        public void UpdateAllUserInformation(int L_id, string L_Email, int u_id,string F_Name, string L_Name, string IMG, string u_Address, string phone, DateTime B_Day)
        {
            _userLoginRepository.UpdateAllUserInformation(L_id, L_Email, u_id, F_Name, L_Name, IMG, u_Address, phone, B_Day);
        }

        public List<UserInformationDto> GetAllUserInformation()
        {
            return _userLoginRepository.GetAllUserInformation();
        }

        public List<UserInformationDto> GetUserinfoByEmail(string email)
        {
            return _userLoginRepository.GetUserinfoByEmail(email);
        }

        public List<UserInformationDto> GetUserinfoByPhone(string phone)
        {
            return _userLoginRepository.GetUserinfoByPhone(phone);
        }

        public List<UserInformationDto> GetUserinfoByName(string F_Name, string L_Name)
        {
            return _userLoginRepository.GetUserinfoByName(F_Name, L_Name);
        }


        public async Task<int> ChangePasswordAsync(ChangePasswordDto changePassword)
        {
            if (changePassword.NewPassword != changePassword.ConfirmPassword)
            {
                // Returning -2 to indicate that the passwords do not match.
                return -2;
            }
            else 
            {
               return await _userLoginRepository.ChangePasswordAsync(changePassword);
            
            }
        }

        public ProfileDTO GetUserinfoByLoginId(int id)
        {
            return _userLoginRepository.GetUserinfoByLoginId(id);
        }
        public async Task<bool> ValidateRecaptcha(string recaptchaResponse)
        {
            var secretKey = _configuration["AppSettings:GoogleReCaptcha:SecretKey"];
            var client = new HttpClient();
            var response = await client.PostAsync($"https://www.google.com/recaptcha/api/siteverify?secret={secretKey}&response={recaptchaResponse}", null);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var recaptchaResult = JsonConvert.DeserializeObject<ReCaptchaDTO>(jsonResponse);
                return recaptchaResult.Success;
            }

            return false;
        }
    }

}


