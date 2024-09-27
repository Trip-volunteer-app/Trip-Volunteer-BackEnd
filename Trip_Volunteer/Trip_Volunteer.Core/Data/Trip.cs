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

        public decimal Trip_Id { get; set; }
        public string? Trip_Name { get; set; }
        public decimal? Trip_Location_Id { get; set; }
        public decimal? Trip_Price { get; set; }
        public decimal? Max_Number_Of_Users { get; set; }
        public DateTime? Start_Date { get; set; }
        public DateTime? End_Date { get; set; }
        public string? Description { get; set; }
        public decimal? Max_Number_Of_Volunteers { get; set; }
        public decimal? Category_Id { get; set; }

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
