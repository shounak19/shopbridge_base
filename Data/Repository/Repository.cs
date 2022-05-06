using Microsoft.EntityFrameworkCore;
using Shopbridge_base.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Shopbridge_base.Data.Repository
{
    public class Repository : IRepository
    {
        private readonly Shopbridge_Context dbcontext;

        public Repository(Shopbridge_Context _dbcontext)
        {
            this.dbcontext = _dbcontext;
        }


        public async Task<Product> AddNewProduct(Product product)
        {
            dbcontext.Product.Add(product);
            await dbcontext.SaveChangesAsync();

            return product;
        }


        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await dbcontext.Product.ToListAsync();
        }


        public async Task<Product> GetProductById(int id)
        {
            return await dbcontext.Product.FindAsync(id);
        }


        public async Task DeleteProductById(int id)
        {
            var productToDelete = await dbcontext.Product.FindAsync(id);
            dbcontext.Product.Remove(productToDelete);

            await dbcontext.SaveChangesAsync();
        }


        public async Task ModifyProduct(Product product)
        {
            dbcontext.Entry(product).State = EntityState.Modified;

            await dbcontext.SaveChangesAsync();
        }
    }
}
