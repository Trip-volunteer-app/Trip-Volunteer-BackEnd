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
    public class AboutUsRepository : IAboutUsRepository
    {
        private readonly IDbContext _dbContext;

        public AboutUsRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Aboutu> GetAllAboutUsElements()
        {
            IEnumerable<Aboutu> result = _dbContext.Connection.Query<Aboutu>("Aboutus_Package.GetAllAboutUsElements", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public Aboutu GetAboutUsElementById(int id)
        {
            var p = new DynamicParameters();
            p.Add("AboutUs_Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Aboutu> result = _dbContext.Connection.Query<Aboutu>("Aboutus_Package.GetAboutUsElementById", p, commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();

        }

        public void CreateAboutUsElements(Aboutu aboutus)
        {

            var p = new DynamicParameters();
            p.Add("A_IMG_1", aboutus.Image1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("A_IMG_2", aboutus.Image2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("A_Text_1", aboutus.Text1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("A_Text_2", aboutus.Text2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("A_Text_3", aboutus.Text3, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("A_IMG_3", aboutus.Image3, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("A_IMG_4", aboutus.Image4, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("A_Text_5", aboutus.Text5, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("A_Text_6", aboutus.Text6, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("A_Text_7", aboutus.Text7, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("Aboutus_Package.CreateAboutUsElements", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateAboutUsElements(Aboutu aboutus)
        {
            var p = new DynamicParameters();
            p.Add("AboutUs_Id", aboutus.Aboutus_Page_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("A_IMG_1", aboutus.Image1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("A_IMG_2", aboutus.Image2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("A_Text_1", aboutus.Text1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("A_Text_2", aboutus.Text2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("A_Text_3", aboutus.Text3, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("A_IMG_3", aboutus.Image3, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("A_IMG_4", aboutus.Image4, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("A_Text_5", aboutus.Text5, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("A_Text_6", aboutus.Text6, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("A_Text_7", aboutus.Text7, dbType: DbType.String, direction: ParameterDirection.Input);
            
            _dbContext.Connection.Execute("Aboutus_Package.UpdateAboutUsElements", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteAboutUsElements(int id)
        {
            var p = new DynamicParameters();
            p.Add("AboutUs_Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("Aboutus_Package.DeleteAboutUsElements", p, commandType: CommandType.StoredProcedure);
        }
    }
}
