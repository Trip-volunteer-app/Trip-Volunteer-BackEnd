using System;
using System.Collections.Generic;

namespace Trip_Volunteer.Core.Data
{
    public partial class BookingService
    {
        public decimal BookingServiceId { get; set; }
        public decimal? BookingId { get; set; }
        public decimal? ServiceId { get; set; }

        public virtual Booking? Booking { get; set; }
        public virtual Service? Service { get; set; }
    }
}
