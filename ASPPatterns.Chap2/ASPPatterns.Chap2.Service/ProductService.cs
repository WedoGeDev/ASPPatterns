using System.Collections.Generic;
using System.Web;

namespace ASPPatterns.Chap2.Service
{
    public class ProductService
    {
        private IProductRepository _productRepository;
        private ICacheStorage _cacheStorage;
        public ProductService(ProductRepository productRepository, ICacheStorage cacheStorage)
        {
            _productRepository = productRepository;
            _cacheStorage = cacheStorage;
        }
        public List<Product> GetAllProductsIn(int categoryId)
        {
            var cacheKey = $"products_in_category_{categoryId}";

            var productos = _cacheStorage.Retrieve<List<Product>>(cacheKey);
            if (productos != null)
            {
                productos = _productRepository.GetAllProductsIn(categoryId);
                _cacheStorage.Store(cacheKey, productos);
            }

            return productos;
        }
    }
}