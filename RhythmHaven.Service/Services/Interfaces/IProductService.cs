using RhythmHaven.Repository.Common;
using RhythmHaven.Service.BusinessModels.ProductModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmHaven.Service.Services.Interfaces
{
    public interface IProductService
    {
        public Task<Pagination<ProductModel>> GetAllProduct(PaginationParameter paginationParameter);
        public Task<ProductModel> GetProduct(Guid id);
        public Task<ProductModel> AddProduct(ProductProcessModel model);
        public Task<ProductModel> UpdateProduct(Guid id, ProductProcessModel model);
        public Task<ProductModel> DeleteProduct(Guid id);
    }
}
