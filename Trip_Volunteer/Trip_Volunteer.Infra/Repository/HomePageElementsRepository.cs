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
    public class HomePageElementsRepository : IHomePageElementsRepository
    {
        private readonly IDbContext _dbContext;

        public HomePageElementsRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<HomePageElement> GetAllHomePageElements()
        {
            IEnumerable<HomePageElement> result = _dbContext.Connection.Query<HomePageElement>("Home_Page_Elements_PACKAGE.GetAllHomePageElements", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public HomePageElement GetHomePageElementById(int id)
        {
            var p = new DynamicParameters();
            p.Add("H_Page_Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<HomePageElement> result = _dbContext.Connection.Query<HomePageElement>("Home_Page_Elements_PACKAGE.GetHomePageElementById", p, commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();

        }

        public void CreateHomePageElement(HomePageElement homePageElement)
        {
            var p = new DynamicParameters();
            p.Add("H_Hero_Image", homePageElement.Hero_Image, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("H_Title", homePageElement.Title, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("H_Logo_Image", homePageElement.Logo_Image, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("H_Logo_Text", homePageElement.Logo_Text, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("H_Text1", homePageElement.Text1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("H_Header", homePageElement.Header, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("Home_Page_Elements_PACKAGE.CreateHomePageElements", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdatHomePageElement(HomePageElement homePageElement)
        {
            var p = new DynamicParameters();
            p.Add("H_Page_Id", homePageElement.Home_Page_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("H_Hero_Image", homePageElement.Hero_Image, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("H_Title", homePageElement.Title, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("H_Logo_Image", homePageElement.Logo_Image, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("H_Logo_Text", homePageElement.Logo_Text, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("H_Text1", homePageElement.Text1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("H_Header", homePageElement.Header, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("Home_Page_Elements_PACKAGE.UpdateHomePageElements", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteHomePageElement(int id)
        {
            var p = new DynamicParameters();
            p.Add("H_Page_Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("Home_Page_Elements_PACKAGE.DeleteHomePageElements", p, commandType: CommandType.StoredProcedure);
        }
        public HomePageElement GetSelectedHomeElement()
        {
            var result = _dbContext.Connection.Query<HomePageElement>("Home_Page_Elements_PACKAGE.GetSelectedHomeElements", commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }

        public void UpdateHomeSelectStatus(int id)
        {
            var p = new DynamicParameters();
            p.Add("H_Page_Id ", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("Home_Page_Elements_PACKAGE.UpdateSelectedHomeElements", p, commandType: CommandType.StoredProcedure);
        }
    }
}
