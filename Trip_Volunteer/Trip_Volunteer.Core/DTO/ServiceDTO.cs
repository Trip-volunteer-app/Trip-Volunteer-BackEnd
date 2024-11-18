using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trip_Volunteer.Core.DTO
{
    public class ServiceDTO
    {
        public decimal? Trip_Id { get; set; }
        public string? Trip_Name { get; set; }
        public decimal? Service_Id { get; set; }
        public string? Service_Name { get; set; }
        public decimal? Service_Cost { get; set; }
        public int? Is_Optional { get; set; }
    }
}