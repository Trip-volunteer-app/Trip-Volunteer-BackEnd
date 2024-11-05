using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.Service;
using Trip_Volunteer.Infra.Service;

namespace Trip_Volunteer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet]
        [Route("GetAllPayments")]
        [CheckClaimsAttribute("Roleid", "1")]
        public List<Payment> GetAllPayments()
        {
            return _paymentService.GetAllPayments();
        }

        [HttpGet]
        [Route("GetPaymantById/{id}")]
        [CheckClaimsAttribute("Roleid", "1")]
        public Payment GetPaymantById(int id)
        {
            return _paymentService.GetPaymantById(id);
        }

        [HttpPost]
        [Route("CreatePayment")]
        [CheckClaimsAttribute("Roleid", "1","2")]
        public void CreatePayment(Payment payment)
        {
            _paymentService.CreatePayment(payment);
        }

        [HttpPut]
        [Route("UpdatePayment")]
        [CheckClaimsAttribute("Roleid", "1","2")]
        public void UpdatePayment(Payment payment)
        {
            _paymentService.UpdatePayment(payment);
        }

        [HttpDelete]
        [Route("DeletePayment/{id}")]
        [CheckClaimsAttribute("Roleid", "1","2")]
        public void DeletePayment(int id)
        {
            _paymentService.DeletePayment(id);
        }


        [HttpGet("TotalNumberOfPayments")]
        //[CheckClaimsAttribute("Roleid", "1")]
        public IActionResult TotalNumberOfPayments()
        {
            int numberOfpayment = _paymentService.TotalNumberOfPayments();
            return Ok(numberOfpayment);
        }


    }
}
