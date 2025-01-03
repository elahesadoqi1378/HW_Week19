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
    public class TransactionAppService : ITransactionAppService
    {
        private readonly ITransactionService _transactionService;

        public TransactionAppService(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }


        public void AddTransaction(Transaction transaction)
        {
            _transactionService.Add(transaction);
        }

        public List<Transaction> GetTransactionsByCardNumber(string cardNumber)
        {
            return _transactionService.GetTransactionsBy(cardNumber);
        }
    }
}

