using System;
using System.Collections.Generic;

namespace Trip_Volunteer.Core.Data
{
    public partial class TripImage
    {
        public decimal Trip_Image_Id { get; set; }
        public decimal? Trip_Id { get; set; }
        public string? Image_Name { get; set; }

        public virtual Trip? Trip { get; set; }
    }
}
