using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Data;

namespace Trip_Volunteer.Core.Repository
{
    public interface ILocationRepository
    {

        List<Location> GetAlllocation();
        Location GetlocationById(int id);
        void CREATElocation(Location location);
        void UPDATElocation(Location location);
        void Deletelocation(int Id);
        
    }
}
