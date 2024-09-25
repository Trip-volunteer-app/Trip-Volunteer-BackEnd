using System;
using System.Collections.Generic;

namespace Trip_Volunteer.Core.Data
{
    public partial class Category
    {
        public Category()
        {
            Trips = new HashSet<Trip>();
        }

        public decimal CategoryId { get; set; }
        public string? CategoryName { get; set; }

        public virtual ICollection<Trip> Trips { get; set; }
    }
}
