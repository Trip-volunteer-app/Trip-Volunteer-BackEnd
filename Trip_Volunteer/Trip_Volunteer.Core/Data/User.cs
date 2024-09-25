using System;
using System.Collections.Generic;

namespace Trip_Volunteer.Core.Data
{
    public partial class User
    {
        public User()
        {
            UserLogins = new HashSet<UserLogin>();
        }

        public decimal UserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        public string? ImagePath { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? BirthDate { get; set; }

        public virtual ICollection<UserLogin> UserLogins { get; set; }
    }
}
