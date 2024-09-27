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
    public class ContactUsRepository : IContactUsRepository
    {
        private readonly IDbContext _dbContext;
        public ContactUsRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<ContactU> GetAllContacts()
        {
            IEnumerable<ContactU> result = _dbContext.Connection.Query<ContactU>("contact_us_Package.GetAllContacts", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public ContactU GetContactById(int contactId)
        {
            var p = new DynamicParameters();
            p.Add("p_contact_id", contactId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Query<ContactU>("contact_us_Package.GetContactById", p, commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }

        public void CreateContact(ContactU contact)
        {
            var p = new DynamicParameters();
            p.Add("p_query", contact.Query, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_messages", contact.Messages, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_email", contact.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_full_name", contact.FullName, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("contact_us_Package.CreateContact", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateContact(ContactU contact)
        {
            var p = new DynamicParameters();
            p.Add("p_query", contact.Query, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_messages", contact.Messages, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_email", contact.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_full_name", contact.FullName, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_contact_id", contact.ContactId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("contact_us_Package.UpdateContact", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteContact(int contactId)
        {
            var p = new DynamicParameters();
            p.Add("p_contact_id", contactId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("contact_us_Package.DeleteContact", p, commandType: CommandType.StoredProcedure);
        }



    }
}
