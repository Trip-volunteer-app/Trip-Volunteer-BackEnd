using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trip_Volunteer.Core.DTO
{
    public class SendEmailBookingDTO
    {

        public string Email { get; set; }
        public string Status { get; set; }
        public string? Trip_Name { get; set; }

        public string? Departure_Location { get; set; }
        public string? Destination_Location { get; set; }
        public string? Start_Date { get; set; }
        public string? End_Date { get; set; }
        public List<Core.Data.Service> Services { get; set; } = new List<Core.Data.Service>();

    }
}
