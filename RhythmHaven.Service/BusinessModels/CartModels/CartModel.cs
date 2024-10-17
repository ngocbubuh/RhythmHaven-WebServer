using RhythmHaven.Repository.Entities;
using RhythmHaven.Service.BusinessModels.ProductModels;
using RhythmHaven.Service.BusinessModels.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmHaven.Service.BusinessModels.CartModels
{
    public class CartModel
    {
        public Guid Id { get; set; }

        public Guid AccountId { get; set; }

        public Guid ProductId { get; set; }

        public int Quantity { get; set; }


        public virtual UserModel Account { get; set; } = null!;

        public virtual ProductModel Product { get; set; } = null!;
    }
}
