using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trip_Volunteer.Core.DTO
{
    public class ProfileDTO
    {
        public decimal Login_Id { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public decimal? Role_Id { get; set; }
        public DateTime? Date_Register { get; set; }
        public decimal? User_Id { get; set; }
        public string Repassword { get; set; } = null!;

        public string First_Name { get; set; } = null!;
        public string? Last_Name { get; set; }
        public string? Image_Path { get; set; }
        public string? Address { get; set; }
        public string? Phone_Number { get; set; }
        public DateTime? Birth_Date { get; set; }
        public string Role_Name { get; set; } = null!;


    }
}
