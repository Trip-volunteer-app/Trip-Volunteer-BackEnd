﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.Service;

namespace Trip_Volunteer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly IBankService _bankService;
        public BankController(IBankService bankService)
        {
            this._bankService = bankService;
        }


        [HttpGet]
        [CheckClaimsAttribute("Roleid", "1", "2")]

        public List<Bank> GetAllCard()
        {
            return _bankService.GetAllCard();
        }


        [HttpGet]
        [Route("GetCardById")]
        [CheckClaimsAttribute("Roleid", "1", "2")]

        public Bank GetCardById(int id)
        {
            return _bankService.GetCardById(id);
        }


        [HttpPost]
        [Route("CreateCard")]
        [CheckClaimsAttribute("Roleid", "1", "2")]

        public void CreateCard(Bank bank)
        {
            _bankService.CreateCard(bank);
        }


        [HttpPut]
        [Route("UpdateCard")]
        [CheckClaimsAttribute("Roleid", "1", "2")]

        public void UpdateCard(Bank bank)
        {
            _bankService.UpdateCard(bank);
        }


        [HttpDelete]
        [Route("DeleteCard")]
        [CheckClaimsAttribute("Roleid", "1", "2")]

        public void DeleteCard(int id)
        {
            _bankService.DeleteCard(id);
        }
        [HttpPut]
        [Route("UpdateBalance")]
        public void UpdateBalance(Bank bank)
        {
            _bankService.UpdateBalance(bank);
        }

    }
}
