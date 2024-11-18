using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.Repository;
using Trip_Volunteer.Core.Service;

namespace Trip_Volunteer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {

        private readonly ICardService _cardService;
        public CardController(ICardService cardService)
        {
            this._cardService = cardService;
        }
        
        [HttpGet]
        public List<Card> GetAllCard()
        {
            return _cardService.GetAllCard();
        }
        
        [HttpGet]
        [Route("GetCardById")]
        public Card GetCardById(int id)
        {
            return _cardService.GetCardById(id);
        }

        [HttpGet]
        [Route("GetCardByLoginId/{id}")]
        [CheckClaimsAttribute("Roleid", "1","2")]

        public List<Card> GetCardByLoginId(int id)
        {
            return _cardService.GetCardByLoginId(id);
        }

        [HttpPost]
        [Route("CreateCard")]
        [CheckClaimsAttribute("Roleid", "1","2")]
        public void CreateCard(Card card)
        {
            _cardService.CreateCard(card);
        }
        
        [HttpPut]
        [Route("UpdateCard")]
        [CheckClaimsAttribute("Roleid", "1", "2")]
        public void UpdateCard(Card card)
        {
            _cardService.UpdateCard(card);
        }

        [HttpDelete]
        [Route("DeleteCard")]
        [CheckClaimsAttribute("Roleid", "1", "2")]
        public void DeleteCard(int id)
        {
            _cardService.DeleteCard(id);
        }
    }
}
