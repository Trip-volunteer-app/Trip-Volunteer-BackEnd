using System;
using System.Collections.Generic;

namespace Trip_Volunteer.Core.Data
{
    public partial class Card
    {
        public decimal CardId { get; set; }
        public string? CardholderName { get; set; }
        public decimal? CardNumber { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public decimal? LoginId { get; set; }

        public virtual UserLogin? Login { get; set; }
    }
}
