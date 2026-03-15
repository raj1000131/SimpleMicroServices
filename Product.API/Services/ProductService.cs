using Microsoft.EntityFrameworkCore;
using Product.API.Data;
using Product.API.DTO;
using Product.API.Mapper;

namespace Product.API.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductDbContext _dbContext;
        public ProductService(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
        {
            var product = ModelConverter.DtoToModel(productDto);
            if (product.Id > 0)
            {
                _dbContext.Products.Update(product);
            }
            else
            {
                _dbContext.Products.Add(product);
            }
            await _dbContext.SaveChangesAsync();

            var dtoProduct = ModelConverter.ModelToDto(product);
            return dtoProduct;
        }

        public async Task<bool> DeleteProductAsyn(int id)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
            {
                return false;
            }
            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProduct()
        {
            var products = await _dbContext.Products.Select(p => ModelConverter.ModelToDto(p)).ToListAsync();
            return products;
        }

        public async Task<ProductDto> GetProductById(int id)
        {
            var product = await _dbContext.Products.Select(p => ModelConverter.ModelToDto(p)).FirstOrDefaultAsync();
            return product;
        }
    }
}
