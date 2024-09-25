using System;
using System.Collections.Generic;

namespace Trip_Volunteer.Core.Data
{
    public partial class Payment
    {
        public decimal PaymentId { get; set; }
        public decimal? Price { get; set; }
        public decimal? TripId { get; set; }
        public decimal? LoginId { get; set; }
        public decimal? BankId { get; set; }
        public DateTime? CreateAt { get; set; }

        public virtual Bank? Bank { get; set; }
        public virtual UserLogin? Login { get; set; }
        public virtual Trip? Trip { get; set; }
    }
}
