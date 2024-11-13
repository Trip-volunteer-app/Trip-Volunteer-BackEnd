using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trip_Volunteer.Core.DTO
{
    public class AuthDTO
    {
        public decimal Login_Id { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public decimal? Role_Id { get; set; }
        public decimal? User_Id { get; set; }
        public string Repassword { get; set; } = null!;
        public string RecaptchaResponse { get; set; } = null!;
    }
}
