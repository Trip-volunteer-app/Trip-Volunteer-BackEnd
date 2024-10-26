using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Common;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.Repository;

namespace Trip_Volunteer.Infra.Repository
{
    public class WebsiteInformationRepository : IWebsiteInformationRepository
    {

        private readonly IDbContext _dbContext;
        public WebsiteInformationRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<WebsiteInformation> GetAllwebsite_information()
        {
            IEnumerable<WebsiteInformation> result = _dbContext.Connection.Query<WebsiteInformation>("website_information_Package.GetAllwebsite_information", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public WebsiteInformation Getwebsite_informationById(int ID)
        {
            var p = new DynamicParameters();
            p.Add("id", ID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<WebsiteInformation> result = _dbContext.Connection.Query<WebsiteInformation>("website_information_Package.Getwebsite_informationById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void CREATEwebsite_information(WebsiteInformation websiteInformation)
        {
            var p = new DynamicParameters();
            p.Add("email", websiteInformation.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("phone_number", websiteInformation.Phone_Number, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("address", websiteInformation.Adress, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("open_time", websiteInformation.Open_Time, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("closing_time", websiteInformation.Closing_Time, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("website_link", websiteInformation.Closing_Time, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("website_information_Package.CREATEwebsite_information", p, commandType: CommandType.StoredProcedure);


        }

        public void UPDATEwebsite_information(WebsiteInformation websiteInformation)
        {
            var p = new DynamicParameters();
            p.Add("websiteid", websiteInformation.Website_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Uemail", websiteInformation.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Phonenumber", websiteInformation.Phone_Number, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("uaddress", websiteInformation.Adress, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("opentime", websiteInformation.Open_Time, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("closingtime", websiteInformation.Closing_Time, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("websitelink", websiteInformation.Website_Link, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("website_information_Package.UPDATEwebsite_information", p, commandType: CommandType.StoredProcedure);
        }

        public void Deletewebsite_information(int Id)
        {
            var p = new DynamicParameters();
            p.Add("Id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("website_information_Package.Deletewebsite_information", p, commandType: CommandType.StoredProcedure);

        }

        public WebsiteInformation GetSelectedWebsiteInfo()
        {
            var result = _dbContext.Connection.Query<WebsiteInformation>("website_information_Package.GetSelectedWebsiteInfo", commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }

        public void UpdateSelectedWebsiteInfo(int id)
        {
            var p = new DynamicParameters();
            p.Add("id ", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("website_information_Package.UpdateSelectedWebsiteInfo", p, commandType: CommandType.StoredProcedure);
        }
    }
}
