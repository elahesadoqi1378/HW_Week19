using Bank.Domain.Core.Contracts.AppService;
using Bank.Domain.Core.Contracts.Repository;
using Bank.Domain.Core.Contracts.Service;
using Bank.Endpoint.MVCCC.Models;
using Bank.Services.AppServices;
using Bank.Services.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Bank.Endpoint.MVCCC.Controllers
{
    public class CardController : Controller
    {
        private readonly ICardAppService _cardAppService;

        private readonly ICardRepository _cardRepository;
       

        public CardController(ICardAppService cardAppService, ICardRepository cardRepository)
        {
            _cardAppService = cardAppService;
            _cardRepository = cardRepository;
           
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string cardNumber, string password)
        {
            var card = _cardRepository.Get(cardNumber);
            if (card == null || card.Password != password)
            {
                return RedirectToAction("Login");
            }

            TempData["CardNumber"] = cardNumber;
            return RedirectToAction("UserMenu");
        }
        [HttpGet]
        public IActionResult UserMenu()
        {
            var cardNumber = TempData["CardNumber"]?.ToString();
            if (string.IsNullOrEmpty(cardNumber))
                return RedirectToAction("Login");

            TempData.Keep("CardNumber");

            var card = _cardRepository.Get(cardNumber);
            return View(card);

        }
        [HttpGet]
        public IActionResult ViewTransactions(string cardNumber)
        {
            var transactions = _cardAppService.GetTransactions(cardNumber);
            return View(transactions);
        }



        [HttpGet]
        public IActionResult Transfer()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Transfer(string sourceCardNumber, string destinationCardNumber, float amount)
        {
            var result = _cardAppService.Transfer(sourceCardNumber, destinationCardNumber, amount);
            ViewData["Message"] = result;
            return View();
        }
        //[HttpGet]
        //public IActionResult CheckBalance(string cardNumber)
        //{
        //    cardNumber = TempData["CardNumber"] as string;
        //    if (string.IsNullOrEmpty(cardNumber))
        //    {
        //        return RedirectToAction("Login");
        //    }

        //    var balance = _cardAppService.GetCardBalance(cardNumber);
        //    return View(new { Balance = balance });
        //}



        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ChangePassword(string cardNumber, string newPassword)
        {
            _cardAppService.ChangePassword(cardNumber, newPassword);
            return RedirectToAction("UserMenu", new { message = "Password changed successfully" });
        }


    }
}





















