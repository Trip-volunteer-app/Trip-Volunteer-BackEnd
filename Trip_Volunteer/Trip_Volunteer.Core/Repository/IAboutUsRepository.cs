using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Data;

namespace Trip_Volunteer.Core.Repository
{
    public interface IAboutUsRepository
    {
        List<Aboutu> GetAllAboutUsElements();
        Aboutu GetAboutUsElementById(int id);
        void CreateAboutUsElements(Aboutu aboutus);
        void UpdateAboutUsElements(Aboutu aboutus);
        void DeleteAboutUsElements(int id);
        Aboutu GetSelectedAboutus();
        void UpdateSelectedAboutus(int id);
    }
}
