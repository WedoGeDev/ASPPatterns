using System.Collections.Generic;

namespace ASPPatterns.Chap2.Service
{
    public interface IProductRepository
    {
        List<Product> GetAllProductsIn(int categoryId);
    }
}