using System.Xml.Serialization;
using tehnohem_api.Model;

namespace tehnohem_api.Repositories.Interface
{
    public interface IProductRepository
    {

        void Add(Product product); 
        ICollection<Product> GetAllProducts();

        Product GetProductById(int productId);

        void UpdateProduct(Product product, Product newProduct);

        void DeleteProduct(Product product);


    }
}
