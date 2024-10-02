using RhythmHaven.Repository.Entities.Base;
using System;
using System.Collections.Generic;

namespace RhythmHaven.Repository.Entities;

public partial class Product : EntityBase
{
    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Type { get; set; } = null!;

    public double Price { get; set; }


    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();
    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
