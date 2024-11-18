using System;
using System.Collections.Generic;
using Trip_Volunteer.Core.Service;
namespace Trip_Volunteer.Core.Data
{
    public partial class TripService
    {
        public decimal Trip_Service_Id { get; set; }
        public decimal? Service_Id { get; set; }
        public decimal? Trip_Id { get; set; }
        public int? Is_Optional { get; set; }

        public virtual Service? Service { get; set; }
        public virtual Trip? Trip { get; set; }
    }
}
