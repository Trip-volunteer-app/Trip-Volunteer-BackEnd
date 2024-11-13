using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.DTO;
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
/*        [CheckClaimsAttribute("Roleid", "1")]
*/        public List<ReviewDTO> GetAllReview()
        {
          return  _reviewService.GetAllReview().ToList();
        }

        [HttpGet]
        [Route("GetReviewById/{id}")]
        [CheckClaimsAttribute("Roleid", "1")]
        public Review GetReviewById(int id)
        {
           return _reviewService.GetReviewById(id);

        }

        [HttpPost]
        [Route("CreateReview")]
        //[CheckClaimsAttribute("Roleid", "1","2")]
        public void CreateReview(Review review)
        {
            _reviewService.CreateReview(review);
        }

        [HttpPut]
        [Route("UpdateReview")]
        [CheckClaimsAttribute("Roleid", "1")]
        public void UpdateReview(Review review)
        {
            _reviewService.UpdateReview(review);
        }

        [HttpDelete]
        [Route("DeleteReview/{id}")]
        [CheckClaimsAttribute("Roleid", "1")]
        public void DeleteReview(int id)
        {
            _reviewService.DeleteReview(id);
        }

        [HttpGet]
        [Route("GetreviewBycategoryId/{id}")]
/*        [CheckClaimsAttribute("Roleid", "1","2")]
*/        public List<ReviewDTO> GetreviewBycategoryId(int id)
        {
            return _reviewService.GetreviewBycategoryId(id);
        }

        [HttpGet]
        [Route("GetreviewByBookingID/{id}")]
        /*        [CheckClaimsAttribute("Roleid", "1","2")]
        */
        public List<Review> GetreviewByBookingID(int id)
        {
            return _reviewService.GetreviewByBookingID(id);
        }
    }
}
