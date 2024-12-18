﻿using System;
using System.Collections.Generic;

namespace Trip_Volunteer.Core.Data
{
    public partial class HomePageElement
    {
        public decimal Home_Page_Id { get; set; }
        public string? Hero_Image { get; set; }
        public string? Title { get; set; }
        public string? Header { get; set; }
        public string? Text1 { get; set; }
        public string? Logo_Image { get; set; }
        public string? Logo_Text { get; set; }
        public int? Selected { get; set; }
    }
}
