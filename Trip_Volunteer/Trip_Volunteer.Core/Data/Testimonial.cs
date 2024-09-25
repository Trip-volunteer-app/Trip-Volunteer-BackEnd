using System;
using System.Collections.Generic;

namespace Trip_Volunteer.Core.Data
{
    public partial class Testimonial
    {
        public decimal TestimonialId { get; set; }
        public decimal? LoginId { get; set; }
        public string? Case { get; set; }
        public string? Status { get; set; }
        public string? Feedback { get; set; }
        public decimal? Rating { get; set; }
        public DateTime? CreateAt { get; set; }

        public virtual UserLogin? Login { get; set; }
    }
}
