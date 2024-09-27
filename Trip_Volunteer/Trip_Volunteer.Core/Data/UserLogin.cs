using System;
using System.Collections.Generic;

namespace Trip_Volunteer.Core.Data
{
    public partial class UserLogin
    {
        public UserLogin()
        {
            Bookings = new HashSet<Booking>();
            Payments = new HashSet<Payment>();
            Testimonials = new HashSet<Testimonial>();
            Volunteers = new HashSet<Volunteer>();
        }

        public decimal Login_Id { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public decimal? Role_Id { get; set; }
        public DateTime? Date_Register { get; set; }
        public decimal? User_Id { get; set; }
        public string? Repassword { get; set; }

        public virtual UserRole? Role { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<Testimonial> Testimonials { get; set; }
        public virtual ICollection<Volunteer> Volunteers { get; set; }
    }
}
