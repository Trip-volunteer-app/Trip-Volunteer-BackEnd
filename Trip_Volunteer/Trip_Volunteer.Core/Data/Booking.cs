using System;
using System.Collections.Generic;

namespace Trip_Volunteer.Core.Data
{
    public partial class Booking
    {
        public Booking()
        {
            Reviews = new HashSet<Review>();
            Booking_Services = new HashSet<BookingServices>();
        }

        public decimal Booking_Id { get; set; }
        public string? Payment_Status { get; set; }
        public decimal? Trip_Id { get; set; }
        public decimal? Login_Id { get; set; }
        public decimal? Total_Amount { get; set; }
        public DateTime? Create_At { get; set; }

        public virtual UserLogin? Login { get; set; }
        public virtual Trip? Trip { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }

        public string? Note { get; set; }

        public decimal? NumberOfUser { get; set; }

        public virtual ICollection<BookingServices>? Booking_Services { get; set; }

    }
}
