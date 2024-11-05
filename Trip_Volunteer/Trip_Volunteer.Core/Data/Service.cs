using System;
using System.Collections.Generic;

namespace Trip_Volunteer.Core.Data
{
    public partial class Service
    {
        public Service()
        {
            TripServices = new HashSet<TripService>();
        }

        public decimal? Service_Id { get; set; }
        public decimal? Service_Cost { get; set; }
        public string? Service_Name { get; set; }

        public virtual ICollection<TripService> TripServices { get; set; }
        public virtual ICollection<BookingServices> Booking_Services { get; set; }

    }
}
