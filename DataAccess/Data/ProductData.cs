using DataAccess.DbAccess;
using DataAccess.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class ProductData : IProductData
    {
        private readonly ISqlDataAccess _db;
        public ProductData(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
           return await _db.LoadData<Product, dynamic>(storeProcedure: "dbo.spProduct_GetAll", new { });
            
        }
            
        public async Task<Product> GetProduct(int id)
        {
            IEnumerable<Product> result = await _db.LoadData<Product, dynamic> (storeProcedure: "dbo.spProduct_Get", new { id});
             return result.FirstOrDefault();
        }

        public Task InsertProduct(Product product)=>
    
            _db.SaveData(storedProcedure: "spProduct_Insert", new
            {
                product.Title,
                product.Description,
                product.Image,
                product.IsPublic,
                product.IsDelete,
                product.CategoryId,
                product.DateCreated,
                product.DateUpdate,
                product.Views
            });

        public Task UpdateProduct(Product product,int id) =>

           _db.SaveData(storedProcedure: "spProduct_Update", new
           {
             id,
               product.Title,
               product.Description,
               product.Image,
               product.IsPublic,
               product.IsDelete,
               product.CategoryId,
               product.DateCreated,
               product.DateUpdate,
               product.Views
           });
        public Task DeleteProduct(int id) =>

        _db.SaveData(storedProcedure: "spProduct_Delete", new
        {
            Id=id
        });
    }
}
