using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.DTO;
using Trip_Volunteer.Core.Repository;
using Trip_Volunteer.Core.Service;

namespace Trip_Volunteer.Core.Service
{
    public interface IUserLoginService
    {
        List<UserLogin> GetAllUserLogin();
        UserLogin GetUserLoginById(int id);
        void CreateUserLogin(UserLogin userLogin);
        void UpdateUserLogin(UserLogin userLogin);
        void Registers(string FirstName, string LastName, string Email, string Password, string RePassword, string PHONE_NUMBER, string ADDRESS);
        void DeleteUserLogin(int id);
        string Auth(AuthDTO userLogin);
        void UpdateAllUserInformation(int L_id, string L_Email, int u_id,string F_Name, string L_Name, string IMG, string u_Address, string phone, DateTime B_Day);
        List<UserInformationDto> GetAllUserInformation();
        List<UserInformationDto> GetUserinfoByEmail(string email);
        List<UserInformationDto> GetUserinfoByPhone(string Phone);
        List<UserInformationDto> GetUserinfoByName(string F_Name, string L_Name);
        Task<int> ChangePasswordAsync(ChangePasswordDto changePassword);
        ProfileDTO GetUserinfoByLoginId(int id);
        ProfileDTO GetUserinfoByLoginIdForReview(int id);
        Task<bool> ValidateRecaptcha(string recaptchaResponse);

    }
}






