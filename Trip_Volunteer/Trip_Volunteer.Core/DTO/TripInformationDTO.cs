using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trip_Volunteer.Core.DTO
{
    public class TripInformationDTO
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
        public decimal Trip_Image_Id { get; set; }
        public decimal i_trip_id { get; set; }
        public string? Image_Name { get; set; }
        public decimal? Location_Id { get; set; }
        public string? Departure_Location { get; set; }
        public string? Destination_Location { get; set; }
        public decimal? Trip_Service_Id { get; set; }
        public decimal? TS_SERVICE_ID { get; set; }
        public decimal? Ts_trip_id { get; set; }
        public decimal? Service_Id { get; set; }
        public string? Service_Name { get; set; }
        public decimal? Service_Cost { get; set; }
        public decimal? Cat_Id { get; set; }
        public string? Category_Name { get; set; }

    }
}
