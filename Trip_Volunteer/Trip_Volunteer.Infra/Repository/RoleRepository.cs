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
    public class RoleRepository: IRoleRepository
    {
        private readonly IDbContext _dbContext;
        public RoleRepository(IDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public List<UserRole> GetAllRoles()
        {
            IEnumerable<UserRole> result = _dbContext.Connection.Query<UserRole>("User_Role_Package.GetAllRoles", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public UserRole GetRoleById(int id)
        {
            var p = new DynamicParameters();
            p.Add("Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Query<UserRole>("User_Role_Package.GetRoleById", p, commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }

        public void CreateRole(UserRole userRole)
        {
            var p = new DynamicParameters();

            p.Add("R_Name", userRole.Role_Name, dbType: DbType.String, direction: ParameterDirection.Input);
          
            _dbContext.Connection.Execute("User_Role_Package.CreateRole", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateRole(UserRole userRole)
        {
            var p = new DynamicParameters();

            p.Add("R_id ", userRole.Role_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("R_Name", userRole.Role_Name, dbType: DbType.String, direction: ParameterDirection.Input);
           
            _dbContext.Connection.Execute("User_Role_Package.UpdateRole", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteRole(int id)
        {
            var p = new DynamicParameters();
            p.Add("Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("User_Role_Package.DeleteRole", p, commandType: CommandType.StoredProcedure);

        }
    }
}
