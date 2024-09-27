using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Trip_Volunteer.Core.Common;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.DTO;
using Trip_Volunteer.Core.Repository;

namespace Trip_Volunteer.Infra.Repository
{
    public class UserLoginRepository: IUserLoginRepository
    {
        private readonly IDbContext _dbContext;
        public UserLoginRepository(IDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public List<UserLogin> GetAllUserLogin()
        {
            IEnumerable<UserLogin> result = _dbContext.Connection.Query<UserLogin>("User_Login_Package.GetAllUserLogin", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public UserLogin GetUserLoginById(int id)
        {
            var p = new DynamicParameters();
            p.Add("Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Query<UserLogin>("User_Login_Package.GetUserLoginById", p, commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }
        public void CreateUserLogin(UserLogin userLogin)
        {
            var p = new DynamicParameters();

            p.Add("L_Email", userLogin.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("L_Pass", userLogin.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("L_RePass", userLogin.Repassword, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Date_Reg", userLogin.Date_Register, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("r_id ", userLogin.Role_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("u_id ", userLogin.User_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("User_Login_Package.CreateUserLogin", p, commandType: CommandType.StoredProcedure);
        }   
        public void UpdateUserLogin(UserLogin userLogin)
        {
            var p = new DynamicParameters();

            p.Add("L_id ", userLogin.Login_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("L_Email", userLogin.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("L_Pass", userLogin.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("L_RePass", userLogin.Repassword, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Date_Reg", userLogin.Date_Register, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("r_id ", userLogin.Role_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("u_id ", userLogin.User_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("User_Login_Package.UpdateUserLogin", p, commandType: CommandType.StoredProcedure);
        }
        public void DeleteUserLogin(int id)
        {
            var p = new DynamicParameters();
            p.Add("Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("User_Login_Package.DeleteUserLogin", p, commandType: CommandType.StoredProcedure);
        }

        public UserLogin Auth(UserLogin userLogin)
        {
            var p = new DynamicParameters();
            p.Add("L_Email", userLogin.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("L_Pass", userLogin.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Query<UserLogin>("User_Login_Package.Login_User", p, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return result;
        }
        public List<UserInformationDto> GetAllUserInformation()
        {
            IEnumerable<UserInformationDto> result = _dbContext.Connection.Query<UserInformationDto>("User_Login_Package.GetAllUserInformation", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public List<UserInformationDto> GetUserinfoByEmail(string email)
        {
            var p = new DynamicParameters();
            p.Add("E_mail", email, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<UserInformationDto> result = _dbContext.Connection.Query<UserInformationDto>("User_Login_Package.GetUserinfoByEmail", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<UserInformationDto> GetUserinfoByPhone(string Phone)
        {
            var p = new DynamicParameters();
            p.Add("Phone", Phone, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<UserInformationDto> result = _dbContext.Connection.Query<UserInformationDto>("User_Login_Package.GetUserinfoByPhone", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public List<UserInformationDto> GetUserinfoByName(string F_Name,string L_Name)
        {
            var p = new DynamicParameters();
            p.Add("F_Name", F_Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("L_Name", L_Name, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<UserInformationDto> result = _dbContext.Connection.Query<UserInformationDto>("User_Login_Package.GetUserinfoByName", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
