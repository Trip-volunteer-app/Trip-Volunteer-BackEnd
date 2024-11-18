using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trip_Volunteer.Core.DTO
{
    public class TripWithServicesListDTO
    {
        public List<ServiceDTO> SelectedServices { get; set; }
        public decimal? Trip_Id { get; set; }
    }
}
