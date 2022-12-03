using DataAccess.Model;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public interface IProductData
    {
        Task<Product> GetProduct(int id);
        Task<IEnumerable<Product>> GetProducts();
        Task InsertProduct(Product product);
        Task UpdateProduct(Product product,int id);
        Task DeleteProduct(int id);
    }
}