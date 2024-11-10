using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;
using System.Net.Mail;
using System.Net;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.DTO;
using Trip_Volunteer.Core.Repository;
using Trip_Volunteer.Core.Service;
using Trip_Volunteer.Infra.Repository;
using System.Reflection.Metadata;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Kernel.Exceptions;
using iText.StyledXmlParser.Jsoup.Nodes;
using System.Text;
namespace Trip_Volunteer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        private readonly ITripsService _tripsService;
        public TripsController(ITripsService tripsService, IConfiguration configuration)
        {
            _tripsService = tripsService;
            _configuration = configuration;
        }

        [HttpGet]
        [Route("GetAllTrips")]
        public List<Trip> GetAllTrips()
        {
            return _tripsService.GetAllTrips();
        }

        [HttpGet]
        [Route("GetTripById/{id}")]

        //[CheckClaimsAttribute("Roleid", "1")]
        public Trip GetTripById(int id)
        {
            return _tripsService.GetTripById(id);
        }

        [HttpPost]
        [Route("CreateTrip")]
        //[CheckClaimsAttribute("Roleid", "1")]
        public void CreateTrip(TripsDto trip)
        {
            _tripsService.CreateTrip(trip);
        }

        [HttpPut]
        [Route("UpdateTrip")]
        [CheckClaimsAttribute("Roleid", "1")]
        public void UpdateTrip(Trip trip)
        {
            _tripsService.UpdateTrip(trip);
        }

        [HttpDelete]
        [Route("DeleteTrip/{id}")]
        //[CheckClaimsAttribute("Roleid", "1")]
        public void DeleteTrip(int id)
        {
            _tripsService.DeleteTrip(id);
        }

        //[HttpGet]
        //[Route("SearchBetweenDate")]
        //public List<Trip> SearchBetweenDate(DateTime Start_Date,DateTime End_Date)
        //{
        //    return _tripsService.SearchBetweenDate(Start_Date, End_Date);
        //}

        [HttpGet("trips/GetNumberOfTrips")]
        [CheckClaimsAttribute("Roleid", "1")]
        public IActionResult GetNumberOfTrips()
        {
            int numberOfTrips = _tripsService.NumberOfTrips();
            return Ok(numberOfTrips);
        }

        [HttpGet]
        [Route("TripsWithMaxReservations")]
        [CheckClaimsAttribute("Roleid", "1")]
        public List<Trip> TripsWithMaxReservations()
        {
            return _tripsService.TripsWithMaxReservations();
        }

        [HttpGet]
        [Route("GetAllTripInformation")]
        public Task<List<TripInfoByIdDTO>> GetAllTripInformation()
        {
            return _tripsService.GetAllTripInformation();
        }

        [HttpGet]
        [Route("GetAllTripInformationById")]
        /*        [CheckClaimsAttribute("Roleid", "1")]
        */
        public TripInfoByIdDTO GetAllTripInformationById(int Id)
        {
            return _tripsService.GetAllTripInformationById(Id);
        }

        [HttpGet]
        [CheckClaimsAttribute("Roleid", "1")]
        [Route("GetTripVolById/{id}")]
        public TripWithVolDTO GetTripVolById(int Id)
        {
            return _tripsService.GetTripVolById(Id);
        }

        [HttpGet]
        [Route("GetTripUsersById")]
        [CheckClaimsAttribute("Roleid", "1")]
        public TripWithVolDTO GetTripUsersById(int Id)
        {
            return _tripsService.GetTripUsersById(Id);
        }

        [HttpGet]
        [Route("GetVolunteerUserInfoByTripId/{ID}")]

        public List<GetVolunteerUserInfoByTripIdDTO> GetVolunteerUserInfoByTripId(int ID)
        {
            return _tripsService.GetVolunteerUserInfoByTripId(ID);
        }

        [HttpGet]
        [Route("GetUserPaymentsForTrip/{ID}")]

        public List<GetUserPaymentsForTripDTO> GetUserPaymentsForTrip(int ID)
        {
            return _tripsService.GetUserPaymentsForTrip(ID);
        }
        [HttpPut]
        [Route("updateMaxUser")]
        /*        [CheckClaimsAttribute("Roleid", "1","2")]
*/
        public void updateMaxUser(int id, int res_num)
        {
            _tripsService.updateMaxUser(id, res_num);
        }
        [HttpPut]
        [Route("updateMaxVolunteer")]
        /*        [CheckClaimsAttribute("Roleid", "1","2")]
*/
        public void updateMaxVolunteer(int id, int res_num)
        {
            _tripsService.updateMaxVolunteer(id, res_num);
        }

        [HttpGet]
        [Route("GetTopRatedTrips")]

        public List<TripsByRatingDTO> GetTopRatedTrips()
        {
            return _tripsService.GetTopRatedTrips();
        }


        //[HttpPost("sendTripDetailsAndPaymentEmail")]
        //public async Task<IActionResult> sendTripDetailsAndPaymentEmail([FromBody] sendTripDetailsAndPaymentEmailDTO sendTripDetailsAndPayment)
        //{
        //    try
        //    {
        //        var smtpClient = new SmtpClient("smtp.gmail.com")
        //        {
        //            Port = 587,
        //            Credentials = new NetworkCredential("sajedaalquraan1@gmail.com", "bobf xqnl rsiq gmbe"),

        //            EnableSsl = true,
        //        };

        //        var mailMessage = new MailMessage
        //        {
        //            From = new MailAddress("sajedaalquraan1@gmail.com"),
        //            Subject = "Trip Details and Payment",
        //            Body = $"Dear Volunteer, \n\nHere are your trip details:\n\n{sendTripDetailsAndPayment.TripDetails}",
        //            IsBodyHtml = false,
        //        };

        //        mailMessage.To.Add(sendTripDetailsAndPayment.Email);

        //        // Use async for email sending
        //        await smtpClient.SendMailAsync(mailMessage);

        //        return Ok("Email sent successfully.");
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Internal server error: {ex.Message}");
        //    }
        //}



        //[HttpPost("SendEmailWithPdfAttachment")]
        //public IActionResult SendEmailWithPdfAttachment([FromBody] sendTripDetailsAndPaymentEmailDTO emailRequest)
        //{
        //    try
        //    {
        //        // Validate the email request
        //        if (string.IsNullOrEmpty(emailRequest.ReceiverEmail))
        //        {
        //            return BadRequest("Receiver email is required.");
        //        }

        //        var senderEmail = "sajedaalquraan1@gmail.com"; 
        //        var senderPassword = "bobf xqnl rsiq gmbe"; 
        //        var smtpHost = "smtp.gmail.com";  
        //        var smtpPort = 587;  

        //        var receiverEmail = emailRequest.ReceiverEmail;  
        //        var subject = "Trip Details and Payment";  
        //        var body = emailRequest.Body ?? "Here is the email body with a PDF attachment.";

        //    try
        //    {
        //        var parsedBody = Newtonsoft.Json.JsonConvert.DeserializeObject(body);
        //        body = parsedBody?.ToString() ?? body;
        //    }
        //    catch
        //    {
        //        // If parsing fails, use the raw body content.
        //    }

        //    var pdfFilePath = GeneratePdfFromText(body);

        //        var mailMessage = new MailMessage
        //        {
        //            From = new MailAddress(senderEmail),
        //            Subject = subject,
        //            Body = "Please find the attached PDF.",
        //            IsBodyHtml = true
        //        };
        //        mailMessage.To.Add(receiverEmail);

        //        var pdfAttachment = new Attachment(pdfFilePath);
        //        mailMessage.Attachments.Add(pdfAttachment);

        //        using (var smtpClient = new SmtpClient(smtpHost, smtpPort))
        //        {
        //            smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);
        //            smtpClient.EnableSsl = true;

        //            smtpClient.Send(mailMessage);
        //        }

        //        return Ok("Email sent successfully with PDF attachment.");
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest($"Error sending email: {ex.Message}");
        //    }
        //}


        //[HttpPost("TESTSendPDF")]

        //public string GeneratePdfFromText(string text)
        //{

        //    var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        //    var pdfFilePath = Path.Combine(documentsPath, "generated-email.pdf");
        //    try
        //    {
        //        using (var writer = new PdfWriter(pdfFilePath))
        //        using (var pdf = new PdfDocument(writer))
        //        {
        //            var document = new iText.Layout.Document(pdf);
        //            //document.Add(new Paragraph(text));  
        //            document.Add(new iText.Layout.Element.Paragraph(text));

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error generating PDF: " + ex.Message, ex);
        //    }

        //    return pdfFilePath;  
        //}



        [HttpPost("SendEmailWithPdfAttachment")]
        public IActionResult SendEmailWithPdfAttachment([FromBody] sendTripDetailsAndPaymentEmailDTO emailRequest)
        {
            try
            {
                if (string.IsNullOrEmpty(emailRequest.ReceiverEmail))
                {
                    return BadRequest("Receiver email is required.");
                }

                var senderEmail = "sajedaalquraan1@gmail.com";
                var senderPassword = "bobf xqnl rsiq gmbe";
                var smtpHost = "smtp.gmail.com";
                var smtpPort = 587;

                var receiverEmail = emailRequest.ReceiverEmail;
                var subject = "Trip and Payment Details";
                var body = emailRequest.Body ?? "Here is the email body with a PDF attachment.";

                // Generate the PDF with the formatted content
                var pdfFilePath = GenerateStyledPdf(body);

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(senderEmail),
                    Subject = subject,
                    Body = "Please find the attached PDF with trip and payment details.",
                    IsBodyHtml = true
                };
                mailMessage.To.Add(receiverEmail);

                var pdfAttachment = new Attachment(pdfFilePath);
                mailMessage.Attachments.Add(pdfAttachment);

                using (var smtpClient = new SmtpClient(smtpHost, smtpPort))
                {
                    smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);
                    smtpClient.EnableSsl = true;
                    smtpClient.Send(mailMessage);
                }

                return Ok("Email sent successfully with PDF attachment.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error sending email: {ex.Message}");
            }
        }

        // Method to generate a styled PDF
        [HttpPost("SendEmailWithPdfAttachmecccccccccccnt")]

        public string GenerateStyledPdf(string content)
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var pdfFilePath = Path.Combine(documentsPath, "TripAndPaymentDetails.pdf");

            try
            {
                using (var writer = new PdfWriter(pdfFilePath))
                using (var pdf = new PdfDocument(writer))
                {
                    var document = new iText.Layout.Document(pdf);

                    var title = new iText.Layout.Element.Paragraph("Trip and Payment Details")
                        .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                        .SetFontSize(18)
                        .SetBold();
                    document.Add(title);

                    var paragraph = new iText.Layout.Element.Paragraph(content)
                        .SetFontSize(12)
                        .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT);
                    document.Add(paragraph);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error generating PDF: " + ex.Message, ex);
            }

            return pdfFilePath;
        }



        //[HttpPost("SendEmailWithPdfAttachment")]
        //public IActionResult SendEmailWithPdfAttachment([FromBody] sendTripDetailsAndPaymentEmailDTO emailRequest)
        //{
        //    try
        //    {
        //        // Validate the email request
        //        if (string.IsNullOrEmpty(emailRequest.ReceiverEmail))
        //        {
        //            return BadRequest("Receiver email is required.");
        //        }

        //        var senderEmail = "sajedaalquraan1@gmail.com";
        //        var senderPassword = "bobf xqnl rsiq gmbe";
        //        var smtpHost = "smtp.gmail.com";
        //        var smtpPort = 587;

        //        var receiverEmail = emailRequest.ReceiverEmail;
        //        var subject = "Trip Details and Payment";
        //        var body = emailRequest.Body ?? "Here is the email body with a PDF attachment.";

        //        // Parse the JSON body
        //        var jsonBody = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(body);

        //        // Format the PDF content
        //        var formattedContent = FormatTripDetails(jsonBody);

        //        // Generate the PDF
        //        var pdfFilePath = GenerateStyledPdf(formattedContent);

        //        // Create and send the email with the PDF attachment
        //        var mailMessage = new MailMessage
        //        {
        //            From = new MailAddress(senderEmail),
        //            Subject = subject,
        //            Body = "Please find the attached PDF.",
        //            IsBodyHtml = true
        //        };
        //        mailMessage.To.Add(receiverEmail);
        //        var pdfAttachment = new Attachment(pdfFilePath);
        //        mailMessage.Attachments.Add(pdfAttachment);

        //        using (var smtpClient = new SmtpClient(smtpHost, smtpPort))
        //        {
        //            smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);
        //            smtpClient.EnableSsl = true;
        //            smtpClient.Send(mailMessage);
        //        }

        //        return Ok("Email sent successfully with PDF attachment.");
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest($"Error sending email: {ex.Message}");
        //    }
        //}

        [HttpPost("SendEmailWithPdfAttaffffffffffchment")]

        // Helper method to format the trip details
        private string FormatTripDetails(dynamic jsonBody)
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Trip Name: {jsonBody.Trip_Name}");
            sb.AppendLine($"Start Date: {jsonBody.Start_Date}");
            sb.AppendLine($"End Date: {jsonBody.End_Date}");
            sb.AppendLine($"Departure Location: {jsonBody.Departure_Location}");
            sb.AppendLine();
            sb.AppendLine("Services:");

            foreach (var service in jsonBody.Services)
            {
                if (service.service_Name != null && service.service_Cost != null)
                {
                    sb.AppendLine($"- Service Name: {service.service_Name}");
                    sb.AppendLine($"  Cost: ${service.service_Cost}");
                    sb.AppendLine();
                }
            }

            return sb.ToString();
        }

        //// Method to generate a styled PDF
        //[HttpPost("SendEmailWithPdfAtxxxxxxxxxxxxtachment")]

        //public string GenerateStyledPdf(string content)
        //{
        //    var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        //    var pdfFilePath = Path.Combine(documentsPath, "TripDetails.pdf");

        //    try
        //    {
        //        using (var writer = new PdfWriter(pdfFilePath))
        //        using (var pdf = new PdfDocument(writer))
        //        {
        //            var document = new iText.Layout.Document(pdf);

        //            // Add title
        //            var title = new iText.Layout.Element.Paragraph("Trip Details and Services")
        //                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
        //                .SetFontSize(18)
        //                .SetBold();
        //            document.Add(title);

        //            // Add the content
        //            var paragraph = new iText.Layout.Element.Paragraph(content)
        //                .SetFontSize(12)
        //                .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT);
        //            document.Add(paragraph);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error generating PDF: " + ex.Message, ex);
        //    }

        //    return pdfFilePath;
        //}



    }


}






















