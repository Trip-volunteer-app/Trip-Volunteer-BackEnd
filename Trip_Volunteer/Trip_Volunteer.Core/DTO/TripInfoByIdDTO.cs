using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Data;

namespace Trip_Volunteer.Core.DTO
{
    public class TripInfoByIdDTO
    {

        public decimal? Trip_Id { get; set; }
        public string? Trip_Name { get; set; }
        public decimal? Trip_Location_Id { get; set; }
        public decimal? Trip_Price { get; set; }
        public decimal? Max_Number_Of_Users { get; set; }
        public DateTime? Start_Date { get; set; }
        public DateTime? End_Date { get; set; }
        public string? Description { get; set; }
        public decimal? Max_Number_Of_Volunteers { get; set; }
        public decimal? Category_Id { get; set; }
        public decimal? Location_Id { get; set; }
        public string? Departure_Location { get; set; }
        public string? Destination_Location { get; set; }
        public decimal? Cat_Id { get; set; }
        public string? Category_Name { get; set; }

        // Add collections for images and services
        public List<TripImage> Images { get; set; } = new List<TripImage>();
        public List<Core.Data.Service> Services { get; set; } = new List<Core.Data.Service>();
        public List<TripService> TripService { get; set; } = new List<TripService>();
    }
}
