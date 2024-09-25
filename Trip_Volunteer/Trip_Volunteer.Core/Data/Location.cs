using System;
using System.Collections.Generic;

namespace Trip_Volunteer.Core.Data
{
    public partial class Location
    {
        public Location()
        {
            Trips = new HashSet<Trip>();
        }

        public decimal LocationId { get; set; }
        public string? DepartureLocation { get; set; }
        public string? DestinationLocation { get; set; }
        public decimal? DepartureLatitude { get; set; }
        public decimal? DepartureLongitude { get; set; }
        public decimal? DestinationLatitude { get; set; }
        public decimal? DestinationLongitude { get; set; }

        public virtual ICollection<Trip> Trips { get; set; }
    }
}
