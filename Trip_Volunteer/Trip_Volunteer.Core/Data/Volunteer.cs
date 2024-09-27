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

        public decimal Volunteer_Id { get; set; }
        public decimal? Login_Id { get; set; }
        public decimal? Trip_Id { get; set; }
        public decimal? Volunteer_Role_Id { get; set; }
        public string? Experience { get; set; }
        public decimal? Phone_Number { get; set; }
        public string? Email { get; set; }
        public string? Status { get; set; }
        public DateTime? Date_Applied { get; set; }
        public string? Notes { get; set; }
        public string? Emergency_Contact { get; set; }

        public virtual UserLogin? Login { get; set; }
        public virtual Trip? Trip { get; set; }
        public virtual VolunteerRole? VolunteerRole { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
