using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InlamningsupgiftApi;
using InlamningsupgiftApi.Models.Entities;
using InlamningsupgiftApi.Models;
using InlamningsupgiftApi.Filter;

namespace InlamningsupgiftApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[UseApiKey]
    public class ProductContoller : ControllerBase
    {
        private readonly SqlContext _context;

        public ProductContoller(SqlContext context)
        {
            _context = context;
        }

        // GET: api/Product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var items = new List<Product>();

            foreach (var item in await _context.Products.Where(p => p.Deleted == false).ToListAsync())
            {
                var categoryName = await _context.Categories.Where(c => c.Id == item.CategoryId).Select(c => c.CategoryName).FirstOrDefaultAsync();
                items.Add(new Product(item.Id, item.Name, item.Description, item.Price, categoryName));
            }

            return items;
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var Product = await _context.Products.FindAsync(id);

            if (Product == null || Product.Deleted)
            {
                return NotFound();
            }
            var categoryName = await _context.Categories.Where(c => c.Id == Product.CategoryId).Select(c => c.CategoryName).FirstOrDefaultAsync();
            return new Product(Product.Id, Product.Name, Product.Description, Product.Price, categoryName);
        }
        // PUT: api/Product/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductEntity(int id, ProductUpdateModel model)
        {
           

            var Product = await _context.Products.FindAsync(id);
            if (Product == null)
                return NotFound();

            var categoryId = await _context.Categories.FindAsync(model.CategoryId);
            if (categoryId == null)
                return NotFound();

            Product.Name = model.Name;
            Product.Description = model.Description;
            Product.Price = model.Price;    
            Product.CategoryId = model.CategoryId;

            _context.Entry(Product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductEntityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Product
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProductEntity(ProductCreateModel model)
        {
            if (await _context.Products.AnyAsync(x => x.Name == model.Name))
                return Conflict("A Product with the same name already exists.");

            var Product = new ProductEntity(model.Name, model.Description, model.Price, model.CategoryId);
            _context.Products.Add(Product);
            await _context.SaveChangesAsync();

            var categoryName = await _context.Categories.Where(c => c.Id == Product.CategoryId).Select(c => c.CategoryName).FirstOrDefaultAsync();
            return CreatedAtAction("PostProductEntity", new { id = Product.Id }, new Product(Product.Id, Product.Name, Product.Description, Product.Price, categoryName));
        }
        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductEntity(int id)
        {
            var productEntity = await _context.Products.FindAsync(id);
            if (productEntity == null)
            {
                return NotFound();
            }

            // Using softdelete
            productEntity.Deleted = true;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductEntityExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}