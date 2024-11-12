﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.DTO;

namespace Trip_Volunteer.Core.Repository
{
    public interface IReviewRepository
    {
        List<ReviewDTO> GetAllReview();
        Review GetReviewById(int id);
        void CreateReview(Review review);
        void UpdateReview(Review review);
        void DeleteReview(int id);
         List<ReviewDTO> GetreviewBycategoryId(int id);
    }
}
