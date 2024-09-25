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

        public decimal RoleId { get; set; }
        public string RoleName { get; set; } = null!;

        public virtual ICollection<UserLogin> UserLogins { get; set; }
    }
}
