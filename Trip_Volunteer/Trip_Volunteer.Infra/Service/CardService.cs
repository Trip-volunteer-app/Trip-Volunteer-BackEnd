using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.Repository;
using Trip_Volunteer.Core.Service;
using Trip_Volunteer.Infra.Repository;

namespace Trip_Volunteer.Infra.Service
{
    public class CardService: ICardService
    {
        private readonly ICardRepository _cardRepository;
        public CardService(ICardRepository cardRepository)
        {
            this._cardRepository = cardRepository;
        }

        public List<Card> GetAllCard()
        {
            return _cardRepository.GetAllCard();
        }
        public Card GetCardById(int id)
        {
            return _cardRepository.GetCardById(id);
        }
        public List<Card> GetCardByLoginId(int id)
        {
            return _cardRepository.GetCardByLoginId(id);
        }
        public void CreateCard(Card card)
        {
            _cardRepository.CreateCard(card);
        }
        public void UpdateCard(Card card)
        {
            _cardRepository.UpdateCard(card);
        }
        public void DeleteCard(int id)
        {
            _cardRepository.DeleteCard(id);
        }
    }
}
