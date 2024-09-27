using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Common;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.Repository;

namespace Trip_Volunteer.Infra.Repository
{
    public class UserRepository: IUserRepository
    {
        private readonly IDbContext _dbContext;
        public UserRepository(IDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public List<User> GetAllUsers()
        {
            IEnumerable<User> result = _dbContext.Connection.Query<User>("users_Package.GetAllUsers", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public User GetUsersById(int id)
        {
            var p = new DynamicParameters();
            p.Add("Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Query<User>("users_Package.GetUsersById", p, commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }
        public void CreateUsers(User user)
        {
            var p = new DynamicParameters();

            p.Add("F_Name", user.First_Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("L_Name", user.Last_Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("IMG", user.Image_Path, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("u_Address", user.Address, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("phone", user.Phone_Number, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("B_Day", user.Birth_Date, dbType: DbType.Date, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("users_Package.CreateUsers", p, commandType: CommandType.StoredProcedure);
        }
        public void UpdateUsers(User user)
        {
            var p = new DynamicParameters();

            p.Add("U_id ",user.User_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("F_Name", user.First_Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("L_Name", user.Last_Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("IMG", user.Image_Path, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("u_Address", user.Address, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("phone", user.Phone_Number, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("B_Day", user.Birth_Date, dbType: DbType.Date, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("users_Package.UpdateUsers", p, commandType: CommandType.StoredProcedure);
        }
        public void DeleteUsers(int id)
        {
            var p = new DynamicParameters();
            p.Add("Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("users_Package.DeleteUsers", p, commandType: CommandType.StoredProcedure);

        }

    }
}
