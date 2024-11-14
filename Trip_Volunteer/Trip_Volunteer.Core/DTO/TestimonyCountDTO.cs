using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trip_Volunteer.Core.DTO
{
    public class TestimonyCountDTO
    {
        public int Rejected_Count { get; set; }
        public int Accepted_Count { get; set; }
        public int Pending_Count { get; set; }
        public int Total_Count { get; set; }
    }
}
