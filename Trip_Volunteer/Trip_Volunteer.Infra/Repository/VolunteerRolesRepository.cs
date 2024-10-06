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
    public class VolunteerRolesRepository : IVolunteerRolesRepository
    {
        private readonly IDbContext _dbContext;

        public VolunteerRolesRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<VolunteerRole> GetAllVolunteerRoles()
        {
            IEnumerable<VolunteerRole> result = _dbContext.Connection.Query<VolunteerRole>("Volunteer_Roles_Package.GetAllVolunteerRoles", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public VolunteerRole GetVolunteerRoleById(int id)
        {
            var p = new DynamicParameters();
            p.Add("V_RoleId", id, DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Query<VolunteerRole>("Volunteer_Roles_Package.GetVolunteerRoleById", p, commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }

        public void CreateVolunteerRole(VolunteerRole volunteerRole)
        {
            var p = new DynamicParameters();
            p.Add("V_RoleName", volunteerRole.Role_Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("TripId", volunteerRole.TripVolunteerroles, dbType: DbType.Int32, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("Volunteer_Roles_Package.CreateVolunteerRole", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateVolunteerRole(VolunteerRole volunteerRole)
        {
            var p = new DynamicParameters();
            p.Add("V_RoleId", volunteerRole.Volunteer_Role_Id, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("V_RoleName", volunteerRole.Role_Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("TripId", volunteerRole.TripVolunteerroles, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("Volunteer_Roles_Package.UpdateVolunteerRole", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteVolunteerRole(int id)
        {
            var p = new DynamicParameters();
            p.Add("V_RoleId", id, DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("Volunteer_Roles_Package.DeleteVolunteerRole", p, commandType: CommandType.StoredProcedure);
        }
    }
}
