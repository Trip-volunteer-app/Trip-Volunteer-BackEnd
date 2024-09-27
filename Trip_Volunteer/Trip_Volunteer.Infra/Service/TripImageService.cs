using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.Repository;
using Trip_Volunteer.Core.Service;

namespace Trip_Volunteer.Infra.Service
{
    public class TripImageService : ITripImageService
    {

        private readonly ITripImageRepository _tripImageRepository;
        public TripImageService(ITripImageRepository tripImageRepository)
        {
            _tripImageRepository = tripImageRepository;
        }

        public List<TripImage> GetAlltrip_image()
        {
            return _tripImageRepository.GetAlltrip_image();
        }


        public TripImage Gettrip_imageById(int ID)
        {
            return _tripImageRepository.Gettrip_imageById(ID);

        }


        public void CREATEtrip_image(TripImage tripImage)
        {
            _tripImageRepository.CREATEtrip_image(tripImage);

        }

        public void UPDATEtrip_image(TripImage tripImage)
        {
            _tripImageRepository.UPDATEtrip_image(tripImage);
        }

        public void Deletetrip_image(int Id)
        {
            _tripImageRepository.Deletetrip_image(Id);
        }


    }
}
