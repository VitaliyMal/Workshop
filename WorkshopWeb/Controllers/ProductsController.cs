//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using WorkshopWeb;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Workshop.Server.Data;
using Workshop.Server.DTOs.ProductDTOs;
using Workshop.Server.Mapper;
using WorkshopWeb.Entity;

namespace WorkshopWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProduct()
        {
            return await _context.Product
                .Select(x => x.ToProductDTO())
                .ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProduct(int id)
        {
            Product? product = await _context.Product.FindAsync(id);

            return product == null
                ? BadRequest() :
                Ok(product.ToProductDTO());
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, UpgradeProductDTO product)
        {
            var existingProduct = await _context.Product.FindAsync(id);

            if (existingProduct is null)
            {
                return NotFound();
            }

            _context.Entry(existingProduct)
                .CurrentValues
                .SetValues(product.ToEntity(id));

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostProduct(AddProductDTO newProduct)
        {
            Product product = newProduct.ToEntity();

            _context.Product.Add(product);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _context.Product
                .Where(product => product.Id == id)
                .ExecuteDeleteAsync();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.Id == id);
        }
    }
}
