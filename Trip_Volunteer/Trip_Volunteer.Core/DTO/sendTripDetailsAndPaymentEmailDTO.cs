using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trip_Volunteer.Core.DTO
{
    public class sendTripDetailsAndPaymentEmailDTO
    {
        public string ReceiverEmail { get; set; }
        //public string Subject { get; set; }
        public string Body { get; set; }
    }
}
