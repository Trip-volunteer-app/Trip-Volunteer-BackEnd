using System;
using System.Collections.Generic;

namespace Trip_Volunteer.Core.Data
{
    public partial class TripVolunteerrole
    {
        public decimal Trip_Volunteerroles_Id { get; set; }
        public decimal? Trip_Id { get; set; }
        public decimal? Volunteer_Role_Id { get; set; }
        public int? Number_Of_Volunteers { get; set; }

        public virtual Trip? Trip { get; set; }
        public virtual VolunteerRole? VolunteerRole { get; set; }
    }
}
