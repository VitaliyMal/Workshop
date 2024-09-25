using Workshop.Core.Data.Remote;
using Workshop.Server.DTOs.ProductDTOs;

namespace Workshop.Core.Service
{
    public class ProductService
    {
        private ProductRemoteDataSource _dataSource;

        public ProductService(ProductRemoteDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public async Task<List<ProductDTO>> GetAll()
        {
            return await _dataSource.GetProducts();
        }

        public async Task<ProductDTO?> Get(int id)
        {
            foreach (ProductDTO product in await _dataSource.GetProducts())
            {
                if (product.Id == id)
                {
                    return product;
                }
            }
            return null;
        }
        public async Task Create(ProductDTO product)
        {
            try
            {
                await _dataSource.PostProduct(new AddProductDTO(
                    product.Name,
                    product.Description,
                    product.Price,
                    product.Production_time
                    ));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                await _dataSource.DeleteProduct(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Update(UpgradeProductDTO product)
        {
            try
            {
                await _dataSource.UpdateProduct(new UpgradeProductDTO(
                    product.id,
                    product.Name,
                    product.Description,
                    product.Price,
                    product.Production_time
                    ));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
