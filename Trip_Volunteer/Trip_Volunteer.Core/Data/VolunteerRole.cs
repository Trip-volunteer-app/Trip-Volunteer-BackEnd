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

        public decimal Volunteer_Role_Id { get; set; }
        public string? Role_Name { get; set; }
        public decimal? Trip_Id { get; set; }

        public virtual Trip? Trip { get; set; }
        public virtual ICollection<Volunteer> Volunteers { get; set; }
    }
}
