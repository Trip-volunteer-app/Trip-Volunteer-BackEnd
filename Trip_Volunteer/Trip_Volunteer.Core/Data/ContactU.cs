using System;
using System.Collections.Generic;

namespace Trip_Volunteer.Core.Data
{
    public partial class ContactU
    {
        public decimal Contact_Id { get; set; }
        public string? Query { get; set; }
        public string? Messages { get; set; }
        public string? Email { get; set; }
        public string? Full_Name { get; set; }
    }
}
