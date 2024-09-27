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
    public class ReviewRepository: IReviewRepository
    {
        private readonly IDbContext _dbContext;
        public ReviewRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Review> GetAllReview()
        {
            IEnumerable<Review> result = _dbContext.Connection.Query<Review>("review_Package.GetAllreview", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Review GetReviewById(int id)
        {
            var p = new DynamicParameters();
            p.Add("IdReview", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Query<Review>("review_Package.GetreviewById", p, commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();

        }

        public void CreateReview(Review review)
        {
            var p = new DynamicParameters();
            p.Add("p_rate", review.Rate, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_feedback", review.Feedback, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_booking_id", review.BookingId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("review_Package.Createreview", p, commandType: CommandType.StoredProcedure);
        }


        public void UpdateReview(Review review)
        {
            var p = new DynamicParameters();
            p.Add("p_rate", review.Rate, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_feedback", review.Feedback, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_booking_id", review.BookingId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("IdReview", review.ReviewId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("review_Package.Updatereview", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteReview(int id)
        {
            var p = new DynamicParameters();
            p.Add("IdReview", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("review_Package.Deletereview", p, commandType: CommandType.StoredProcedure);
        }
    }
}
