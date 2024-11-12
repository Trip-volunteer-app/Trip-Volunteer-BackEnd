using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trip_Volunteer.Core.DTO
{
    public class ReviewDTO
    {
        public decimal Review_Id { get; set; }
        public decimal? Rate { get; set; }
        public string? Feedback { get; set; }
        public decimal? Booking_Id { get; set; }
        public DateTime? Create_At { get; set; }
        public decimal? Volunteer_Id { get; set; }
        public decimal Trip_Id { get; set; }
        public string? Trip_Name { get; set; }
        public decimal? Trip_Location_Id { get; set; }
        public decimal? Trip_Price { get; set; }
        public decimal? Max_Number_Of_Users { get; set; }
        public DateTime? Start_Date { get; set; }
        public DateTime? End_Date { get; set; }
        public string? Description { get; set; }
        public decimal? Max_Number_Of_Volunteers { get; set; }
        public decimal? Category_Id { get; set; }
        public string? Category_Name { get; set; }
        public string? Payment_Status { get; set; }
        public decimal? Login_Id { get; set; }
        public string First_Name { get; set; } = null!;
        public string? Last_Name { get; set; }
        public string? Image_Path { get; set; }
    }
}
