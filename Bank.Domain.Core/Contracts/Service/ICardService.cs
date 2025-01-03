using Bank.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Domain.Core.Contracts.Service
{
    public interface ICardService
    {
        Card Get(string cardNumber);
        void Update(Card card);
        void Save();
    }
}
