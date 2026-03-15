using Microsoft.AspNetCore.Mvc;
using Product.API.DTO;
using Product.API.Entities;
using Product.API.Services;

namespace Product.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ResponseDto _response;
        public ProductController(IProductService productService)
        {
            _productService = productService;
            _response = new ResponseDto();
        }
        [HttpGet]
        public async Task<object> GetProducts()
        {
            try
            {
                IEnumerable<ProductDto> productDtos = await _productService.GetAllProduct();
                _response.Result = productDtos;

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Errors = new List<string> { ex.Message };
            }
            return _response;
        }
        [HttpPost("Post")]
        public async Task<object> Post([FromBody] ProductDto product)
        {
            try
            {
                ProductDto productDto = await _productService.CreateUpdateProduct(product);
                _response.Result = productDto;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Errors = new List<string> { ex.Message };

            }
            return _response;
        }
        [HttpPut("Put")]
        public async Task<object> Put([FromBody] ProductDto product)
        {
            try
            {
                ProductDto productDto = await _productService.CreateUpdateProduct(product);
                _response.Result = productDto;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Errors = new List<string> { ex.Message };
            }
            return _response;
        }
        [HttpDelete("{id}")]
        public async Task<object> Delete(int id)
        {
            try
            {
                var isDeleted = await _productService.DeleteProductAsyn(id);
                _response.Result = isDeleted;
            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.Errors = new List<string> { ex.Message };
            }
            return _response;
        }
        [HttpGet("GetProductById")]
        public async Task<object> GetProductById(int id)
        {
            try
            {
                var product = await _productService.GetProductById(id);
                _response.Result = product;

            }
            catch (Exception ex)
            {

                _response.IsSuccess = true;
                _response.Errors = new List<string> { ex.Message };
            }
            return _response;
        }
    }
}
