﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Common;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.DTO;
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

            _dbContext.Connection.Execute("Volunteer_Roles_Package.CreateVolunteerRole", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateVolunteerRole(VolunteerRole volunteerRole)
        {
            var p = new DynamicParameters();
            p.Add("V_RoleId", volunteerRole.Volunteer_Role_Id, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("V_RoleName", volunteerRole.Role_Name, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("Volunteer_Roles_Package.UpdateVolunteerRole", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteVolunteerRole(int id)
        {
            var p = new DynamicParameters();
            p.Add("V_RoleId", id, DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("Volunteer_Roles_Package.DeleteVolunteerRole", p, commandType: CommandType.StoredProcedure);
        }

        public List<VolunteerRoleDTO> GetRoleByTripID (int tripId)
        {
            var p = new DynamicParameters();
            p.Add("p_trip_id", tripId, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Query<VolunteerRoleDTO>("Volunteer_Roles_Package.GetRoleByTripID", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public void CreateVolunteerRoleForTrip(VolunteerRoleDTO volunteerRoleDTO)
        {
            var p = new DynamicParameters();
            p.Add("T_id", volunteerRoleDTO.Trip_Id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("v_id", volunteerRoleDTO.Volunteer_Role_Id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("v_name", volunteerRoleDTO.Role_Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("V_Number_Of_Voluntters", volunteerRoleDTO.Number_Of_Volunteers, dbType: DbType.Int32, direction: ParameterDirection.Input);


            _dbContext.Connection.Execute(
                "Volunteer_Roles_Package.CreateVolunteerRoleForTrip",
                p,
                commandType: CommandType.StoredProcedure);
        }
    }
}
