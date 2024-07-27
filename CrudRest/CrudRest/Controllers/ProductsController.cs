using CrudRest.Data;
using CrudRest.Dtos;
using CrudRest.Models;
using CrudRest.Response;
using CrudRest.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<Response<IEnumerable<ProductDto>>>> GetProducts()
        {
            var response = await _productService.GetAllAsync();
            return Ok(response);
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Response<ProductDto>>> GetProduct(int id)
        {
            var response = await _productService.GetByIdAsync(id);
            return Ok(response);
        }

        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult<Response<ProductDto>>> PostProduct(RqProductDto product)
        {
            var response = await _productService.AddAsync(product);
            return Ok(response);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Response<ProductDto>>> PutProduct(int id, RqProductDto product)
        {
            var response = await _productService.UpdateAsync(id, product);
            return Ok(response);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Response<ProductDto>>> DeleteProduct(int id)
        {
            var response = await _productService.DeleteAsync(id);
            return Ok(response);
            
        }

    }
}
