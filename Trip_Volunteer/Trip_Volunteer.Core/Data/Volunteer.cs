using System;
using System.Collections.Generic;

namespace Trip_Volunteer.Core.Data
{
    public partial class Volunteer
    {
        public Volunteer()
        {
            Reviews = new HashSet<Review>();
        }

        public decimal VolunteerId { get; set; }
        public decimal? LoginId { get; set; }
        public decimal? TripId { get; set; }
        public decimal? VolunteerRoleId { get; set; }
        public string? Experience { get; set; }
        public decimal? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Status { get; set; }
        public DateTime? DateApplied { get; set; }
        public string? Notes { get; set; }
        public string? EmergencyContact { get; set; }

        public virtual UserLogin? Login { get; set; }
        public virtual Trip? Trip { get; set; }
        public virtual VolunteerRole? VolunteerRole { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
