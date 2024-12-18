﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.DTO;

namespace Trip_Volunteer.Core.Repository
{
    public interface ITripVolunteerroleRepository
    {

         List<TripVolunteerrole> GetAlltrip_volunteerRoles();
         TripVolunteerrole Gettrip_volunteerRolesById(int id);

         void CREATEtrip_volunteerRoles(TripVolunteerrole tripVolunteerrole);

         void UPDATEtrip_volunteerRoles(TripVolunteerrole tripVolunteerrole);

         void Deletetrip_volunteerRoles(int id);

         List<VolunteerRoleDTO> GetVolunteerRoleByTripId(int id);

        void CreateTripVRoleForVRolesList(TripWithVolunteerRolesDTO tripWithVolunteerRoles);
        void DeleteTripVolunteerRoleForATrip(int tripId, int vRoleId);
        void UpdateTrip_vrole_NumberOfVolunteers(TripVolunteerrole tripVolunteerrole);


        void updateNumberOfVolunteer(TripVolunteerrole tripVolunteerrole);


    }
}
