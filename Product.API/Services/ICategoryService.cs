using Product.API.DTO;

namespace Product.API.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllCategory();
        Task<CategoryDto> GetCategoryById(int id);
        Task<CategoryDto> CreateUpdateCategory(CategoryDto product);
        Task<bool> DeleteCategoryAsyn(int id);
    }
}
