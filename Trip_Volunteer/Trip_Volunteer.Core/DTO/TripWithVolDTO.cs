using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trip_Volunteer.Core.DTO
{
    public class TripWithVolDTO
    {
        public decimal Trip_Id { get; set; }
        public string? Trip_Name { get; set; }
        public decimal? Trip_Price { get; set; }
        public decimal? Max_Number_Of_Users { get; set; }
        public DateTime? Start_Date { get; set; }
        public DateTime? End_Date { get; set; }
        public string? Description { get; set; }
        public decimal? Max_Number_Of_Volunteers { get; set; }
        public decimal User_Id { get; set; }
        public string? Email { get; set; }
        public string? First_Name { get; set; }
        public string? Last_Name { get; set; }
        public string? Address { get; set; }
        public string? Phone_Number { get; set; }
        public string? Role_Name { get; set; }

    }
}
