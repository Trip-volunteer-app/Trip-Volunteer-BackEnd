using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.Repository;
using Trip_Volunteer.Core.Service;

namespace Trip_Volunteer.Infra.Service
{
    public class BankService: IBankService
    {
        private readonly IBankRepository _bankRepository;
        public BankService(IBankRepository bankRepository)
        {
            this._bankRepository = bankRepository;
        }
        public List<Bank> GetAllCard()
        {
            return _bankRepository.GetAllCard();
        }
        public Bank GetCardById(int id)
        {
            return _bankRepository.GetCardById(id);
        }
        public void CreateCard(Bank bank)
        {
            _bankRepository.CreateCard(bank);
        }
        public void UpdateCard(Bank bank)
        {
            _bankRepository.UpdateCard(bank);
        }
        public void DeleteCard(int id)
        {
            _bankRepository.DeleteCard(id);
        }
    }
}
