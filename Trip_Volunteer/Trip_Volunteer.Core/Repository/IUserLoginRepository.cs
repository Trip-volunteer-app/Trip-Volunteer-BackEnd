using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.DTO;

namespace Trip_Volunteer.Core.Repository
{
    public interface IUserLoginRepository
    {
        List<UserLogin> GetAllUserLogin();
        UserLogin GetUserLoginById(int id);
        void CreateUserLogin(UserLogin userLogin);
        void UpdateUserLogin(UserLogin userLogin);
        void DeleteUserLogin(int id);
        UserLogin Auth(UserLogin userLogin);
        List<UserInformationDto> GetAllUserInformation();
        List<UserInformationDto> GetUserinfoByEmail(string email);
        List<UserInformationDto> GetUserinfoByPhone(string Phone);
        List<UserInformationDto> GetUserinfoByName(string F_Name, string L_Name);


    }
}
