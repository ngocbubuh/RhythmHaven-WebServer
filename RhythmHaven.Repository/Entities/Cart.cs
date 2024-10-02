using RhythmHaven.Repository.Entities.Base;
using System;
using System.Collections.Generic;

namespace RhythmHaven.Repository.Entities;

public partial class Cart : EntityBase
{
    public Guid AccountId { get; set; }

    public Guid ProductId { get; set; }

    public int Quantity { get; set; }


    public virtual Account Account { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
