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
    public class TripImageRepository : ITripImageRepository
    {

        private readonly IDbContext _dbContext;
        public TripImageRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<TripImage> GetAllTripImage()
        {
            IEnumerable<TripImage> result = _dbContext.Connection.Query<TripImage>("trip_image_Package.GetAlltrip_image", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public TripImage GetTripImageById(int ID)
        {
            var p = new DynamicParameters();
            p.Add("id", ID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<TripImage> result = _dbContext.Connection.Query<TripImage>("trip_image_Package.Gettrip_imageById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public List<TripImage> GetTripImageByTripId(int id)
        {
            var p = new DynamicParameters();
            p.Add("id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<TripImage> result = _dbContext.Connection.Query<TripImage>("trip_image_Package.GetTripImageByTripId",p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public void CreateTripImage(TripImage tripImage)
        {
            var p = new DynamicParameters();
            p.Add("trip_image_id", tripImage.Trip_Image_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("trip_id", tripImage.Trip_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("image_name", tripImage.Image_Name, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("trip_image_Package.CREATEtrip_image", p, commandType: CommandType.StoredProcedure);


        }

        public void UpdateTripImage(TripImage tripImage)
        {
            var p = new DynamicParameters();
            p.Add("tripimageid", tripImage.Trip_Image_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("tripid", tripImage.Trip_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("imagename", tripImage.Image_Name, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("trip_image_Package.UPDATEtrip_image", p, commandType: CommandType.StoredProcedure);

        }

        public void DeleteTripImage(int Id)
        {
            var p = new DynamicParameters();
            p.Add("Id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("trip_image_Package.Deletetrip_image", p, commandType: CommandType.StoredProcedure);

        }

    }
}
