using RhythmHaven.Service.BusinessModels.ProductModels;
using RhythmHaven.Service.BusinessModels.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmHaven.Service.BusinessModels.CartModels
{
    public class CartProcessModel
    {
        public Guid ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
