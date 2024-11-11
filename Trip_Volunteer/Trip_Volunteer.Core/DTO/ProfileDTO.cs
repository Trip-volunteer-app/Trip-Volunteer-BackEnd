using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Data;

namespace Trip_Volunteer.Core.DTO
{
    public class ProfileDTO
    {
        public decimal Login_Id { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public decimal? Role_Id { get; set; }
        public DateTime? Date_Register { get; set; }
        public decimal? User_Id { get; set; }
        public string Repassword { get; set; } = null!;

        public string First_Name { get; set; } = null!;
        public string? Last_Name { get; set; }
        public string? Image_Path { get; set; }
        public string? Address { get; set; }
        public string? Phone_Number { get; set; }
        public DateTime? Birth_Date { get; set; }
        public string Role_Name { get; set; } = null!;

        public List<BookingsDTO> Bookings { get; set; } = new List<BookingsDTO>();
        public List<AllVolunteerDTO> Volunteer { get; set; } = new List<AllVolunteerDTO>();


    }

    public class BookingsDTO
    {
        public decimal? Booking_Id { get; set; }
        public string? Payment_Status { get; set; }
        public decimal? Trip_Id { get; set; }
        public decimal? Login_Id { get; set; }
        public decimal? Total_Amount { get; set; }
        public DateTime? Create_At { get; set; }
        public string? Note { get; set; }
        public decimal? NumberOfUser { get; set; }
        public string? Trip_Name { get; set; }
        public decimal? Trip_Location_Id { get; set; }
        public decimal? Trip_Price { get; set; }
        public decimal? Max_Number_Of_Users { get; set; }
        public DateTime? Start_Date { get; set; }
        public DateTime? End_Date { get; set; }
        public string? Description { get; set; }

        public string? Departure_Location { get; set; }
        public string? Destination_Location { get; set; }
        public decimal? Max_Number_Of_Volunteers { get; set; }
        public decimal? Category_Id { get; set; }
        public List<ServiceBookingDTO> ServiceBooking { get; set; } = new List<ServiceBookingDTO>();

    }
    public class AllVolunteerDTO
    {
        public decimal Volunteer_Id { get; set; }
        public decimal? Login_Id { get; set; }
        public decimal? Trip_Id { get; set; }
        public decimal? Volunteer_Role_Id { get; set; }
        public string? Experience { get; set; }
        public decimal? Phone_Number { get; set; }
        public string? Email { get; set; }
        public string? Status { get; set; }
        public DateTime? Date_Applied { get; set; }
        public string? Notes { get; set; }
        public string? Emergency_Contact { get; set; }
        public string? Role_Name { get; set; }
        public string? Trip_Name { get; set; }
        public decimal? Trip_Location_Id { get; set; }
        public decimal? Trip_Price { get; set; }
        public decimal? Max_Number_Of_Users { get; set; }
        public DateTime? Start_Date { get; set; }
        public DateTime? End_Date { get; set; }
        public string? Description { get; set; }
        public string? Departure_Location { get; set; }
        public string? Destination_Location { get; set; }
        public decimal? Max_Number_Of_Volunteers { get; set; }
        public decimal? Category_Id { get; set; }
        public List<VolanteerRoleBookingDTO> VolanteerRoleBooking { get; set; } = new List<VolanteerRoleBookingDTO>();

    }
    public class ServiceBookingDTO
    {
        public decimal? Booking_Id { get; set; }
        public decimal? Trip_Id { get; set; }

        public decimal? Service_Id { get; set; }
        public decimal? Service_Cost { get; set; }
        public string? Service_Name { get; set; }
    }

    public class VolanteerRoleBookingDTO
    {
        public decimal? Trip_Id { get; set; }
        public decimal? Volunteer_Role_Id { get; set; }
        public string? Role_Name { get; set; }


    }

}
