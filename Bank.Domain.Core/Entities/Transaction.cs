using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Domain.Core.Entities
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        public string SourceCardNumber { get; set; }
        public string DestinationCardNumber { get; set; }
        public float Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public bool IsSuccessful { get; set; } = false;

        #region Navigation Properties
        public Card SourceCard { get; set; }
        public Card DestinationCard { get; set; }
        #endregion

    }
}
