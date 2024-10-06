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
    public class BankRepository: IBankRepository
    {
        private readonly IDbContext _dbContext;
        public BankRepository(IDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public List<Bank> GetAllCard()
        {
            IEnumerable<Bank> result = _dbContext.Connection.Query<Bank>("Bank_Package.GetAllCard", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Bank GetCardById(int id)
        {
            var p = new DynamicParameters(); 
            p.Add("Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Query<Bank>("Bank_Package.GetCardById", p, commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }

        public void CreateCard(Bank bank)
        {
            var p = new DynamicParameters();

            p.Add("F_Name", bank.Full_Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("C_Namber", bank.Card_Number, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("B_Bank", bank.Balance, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Cvv_B", bank.Cvv, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Ex_Date", bank.Expiration_Date, dbType: DbType.Date, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("Bank_Package.CreateCard", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateCard(Bank bank)
        {
            var p = new DynamicParameters();

            p.Add("B_id ", bank.Bank_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("F_Name", bank.Full_Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("C_Namber", bank.Card_Number, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("B_Bank", bank.Balance, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Cvv_B", bank.Cvv, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Ex_Date", bank.Expiration_Date, dbType: DbType.Date, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("Bank_Package.UpdateCard", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteCard(int id)
        {
            var p = new DynamicParameters();
            p.Add("Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("Bank_Package.DeleteCard", p, commandType: CommandType.StoredProcedure);

        }
    }
}
