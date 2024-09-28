using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Data;

namespace Trip_Volunteer.Core.Service
{
    public interface IHomePageElementsService
    {
        List<HomePageElement> GetAllHomePageElements();
        HomePageElement GetHomePageElementById(int id);
        void CreateHomePageElement(HomePageElement homePageElement);
        void UpdatHomePageElement(HomePageElement homePageElement);
        void DeleteHomePageElement(int id);
    }
}
