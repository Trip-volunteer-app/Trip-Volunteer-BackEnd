using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.Repository;
using Trip_Volunteer.Core.Service;

namespace Trip_Volunteer.Infra.Service
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }
        public List<Payment> GetAllPayments()
        {
            return _paymentRepository.GetAllPayments();
        }
        public Payment GetPaymantById(int id)
        {
            return _paymentRepository.GetPaymantById(id);
        }
        public void CreatePayment(Payment payment)
        {
             _paymentRepository.CreatePayment(payment);
        }
        public void UpdatePayment(Payment payment)
        {
             _paymentRepository.UpdatePayment(payment);
        }
        public void DeletePayment(int id)
        {
             _paymentRepository.DeletePayment(id);
        }
    }
}
