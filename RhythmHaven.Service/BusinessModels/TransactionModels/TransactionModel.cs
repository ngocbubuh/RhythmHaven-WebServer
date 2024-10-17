using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmHaven.Service.BusinessModels.TransactionModels
{
    public class TransactionModel
    {
        public Guid Id { get; set; }

        public Guid AccountId { get; set; }

        public double Amount { get; set; }

        public string TransactionType { get; set; } = null!;

        public string TransactionDes { get; set; } = null!;

        public bool TransactionStatus { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
