using Dapper;
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
    public class ContactusElementRepository: IContactusElementRepository
    {
        private readonly IDbContext _dbContext;
        public ContactusElementRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public List<ContactusElement> GetAllContactusElements()
        {
            IEnumerable<ContactusElement> result = _dbContext.Connection.Query<ContactusElement>("Contactus_Elements_Package.GetAllContactusElements", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public ContactusElement GetContactusElementById(int id)
        {
            var p = new DynamicParameters();
            p.Add("Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Query<ContactusElement>("Contactus_Elements_Package.GetContactusElementById", p, commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }

        public void CreateContactusElement(ContactusElement contactusElement)
        {
            var p = new DynamicParameters();

            p.Add("C_Img", contactusElement.Image1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("C_hero_img", contactusElement.Hero_Img, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("C_header", contactusElement.Header, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("Contactus_Elements_Package.CreateContactusElement", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateContactusElement(ContactusElement contactusElement)
        {
            var p = new DynamicParameters();

            p.Add("C_id ", contactusElement.Contactus_Elements_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("C_Img", contactusElement.Image1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("C_hero_img", contactusElement.Hero_Img, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("C_header", contactusElement.Header, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("Contactus_Elements_Package.UpdateContactusElement", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteContactusElement(int id)
        {
            var p = new DynamicParameters();
            p.Add("Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("Contactus_Elements_Package.DeleteContactusElement", p, commandType: CommandType.StoredProcedure);

        }

        public ContactusElement GetSelectedContactusElement()
        {
            var result = _dbContext.Connection.Query<ContactusElement>("Contactus_Elements_Package.GetSelectedContactusElement", commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }

        public void UpdateContactusElementSelectStatus(int id)
        {
            var p = new DynamicParameters();
            p.Add("C_id ", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("Contactus_Elements_Package.UpdateContactusElementSelectStatus", p, commandType: CommandType.StoredProcedure);
        }
        public List<TeamDTO> GetAllTeam()
        {
            IEnumerable<TeamDTO> result = _dbContext.Connection.Query<TeamDTO>("GetAllTeam", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
