using AutoMapper;
using RhythmHaven.Repository;
using RhythmHaven.Repository.Common;
using RhythmHaven.Repository.Entities;
using RhythmHaven.Service.BusinessModels.ProductModels;
using RhythmHaven.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmHaven.Service.Services
{
    public class ProductService : IProductService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ProductModel> AddProduct(ProductProcessModel model)
        {
            var addProduct = _mapper.Map<Product>(model);
            var result = await _unitOfWork.ProductRepository.AddAsync(addProduct);
            _unitOfWork.Save();
            return _mapper.Map<ProductModel>(result);
        }

        public async Task<ProductModel> DeleteProduct(Guid id)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(id);
            if (product == null)
            {
                throw new Exception("Product not found");
            }
            _unitOfWork.ProductRepository.SoftDeleteAsync(product);
            _unitOfWork.Save();
            return _mapper.Map<ProductModel>(product);
        }

        public async Task<Pagination<ProductModel>> GetAllProduct(PaginationParameter paginationParameter)
        {
            var result = await _unitOfWork.ProductRepository.GetAllAsync(paginationParameter);
            return _mapper.Map<Pagination<ProductModel>>(result);
        }

        public async Task<ProductModel> GetProduct(Guid id)
        {
            var result = await _unitOfWork.ProductRepository.GetByIdAsync(id);
            return _mapper.Map<ProductModel>(result);
        }

        public async Task<ProductModel> UpdateProduct(Guid id, ProductProcessModel model)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(id);
            if (product == null)
            {
                throw new Exception("Product not found");
            }
            var updateProduct = _mapper.Map(model, product);
            _unitOfWork.ProductRepository.UpdateAsync(updateProduct);
            _unitOfWork.Save();
            return _mapper.Map<ProductModel>(updateProduct);
        }
    }
}
