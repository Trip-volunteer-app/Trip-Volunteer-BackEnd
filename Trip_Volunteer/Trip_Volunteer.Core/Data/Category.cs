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

        public decimal Category_Id { get; set; }
        public string? Category_Name { get; set; }
        public string? IMAGES { get; set; }
        public string? TEXT { get; set; }

        public virtual ICollection<Trip> Trips { get; set; }
    }
}
