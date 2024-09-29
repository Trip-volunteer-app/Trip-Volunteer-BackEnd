using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Data;

namespace Trip_Volunteer.Core.Service
{
    public interface ITripsService
    {
        List<Trip> GetAlltrips();
        Trip GettripsById(int ID);

        void CREATEtrips(Trip trip);

        void UPDATEtrips(Trip trip);

        void Deletetrips(int Id);

        int NumberOfTrips();

        List<Trip> TripsWithMaxReservations();
    }
}
