using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trip_Volunteer.Core.DTO
{
    public class VolunteerSearchDto
    {
        public int? Volunteer_Id { get; set; }
        public string? First_Name { get; set; } = null!;
        public string? Last_Name { get; set; }
        public int? Login_Id { get; set; }
        public int? Trip_Id { get; set; }
        public string? Experience { get; set; }
        public string? Phone_Number { get; set; }
        public string? Email { get; set; }
        public string? Status { get; set; }
        public DateTime? Date_Applied { get; set; }
        public string? Notes { get; set; }
        public string? Emergency_Contact { get; set; }
        public string? Trip_Name { get; set; }
        public string? Role_Name { get; set; }

    }
}
