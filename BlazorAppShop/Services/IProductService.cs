using DataAccess.Model;

namespace BlazorAppShop.Services
{
    public interface IProductService
    {
        Task<HttpResponseMessage> CreateProduct(Product newProduct);
        Task DeleteProduct(int id);
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProduct(int id);
        Task<HttpResponseMessage> UpdateProduct(int id, Product updateProducts);
    }
}