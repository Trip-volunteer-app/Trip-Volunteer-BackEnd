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
    public class TestimonialElementRepository: ITestimonialElementRepository
    {
        private readonly IDbContext _dbContext;
        public TestimonialElementRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public List<TestimonialElement> GetAllTestimonialElements()
        {
            IEnumerable<TestimonialElement> result = _dbContext.Connection.Query<TestimonialElement>("Testimonial_Elements_Package.GetAllTestimonialElements", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public TestimonialElement GetTestimonialElementById(int id)
        {
            var p = new DynamicParameters();
            p.Add("Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Query<TestimonialElement>("Testimonial_Elements_Package.GetTestimonialElementById", p, commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }

        public void CreateTestimonialElement(TestimonialElement testimonialElement)
        {
            var p = new DynamicParameters();

            p.Add("T_Img", testimonialElement.Image1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("T_Text", testimonialElement.Text1, dbType: DbType.String, direction: ParameterDirection.Input);
          
            _dbContext.Connection.Execute("Testimonial_Elements_Package.CreateTestimonialElement", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateTestimonialElement(TestimonialElement testimonialElement)
        {
            var p = new DynamicParameters();

            p.Add("T_id ", testimonialElement.Testimonial_Elements_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("T_Img", testimonialElement.Image1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("T_Text", testimonialElement.Text1, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("Testimonial_Elements_Package.UpdateTestimonialElement", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteTestimonialElement(int id)
        {
            var p = new DynamicParameters();
            p.Add("Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("Testimonial_Elements_Package.DeleteTestimonialElement", p, commandType: CommandType.StoredProcedure);

        }
    }
}
