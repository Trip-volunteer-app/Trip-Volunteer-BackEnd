﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trip_Volunteer.Core.DTO
{
    public class TripWithVolunteerRolesDTO
    {
        public List<VolunteerRoleDto> SelectedVolunteerRoles { get; set; }

        public decimal? Trip_Id { get; set; }
    }
}
