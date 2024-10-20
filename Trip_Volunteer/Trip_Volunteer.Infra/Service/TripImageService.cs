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

        public List<TripImage> GetAllTripImage()
        {
            return _tripImageRepository.GetAllTripImage();
        }


        public TripImage GetTripImageById(int ID)
        {
            return _tripImageRepository.GetTripImageById(ID);

        }
        public List<TripImage> GetTripImageByTripId(int id)
        {
            return _tripImageRepository.GetTripImageByTripId(id);
        }


        public void CreateTripImage(TripImage tripImage)
        {
            _tripImageRepository.CreateTripImage(tripImage);

        }

        public void UpdateTripImage(TripImage tripImage)
        {
            _tripImageRepository.UpdateTripImage(tripImage);
        }

        public void DeleteTripImage(int Id)
        {
            _tripImageRepository.DeleteTripImage(Id);
        }


    }
}
