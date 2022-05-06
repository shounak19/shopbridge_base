using Microsoft.Extensions.Logging;
using Shopbridge_base.Data.Repository;
using Shopbridge_base.Domain.Models;
using Shopbridge_base.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopbridge_base.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly ILogger<ProductService> logger;
        private readonly IRepository productRepository;

        public ProductService(IRepository productRepository)
        {
            this.productRepository = productRepository;
        }


        public async Task<Product> AddNewProduct(Product product)
        {
            return await productRepository.AddNewProduct(product);
        }


        public async Task DeleteProductById(int id)
        {
            await productRepository.DeleteProductById(id);
        }


        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await productRepository.GetAllProducts();
        }


        public async Task<Product> GetProductById(int id)
        {
            return await productRepository.GetProductById(id);
        }


        public async Task ModifyProduct(Product product)
        {
            await productRepository.ModifyProduct(product);
        }
    }
}
