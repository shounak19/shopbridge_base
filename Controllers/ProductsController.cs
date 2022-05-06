using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Shopbridge_base.Data;
using Shopbridge_base.Domain.Models;
using Shopbridge_base.Domain.Services.Interfaces;

namespace Shopbridge_base.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly ILogger<ProductsController> logger;

        public ProductsController(IProductService _productService, ILogger<ProductsController> logger)
        {
            this.productService = _productService;
            this.logger = logger;
        }

       
        [HttpGet]   
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
            try
            {
                var products = await productService.GetAllProducts();

                return Ok(products);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Something went wrong inside the ProductsController => HttpGet(api/Products/GetProduct)");
                return StatusCode(500, "Internal Server Error");
            }
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            try
            {
                var product = await productService.GetProductById(id);

                return Ok(product);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Something went wrong inside the ProductsController => HttpGet(api/Products/GetProduct{id})");
                return StatusCode(500, "Internal Server Error");
            }
        }

       
        [HttpPut]
        public async Task<IActionResult> PutProduct(Product product)
        {
            try
            {
                await productService.ModifyProduct(product);

                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Something went wrong inside the ProductsController => HttpGet(api/Products/PutProduct)");
                return StatusCode(500, "Internal Server Error");
            }
        }

        
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            try
            {
                var addedProduct = await productService.AddNewProduct(product);

                return Ok(addedProduct);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Something went wrong inside the ProductsController => HttpGet(api/Products/PostProduct)");
                return StatusCode(500, "Internal Server Error");
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                await productService.DeleteProductById(id);

                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Something went wrong inside the ProductsController => HttpDelete(api/Products/DeleteProduct{id})");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
