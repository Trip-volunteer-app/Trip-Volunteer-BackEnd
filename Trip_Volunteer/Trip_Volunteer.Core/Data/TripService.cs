using System;
using System.Collections.Generic;
using Trip_Volunteer.Core.Service;
namespace Trip_Volunteer.Core.Data
{
    public partial class TripService
    {
        public decimal TripServiceId { get; set; }
        public decimal? ServiceId { get; set; }
        public decimal? TripId { get; set; }

        public virtual Core.Service? Service { get; set; }
        public virtual Trip? Trip { get; set; }
    }
}
