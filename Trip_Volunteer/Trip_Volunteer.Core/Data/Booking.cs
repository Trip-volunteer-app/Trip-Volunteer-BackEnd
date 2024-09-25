using System;
using System.Collections.Generic;

namespace Trip_Volunteer.Core.Data
{
    public partial class Booking
    {
        public Booking()
        {
            Reviews = new HashSet<Review>();
        }

        public decimal BookingId { get; set; }
        public string? PaymentStatus { get; set; }
        public decimal? TripId { get; set; }
        public decimal? LoginId { get; set; }
        public decimal? TotalAmount { get; set; }
        public DateTime? CreateAt { get; set; }

        public virtual UserLogin? Login { get; set; }
        public virtual Trip? Trip { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
