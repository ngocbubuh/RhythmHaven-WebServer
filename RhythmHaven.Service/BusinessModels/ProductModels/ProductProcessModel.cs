using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmHaven.Service.BusinessModels.ProductModels
{
    public class ProductProcessModel
    {
        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Type { get; set; } = null!;

        public double Price { get; set; }

        public int Quantity { get; set; }
    }
}
