using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trip_Volunteer.Core.DTO
{
    public class BookingDTO
    {
        public decimal Booking_Id { get; set; }
        public string? Payment_Status { get; set; }
        public decimal? Trip_Id { get; set; }
        public decimal? Login_Id { get; set; }
        public decimal? Total_Amount { get; set; }
        public DateTime? Create_At { get; set; }
        public string? Note { get; set; }

        public decimal? NumberOfUser { get; set; }
        public int[]? ArrayParam { get; set; }

    }
}
