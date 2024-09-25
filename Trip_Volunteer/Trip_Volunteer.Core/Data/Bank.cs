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

        public decimal BankId { get; set; }
        public string? FullName { get; set; }
        public string? CardNumber { get; set; }
        public decimal Balance { get; set; }
        public string Cvv { get; set; } = null!;
        public DateTime? ExpirationDate { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }
    }
}
