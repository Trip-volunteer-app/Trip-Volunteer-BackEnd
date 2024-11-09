﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Common;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.DTO;
using Trip_Volunteer.Core.Repository;

namespace Trip_Volunteer.Infra.Repository
{
    public class TripVolunteerroleRepository : ITripVolunteerroleRepository
    {
        private readonly IDbContext _dbContext;

        public TripVolunteerroleRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<TripVolunteerrole> GetAlltrip_volunteerRoles()
        {
            IEnumerable<TripVolunteerrole> result = _dbContext.Connection.Query<TripVolunteerrole>("trip_volunteerRoles_Packegs.GetAlltrip_volunteerRoles", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public TripVolunteerrole Gettrip_volunteerRolesById(int id)
        {
            var p = new DynamicParameters();
            p.Add("id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Query<TripVolunteerrole>("trip_volunteerRoles_Packegs.Gettrip_volunteerRolesById", p, commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }

        public void CREATEtrip_volunteerRoles(TripVolunteerrole tripVolunteerrole)
        {
            var p = new DynamicParameters();
            p.Add("trip_volunteerRoles_id", tripVolunteerrole.Trip_Volunteerroles_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("trip_id", tripVolunteerrole.Trip_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Volunteer_Role_ID", tripVolunteerrole.Volunteer_Role_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            
            _dbContext.Connection.Execute("trip_volunteerRoles_Packegs.CREATEtrip_volunteerRoles", p, commandType: CommandType.StoredProcedure);
        }

        public void UPDATEtrip_volunteerRoles(TripVolunteerrole tripVolunteerrole)
        {
            var p = new DynamicParameters();
            p.Add("trip_volunteerRoles_id", tripVolunteerrole.Trip_Volunteerroles_Id, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("trip_id", tripVolunteerrole.Trip_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Volunteer_Role_ID", tripVolunteerrole.Volunteer_Role_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("trip_volunteerRoles_Packegs.UPDATEtrip_volunteerRoles", p, commandType: CommandType.StoredProcedure);
        }

        public void Deletetrip_volunteerRoles(int id)
        {
            var p = new DynamicParameters();
            p.Add("id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("trip_volunteerRoles_Packegs.Deletetrip_volunteerRoles", p, commandType: CommandType.StoredProcedure);
        }

        public List<VolunteerRoleDTO> GetVolunteerRoleByTripId(int id)
        {
            var p = new DynamicParameters();
            p.Add("id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<VolunteerRoleDTO> result = _dbContext.Connection.Query<VolunteerRoleDTO>("trip_volunteerRoles_Packegs.GetVolunteerRoleByTripId", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public void CreateTripVRoleForVRolesList(TripWithVolunteerRolesDTO tripWithVolunteerRoles)
        {
            var p = new DynamicParameters();
            p.Add("v_tripId", tripWithVolunteerRoles.Trip_Id, dbType: DbType.String, direction: ParameterDirection.Input);

            var SelectedVolunteerRoles = string.Join(",", tripWithVolunteerRoles.SelectedVolunteerRoles);
            p.Add("SelectedVolunteerRoles", SelectedVolunteerRoles, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("trip_volunteerRoles_Packegs.CreateTripVRoleForVRolesList", p, commandType: CommandType.StoredProcedure);
        }
        public void DeleteTripVolunteerRoleForATrip(int tripId, int vRoleId)
        {
            var p = new DynamicParameters();
            p.Add("t_Id", tripId, DbType.Int32, ParameterDirection.Input);
            p.Add("vRole_Id", vRoleId, DbType.Int32, ParameterDirection.Input);
            _dbContext.Connection.Execute("trip_volunteerRoles_Packegs.DeleteTripVolunteerRoleForATrip", p, commandType: CommandType.StoredProcedure);
        }
    }
}
