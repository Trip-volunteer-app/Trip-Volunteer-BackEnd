using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Data;

namespace Trip_Volunteer.Core.Service
{
    public interface IcategoriesService
    {
        List<Category> GetAllcategories();
        Category GetcategoriesById(int ID);
        void CREATEcategories(Category category);

        void UPDATEcategories(Category category);

        void Deletecategories(int Id);
    }
}
