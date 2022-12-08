using System.Net.Http.Json;
using DataAccess.Model;

namespace BlazorAppShop.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        public ProductService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<Product> GetProduct(int id)
        {
            try
            {

                return await _httpClient.GetFromJsonAsync<Product>($"api/products/{id}");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            try
            {

                IEnumerable<Product> products= await _httpClient.GetFromJsonAsync<Product[]>("api/products");
                return products;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
        public async Task<HttpResponseMessage> CreateProduct(Product newProduct)
        {
            try
            {
                return await _httpClient.PostAsJsonAsync<Product>("api/products", newProduct);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<HttpResponseMessage> UpdateProduct(int id, Product updateProducts)
        {
            try
            {
                return await _httpClient.PutAsJsonAsync<Product>("api/products/" + id, updateProducts);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public async Task DeleteProduct(int id)
        {
            try
            {
                await _httpClient.DeleteAsync($"api/products/{id}");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}
