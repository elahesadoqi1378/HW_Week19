using Bank.Domain.Core.Contracts.AppService;
using Bank.Domain.Core.Contracts.Repository;
using Bank.Domain.Core.Contracts.Service;
using Bank.Domain.Core.Entities;
using Bank.Services.Services;
using HW_Week15.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Services.AppServices
{
    public class CardAppService : ICardAppService
    {

        private readonly ICardService _cardService;
        private readonly ITransactionService _transactionService;
        private readonly IUserService _userService;

        public CardAppService(ICardService cardService , ITransactionService transactionService , IUserService userService)
        {
            _cardService = cardService;
            _transactionService = transactionService;
            _userService = userService; 

        }



        public string Transfer(string sourceCardNumber, string destinationCardNumber, float amount)
        {

            if (sourceCardNumber.Length != 16 || destinationCardNumber.Length != 16)
                return "Card numbers must be 16 digits.";

            if (amount <= 0)
                return "Transfer amount must be greater than zero.";

            var sourceCard = _cardService.Get(sourceCardNumber);
            var destinationCard = _cardService.Get(destinationCardNumber);

            if (sourceCard == null || destinationCard == null)
                return "Invalid card number.";

            if (sourceCard.Balance < amount)
                return "Insufficient balance.";

            Console.WriteLine($" This Amount is tranfering  to: {destinationCard.HolderName}");
            Console.WriteLine("Do you confirm the transfer? (yes/no): ");
            var confirmation = Console.ReadLine();
            if (confirmation?.ToLower() != "yes")
            {
                return "Transfer cancelled by user.";
            }

            if (!sourceCard.IsActive)
            {

                return "Source card is inactive.";

            }

            var user = _userService.Get(sourceCardNumber);
            if (user == null)
                return "User not found.";

            if (DailyLimit(sourceCardNumber, amount))
                return "Transfer limit exceeded for today.";


            float fee = TransactionFee(amount);
            float totalAmount = amount + fee;

            if (sourceCard.Balance < totalAmount)
                return "Insufficient balance including transaction fee.";


            var transaction = new Transaction
            {
                SourceCardNumber = sourceCardNumber,
                DestinationCardNumber = destinationCardNumber,
                Amount = amount,
                IsSuccessful = false,
                TransactionDate = DateTime.Now
            };


            sourceCard.Balance -= totalAmount;
            destinationCard.Balance += amount;

            _cardService.Update(sourceCard);
            _cardService.Update(destinationCard);
            _transactionService.Add(transaction);


            transaction.IsSuccessful = true;
            _transactionService.Save();

            return "Transfer successful.";

        }

        public List<Transaction> GetTransactions(string cardNumber)
        {
            return _transactionService.GetTransactionsBy(cardNumber);
        }

        public bool ValidatePassword(string cardNumber, string password)
        {
            var card =_cardService.Get(cardNumber);
            if (card != null && !card.IsActive)
            {
                Console.WriteLine("Your card is blocked. Please contact support.");
                return false;
            }

            if (card != null && card.Password == password)
            {
                card.FailedLoginAttempts = 0;
                _cardService.Update(card);
                return true;
            }
            else
            {
                var failedAttempts = card != null ? card.FailedLoginAttempts : 0;
                card.FailedLoginAttempts = failedAttempts + 1;
                _cardService.Update(card);

                if (card.FailedLoginAttempts >= 3)
                {
                    BlockFailedAttempts(cardNumber, card.FailedLoginAttempts);
                    Console.WriteLine("Your card has been blocked probobly cause your failed attempt by wrong pass.");
                }
                return false;
            }
        }


        public void ChangePassword(string cardNumber, string newPassword)
        {
            var card = _cardService.Get(cardNumber);
            if (card != null)
            {
                card.Password = newPassword;
                _cardService.Update(card);
            }
        }
        public bool DailyLimit(string cardNumber, float amount)
        {

            var todayTransfers = _transactionService.GetTransactionsBy(cardNumber)
                .Where(t => t.TransactionDate.Date == DateTime.Today).Sum(t => t.Amount);


            return (todayTransfers + amount) > 250;
        }
        public float TransactionFee(float amount)
        {
            if (amount > 1000)
            {
                return amount * 0.015f;
            }
            else
            {

                return amount * 0.005f;
            }
        }
        public float GetCardBalance(string cardNumber)
        {
            var card = _cardService.Get(cardNumber);
            if (card != null)
            {
                return card.Balance;
            }
            throw new Exception("Card not found.");
        }

        public void BlockFailedAttempts(string cardNumber, int failedAttempts)
        {
            if (failedAttempts >= 3)
            {
                var card = _cardService.Get(cardNumber);
                if (card != null)
                {
                    card.IsActive = false;
                    _cardService.Update(card);
                }
            }
        }

      
    }
}

