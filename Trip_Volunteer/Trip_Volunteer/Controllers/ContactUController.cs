using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net.Mail;
using System.Net;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.DTO;
using Trip_Volunteer.Core.Service;
using Trip_Volunteer.Infra.Service;

namespace Trip_Volunteer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactUController : ControllerBase
    {
        private readonly IContactUsService _contactUsService;

        public ContactUController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }


        [HttpGet]
        [CheckClaimsAttribute("Roleid", "1")]
        public List<ContactU> GetAllContacts()
        {
            return _contactUsService.GetAllContacts();

        }

        [HttpGet]
        [Route("GetContactById/{contactId}")]
        public ContactU GetContactById(int contactId)
        {
            return _contactUsService.GetContactById(contactId);
        }

        [HttpPost]
        [Route("CreateContact")]
        public void CreateContact(ContactU contact)
        {
            _contactUsService.CreateContact(contact);
        }

        [HttpPut]
        [Route("UpdateContact")]
        [CheckClaimsAttribute("Roleid", "1")]
        public void UpdateContact(ContactU contact)
        {
            _contactUsService.UpdateContact(contact);
        }

        [HttpDelete]
        [Route("DeleteContact/{contactId}")]
        [CheckClaimsAttribute("Roleid", "1")]
        public void DeleteContact(int contactId)
        {
            _contactUsService.DeleteContact(contactId);
        }


        [HttpPost("send-email")]
        public IActionResult SendEmail([FromBody] EmailContactRequest emailRequest)
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
                    Subject = "Contact Us ",

                    Body = "Thank you for reaching out to us! We have received your message and appreciate you taking the time to contact us.\n One of our team members will review your query and get back to you shortly.",

                    IsBodyHtml = false,
                };

                // Send email to the user (assuming their email is in the request)
                mailMessage.To.Add(emailRequest.email);

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
