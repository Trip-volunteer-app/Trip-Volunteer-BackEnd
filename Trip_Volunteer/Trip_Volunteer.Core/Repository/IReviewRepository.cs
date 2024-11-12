using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Data;

namespace Trip_Volunteer.Core.Repository
{
    public interface IReviewRepository
    {
        List<Review> GetAllReview();
        Review GetReviewById(int id);
        List<Review> GetreviewByBookingID(int id);
        void CreateReview(Review review);
        void UpdateReview(Review review);
        void DeleteReview(int id);
    }
}
