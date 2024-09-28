using System;
using System.Collections.Generic;

namespace Trip_Volunteer.Core.Data
{
    public partial class Testimonial
    {
        public decimal Testimonial_Id { get; set; }
        public decimal? Login_Id { get; set; }
        public string? Case { get; set; }
        public string? Status { get; set; }
        public string? Feedback { get; set; }
        public decimal? Rating { get; set; }
        public DateTime? Create_At { get; set; }

        public virtual UserLogin? Login { get; set; }
    }
}
