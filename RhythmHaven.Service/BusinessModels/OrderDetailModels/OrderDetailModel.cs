using RhythmHaven.Repository.Entities;
using RhythmHaven.Service.BusinessModels.ProductModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmHaven.Service.BusinessModels.OrderDetailModels
{
    public class OrderDetailModel
    {
        public Guid Id { get; set; }

        public Guid OrderId { get; set; }

        public Guid ProductId { get; set; }

        public int Quantity { get; set; }

        public double UnitPrice { get; set; }

        public virtual ProductModel? Product { get; set; }
    }
}
