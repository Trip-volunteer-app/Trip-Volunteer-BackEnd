using Dapper;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Trip_Volunteer.Core.Common;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.DTO;
using Trip_Volunteer.Core.Repository;

namespace Trip_Volunteer.Infra.Repository
{
    public class UserLoginRepository : IUserLoginRepository
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
        public void Registers(string FirstName, string LastName, string Email, string Password, string RePassword, string PHONE_NUMBER, string ADDRESS)
        {
         
            string hashedPassword = HashPassword(Password);
            string hashedRePassword = HashPassword(RePassword);




            if (hashedPassword != hashedRePassword)
            {
                throw new ArgumentException("Passwords do not match.");
            }
            var p = new DynamicParameters();
            p.Add("P_FirstName", FirstName, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("P_LastName", LastName, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("P_Email", Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("P_Password", hashedPassword, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("P_RePassword", hashedRePassword, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("PHONE_NUMBER", PHONE_NUMBER, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("ADDRESS", ADDRESS, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("User_Login_Package.Registers", p, commandType: CommandType.StoredProcedure);
        }
        
        public UserLogin Auth(AuthDTO userLogin)
        {
            string hashedPassword = HashPassword(userLogin.Password);

            var p = new DynamicParameters();
            p.Add("L_Email", userLogin.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("L_Pass", hashedPassword, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Query<UserLogin>("User_Login_Package.Login_User", p, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return result;
        }

        public void UpdateAllUserInformation(int L_id, string L_Email, int u_id,
            string F_Name, string L_Name, string IMG, string u_Address, string phone, DateTime B_Day)
        {
            var p = new DynamicParameters();

            p.Add("L_id", L_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("L_Email", L_Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("u_id", u_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("F_Name", F_Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("L_Name", L_Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("IMG", IMG, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("u_Address", u_Address, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("phone", phone, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("B_Day", B_Day, dbType: DbType.Date, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("User_Login_Package.UpdateAllUserInformation", p, commandType: CommandType.StoredProcedure);
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
        public List<UserInformationDto> GetUserinfoByName(string F_Name, string L_Name)
        {
            var p = new DynamicParameters();
            p.Add("F_Name", F_Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("L_Name", L_Name, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<UserInformationDto> result = _dbContext.Connection.Query<UserInformationDto>("User_Login_Package.GetUserinfoByName", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

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

        public async Task<int> ChangePasswordAsync(ChangePasswordDto changePassword)
        {
            if (changePassword.NewPassword != changePassword.ConfirmPassword)
            {
                // Returning -2 to indicate that the passwords do not match.
                return -2;
            }

            var parameters = new DynamicParameters();
            parameters.Add("p_user_id", changePassword.LOGIN_ID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("p_old_password", changePassword.OldPassword, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("p_new_password", changePassword.NewPassword, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("p_status", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _dbContext.Connection.ExecuteAsync("User_Login_Package.change_password", parameters, commandType: CommandType.StoredProcedure);

            return parameters.Get<int>("p_status");
        }

 

        public ProfileDTO GetUserinfoByLoginId(int id)
        {
            var p = new DynamicParameters();
            p.Add("Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (var multi = _dbContext.Connection.QueryMultiple("User_Login_Package.GetUserinfoByLoginId", p, commandType: CommandType.StoredProcedure))
            {
                var profileInfo = multi.Read<ProfileDTO>().FirstOrDefault();
                var bookings = multi.Read<BookingsDTO>().ToList();
                var volunteerInfo = multi.Read<AllVolunteerDTO>().ToList();


                if (profileInfo != null)
                {
                    profileInfo.Bookings = bookings;
                    profileInfo.Volunteer = volunteerInfo;

                }

                return profileInfo;
            }
        }


        public ProfileDTO GetUserinfoByLoginIdForReview(int id)
        {
            var p = new DynamicParameters();
            p.Add("Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (var multi = _dbContext.Connection.QueryMultiple("GetUserinfoByLoginIdForReview", p, commandType: CommandType.StoredProcedure))
            {
                var profileInfo = multi.Read<ProfileDTO>().FirstOrDefault();
                var bookings = multi.Read<BookingsDTO>().ToList();
                var volunteerInfo = multi.Read<AllVolunteerDTO>().ToList();


                if (profileInfo != null)
                {
                    profileInfo.Bookings = bookings;
                    profileInfo.Volunteer = volunteerInfo;

                }

                return profileInfo;
            }
        }


    }
}
