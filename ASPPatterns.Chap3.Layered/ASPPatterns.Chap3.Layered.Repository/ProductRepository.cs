using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASPPatterns.Chap3.Layered.Model;
using Dapper;

namespace ASPPatterns.Chap3.Layered.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _conString;
        private readonly string _getProducts = "select * from products";

        public ProductRepository()
        {
            var connBuilder = new SqlConnectionStringBuilder();
            connBuilder.DataSource = "Mac-mini-de-Omar.local";
            connBuilder.TrustServerCertificate = true;
            connBuilder.UserID = "sa";
            connBuilder.Password = "w3d0123.";
            connBuilder.InitialCatalog = "Shop";

            _conString = connBuilder.ConnectionString;
        }

        public IList<Product> FindAll()
        {
            using (var conn = new SqlConnection(_conString))
            {
                return conn.Query<ProductDto>(
                    _getProducts, null,
                    commandType: System.Data.CommandType.Text)
                    .Select(p => new Product
                    {
                        Id = p.ProductId,
                        Name = p.ProductName,
                        Price = new Price(p.RRP, p.SellingPrice)
                    }).ToList();
            }
        }
    }

    public class ProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal RRP { get; set; }
        public decimal SellingPrice { get; set; }
    }
}
