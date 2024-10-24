using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.DTO;
using Trip_Volunteer.Core.Repository;
using Trip_Volunteer.Core.Service;

namespace Trip_Volunteer.Infra.Service
{
    public class UserLoginService : IUserLoginService
    {
        private readonly IUserLoginRepository _userLoginRepository;

        public UserLoginService(IUserLoginRepository userLoginRepository)
        {
            _userLoginRepository = userLoginRepository;
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

        public string Auth(UserLogin userLogin)
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

        public void UpdateAllUserInformation(string L_id, string L_Email, string L_Pass, string L_RePass, string r_id, string u_id, string F_Name, string L_Name, string IMG, string u_Address, string phone, DateTime B_Day)
        {
            _userLoginRepository.UpdateAllUserInformation(L_id, L_Email, L_Pass, L_RePass, r_id, u_id, F_Name, L_Name, IMG, u_Address, phone, B_Day);
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



    }
}
