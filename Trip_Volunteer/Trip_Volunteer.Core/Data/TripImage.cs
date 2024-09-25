using System;
using System.Collections.Generic;

namespace Trip_Volunteer.Core.Data
{
    public partial class TripImage
    {
        public decimal TripImageId { get; set; }
        public decimal? TripId { get; set; }
        public string? ImageName { get; set; }

        public virtual Trip? Trip { get; set; }
    }
}
