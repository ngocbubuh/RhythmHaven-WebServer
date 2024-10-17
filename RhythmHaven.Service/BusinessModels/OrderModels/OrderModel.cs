using RhythmHaven.Repository.Entities;
using RhythmHaven.Service.BusinessModels.OrderDetailModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmHaven.Service.BusinessModels.OrderModels
{
    public class OrderModel
    {
        public Guid Id { get; set; }

        public Guid AccountId { get; set; }

        public Guid TransactionId { get; set; }

        public string Address { get; set; } = null!;

        public double Total { get; set; }


        public virtual ICollection<OrderDetailModel>? OrderDetails { get; set; }
    }
}
