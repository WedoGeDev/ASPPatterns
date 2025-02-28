using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPPatterns.Chap3.Layered.Model
{
    public class ProductService
    {
        private IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IList<Product> GetAllProductsFor(CustomerType customerType)
        {
            var discountEstrategy = DiscountFactory.GetDiscountStrategyFor(customerType);

            var products = _productRepository.FindAll();
            products.Apply(discountEstrategy);

            return products;
        }
    }
}
