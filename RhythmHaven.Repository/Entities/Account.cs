using RhythmHaven.Repository.Entities.Base;
using System;
using System.Collections.Generic;

namespace RhythmHaven.Repository.Entities;

public partial class Account : EntityBase
{
    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PhoneNum { get; set; } = null!;

    public double Credit { get; set; } = 0;

    public string UserName { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public string? Avatar { get; set; }
    public string? UnsignName { get; set; }
    public string? Role { get; set; }
    public string? Status { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
