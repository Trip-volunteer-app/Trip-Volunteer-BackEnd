using System;
using System.Collections.Generic;

namespace Trip_Volunteer.Core.Data
{
    public partial class Service
    {
        public Service()
        {
            TripServices = new HashSet<TripService>();
        }

        public decimal ServiceId { get; set; }
        public decimal? ServiceCost { get; set; }
        public string? ServiceName { get; set; }

        public virtual ICollection<TripService> TripServices { get; set; }
    }
}
