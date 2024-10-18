using System;
using System.Collections.Generic;

namespace Trip_Volunteer.Core.Data
{
    public partial class WebsiteInformation
    {
        public decimal Website_Id { get; set; }
        public string? Email { get; set; }
        public string? Phone_Number { get; set; }
        public string? Adress { get; set; }
        public string? Website_Link { get; set; }
        public string? Open_Time { get; set; }
        public int? Selected { get; set; }
        public string? Closing_Time { get; set; }
    }
}
