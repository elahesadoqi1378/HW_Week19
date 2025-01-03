using Bank.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Domain.Core.Contracts.Service
{
    public interface IUserService
    {
        User Get(string cardNumber);
        void Save();
    }
}
