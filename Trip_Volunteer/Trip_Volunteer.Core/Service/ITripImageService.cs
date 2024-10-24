﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Data;

namespace Trip_Volunteer.Core.Service
{
    public interface ITripImageService
    {
        List<TripImage> GetAllTripImage();

        TripImage GetTripImageById(int ID);

        List<TripImage> GetTripImageByTripId(int id);
        void CreateTripImage(TripImage tripImage);

        void UpdateTripImage(TripImage tripImage);

        void DeleteTripImage(int Id);
    }
}
