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
    public class UserAppService :IUserAppService
    {
        private readonly IUserService _userService;

        public UserAppService(IUserService userService)
        {
            _userService = userService;
        }

        public User GetUserByCardNumber(string cardNumber)
        {
            return _userService.Get(cardNumber);
        }
    }
}
