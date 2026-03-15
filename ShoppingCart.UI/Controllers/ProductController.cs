using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Services;
using ShoppingCart.UI.Models;

namespace ShoppingCart.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        //public async Task<IActionResult> Index()
        //{
        //    List<ProductDto> productList = new();
        //    var response = await _productService.GetAllProduct<ResponseDto>();
        //    if (response != null && response.IsSuccess)
        //    {
        //        productList = System.Text.Json.JsonSerializer.Deserialize<List<ProductDto>>(Convert.ToString(response.Result));
        //    }
        //    return View(productList);
        //}
    }
}
