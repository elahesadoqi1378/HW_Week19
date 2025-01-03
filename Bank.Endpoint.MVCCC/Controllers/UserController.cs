using Bank.Domain.Core.Contracts.AppService;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Endpoint.MVCCC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserAppService _userAppService;

        public UserController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }
     
        [HttpGet]
        public IActionResult GetUserByCardNumber(string cardNumber)
        {
            var user = _userAppService.GetUserByCardNumber(cardNumber);
            return View(user); 
        }
    }
}



