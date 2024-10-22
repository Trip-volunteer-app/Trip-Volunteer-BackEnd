using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.Repository;
using Trip_Volunteer.Core.Service;
using Trip_Volunteer.Infra.Repository;

namespace Trip_Volunteer.Infra.Service
{
    public class AboutUsService : IAboutUsService
    {

        private readonly IAboutUsRepository _aboutUsRepository;
        public AboutUsService(IAboutUsRepository aboutUsRepository)
        {
            _aboutUsRepository = aboutUsRepository;
        }
        public List<Aboutu> GetAllAboutUsElements()
        {
            return _aboutUsRepository.GetAllAboutUsElements();
        }
        public Aboutu GetAboutUsElementById(int id)
        {
            return _aboutUsRepository.GetAboutUsElementById(id);
        }
        public void CreateAboutUsElements(Aboutu aboutus)
        {
            _aboutUsRepository.CreateAboutUsElements(aboutus);
        }
        public void UpdateAboutUsElements(Aboutu aboutus)
        {
            _aboutUsRepository.UpdateAboutUsElements(aboutus);
        }
        public void DeleteAboutUsElements(int id)
        {
            _aboutUsRepository.DeleteAboutUsElements(id);
        }
        public Aboutu GetSelectedAboutus()
        {
            return _aboutUsRepository.GetSelectedAboutus();

        }
        public void UpdateSelectedAboutus(int id)
        {
            _aboutUsRepository.UpdateSelectedAboutus(id);
        }
    }
}
