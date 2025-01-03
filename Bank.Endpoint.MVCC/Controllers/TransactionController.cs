using Bank.Domain.Core.Contracts.Service;
using Bank.Services.AppServices;
using Bank.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Endpoint.MVCC.Controllers
{
    public class TransactionController : Controller
    {
        private readonly CardAppService cardAppService;
        public TransactionController()
        {
            cardAppService = new CardAppService();
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Transfer(string destinationCard, float amount)
        {
            string cardNumber = TempData["CardNumber"]?.ToString();
            if (string.IsNullOrEmpty(cardNumber))
                return RedirectToAction("Index", "Card");

            string result = cardAppService.Transfer(cardNumber, destinationCard, amount);
            ViewBag.TransferMessage = result;
            ViewBag.Balance = cardAppService.GetCardBalance(cardNumber);

            return View("Dashboard", "Card");
        }
        public IActionResult History()
        {
            string cardNumber = TempData["CardNumber"]?.ToString();
            if (string.IsNullOrEmpty(cardNumber))
                return RedirectToAction("Index", "Card");

            var transactions = cardAppService.GetTransactions(cardNumber);
            return View(transactions);
        }

    }
}






