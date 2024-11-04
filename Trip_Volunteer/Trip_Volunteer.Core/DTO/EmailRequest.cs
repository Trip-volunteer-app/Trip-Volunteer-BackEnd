using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Data;

namespace Trip_Volunteer.Core.DTO
{
    public class EmailRequest
    {
        public string Email { get; set; }
        public string Status { get; set; }
        public string? Trip_Name { get; set; }

        public string? Departure_Location { get; set; }
        public string? Destination_Location { get; set; }
        public DateTime? Start_Date { get; set; }
        public DateTime? End_Date { get; set; }
        public List<Core.Data.Service> Services { get; set; } = new List<Core.Data.Service>();


    }
}
