using Bank.Domain.Core.Contracts.AppService;
using Bank.Domain.Core.Contracts.Repository;
using Bank.Domain.Core.Contracts.Service;
using Bank.Services.AppServices;
using HW_Week15.DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bank.Endpoint.RazorPages.Pages.Login
{
    public class LoginModel : PageModel
    {
        private readonly ICardAppService cardAppService;
        private readonly ICardRepository cardRepository;

        public LoginModel()
        {
            cardAppService = new CardAppService();
            cardRepository = new CardRepository();
        }

        [BindProperty]
        public string CardNumber { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        public IActionResult OnPost()
        {
            var card = cardRepository.Get(CardNumber);

            if (card == null || !card.IsActive)
            {
                ErrorMessage = "Invalid card number or your card is blocked.";
                return Page();
            }

            if (cardAppService.ValidatePassword(CardNumber, Password))
            {
                return RedirectToPage("/UserMenu", new { cardNumber = CardNumber });
            }
            else
            {
                ErrorMessage = "Invalid password.";
                return Page();
            }
        }
    }

}
