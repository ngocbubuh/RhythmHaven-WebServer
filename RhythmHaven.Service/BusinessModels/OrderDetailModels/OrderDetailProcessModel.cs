using RhythmHaven.Service.BusinessModels.ProductModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmHaven.Service.BusinessModels.OrderDetailModels
{
    public class OrderDetailProcessModel
    {
        public Guid ProductId { get; set; }

        public int Quantity { get; set; }

        public double UnitPrice { get; set; }
    }
}
