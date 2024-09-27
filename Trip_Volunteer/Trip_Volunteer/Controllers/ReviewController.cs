using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.Service;

namespace Trip_Volunteer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet]
        public List<Review> GetAllReview()
        {
          return  _reviewService.GetAllReview().ToList();
        }

        [HttpGet]
        [Route("GetReviewById/{id}")]
        public Review GetReviewById(int id)
        {
           return _reviewService.GetReviewById(id);

        }

        [HttpPost]
        [Route("CreateReview")]
        public void CreateReview(Review review)
        {
            _reviewService.CreateReview(review);
        }

        [HttpPut]
        [Route("UpdateReview")]
        public void UpdateReview(Review review)
        {
            _reviewService.UpdateReview(review);
        }

        [HttpDelete]
        [Route("DeleteReview/{id}")]
        public void DeleteReview(int id)
        {
            _reviewService.DeleteReview(id);
        }
    }
}
