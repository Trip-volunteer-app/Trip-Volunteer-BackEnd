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
    public class CardRepository: ICardRepository
    {
  
            private readonly IDbContext _dbContext;
            public CardRepository(IDbContext dbContext)
            {
                _dbContext = dbContext;
            }

        public List<Card> GetAllCard()
        {
            IEnumerable<Card> result = _dbContext.Connection.Query<Card>("Card_Package.GetAllCard", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Card GetCardById(int id)
        {
            var p = new DynamicParameters();
            p.Add("Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Query<Card>("Card_Package.GetCardById", p, commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }

        public List<Card> GetCardByLoginId(int id)
        {
            var p = new DynamicParameters();
            p.Add("Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Card> result = _dbContext.Connection.Query<Card>("Card_Package.GetCardByLoginId", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public void CreateCard(Card card)
        {
            var p = new DynamicParameters();

            p.Add("cardHolder", card.Cardholder_Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("C_Namber", card.Card_Number, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Ex_Date", card.Expiry_Date, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Log_id", card.Login_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("Card_Package.CreateCard", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateCard(Card card)
        {
            var p = new DynamicParameters();

            p.Add("c_id ", card.Card_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("cardHolder", card.Cardholder_Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("C_Namber", card.Card_Number, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Ex_Date", card.Expiry_Date, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Log_id", card.Login_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("Card_Package.UpdateCard", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteCard(int id)
        {
            var p = new DynamicParameters();
            p.Add("Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("Card_Package.DeleteCard", p, commandType: CommandType.StoredProcedure);

        }
    }
}
