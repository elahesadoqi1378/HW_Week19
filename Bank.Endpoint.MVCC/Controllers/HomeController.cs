using Bank.Domain.Core.Contracts.AppService;
using Bank.Domain.Core.Contracts.Service;
using Bank.Endpoint.MVCC.Models;
using Bank.Services.AppServices;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Bank.Endpoint.MVCC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICardAppService cardAppService;
        private readonly ITransactionAppService transactionAppService;

        //public HomeController()
        //{
        //    cardAppService = new CardAppService();
        //    transactionAppService = new TransactionAppService();
        //}

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

       
    }
}






