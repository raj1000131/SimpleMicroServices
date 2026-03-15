using Product.API.DTO;
using Product.API.Entities;

namespace Product.API.Mapper
{
    public static class ModelConverter
    {
        public static Product.API.Entities.Product DtoToModel(ProductDto model)
        {
            return new Product.API.Entities.Product
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                Price = model.Price,
                ImageUrl = model.ImageUrl,
                CategoryId = model.CategoryId
            };
        }
        public static Product.API.DTO.ProductDto ModelToDto(Product.API.Entities.Product model)
        {
            return new ProductDto
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                Price = model.Price,
                ImageUrl = model.ImageUrl,
                CategoryId = model.CategoryId
            };
        }
        public static Product.API.Entities.Category DtoToModel(CategoryDto model)
        {
            return new Product.API.Entities.Category
            {
                CategoryId = model.CategoryId,
                Title = model.Title
            };
        }
        public static Product.API.DTO.CategoryDto ModelToDto(Product.API.Entities.Category model)
        {
            return new CategoryDto
            {
                CategoryId = model.CategoryId,
                Title = model.Title,
            };
        }
    }
}
