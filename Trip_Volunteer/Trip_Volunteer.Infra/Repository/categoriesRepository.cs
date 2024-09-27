using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Common;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.Repository;

namespace Trip_Volunteer.Infra.Repository
{
    public class categoriesRepository : IcategoriesRepository
    {

        private readonly IDbContext _dbContext;
        public categoriesRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Category> GetAllcategories()
        {
            IEnumerable<Category> result = _dbContext.Connection.Query<Category>("categories_Package.GetAllcategories", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Category GetcategoriesById(int ID)
        {
            var p = new DynamicParameters();
            p.Add("id", ID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Category> result = _dbContext.Connection.Query<Category>("categories_Package.GetcategoriesById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void CREATEcategories(Category category)
        {
            var p = new DynamicParameters();
            p.Add("category_id", category.Category_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("category_name", category.Category_Name, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("categories_Package.CREATEcategories", p, commandType: CommandType.StoredProcedure);


        }

        public void UPDATEcategories(Category category)
        {
            var p = new DynamicParameters();
            p.Add("categoryid", category.Category_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("categoryname", category.Category_Name, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("categories_Package.UPDATEcategories", p, commandType: CommandType.StoredProcedure);

        }

        public void Deletecategories(int Id)
        {
            var p = new DynamicParameters();
            p.Add("Id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("categories_Package.Deletecategories", p, commandType: CommandType.StoredProcedure);

        }
    }
}
