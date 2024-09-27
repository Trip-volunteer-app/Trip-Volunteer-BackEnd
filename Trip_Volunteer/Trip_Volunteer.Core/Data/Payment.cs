using System;
using System.Collections.Generic;

namespace Trip_Volunteer.Core.Data
{
    public partial class Payment
    {
        public int Payment_Id { get; set; }
        public decimal? Price { get; set; }
        public decimal? Trip_Id { get; set; }
        public decimal? Login_Id { get; set; }
        public decimal? Bank_Id { get; set; }
        public DateTime? Create_At { get; set; }

        public virtual Bank? Bank { get; set; }
        public virtual UserLogin? Login { get; set; }
        public virtual Trip? Trip { get; set; }
    }
}
