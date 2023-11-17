using tehnohem_api.Model;

namespace tehnohem_api.Services.Interface
{
    public interface IProductService
    {
        
        ICollection<Product> GetAllProducts();

        Product GetProductById(int productId);

        void Add(Product product);
        void UpdateProduct(Product product);

        void DeleteProduct(int productId);
    }
}
