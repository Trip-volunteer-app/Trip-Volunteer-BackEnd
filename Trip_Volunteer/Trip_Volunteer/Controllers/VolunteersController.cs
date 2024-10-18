using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.DTO;
using Trip_Volunteer.Core.Service;

namespace Trip_Volunteer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VolunteersController : ControllerBase
    {
        private readonly IVolunteersService _volunteersService;
        public VolunteersController(IVolunteersService volunteersService)
        {
            _volunteersService = volunteersService;
        }

        [HttpGet]
        [Route("GetAllVolunteers")]
        public List<Volunteer> GetAllVolunteers()
        {
            return _volunteersService.GetAllVolunteers();
        }

        [HttpGet]
        [Route("GetVolunteerById/{id}")]
        public Volunteer GetVolunteerById(int id)
        {
            return _volunteersService.GetVolunteerById(id);
        }

        [HttpPost]
        [Route("CreateVolunteer")]
        public void CreateVolunteer(Volunteer volunteer)
        {
            _volunteersService.CreateVolunteer(volunteer);
        }

        [HttpPut]
        [Route("UpdateVolunteer")]
        public void UpdateVolunteer(Volunteer volunteer)
        {
            _volunteersService.UpdateVolunteer(volunteer);
        }

        [HttpDelete]
        [Route("DeleteVolunteer/{id}")]
        public void DeleteVolunteer(int id)
        {
            _volunteersService.DeleteVolunteer(id);
        }

        [HttpPut]
        [Route("UpdateVolunteerStatus/{id}/{status}")]
        public void UpdateVolunteerStatus(int id, string status)
        {
            _volunteersService.UpdateVolunteerStatus(id, status);
        }
        [HttpPost]
        [Route("Search")]
        public List<VolunteerSearchDto> SearchVolunteers(VolunteerSearchDto searchCriteria)
        {
            return _volunteersService.SearchVolunteers(searchCriteria);
        }

        [HttpPost]
        [Route("GetTripsByVolunteerName")]
        public List<Trip> GetTripsForVolunteerByName(string firstName, string lastName)
        {
            return _volunteersService.GetTripsForVolunteerByName(firstName, lastName);
        }


        [HttpPost("send-email")]
        public IActionResult SendEmail([FromBody] EmailRequest emailRequest)
        {
            try
            {
                // Set up the SMTP client
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("sajedaalquraan1@gmail.com", "bobf xqnl rsiq gmbe"),
                    EnableSsl = true,
                };

                // Compose the email
                var mailMessage = new MailMessage
                {
                    From = new MailAddress("sajedaalquraan1@gmail.com"),
                    Subject = $"Volunteer Application Status: {emailRequest.Status}",
                    Body = emailRequest.Status == "Accepted"
                        ? "Congratulations! Your volunteer application has been accepted. We are excited to welcome you to our team and look forward to the valuable contributions you will make. Together, we can make a meaningful impact, and we are excited to have you on this journey!.\r\nWe will be in touch with you shortly."
                        : "We regret to inform you that your volunteer application has been declined. While we appreciate your interest in volunteering, we are unable to accept you at this time. We encourage you to apply again in the future and wish you all the best in your endeavors",
                    IsBodyHtml = false,
                };

                // Send email to the user (assuming their email is in the request)
                mailMessage.To.Add(emailRequest.Email);

                // Send the email
                smtpClient.Send(mailMessage);

                return Ok("Email sent successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }

}


