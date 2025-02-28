using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASPPatterns.Chap3.Layered.Model;

namespace ASPPatterns.Chap3.Layered.Service
{
    public static class ProductMapperExtensionMethods
    {
        public static IList<ProductViewModel> ConvertToProductListViewModel(this IList<Product> products)
        {
            var productViewModels = new List<ProductViewModel>();

            foreach (var p in products)
            {
                productViewModels.Add(p.ConvertToProductViewModel());
            }

            return productViewModels;
        }

        public static ProductViewModel ConvertToProductViewModel(this Product product)
        {
            return new ProductViewModel
            {
                ProductId = product.Id,
                Name = product.Name,
                RRP = $"{product.Price.RPP:C}",
                SellingPrice = $"{product.Price.SellingPrice:C}",
                Discount = product.Price.Discount > 0
                    ? $"{product.Price.Discount}"
                    : string.Empty,
                Savings = product.Price.Savings < 1 && product.Price.Savings > 0
                    ? product.Price.Savings.ToString("#%")
                    : string.Empty
            };
        }
    } 
}
