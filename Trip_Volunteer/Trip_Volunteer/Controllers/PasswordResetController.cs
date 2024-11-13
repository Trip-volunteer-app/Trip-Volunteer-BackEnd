using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using Trip_Volunteer.Core.DTO;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.Repository;
using Trip_Volunteer.Core.Service;

namespace Trip_Volunteer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordResetController : ControllerBase
    {
        private readonly IUserLoginService _userLoginService;
        public PasswordResetController(IUserLoginService userLoginService)
        {
            _userLoginService = userLoginService;
        }

        [HttpPost("send-reset-email")]
        public async Task<IActionResult> SendResetEmail([FromBody] ForgotPasswordRequest model)
        {
            if (string.IsNullOrEmpty(model.Email))
            {
                return BadRequest("Email is required");
            }

            // Generate a random 6-digit code
            var verificationCode = GenerateVerificationCode();

            // Send the email with the 6-digit code
            var emailSent = await SendEmailAsync(model.Email, verificationCode);

            if (!emailSent)
            {
                return StatusCode(500, "Error sending email");
            }

            // Return the verification code in the response for client-side validation
            return Ok(new { message = "Verification code sent successfully", verificationCode });
        }


       

        private string GenerateVerificationCode()
        {
            return new Random().Next(100000, 999999).ToString();
        }

        private async Task<bool> SendEmailAsync(string email, string verificationCode)
        {
            try
            {
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("sajedaalquraan1@gmail.com", "bobf xqnl rsiq gmbe"),
                    EnableSsl = true,
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress("sajedaalquraan1@gmail.com"),
                    Subject = "Password Reset Verification Code",
                    Body = $"Your verification code is: {verificationCode}",
                    IsBodyHtml = false,
                };
                mailMessage.To.Add(email);

                await smtpClient.SendMailAsync(mailMessage);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
                return false;
            }
        }






    }



}






