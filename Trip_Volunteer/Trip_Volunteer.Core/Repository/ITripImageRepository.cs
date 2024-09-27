using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Data;

namespace Trip_Volunteer.Core.Repository
{
    public interface ITripImageRepository
    {
         List<TripImage> GetAlltrip_image();

         TripImage Gettrip_imageById(int ID);

         void CREATEtrip_image(TripImage tripImage);

         void UPDATEtrip_image(TripImage tripImage);

         void Deletetrip_image(int Id);
    }
}
