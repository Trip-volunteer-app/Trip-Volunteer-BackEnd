using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trip_Volunteer.Core.DTO
{
    public class MonthlyReportDTO
    {
        public string month_year { get; set; }
        public decimal cost { get; set; }
        public decimal total_revenue { get; set; }

        public decimal monthly_revenue { get; set; }

    }

}
