using Bank.Domain.Core.Contracts.AppService;
using Bank.Domain.Core.Contracts.Service;
using Bank.Domain.Core.Entities;
using Bank.Services.AppServices;
using Bank.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Endpoint.MVCCC.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ITransactionAppService _transactionAppService;

        public TransactionController(ITransactionAppService transactionAppService)
        {
            _transactionAppService = transactionAppService;
        }
        public IActionResult ViewTransactions()
        {
            var cardNumber = TempData["CardNumber"] as string;
            if (string.IsNullOrEmpty(cardNumber))
            {
                return RedirectToAction("Login");
            }

            var transactions = _transactionAppService.GetTransactionsByCardNumber(cardNumber);
            return View(transactions);
        }

    }
}




