
using Bank.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Domain.Core.Contracts.Repository
{
    public interface ITransactionRepository
    {
        void Add(Transaction transaction);
        List<Transaction> GetTransactionsBy(string cardNumber);
        void Save();

    }
}
