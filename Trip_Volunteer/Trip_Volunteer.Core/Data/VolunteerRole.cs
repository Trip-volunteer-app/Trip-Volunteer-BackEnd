using System;
using System.Collections.Generic;

namespace Trip_Volunteer.Core.Data
{
    public partial class VolunteerRole
    {
        public VolunteerRole()
        {
            Volunteers = new HashSet<Volunteer>();
        }

        public decimal VolunteerRoleId { get; set; }
        public string? RoleName { get; set; }
        public decimal? TripId { get; set; }

        public virtual Trip? Trip { get; set; }
        public virtual ICollection<Volunteer> Volunteers { get; set; }
    }
}
