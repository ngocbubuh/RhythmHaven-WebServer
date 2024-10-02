using RhythmHaven.Repository.Entities.Base;
using System;
using System.Collections.Generic;

namespace RhythmHaven.Repository.Entities;

public partial class OrderDetail : EntityBase
{
    public Guid OrderId { get; set; }

    public Guid ProductId { get; set; }

    public int Quantity { get; set; }

    public double UnitPrice { get; set; }


    public virtual Order Order { get; set; } = null!;
    public virtual Product Product { get; set; } = null!;
}
