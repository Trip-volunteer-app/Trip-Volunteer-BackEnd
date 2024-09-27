using System;
using System.Collections.Generic;

namespace Trip_Volunteer.Core.Data
{
    public partial class Bank
    {
        public Bank()
        {
            Payments = new HashSet<Payment>();
        }

        public decimal Bank_Id { get; set; }
        public string? Full_Name { get; set; }
        public string? Card_Number { get; set; }
        public decimal Balance { get; set; }
        public string Cvv { get; set; } = null!;
        public DateTime? Expiration_Date { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }
    }
}
