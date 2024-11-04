using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trip_Volunteer.Core.DTO
{
    public class LocationDTO
    {
        public decimal Location_Id { get; set; }
        public string? Departure_Location { get; set; }
        public string? Destination_Location { get; set; }
        public decimal? Destination_Latitude { get; set; }
        public decimal? Destination_Longitude { get; set; }
        public decimal Trip_Id { get; set; }
        public string? Trip_Name { get; set; }
        public decimal? Trip_Price { get; set; }
    }
}
