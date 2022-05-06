using Shopbridge_base.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Shopbridge_base.Data.Repository
{
    public interface IRepository
    {
        public Task<Product> AddNewProduct(Product product);

        public Task<IEnumerable<Product>> GetAllProducts();

        public Task<Product> GetProductById(int id);

        public Task DeleteProductById(int id);

        public Task ModifyProduct(Product product);
    }
}
