using tehnohem_api.Model;
using tehnohem_api.Services.Interface;
using tehnohem_api.UnitOfWork.Interface;

namespace tehnohem_api.Services.Implementation
{
    public class ProductService : IProductService
    {
        private IUnitOfWork unitOfWork;
        public ProductService(IUnitOfWork unitOfWork) {
            this.unitOfWork = unitOfWork;
        }

        public void Add(Product product)
        {
            this.unitOfWork.ProductRepository.Add(product);
            this.unitOfWork.Commit();
        }

        public void DeleteProduct(int productId)
        {
            Product product = this.unitOfWork.ProductRepository.GetProductById(productId);
            this.unitOfWork.ProductRepository.DeleteProduct(product);
            this.unitOfWork.Commit();
        }

        public ICollection<Product> GetAllProducts()
        {
            return this.unitOfWork.ProductRepository.GetAllProducts();
        }

        public Product GetProductById(int productId)
        {
            return this.unitOfWork.ProductRepository.GetProductById(productId);
        }

        public void UpdateProduct(Product newProduct)
        {
            Product product = this.unitOfWork.ProductRepository.GetProductById(newProduct.ID);
            this.unitOfWork.ProductRepository.UpdateProduct(product, newProduct);
            this.unitOfWork.Commit();
        }
    }
}
