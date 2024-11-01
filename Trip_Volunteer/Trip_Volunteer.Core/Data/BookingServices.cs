using System;
using System.Collections.Generic;

namespace Trip_Volunteer.Core.Data
{
    public partial class BookingServices
    {
        public decimal Booking_Service_Id { get; set; }
        public decimal? Booking_Id { get; set; }
        public decimal? Service_Id { get; set; }

        public virtual Booking? Booking { get; set; }
        public virtual Service? Service { get; set; }
    }
}
