using Workshop.Server.DTOs.ProductDTOs;
using WorkshopWeb.Entity;

namespace Workshop.Server.Mapper
{
    public static class ProductMapper
    {
        public static Product ToEntity(this AddProductDTO addProduct)
        {
            return new Product()
            {
                Name = addProduct.Name,
                Description = addProduct.Description,
                Price = addProduct.Price,
                Production_time = addProduct.Production_time
            };
        }

        public static Product ToEntity(this UpgradeProductDTO UpProduct, int id)
        {
            return new Product()
            {
                Name = UpProduct.Name,
                Description = UpProduct.Description,
                Price = UpProduct.Price,
                Production_time = UpProduct.Production_time
            };
        }

        public static ProductDTO ToProductDTO (this Product product)
        {
            return new ProductDTO(
                product.Id,
                product.Name,
                product.Description,
                product.Price,
                product.Production_time
            );
        }
    }
}
