using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trip_Volunteer.Core.DTO
{
    public class TotalUsersPerCategoryDTO
    {
        public decimal Category_Id { get; set; }
        public string? Category_Name { get; set; }
        public int? total_users { get; set; }
    }
}
