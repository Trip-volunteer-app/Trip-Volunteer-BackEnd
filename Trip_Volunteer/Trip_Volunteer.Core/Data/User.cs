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

        public decimal User_Id { get; set; }
        public string First_Name { get; set; } = null!;
        public string? Last_Name { get; set; }
        public string? Image_Path { get; set; }
        public string? Address { get; set; }
        public string? Phone_Number { get; set; }
        public DateTime? Birth_Date { get; set; }

        public virtual ICollection<UserLogin> UserLogins { get; set; }
    }
}
