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
            p.Add("A_Title", aboutus.Title, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("A_Hero_Image", aboutus.Hero_image, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("A_Header", aboutus.Header, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("A_Image1", aboutus.Image1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("A_Image2", aboutus.Image2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("A_Image3", aboutus.Image3, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("A_Image4", aboutus.Image4, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("A_Feature1_Header", aboutus.Feature1_header, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("A_Feature1", aboutus.Feature1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("A_Feature2_Header", aboutus.Feature2_header, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("A_Feature2", aboutus.Feature2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("A_Feature3_Header", aboutus.Feature3_header, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("A_Feature3", aboutus.Feature3, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("A_Feature4_Header", aboutus.Feature4_header, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("A_Feature4", aboutus.Feature4, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("A_Header2", aboutus.Header2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("A_Title2", aboutus.Title2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("A_AboutUs", aboutus.Aboutus, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("A_Image5", aboutus.Image5, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("A_Image6", aboutus.Image6, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("A_Header3", aboutus.Header3, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("A_Text1", aboutus.Text1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("A_FeedbackHeader", aboutus.FeedbackHeader, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("A_FeedbackTitle", aboutus.FeedbackTitle, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("A_Feedback_Background", aboutus.Feedback_background, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute(
                "Aboutus_Package.CreateAboutUsElements",
                p,
                commandType: CommandType.StoredProcedure
            );
        }

        public void UpdateAboutUsElements(Aboutu aboutus)
        {
            var p = new DynamicParameters();

            p.Add("AboutUs_Id", aboutus.Aboutus_Page_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("A_Title", aboutus.Title, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("A_Hero_Image", aboutus.Hero_image, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("A_Header", aboutus.Header, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("A_Image1", aboutus.Image1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("A_Image2", aboutus.Image2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("A_Image3", aboutus.Image3, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("A_Image4", aboutus.Image4, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("A_Feature1_Header", aboutus.Feature1_header, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("A_Feature1", aboutus.Feature1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("A_Feature2_Header", aboutus.Feature2_header, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("A_Feature2", aboutus.Feature2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("A_Feature3_Header", aboutus.Feature3_header, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("A_Feature3", aboutus.Feature3, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("A_Feature4_Header", aboutus.Feature4_header, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("A_Feature4", aboutus.Feature4, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("A_Header2", aboutus.Header2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("A_Title2", aboutus.Title2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("A_AboutUs", aboutus.Aboutus, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("A_Image5", aboutus.Image5, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("A_Image6", aboutus.Image6, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("A_Header3", aboutus.Header3, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("A_Text1", aboutus.Text1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("A_FeedbackHeader", aboutus.FeedbackHeader, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("A_FeedbackTitle", aboutus.FeedbackTitle, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("A_Feedback_Background", aboutus.Feedback_background, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute(
                "Aboutus_Package.UpdateAboutUsElements",
                p,
                commandType: CommandType.StoredProcedure
            );
        }


        public void DeleteAboutUsElements(int id)
        {
            var p = new DynamicParameters();
            p.Add("AboutUs_Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("Aboutus_Package.DeleteAboutUsElements", p, commandType: CommandType.StoredProcedure);
        }

        public Aboutu GetSelectedAboutus()
        {
            var result = _dbContext.Connection.Query<Aboutu>("Aboutus_Package.GetSelectedAboutus", commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }

        public void UpdateSelectedAboutus(int id)
        {
            var p = new DynamicParameters();
            p.Add("AboutUs_Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("Aboutus_Package.UpdateSelectedAboutus", p, commandType: CommandType.StoredProcedure);
        }
    }
}
