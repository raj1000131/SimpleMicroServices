using Microsoft.AspNetCore.Mvc;
using Product.API.DTO;
using Product.API.Services;

namespace Product.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly ResponseDto _response;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
            _response = new ResponseDto();
        }
        [HttpGet("Get")]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<CategoryDto> categorytDtos = await _categoryService.GetAllCategory();
                _response.Result = categorytDtos;

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Errors = new List<string> { ex.Message };
            }
            
            return _response;
        }
        [HttpPost("Post")]
        public async Task<object> Post([FromBody] CategoryDto category)
        {
            try
            {
                CategoryDto categorytDtos = await _categoryService.CreateUpdateCategory(category);
                _response.Result = categorytDtos;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Errors = new List<string> { ex.Message };

            }
            return _response;
        }
        [HttpPut("Put")]
        public async Task<object> Put([FromBody] CategoryDto category)
        {
            try
            {
                CategoryDto categorytDtos = await _categoryService.CreateUpdateCategory(category);
                _response.Result = categorytDtos;
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
                var isDeleted = await _categoryService.DeleteCategoryAsyn(id);
                _response.Result = isDeleted;
            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.Errors = new List<string> { ex.Message };
            }
            return _response;
        }
        [HttpGet("GetCategoryById")]
        public async Task<object> GetCategoryById(int id)
        {
            try
            {
                var product = await _categoryService.GetCategoryById(id);
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
