﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trip_Volunteer.Core.DTO
{
    public class ServiceTripDTO
    {
        public decimal Trip_Id { get; set; }
        public decimal? Service_Id { get; set; }
        public decimal? Service_Cost { get; set; }
        public string? Service_Name { get; set; }
    }
}
