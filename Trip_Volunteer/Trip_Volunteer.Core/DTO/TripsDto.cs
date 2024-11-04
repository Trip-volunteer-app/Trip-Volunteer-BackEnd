using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trip_Volunteer.Core.DTO
{
    public class TripsDto
    {
        public string? Trip_Name { get; set; }
        public decimal? Trip_Price { get; set; }
        public decimal? Max_Number_Of_Users { get; set; }
        public DateTime? Start_Date { get; set; }
        public DateTime? End_Date { get; set; }
        public string? Description { get; set; }
        public decimal? Max_Number_Of_Volunteers { get; set; }
        public decimal? Category_Id { get; set; }
        public string? Image_Name { get; set; }
        public List<int> SelectedServices { get; set; }
        public string? Departure_Location { get; set; }
        public string? Destination_Location { get; set; }
        public decimal? Departure_Latitude { get; set; }
        public decimal? Departure_Longitude { get; set; }
        public decimal? Destination_Latitude { get; set; }
        public decimal? Destination_Longitude { get; set; }

    }
}
