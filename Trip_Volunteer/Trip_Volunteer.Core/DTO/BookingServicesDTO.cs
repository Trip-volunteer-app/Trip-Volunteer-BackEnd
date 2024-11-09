using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Data;

namespace Trip_Volunteer.Core.DTO
{
    public class BookingServicesDTO
    {
        public decimal Booking_Service_Id { get; set; }
        public decimal? Booking_Id { get; set; }
        public decimal? Service_Id { get; set; }
        public decimal? Service_Cost { get; set; }
        public string? Service_Name { get; set; }
        public virtual ICollection<Core.Data.Service>? Services { get; set; }
    }
}
