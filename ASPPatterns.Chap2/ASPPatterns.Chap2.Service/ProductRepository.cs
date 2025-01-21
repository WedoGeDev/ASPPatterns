using System.Collections.Generic;

namespace ASPPatterns.Chap2.Service
{
    public class ProductRepository : IProductRepository
    {
        public List<Product> GetAllProductsIn(int categoryId)
        {
            var productos = new List<Product>();
            //DB code
            return productos;
        }
    }
}