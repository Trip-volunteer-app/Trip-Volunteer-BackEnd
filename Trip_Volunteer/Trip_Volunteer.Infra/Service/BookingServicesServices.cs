using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Repository;
using Trip_Volunteer.Core.Service;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.DTO;


namespace Trip_Volunteer.Infra.Service
{
    public class BookingServicesServices : IBookingServicesServices
    {
        private readonly IBookingServiceRepository _BookingServiceRepository;
        public BookingServicesServices(IBookingServiceRepository bookingServiceRepository)
        {
            _BookingServiceRepository = bookingServiceRepository;
        }

        public List<BookingServices> GetAllBookingServices()
        {
            return _BookingServiceRepository.GetAllBookingServices();
        }
        public BookingServices GetBookingServiceById(int id)
        {
            return _BookingServiceRepository.GetBookingServiceById(id);
        }
        public List<BookingServicesDTO> GetBookingServiceByBookingId(int id)
        {
            return _BookingServiceRepository.GetBookingServiceByBookingId(id);
        }
        public void CreateBookingService(BookingServices bookingServices)
        {
            _BookingServiceRepository.CreateBookingService(bookingServices);
        }
        public void UpdateBookingService(BookingServices bookingServices)
        {
            _BookingServiceRepository.UpdateBookingService(bookingServices);
        }
        public void DeleteBookingService(int id)
        {
            _BookingServiceRepository.DeleteBookingService(id);
        }
    }
}
