using System;
using System.Collections.Generic;

namespace Trip_Volunteer.Core.Data
{
    public partial class Stdcourse
    {
        public decimal Id { get; set; }
        public decimal? Stdid { get; set; }
        public decimal? Courseid { get; set; }
        public decimal? Markofstd { get; set; }
        public DateTime? Dateofregister { get; set; }

        public virtual Course? Course { get; set; }
        public virtual Student? Std { get; set; }
    }
}
