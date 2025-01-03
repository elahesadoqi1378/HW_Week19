using Bank.Domain.Core.Contracts.Repository;
using Bank.Domain.Core.Contracts.Service;
using Bank.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Services.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public void Add(Transaction transaction)
        {
            _transactionRepository.Add(transaction);
        }

        public List<Transaction> GetTransactionsBy(string cardNumber)
        {
          return  _transactionRepository.GetTransactionsBy(cardNumber);
        }

        public void Save()
        {
            _transactionRepository.Save();
        }
    }
}
