using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Common;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.DTO;
using Trip_Volunteer.Core.Repository;

namespace Trip_Volunteer.Infra.Repository
{
    public class TestimonialRepository : ITestimonialRepository
    {
        private readonly IDbContext _dbContext;

        public TestimonialRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Testimonial> GetAllTestimonies()
        {
            IEnumerable<Testimonial> result = _dbContext.Connection.Query<Testimonial>("Testimonial_Package.GetAllTestimonies", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<TestimonialDTO> GetAcceptedTestimonies()
        {
            IEnumerable<TestimonialDTO> result = _dbContext.Connection.Query<TestimonialDTO>("Testimonial_Package.GetAcceptedTestimonies", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Testimonial GetTestimonyById(int id)
        {
            var p = new DynamicParameters();
            p.Add("T_Id", id, DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Query<Testimonial>("Testimonial_Package.GetTestimonyById", p, commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }

        public void CreateTestimony(Testimonial testimonial) 
        {
            var p = new DynamicParameters();
            p.Add("LoginId", testimonial.Login_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("T_Case", testimonial.Case, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("T_Status", testimonial.Status, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("T_Feedback", testimonial.Feedback, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("T_Rating", testimonial.Rating, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("T_CreateAt", testimonial.Create_At, dbType: DbType.Date, direction: ParameterDirection.Input);


            _dbContext.Connection.Execute("Testimonial_Package.CreateTestimony", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateTestimony(Testimonial testimonial)
        {
            var p = new DynamicParameters();
            p.Add("T_Id", testimonial.Testimonial_Id, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("LoginId", testimonial.Login_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("T_Case", testimonial.Case, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("T_Status", testimonial.Status, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("T_Feedback", testimonial.Feedback, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("T_Rating", testimonial.Rating, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("T_CreateAt", testimonial.Create_At, dbType: DbType.Date, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("Testimonial_Package.UpdateTestimony", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteTestimony(int id)
        {
            var p = new DynamicParameters();
            p.Add("T_Id", id, DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("Testimonial_Package.DeleteTestimony", p, commandType: CommandType.StoredProcedure);
        }
        public List<TestimonyCountDTO> GetTestimonyStatusCounts()
        {
            IEnumerable<TestimonyCountDTO> result = _dbContext.Connection.Query<TestimonyCountDTO>("GetTestimonyStatusCounts", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }


    }
}
