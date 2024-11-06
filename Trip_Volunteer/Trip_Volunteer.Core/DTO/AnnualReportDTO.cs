using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trip_Volunteer.Core.DTO
{
    public class AnnualReportDTO
    {
        public DateTime trip_year { get; set; }  
        public decimal TOTAL_SERVICE_COST { get; set; }
        public decimal TOTAL_REVENUE { get; set; }

        public decimal NET_REVENUE { get; set; }

    }
}
