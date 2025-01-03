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
    public class UserRepository : IUserRepository
    {
        AppDBContext _appDBContext;

        public UserRepository()
        {
            _appDBContext = new AppDBContext();
        }
        public User Get(string cardNumber)
        {
            return _appDBContext.Users.FirstOrDefault(u => u.Cards.Any(c => c.CardNumber == cardNumber));

        }

        public void Save()
        {
            _appDBContext.SaveChanges();
        }
    }
}
