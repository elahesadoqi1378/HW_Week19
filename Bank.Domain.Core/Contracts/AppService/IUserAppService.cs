using Bank.Domain.Core.Contracts.Repository;
using Bank.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Domain.Core.Contracts.AppService
{
    public interface IUserAppService
    {
        User GetUserByCardNumber(string cardNumber);
    }
}




