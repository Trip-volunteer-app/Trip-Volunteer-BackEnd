using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Data;

namespace Trip_Volunteer.Core.Repository
{
    public interface IcategoriesRepository
    {

        List<Category> GetAllcategories();

         Category GetcategoriesById(int ID);
       
        void CREATEcategories(Category category);

         void UPDATEcategories(Category category);

         void Deletecategories(int Id);
    }
}
