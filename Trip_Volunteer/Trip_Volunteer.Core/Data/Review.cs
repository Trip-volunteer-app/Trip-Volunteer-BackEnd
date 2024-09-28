using System;
using System.Collections.Generic;

namespace Trip_Volunteer.Core.Data
{
    public partial class Review
    {
        public decimal Review_Id { get; set; }
        public decimal? Rate { get; set; }
        public string? Feedback { get; set; }
        public decimal? Booking_Id { get; set; }
        public DateTime? Create_At { get; set; }
        public decimal? Volunteer_Id { get; set; }

        public virtual Booking? Booking { get; set; }
        public virtual Volunteer? Volunteer { get; set; }
    }
}
