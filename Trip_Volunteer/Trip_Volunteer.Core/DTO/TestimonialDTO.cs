using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trip_Volunteer.Core.DTO
{
    public class TestimonialDTO
    {
        public decimal Testimonial_Id { get; set; }
        public decimal? Login_Id { get; set; }
        public string? Case { get; set; }
        public string? Status { get; set; }
        public string? Feedback { get; set; }
        public decimal? Rating { get; set; }
        public DateTime? Create_At { get; set; }
        public decimal User_Id { get; set; }
        public string First_Name { get; set; } = null!;
        public string? Last_Name { get; set; }
        public string? Image_Path { get; set; }
    }
}
