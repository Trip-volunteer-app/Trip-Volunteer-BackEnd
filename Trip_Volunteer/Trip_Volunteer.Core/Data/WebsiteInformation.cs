using System;
using System.Collections.Generic;

namespace Trip_Volunteer.Core.Data
{
    public partial class WebsiteInformation
    {
        public decimal WebsiteId { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Adress { get; set; }
        public string? OpenTime { get; set; }
        public string? ClosingTime { get; set; }
    }
}
