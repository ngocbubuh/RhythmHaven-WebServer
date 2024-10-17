using RhythmHaven.Repository.Entities.Base;
using System;
using System.Collections.Generic;

namespace RhythmHaven.Repository.Entities;

public partial class Transaction : EntityBase
{
    public Guid AccountId { get; set; }

    public double Amount { get; set; }

    public string TransactionType { get; set; } = null!;

    public string TransactionDes { get; set; } = null!;

    public bool TransactionStatus { get; set; }


    public virtual Account Account { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
