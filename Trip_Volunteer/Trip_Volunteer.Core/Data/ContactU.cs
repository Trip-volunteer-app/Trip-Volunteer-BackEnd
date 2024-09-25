using System;
using System.Collections.Generic;

namespace Trip_Volunteer.Core.Data
{
    public partial class ContactU
    {
        public decimal ContactId { get; set; }
        public string? Query { get; set; }
        public string? Messages { get; set; }
        public string? Email { get; set; }
        public string? FullName { get; set; }
    }
}
