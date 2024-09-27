using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Data;

namespace Trip_Volunteer.Core.Service
{
    public interface IBankService
    {
        List<Bank> GetAllCard();
        Bank GetCardById(int id);
        void CreateCard(Bank bank);
        void UpdateCard(Bank bank);
        void DeleteCard(int id);
    }
}
