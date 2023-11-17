using Microsoft.EntityFrameworkCore;
using tehnohem_api.DB;
using tehnohem_api.Model;
using tehnohem_api.Repositories.Interface;

namespace tehnohem_api.Repositories.Implementation
{
    public class ProductRepository : IProductRepository
    {
        PostgresqlContext postgresqlContext;
        DbSet<Product> products;

        public ProductRepository(PostgresqlContext postgresqlContext)
        {
            products = postgresqlContext.products;
        }

        public void Add(Product product)
        {
            products.Add(product);
        }

        public void DeleteProduct(Product product)
        {
            products.Remove(product);
        }

        public ICollection<Product> GetAllProducts()
        {
            return products.ToList();
        }

        public Product GetProductById(int productId)
        {
            return products.Where(p => p.ID == productId).FirstOrDefault();
        }


        public void UpdateProduct(Product product,Product newProduct)
        {
            product.BarCode = newProduct.BarCode;
            product.Name = newProduct.Name;
            product.SinglePrice = newProduct.SinglePrice;
            product.TotalValue = newProduct.TotalValue;
            product.Volume = newProduct.Volume;
            product.CurrentAmount = newProduct.CurrentAmount;
        }

    }
}
