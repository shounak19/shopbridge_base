using Shopbridge_base.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopbridge_base.Domain.Services.Interfaces
{
    public interface IProductService
    {
        public Task<Product> AddNewProduct(Product product);

        public Task<IEnumerable<Product>> GetAllProducts();

        public Task<Product> GetProductById(int id);

        public Task DeleteProductById(int id);

        public Task ModifyProduct(Product product);
    }
}
