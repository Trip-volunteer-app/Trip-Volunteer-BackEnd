using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.Repository;
using Trip_Volunteer.Core.Service;

namespace Trip_Volunteer.Infra.Service
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public void CreateReview(Review review)
        {
            _reviewRepository.CreateReview(review);
        }

        public void DeleteReview(int id)
        {
            _reviewRepository.DeleteReview(id);
        }

        public List<Review> GetAllReview()
        {
           return _reviewRepository.GetAllReview();
        }

        public Review GetReviewById(int id)
        {
         return _reviewRepository.GetReviewById(id);
        }

        public List<Review> GetreviewByBookingID(int id)
        {
            return _reviewRepository.GetreviewByBookingID(id);
        }

        public void UpdateReview(Review review)
        {
            _reviewRepository.UpdateReview(review);
        }
    }
}
