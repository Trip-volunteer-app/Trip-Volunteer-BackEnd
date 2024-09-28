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
    public class HomePageElementsService : IHomePageElementsService
    {

        private readonly IHomePageElementsRepository _homePageElementsRepository;
        public HomePageElementsService(IHomePageElementsRepository homePageElementsRepository)
        {
            _homePageElementsRepository = homePageElementsRepository;
        }
        public List<HomePageElement> GetAllHomePageElements()
        {
            return _homePageElementsRepository.GetAllHomePageElements();
        }
        public HomePageElement GetHomePageElementById(int id)
        {
            return _homePageElementsRepository.GetHomePageElementById(id);
        }
        public void CreateHomePageElement(HomePageElement homePageElement)
        {
            _homePageElementsRepository.CreateHomePageElement(homePageElement);
        }
        public void UpdatHomePageElement(HomePageElement homePageElement)
        {
            _homePageElementsRepository.UpdatHomePageElement(homePageElement);
        }
        public void DeleteHomePageElement(int id)
        {
            _homePageElementsRepository.DeleteHomePageElement(id);
        }
    }
}
