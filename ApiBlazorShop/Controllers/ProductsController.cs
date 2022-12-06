using Microsoft.AspNetCore.Http;
using DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Model;

namespace ApiBlazorShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductData _data;
        public ProductsController(IProductData data)
        {
            _data = data;
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var products = await _data.GetProducts();
                return Ok(products);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            try
            {
                if (id == 0)
                    return BadRequest();

                var product = await _data.GetProduct(id);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            try
            {
                if (product == null)
                    return BadRequest();

                await _data.InsertProduct(product);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(Product product,int id)
            {
                try
                {
                    if (product == null)
                        return BadRequest();
                    if(id == 0)
                      return BadRequest();

                await _data.UpdateProduct(product,id);

                    return Ok();
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                if (id == 0)
                    return BadRequest();

                await _data.DeleteProduct(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
