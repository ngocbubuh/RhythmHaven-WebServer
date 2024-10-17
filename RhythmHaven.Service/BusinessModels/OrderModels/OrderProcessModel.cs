using RhythmHaven.Service.BusinessModels.OrderDetailModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmHaven.Service.BusinessModels.OrderModels
{
    public class OrderProcessModel
    {
        public string Address { get; set; } = null!;

        public double Total { get; set; }

        public virtual ICollection<OrderDetailModel>? OrderDetails { get; set; }
    }
}
