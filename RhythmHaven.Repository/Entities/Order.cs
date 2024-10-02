using RhythmHaven.Repository.Entities.Base;
using System;
using System.Collections.Generic;

namespace RhythmHaven.Repository.Entities;

public partial class Order : EntityBase
{
    public Guid AccountId { get; set; }

    public Guid TransactionId { get; set; }

    public string Address { get; set; } = null!;

    public double Total { get; set; }


    public virtual Account Account { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Transaction Transaction { get; set; } = null!;
}
