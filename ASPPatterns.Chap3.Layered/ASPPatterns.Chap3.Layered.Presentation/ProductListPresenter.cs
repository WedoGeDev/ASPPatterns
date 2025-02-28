using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASPPatterns.Chap3.Layered.Service;

namespace ASPPatterns.Chap3.Layered.Presentation
{
    public class ProductListPresenter
    {
        private IProductListView _productListView;
        private Service.ProductService _productService;

        public ProductListPresenter(IProductListView productListView, Service.ProductService productService)
        {
            _productListView = productListView;
            _productService = productService;
        }

        public void Display() {
            var productListRequest = new ProductListRequest();
            productListRequest.CustomerType = _productListView.CustomerType;

            var productsResponse = _productService.GetAllProductsFor(productListRequest);

            if (productsResponse.Success)
            {
                _productListView.Display(productsResponse.Products);

            }
            else {
                _productListView.ErrorMessage = productsResponse.Message;
            }
        }
    }
}
