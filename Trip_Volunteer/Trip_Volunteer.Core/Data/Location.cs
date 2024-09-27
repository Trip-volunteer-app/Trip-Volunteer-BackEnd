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

        public decimal Location_Id { get; set; }
        public string? Departure_Location { get; set; }
        public string? Destination_Location { get; set; }
        public decimal? Departure_Latitude { get; set; }
        public decimal? Departure_Longitude { get; set; }
        public decimal? Destination_Latitude { get; set; }
        public decimal? Destination_Longitude { get; set; }

        public virtual ICollection<Trip> Trips { get; set; }
    }
}
