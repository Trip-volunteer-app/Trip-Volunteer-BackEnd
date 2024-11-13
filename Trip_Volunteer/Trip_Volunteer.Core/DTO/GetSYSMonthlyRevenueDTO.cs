using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trip_Volunteer.Core.DTO
{
    public class GetSYSMonthlyRevenueDTO
    {
        public decimal? month_year {  get; set; }
        public decimal? TOTAL_REVENUE { get; set; }
        public decimal? MONTHLY_REVENUE { get; set; }
        public decimal? COST { get; set; }

    }
}
