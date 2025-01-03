using Bank.Domain.Core.Contracts.Repository;
using Bank.Domain.Core.Contracts.Service;
using Bank.Domain.Core.Entities;
using HW_Week15.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Services.Services
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _cardRepository;

        public CardService(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }
        public Card Get(string cardNumber)
        {
            return _cardRepository.Get(cardNumber);
        }

        public void Save()
        {
            _cardRepository.Save();
        }

        public void Update(Card card)
        {
           _cardRepository.Update(card);
        }
    }
}
