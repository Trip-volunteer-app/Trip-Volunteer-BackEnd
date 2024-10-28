using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Data;

namespace Trip_Volunteer.Core.Repository
{
    public interface IHomePageElementsRepository
    {
        List<HomePageElement> GetAllHomePageElements();
        HomePageElement GetHomePageElementById(int id);
        void CreateHomePageElement(HomePageElement homePageElement);
        void UpdatHomePageElement(HomePageElement homePageElement);
        void DeleteHomePageElement(int id);
        void UpdateHomeSelectStatus(int id);
        HomePageElement GetSelectedHomeElement();
    }
}
