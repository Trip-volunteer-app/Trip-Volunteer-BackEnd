using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trip_Volunteer.Core.DTO
{
    public class VolunteerRoleDTO
    {
        public decimal? Trip_Id { get; set; }
        public decimal? Volunteer_Role_Id { get; set; }
        public string? Role_Name { get; set; }
        public int? Number_Of_Volunteers { get; set; }
        public decimal? Trip_Volunteerroles_Id { get; set; }

    }
}
