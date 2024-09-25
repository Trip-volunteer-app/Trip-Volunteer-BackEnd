using System;
using System.Collections.Generic;

namespace Trip_Volunteer.Core.Data
{
    public partial class Review
    {
        public decimal ReviewId { get; set; }
        public decimal? Rate { get; set; }
        public string? Feedback { get; set; }
        public decimal? BookingId { get; set; }
        public DateTime? CreateAt { get; set; }
        public decimal? VolunteerId { get; set; }

        public virtual Booking? Booking { get; set; }
        public virtual Volunteer? Volunteer { get; set; }
    }
}
