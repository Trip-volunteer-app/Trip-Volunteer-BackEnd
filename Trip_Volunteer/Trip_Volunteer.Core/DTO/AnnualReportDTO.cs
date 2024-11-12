using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trip_Volunteer.Core.DTO
{
    public class AnnualReportDTO
    {
        public string Year { get; set; }
        public string Month { get; set; }
        public decimal Cost { get; set; }
        public decimal Total_Revenue { get; set; }
        public decimal Net_Revenue { get; set; }

    }
}
