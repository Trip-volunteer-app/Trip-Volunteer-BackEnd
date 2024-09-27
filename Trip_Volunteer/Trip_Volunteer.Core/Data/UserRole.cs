using System;
using System.Collections.Generic;

namespace Trip_Volunteer.Core.Data
{
    public partial class UserRole
    {
        public UserRole()
        {
            UserLogins = new HashSet<UserLogin>();
        }

        public decimal Role_Id { get; set; }
        public string Role_Name { get; set; } = null!;

        public virtual ICollection<UserLogin> UserLogins { get; set; }
    }
}
