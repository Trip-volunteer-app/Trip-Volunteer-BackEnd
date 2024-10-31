using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trip_Volunteer.Core.DTO
{
    public class GetUserPaymentsForTripDTO
    {

        public int payment_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string image_path { get; set; }
        public string address { get; set; }
        public string phone_number { get; set; }
        public DateTime birth_date { get; set; }
        public string email { get; set; }
        public DateTime date_register { get; set; }
        
        
    }
}






