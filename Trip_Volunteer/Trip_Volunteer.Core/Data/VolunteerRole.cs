using System;
using System.Collections.Generic;

namespace Trip_Volunteer.Core.Data
{
    public partial class VolunteerRole
    {
        public VolunteerRole()
        {
            TripVolunteerroles = new HashSet<TripVolunteerrole>();
            Volunteers = new HashSet<Volunteer>();
        }

        public decimal Volunteer_Role_Id { get; set; }
        public string? Role_Name { get; set; }
        public int? Number_Of_Volunteers { get; set; }


        public virtual ICollection<TripVolunteerrole> TripVolunteerroles { get; set; }
        public virtual ICollection<Volunteer> Volunteers { get; set; }
    }
}
