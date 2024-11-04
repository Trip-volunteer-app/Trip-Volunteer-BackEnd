using System;
using System.Collections.Generic;

namespace Trip_Volunteer.Core.Data
{
    public partial class Card
    {
        public decimal Card_Id { get; set; }
        public string? Cardholder_Name { get; set; }
        public string? Card_Number { get; set; }
        public string? Expiry_Date { get; set; }
        public decimal? Login_Id { get; set; }

        public virtual UserLogin? Login { get; set; }
    }
}
