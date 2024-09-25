using System;
using System.Collections.Generic;

namespace Trip_Volunteer.Core.Data
{
    public partial class Trip
    {
        public Trip()
        {
            Bookings = new HashSet<Booking>();
            Payments = new HashSet<Payment>();
            TripImages = new HashSet<TripImage>();
            TripServices = new HashSet<TripService>();
            VolunteerRoles = new HashSet<VolunteerRole>();
            Volunteers = new HashSet<Volunteer>();
        }

        public decimal TripId { get; set; }
        public string? TripName { get; set; }
        public decimal? TripLocationId { get; set; }
        public decimal? TripPrice { get; set; }
        public decimal? MaxNumberOfUsers { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? MaxNumberOfVolunteers { get; set; }
        public string? Description { get; set; }
        public decimal? CategoryId { get; set; }

        public virtual Category? Category { get; set; }
        public virtual Location? TripLocation { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<TripImage> TripImages { get; set; }
        public virtual ICollection<TripService> TripServices { get; set; }
        public virtual ICollection<VolunteerRole> VolunteerRoles { get; set; }
        public virtual ICollection<Volunteer> Volunteers { get; set; }
    }
}
