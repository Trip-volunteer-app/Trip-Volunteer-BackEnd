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
    public class PaymentRepository : IPaymentRepository
    {
        private readonly IDbContext _dbContext;

        public PaymentRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Payment> GetAllPayments()
        {
            IEnumerable<Payment> result = _dbContext.Connection.Query<Payment>("Payments_Package.GetAllPayments", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public Payment GetPaymantById(int id)
        {
            var p = new DynamicParameters();
            p.Add("Pay_Id", id, DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Query<Payment>("Payments_Package.GetPaymentById",p,commandType:CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }

        public void CreatePayment(Payment payment)
        {
            var p = new DynamicParameters();
            p.Add("Total_Price", payment.Price, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("TripId", payment.Trip_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("LoginId", payment.Login_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("BankId", payment.Bank_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Create_Date", payment.Create_At, dbType: DbType.Date, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("Payments_Package.CreatePayment", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdatePayment(Payment payment)
        {
            var p = new DynamicParameters();
            p.Add("Pay_Id", payment.Payment_Id, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Total_Price", payment.Price, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("TripId", payment.Trip_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("LoginId", payment.Login_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("BankId", payment.Bank_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Create_Date", payment.Create_At, dbType: DbType.Date, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("Payments_Package.UpdatePayment", p, commandType: CommandType.StoredProcedure);
        }

        public void DeletePayment(int id)
        {
            var p = new DynamicParameters();
            p.Add("Pay_Id", id, DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("Payments_Package.DeletePayment", p, commandType: CommandType.StoredProcedure);
        }
    }
}
