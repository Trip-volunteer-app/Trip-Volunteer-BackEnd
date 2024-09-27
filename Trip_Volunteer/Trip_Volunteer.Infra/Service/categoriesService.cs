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

namespace Trip_Volunteer.Infra.Service
{
    public class categoriesService : IcategoriesService
    {
        private readonly IcategoriesRepository _categoriesRepository;
        public categoriesService(IcategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        public List<Category> GetAllcategories()
        {
            return _categoriesRepository.GetAllcategories();
        }


        public Category GetcategoriesById(int ID)
        {
            return _categoriesRepository.GetcategoriesById(ID);
            
        }


        public void CREATEcategories(Category category)
        {
            _categoriesRepository.CREATEcategories(category);

        }

        public void UPDATEcategories(Category category)
        {
           _categoriesRepository.UPDATEcategories(category);
        }

        public void Deletecategories(int Id)
        {
            _categoriesRepository.Deletecategories(Id);
        }


    }
}
