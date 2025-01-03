using Bank.Domain.Core.Contracts.Repository;
using Bank.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Week15.DAL.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        AppDBContext _appDBContext;

        public TransactionRepository()
        {
            _appDBContext = new AppDBContext();
        }
        public void Add(Transaction transaction)
        {
            _appDBContext.Transactions.Add(transaction);
           _appDBContext.SaveChanges();
        }

        public List<Transaction> GetTransactionsBy(string cardNumber)
        {
            return _appDBContext.Transactions
                      .Where(t => t.SourceCardNumber == cardNumber || t.DestinationCardNumber == cardNumber)
                      .ToList();
        }

        public void Save()
        {
            _appDBContext.SaveChanges();
        }
    }
}
