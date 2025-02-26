using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPPatterns.Chap3.Layered.Service
{
    public class ProductService
    {
        private Model.ProductService _productService;

        public ProductService(Model.ProductService productService)
        {
            _productService = productService;
        }

        public ProductListResponse GetAllProductsFor(ProductListRequest productListRequest)
        {
            var response = new ProductListResponse();

            try
            {
                var productEntities = _productService.GetAllProductsFor(productListRequest.CustomerType);
                response.Products = productEntities.ConvertToProductListViewModel();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
