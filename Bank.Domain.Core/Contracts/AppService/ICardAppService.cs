using Bank.Domain.Core.Contracts.Repository;
using Bank.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Domain.Core.Contracts.AppService
{
    public interface ICardAppService
    {
        string Transfer(string sourceCardNumber, string destinationCardNumber, float amount);
        List<Transaction> GetTransactions(string cardNumber);
        bool ValidatePassword(string cardNumber, string password);
        void ChangePassword(string cardNumber, string newPassword);
        bool DailyLimit(string cardNumber, float amount);
        float TransactionFee(float amount);
        float GetCardBalance(string cardNumber);
        void BlockFailedAttempts(string cardNumber, int failedAttempts);
    }


}







