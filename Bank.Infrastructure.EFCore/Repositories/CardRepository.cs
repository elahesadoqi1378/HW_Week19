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
    public class CardRepository : ICardRepository
    {
        AppDBContext _appDBContext;

        public CardRepository()
        {
            _appDBContext = new AppDBContext();
        }
        public Card Get(string cardNumber)
        {
            return _appDBContext.Cards.FirstOrDefault(c => c.CardNumber == cardNumber);
        }

        public void Save()
        {
            _appDBContext.SaveChanges();
        }

        public void Update(Card card)
        {
            var existingCard =  _appDBContext.Cards.FirstOrDefault(c => c.Id == card.Id);
            if (existingCard != null)
            {
                existingCard.Balance = card.Balance;
                existingCard.IsActive = card.IsActive;
                existingCard.Password = card.Password;
                existingCard.FailedLoginAttempts = card.FailedLoginAttempts;
            }
            _appDBContext.SaveChanges();
        }
    }
}
