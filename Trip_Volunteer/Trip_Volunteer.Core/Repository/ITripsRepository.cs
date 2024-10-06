using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Data;

namespace Trip_Volunteer.Core.Repository
{
    public interface ITripsRepository
    {
         List<Trip> GetAlltrips();
         Trip GettripsById(int ID);

         void CREATEtrips(Trip trip);

         void UPDATEtrips(Trip trip);

         void Deletetrips(int Id);

        List<Trip> searchBetweendate(DateTime Start_Date, DateTime End_Date);

        int NumberOfTrips();

        List<Trip> TripsWithMaxReservations();
    }
}
