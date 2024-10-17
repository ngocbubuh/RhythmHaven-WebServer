using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RhythmHaven.Repository.Common;
using RhythmHaven.Service.BusinessModels.ProductModels;
using RhythmHaven.Service.Services.Interfaces;

namespace RhythmHaven.API.Controllers
{
    [Route("products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PaginationParameter paginationParameter)
        {
            try
            {
                var result = await _productService.GetAllProduct(paginationParameter);
                return Ok(result);
            } catch { throw; }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id) 
        {
            try
            {
                var result = await _productService.GetProduct(id);
                return Ok(result);
            } catch { throw; }
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductProcessModel model)
        {
            try
            {
                var result = await _productService.AddProduct(model);
                return Ok(result);
            } catch { throw;}
        }

        [HttpPut]
        public async Task<IActionResult> Update(Guid id,  ProductProcessModel model)
        {
            try
            {
                var result = await _productService.UpdateProduct(id, model);
                return Ok(result);
            } catch { throw; }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var result = await _productService.DeleteProduct(id);
                return Ok(result);
            } catch { throw; }
        }
    }
}
