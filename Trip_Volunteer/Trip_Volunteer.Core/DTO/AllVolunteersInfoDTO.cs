using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trip_Volunteer.Core.DTO
{
    public class AllVolunteersInfoDTO
    {

        public decimal Volunteer_Id { get; set; }
        public decimal? Login_Id { get; set; }
        public decimal? Trip_Id { get; set; }
        public decimal? Volunteer_Role_Id { get; set; }
        public string? Experience { get; set; }
        public decimal? Phone_Number { get; set; }
        public string? Email { get; set; }
        public string? Status { get; set; }
        public DateTime? Date_Applied { get; set; }
        public string? Notes { get; set; }
        public string? Emergency_Contact { get; set; }
        public string? Role_Name { get; set; }
        public string? Trip_Name { get; set; }


    }
}
