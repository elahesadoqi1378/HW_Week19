using Bank.Domain.Core.Contracts.Service;
using Bank.Domain.Core.Entities;
using Bank.Services.AppServices;
using Bank.Services.Services;
using HW_Week15.DAL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Endpoint.MVCC.Controllers
{
    public class AccountController : Controller
    {
        private readonly CardAppService cardAppService;
        private readonly CardRepository cardRepository;

        public AccountController()
        {
            cardAppService = new CardAppService();
            cardRepository = new CardRepository();
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet ("account/login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string cardNumber, string password)
        {
            if (cardAppService.ValidatePassword(cardNumber, password))
            {
                TempData["CardNumber"] = cardNumber;
                return RedirectToAction("Dashboard");
            }

            ViewBag.ErrorMessage = "Invalid card number or password.";
            return View("Index");
        }
        [HttpGet("account/dashboard")]
        public IActionResult Dashboard()
        {
            string cardNumber = TempData["CardNumber"]?.ToString();
            if (string.IsNullOrEmpty(cardNumber))
                return RedirectToAction("Index");

            ViewBag.CardNumber = cardNumber;
            ViewBag.Balance = cardAppService.GetCardBalance(cardNumber);
            return View();
        }

        [HttpPost]
        public IActionResult ChangePassword(string newPassword)
        {
            string cardNumber = TempData["CardNumber"]?.ToString();
            if (string.IsNullOrEmpty(cardNumber))
                return RedirectToAction("Index");

            cardAppService.ChangePassword(cardNumber, newPassword);
            ViewBag.Message = "Password changed successfully.";
            return View("Dashboard");
        }



    }
}









