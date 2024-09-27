using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Data;

namespace Trip_Volunteer.Core.Service
{
    public interface ITripImageService
    {
        List<TripImage> GetAlltrip_image();

        TripImage Gettrip_imageById(int ID);

        void CREATEtrip_image(TripImage tripImage);

        void UPDATEtrip_image(TripImage tripImage);

        void Deletetrip_image(int Id);
    }
}
