using Microsoft.EntityFrameworkCore;
using Product.API.Data;
using Product.API.DTO;
using Product.API.Mapper;

namespace Product.API.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ProductDbContext _dbContext;
        public CategoryService(ProductDbContext productDbContext)
        {
            _dbContext = productDbContext;
        }
        public async Task<CategoryDto> CreateUpdateCategory(CategoryDto categoryDto)
        {
            var category = ModelConverter.DtoToModel(categoryDto);
            if (category.CategoryId > 0)
            {
                _dbContext.Categories.Update(category);
            }
            else
            {
                _dbContext.Categories.Add(category);
            }
            await _dbContext.SaveChangesAsync();

            var dtoProduct = ModelConverter.ModelToDto(category);
            return dtoProduct;
        }

        public async Task<bool> DeleteCategoryAsyn(int id)
        {
            var category = await _dbContext.Categories.FirstOrDefaultAsync(p => p.CategoryId == id);
            if (category == null)
            {
                return false;
            }
            _dbContext.Categories.Remove(category);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategory()
        {
            var category = await _dbContext.Categories.Select(p => ModelConverter.ModelToDto(p)).ToListAsync();
            return category;
        }

        public async Task<CategoryDto> GetCategoryById(int id)
        {
            var category = await _dbContext.Categories.Select(p => ModelConverter.ModelToDto(p)).FirstOrDefaultAsync();
            return category;
        }
    }
}
