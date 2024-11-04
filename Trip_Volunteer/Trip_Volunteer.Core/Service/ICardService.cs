using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Data;

namespace Trip_Volunteer.Core.Service
{
    public interface ICardService
    {
        List<Card> GetAllCard();
        Card GetCardById(int id);
        List<Card> GetCardByLoginId(int id);
        void CreateCard(Card card);
        void UpdateCard(Card card);
        void DeleteCard(int id);
    }
}
