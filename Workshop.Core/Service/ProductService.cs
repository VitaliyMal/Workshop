using Workshop.Core.Data.Direct;
using Workshop.Core.Entity;

namespace Workshop.Core.Service
{
    public class ProductService
    {
        public ProductDataSource _dataSource;
        private List<Product> _products = [];

        public ProductService(ProductDataSource dataSource)
        {
            _dataSource = dataSource;
            _products = _dataSource.Get() ?? new List<Product>();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public Product Get(int id)
        {
            foreach (Product product in _products)
            {
                if (product.Id == id)
                {
                    return product;
                }
            }
            return null;
        }
        public void Create(Product product)
        {
            _products.Add(product);
            _dataSource.Write(_products);

        }

        public void Delete(int id)
        {
            foreach (Product product in _products)
            {
                if (product.Id == id)
                {
                    _products.Remove(product);
                    break;
                }
            }

            _dataSource.Write(_products);
        }

        public void Update(Product product)
        {
            for (int i = 0; i < _products.Count; i++)
                if (product.Id == _products[i].Id)
                    _products[i] = product;
            _dataSource.Write(_products);

        }


    }
}
